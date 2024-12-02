using Monetizacao.Modules.Financial.Interfaces;
using Monetizacao.Modules.Financial.Requests;
using Monetizacao.Modules.Financial.Services;
using Monetizacao.Providers.Contexts.Enums;
using Monetizacao.Providers.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Modules.Financial.Controllers.Sell;

[ApiController]
[Route("Financial/Sell")]
public partial class WithdrawController(InternalPaymentServiceInterface _internalService, CheckoutService _checkoutService, BalanceService _balanceService) : HttpControllerHandler
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

        if (!_checkoutService.IsSellModelValid(uid, model))
            return UnsupportedMediaType();

        var internalPayment = await _internalService.WithdrawAsync(uid, model, token);

        if (internalPayment is null)
            return BadRequest();

        var ipi = internalPayment.Id;
        var coins = (int)internalPayment.Coins;

        await _balanceService.RemoveOnWithdrawAsync(uid, ipi, coins, token);

        if (!await _internalService.PersistFinancialAsync(token, 2))
            return PartialContent();

        return Ok();
    }
}