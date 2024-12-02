using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Modules.Room.Services;
using Monetizacao.Providers.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Modules.Room.Controllers.Action;

[ApiController]
[Route("Room")]
public sealed class ListController(
    ActionService _actionService,
    AnswerService _answerService
) : HttpControllerHandler
{
    [HttpGet("{aid}/Action")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status208AlreadyReported)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ActionEntity>> GetAsync([FromRoute] long? aid, CancellationToken token = default)
    {
        var uid = UserId();

        if (!_actionService.IsModelValid(uid , aid))
            return UnsupportedMediaType();

        var entity = await _actionService.FindByIdForArenaAsync(aid!.Value, token);

        if (entity is null)
            return NotFound();

        if (await _answerService.HasAnsweredAsync(uid, entity.id, token))
            return AlreadyReported(entity);

        return Ok(entity);
    }
}