using Monetizacao.Modules.Account.Services;
using Monetizacao.Providers.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Modules.Account.Controllers.Recovery;

[ApiController]
[Route("Account/Recovery")]
public sealed class EmailController(
    RecoveryService _recoveryService
) : HttpControllerHandler
{
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAsync([FromQuery] string email, CancellationToken token = default)
    {
        if (!_recoveryService.IsModelValid(email))
            return UnsupportedMediaType();

        if (await _recoveryService.SendEmailAsync(email, token))
            await _recoveryService.PersistEmailAccountAsync(token);

        return Ok();
    }
}