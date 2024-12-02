using Monetizacao.Modules.Financial.Interfaces;
using Monetizacao.Modules.Financial.Services;
using Monetizacao.Providers.Contexts.Enums;
using Monetizacao.Providers.Handlers;
using Microsoft.AspNetCore.Authorization;
using MercadoPago.Resource.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Modules.Financial.Controllers.Buy;

[ApiController]
[Route("Financial/Buy")]
public sealed class ExpirationController(
    HistoryPaymentServiceInterface<Payment> _historyService,
    InternalPaymentServiceInterface _internalService,
    CheckoutService _checkoutService
) : HttpControllerHandler
{
    [HttpPut]
    [Authorize(Roles = nameof(RoleEnum.Member))]
    [Authorize(Policy = nameof(ClaimEnum.HasEmailConfirmed))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PutAsync([FromHeader] long? ipi, [FromHeader] long? epi, CancellationToken token = default)
    {
        var uid = UserId();

        if (!_checkoutService.IsModelValid(uid, ipi, epi))
            return UnsupportedMediaType();

        if (!await _internalService.IsOwnerAsync(uid, ipi!.Value, token) && 
                !await _historyService.IsExpiredAsync(uid, ipi!.Value, epi!.Value, token))
                    return Forbid();

        await _internalService.RemoveAsync(uid, ipi!.Value, token);

        if (!await _internalService.PersistFinancialAsync(token))
            return NotFound();

        return Ok();
    }
}