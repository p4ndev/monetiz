using Monetizacao.Modules.Room.Responses;
using Monetizacao.Modules.Room.Services;
using Monetizacao.Providers.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Modules.Room.Controllers.Game;

[ApiController]
[Route("Room")]
public sealed class ListController(
    GameService _gameService
) : HttpControllerHandler
{
    [HttpGet("{tid}/Tenant/{cid}/Category")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<GameResponse>>> GetAsync([FromRoute] long? tid, [FromRoute] long? cid, CancellationToken token = default)
    {
        if (!_gameService.IsModelValid(tid, cid))
            return UnsupportedMediaType();

        var entities = await _gameService.ListAsync(tid!.Value, cid!.Value, token);

        if (entities == null)
            return NotFound();

        return Ok(entities);
    }
}