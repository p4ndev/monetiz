using Monetizacao.Modules.Account.Requests;
using Monetizacao.Modules.Account.Services;
using Monetizacao.Providers.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Modules.Account.Controllers.Recovery;

[ApiController]
[Route("Account/Recovery")]
public sealed class ResetController(
    RecoveryService _recoveryService
) : HttpControllerHandler
{
    [HttpPatch]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status304NotModified)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PatchAsync([FromBody] RecoveryRequest model, CancellationToken token = default)
    {
        if (!_recoveryService.IsModelValid(model))
            return UnsupportedMediaType();

        await _recoveryService.EditAsync(model, token);

        if (!await _recoveryService.PersistRelationalAccountAsync(token))
            return NotModified();

        return Ok();
    }
}