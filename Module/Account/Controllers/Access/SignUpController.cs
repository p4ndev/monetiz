using Monetizacao.Modules.Account.Requests;
using Monetizacao.Modules.Account.Services;
using Monetizacao.Providers.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Modules.Account.Controllers.Access;

[ApiController]
[Route("Account/Access")]
public sealed class SignUpController(
    ClaimService _claimService,
    AccessService _accessService
) : HttpControllerHandler
{
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status206PartialContent)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PostAsync([FromBody] AccountRequest model, CancellationToken token = default)
    {
        if (!_accessService.IsModelValid(model))
            return UnsupportedMediaType();

        if (await _accessService.ExistsAsync(model.email, token))
            return Conflict();

        var entity = await _accessService.AddGuestAsync(model, token);

        await _accessService.PersistRelationalAccountAsync(token, 2);
        await _claimService.AddAppAccessAsync(entity.Id, token);
        await _claimService.AddApiAccessAsync(entity.Id, token);
        await _accessService.PersistRelationalAccountAsync(token, 2);

        _accessService.NotifyAfterRegister(entity.Id, entity.Email, entity.ActivationStamp);

        await _accessService.PersistEmailAccountAsync(token);

        return Created(string.Empty, entity.Id);
    }
}