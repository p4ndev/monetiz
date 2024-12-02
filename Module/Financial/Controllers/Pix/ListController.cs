using Monetizacao.Modules.Financial.Responses;
using Monetizacao.Modules.Financial.Services;
using Monetizacao.Providers.Contexts.Enums;
using Monetizacao.Providers.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Modules.Financial.Controllers.Pix;

[ApiController]
[Route("Financial/Pix")]
public sealed class ListController(
    PixService _pixServices
) : HttpControllerHandler
{
    [HttpGet]
    [Authorize(Roles = nameof(RoleEnum.Member))]
    [Authorize(Policy = nameof(ClaimEnum.HasEmailConfirmed))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IList<PixResponse>>> GetAsync(CancellationToken token = default)
    {
        var uid = UserId();

        if (!_pixServices.IsModelValid(uid))
            return UnsupportedMediaType();

        var results = await _pixServices.ListAsync(uid, token);

        if (results is null || !results.Any())
            return NotFound();

        return Ok(results);
    }
}