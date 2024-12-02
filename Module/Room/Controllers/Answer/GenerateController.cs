using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Enums;
using Monetizacao.Providers.Handlers;
using Monetizacao.Modules.Financial.Services;
using Monetizacao.Modules.Account.Services;
using Monetizacao.Modules.Lobby.Responses;
using Monetizacao.Modules.Lobby.Services;
using Monetizacao.Modules.Room.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Modules.Room.Controllers.Answer;

[ApiController]
[Route("Room")]
public sealed class GenerateController(
    ActivityService _activityService,
    CategoryService _categoryService,
    BalanceService _balanceService,
    PlayerService _playerService,
    ActionService _actionService,
    AnswerService _answerService,
    GroupService _groupService,
    GameService _gameService
) : HttpControllerHandler
{
    [HttpPost("{content}/Answer/Boolean")]
    [Authorize(Roles = nameof(RoleEnum.Member))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status206PartialContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PostAsync([FromQuery] long? aid, [FromRoute] string? content, CancellationToken token = default)
    {
        var uid = UserId();

        if (!_actionService.IsModelValid(uid, aid, content))
            return UnsupportedMediaType();

        if (await _answerService.HasAnsweredAsync(uid, aid!.Value, token))
            return Conflict();

        if (!await _balanceService.ExistsAsync(uid, token))
            return Forbid();

        ActionEntity? actionEntity = await _actionService.FindByIdAsync(aid!.Value, token);

        if (actionEntity is null || actionEntity.Game is null)
            return BadRequest();

        List<long> gids = new();
        gids.Add(actionEntity.Game.FirstGroupId);

        if (actionEntity.Game.SecondGroupId.HasValue)
            gids.Add(actionEntity.Game.SecondGroupId.Value);

        string gameName = "";
        IEnumerable<PlayerResponse>? groupResponse = await _playerService.ListAsync(gids.AsEnumerable(), token);

        if (groupResponse is not null && groupResponse.Count() >= 2)
            gameName = _groupService.Headline(groupResponse!);
        else
        {
            var gameEntity = await _gameService.FindAsync(actionEntity.GameId, token);                
            if (gameEntity is not null)
            {
                var categoryEntity = await _categoryService.FindAsync(gameEntity.CategoryId, token);

                if (categoryEntity is not null)
                    gameName = categoryEntity.Name;
            }
        }

        string? stamp = await _actionService.StampAsync(aid.Value, token);

        if (stamp is null)
            return BadRequest();

        await _balanceService.AddAfterAnswerAsync(uid, aid!.Value, stamp, token);
        await _activityService.AddAnswerAsync(uid, gameName, actionEntity.Name, content!, stamp, token);
        var answerEntity = await _answerService.AddBooleanAnswerAsync(uid, aid!.Value, content!, token);

        var financialPersistance = await _balanceService.PersistFinancialAsync(token);
        var accountPersistance = await _activityService.PersistAccountAsync(token);
        var roomPersistance = await _actionService.PersistRoomAsync(token);

        if(answerEntity is not null)
        {
            if (!financialPersistance || !accountPersistance || !roomPersistance)
                return PartialContent(answerEntity!.Id);
                
            return Created(string.Empty, answerEntity!.Id);
        }

        return BadRequest();
    }
}