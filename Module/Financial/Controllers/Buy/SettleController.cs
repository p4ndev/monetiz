using Monetizacao.Modules.Financial.Interfaces;
using Monetizacao.Modules.Financial.Responses;
using Monetizacao.Modules.Financial.Services;
using Monetizacao.Modules.Account.Services;
using Monetizacao.Providers.Contexts.Enums;
using Monetizacao.Providers.Handlers;
using Microsoft.AspNetCore.Authorization;
using MercadoPago.Resource.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Modules.Financial.Controllers.Buy;

[ApiController]
[Route("Financial/Buy")]
public sealed class SettleController(
    ExternalPaymentServiceInterface<Payment> _externalService,
    HistoryPaymentServiceInterface<Payment> _historyService,
    InternalPaymentServiceInterface _internalService,
    CheckoutService _checkoutService,
    ActivityService _activityService,
    BalanceService _balanceService,
    AccessService _accessService
) : HttpControllerHandler
{
    [HttpPatch]
    [Authorize(Roles = nameof(RoleEnum.Member))]
    [Authorize(Policy = nameof(ClaimEnum.HasEmailConfirmed))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CheckoutResponse?>> PatchAsync([FromHeader] long? ipi, [FromHeader] long? epi, CancellationToken token = default)
    {
        var uid = UserId();
        var ems = UserEmail();

        if (!_checkoutService.IsModelValid(uid, ipi, epi))
            return UnsupportedMediaType();

        if (!await _internalService.IsOwnerAsync(uid, ipi!.Value, token) &&
                !await _historyService.IsExpiredAsync(uid, ipi!.Value, epi!.Value, token))
            return Forbid();

        var internalPayment     = await _internalService.FindAsync(uid, token);
        var historyPayment      = await _historyService.FindAsync(ipi!.Value, token, epi!.Value);
        var externalPayment     = await _externalService.FindAsync(epi!.Value);

        if (internalPayment is null || historyPayment is null || externalPayment is null)
            return BadRequest();

        if (!internalPayment.id.Equals(ipi!.Value) || !historyPayment.id.Equals(epi!.Value))
            return BadRequest();

        if (!_externalService.IsSuccessful(externalPayment))
            return PaymentRequired();

        var trackId             = $"{ipi}.{epi}";
        var stamp               = internalPayment.stamp;
        var coins               = (int)internalPayment.coins;

        await _balanceService.AddAfterPaymentAsync(uid, ipi!.Value, coins, stamp, token);
        await _historyService.AddAsync(ipi!.Value, externalPayment, token);
        await _internalService.RemoveAsync(uid, ipi!.Value, token);
        await _internalService.PersistFinancialAsync(token, 3);

        _accessService.NotifyAfterPurchase(uid, ems, trackId, coins, internalPayment.total, internalPayment.createdAt);
        await _activityService.AddPaymentAsync(uid, ipi!.Value, epi!.Value, coins, stamp, token);
        await _activityService.PersistAccountAsync(token, 2);

        return Ok();
    }
}