using Monetizacao.Modules.Financial.Interfaces;
using Monetizacao.Modules.Financial.Responses;
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
public sealed class AvailabilityController(
    HistoryPaymentServiceInterface<Payment> _historyService,
    InternalPaymentServiceInterface _internalService,
    CheckoutService _checkoutService
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
    public async Task<ActionResult<CheckoutResponse?>> GetAsync(CancellationToken token = default)
    {
        var internalPayment = await _internalService.FindAsync(UserId(), token);

        if (internalPayment is null)
            return NotFound();

        var historyPayment = await _historyService.FindAsync(internalPayment.id, token);

        if (historyPayment is null)
            return NotFound();

        var output = _checkoutService.ToResponse(internalPayment, historyPayment);

        return Ok(output);
    }
}