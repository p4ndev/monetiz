using Monetizacao.Modules.Lobby.Responses;
using Monetizacao.Modules.Lobby.Services;
using Monetizacao.Providers.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Modules.Lobby.Controllers;

[ApiController]
[Route("Lobby/Tenant")]
public sealed class TenantListController(TenantService _tenantService) : HttpControllerHandler
{
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<TenantResponse>>> GetAsync(CancellationToken token = default)
    {
        var result = await _tenantService.ListAsync(token);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}