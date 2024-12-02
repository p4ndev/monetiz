using Monetizacao.Modules.Financial.Interfaces;
using Monetizacao.Modules.Financial.Requests;
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
public sealed class PurchaseController(
    ExternalPaymentServiceInterface<Payment> _externalService,
    HistoryPaymentServiceInterface<Payment> _historyService,
    InternalPaymentServiceInterface _internalService,
    CheckoutService _checkoutService
) : HttpControllerHandler
{
    [HttpPost]
    [Authorize(Roles = nameof(RoleEnum.Member))]
    [Authorize(Policy = nameof(ClaimEnum.HasEmailConfirmed))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status206PartialContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PostAsync([FromBody] PaymentRequest model, CancellationToken token = default)
    {
        var uid = UserId();
        var nms = UserNames();
        var ems = UserEmail();

        if (!_checkoutService.IsBuyModelValid(uid, model))
            return UnsupportedMediaType();

        if (await _internalService.IsBuyAvailableAsync(uid, token))
            return Conflict();

        var internalPayment = await _internalService.PurchaseAsync(uid, model, token);

        await _internalService.PersistFinancialAsync(token);

        if (internalPayment is null)
            return BadRequest();
            
        var idk = _checkoutService.GenerateIdempotencyKey();
        var ipi = internalPayment.Id;

        _externalService.AddAccountInfo(nms, ems);
        _externalService.AddPaymentInfo(ipi, idk);
        _externalService.AddProductInfo(model);

        var externalPayment = await _externalService.AddAsync(uid, token);

        if (externalPayment is null)
            return BadRequest();

        var entity = await _historyService.AddAsync(ipi, externalPayment, token);

        if (!await _historyService.PersistFinancialAsync(token))
            return PartialContent();

        return Ok();
    }
}