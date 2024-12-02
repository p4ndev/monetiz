using Monetizacao.Modules.Account.Services;
using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Modules.Account.Controllers.Activity;

[ApiController]
[Route("Account/Activity")]
public sealed class ListController(
    ActivityService _activityService
) : HttpControllerHandler
{
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IList<ActivityEntity>>> GetAsync([FromQuery] int page = 0, CancellationToken token = default)
    {
        if (!_activityService.IsModelValid(page))
            return UnsupportedMediaType();

        var uid = UserId();

        var results = await _activityService.ListAsync(uid, page, token);

        if (!results.Any())
            return NotFound();

        if (await _activityService.IsLastPageAsync(uid, page, token))
            return ClientClosedRequest(results);

        return Ok(results);
    }
}