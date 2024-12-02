using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Handlers;
using Monetizacao.Modules.Lobby.Services;
using Monetizacao.Modules.Room.Services;
using Monetizacao.Modules.Room.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Modules.Room.Controllers.Action;

[ApiController]
[Route("Room")]
public sealed class GenerateController(
    ActionService _actionService,
    GameService _gameService,
    PlayerService _playerService,
    TemplateService _templateService,
    GroupService _groupService
) : HttpControllerHandler
{
    [HttpPost("Action")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PostAsync([FromQuery] long? gid, CancellationToken token = default)
    {
        var uid = 4;

        if (!_actionService.IsModelValid(uid, gid))
            return UnsupportedMediaType();

        #region Lobby
        IEnumerable<long>                       groupIds;
        IEnumerable<long>                       playerIds;
        GroupEntity?                            groupEntity             = null;
        PlayerEntity?                           playerEntity            = null;
        #endregion

        #region Room
        IEnumerable<TemplateEntity>             templateEntity;
        IEnumerable<ActionTemplateEntity>       actionTemplateEntity;
        TemplateEntity?                         template                = null;
        GameEntity?                             gameEntity              = null;
        TemplateDto?                            templateDto             = null;
        List<ActionEntity>                      actions                 = new();
        #endregion

        gameEntity = await _gameService.FindAsync(gid!.Value, token);

        if (gameEntity is null)
            return NotFound();

        groupIds = _gameService.ListGroupIds(gameEntity);
        playerIds = await _playerService.ListIdsAsync(groupIds, token);

        if (!groupIds.Any() && !playerIds.Any())
            return NotFound();

        actionTemplateEntity = await _templateService.ListFiftyRandomicallyAsync(groupIds, playerIds, token);

        if (!actionTemplateEntity.Any())
            return NotFound();

        templateEntity = await _templateService.ListAsync(actionTemplateEntity.Select(ate => ate.TemplateId), token);

        if (!templateEntity.Any())
            return NotFound();

        foreach (var ate in actionTemplateEntity)
        {
            if (ate.GroupId is not null)
            {
                groupEntity = await _groupService.FindAsync(ate.GroupId!.Value, token);
                    
                template = templateEntity.SingleOrDefault(t => t.Id.Equals(ate.TemplateId));

                if (groupEntity is null || 
                        template is null)
                            continue;

                _templateService
                    .Initialize(uid, gameEntity.Id)
                        .AttachImage(groupEntity.Poster)
                        .AttachName(
                            groupEntity.Name,
                            template.Name,
                            groupEntity.Label,
                            template.Label
                        )
                        .AttachInterval(
                            gameEntity.StartsAt,
                            gameEntity.EndsAt,
                            template.SkipMinutes,
                            template.DurationMinutes
                        );
            }
            else if (ate.PlayerId is not null)
            {
                playerEntity = await _playerService.FindAsync(ate.PlayerId!.Value, token);

                template = templateEntity.SingleOrDefault(t => t.Id.Equals(ate.TemplateId));

                if (playerEntity is null || 
                        template is null)
                            continue;

                _templateService
                    .Initialize(uid, gameEntity.Id)
                        .AttachImage(playerEntity.Poster)
                        .AttachName(
                            playerEntity.Name,
                            template.Name,
                            playerEntity.Label,
                            template.Label
                        )
                        .AttachInterval(
                            gameEntity.StartsAt,
                            gameEntity.EndsAt,
                            template.SkipMinutes,
                            template.DurationMinutes
                        );
            }

            templateDto = _templateService.Flush();

            if (!templateDto.HasValue)
                continue;

            var actionEntity = await _actionService
                .AddAsync(
                    templateDto.Value.uid,
                    templateDto.Value.gid,
                    ate.TemplateId,
                    templateDto.Value.action,
                    templateDto.Value.image,
                    templateDto.Value.starts,
                    templateDto.Value.ends,
                    templateDto.Value.stamp,
                    token
                );

            actions.Add(actionEntity);

            _templateService.Deactive(ate);
        }

        await _actionService.PersistRoomAsync(token);
        await _templateService.PersistRoomAsync(token);

        return Created(string.Empty, null);
    }
}