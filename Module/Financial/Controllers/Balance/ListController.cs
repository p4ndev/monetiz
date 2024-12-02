using Monetizacao.Modules.Financial.Responses;
using Monetizacao.Modules.Financial.Services;
using Monetizacao.Providers.Contexts.Enums;
using Monetizacao.Providers.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Modules.Financial.Controllers.Balance;

[ApiController]
[Route("Financial/Balance")]
public sealed class ListController(
    BalanceService _balanceService
) : HttpControllerHandler
{
    [HttpGet]
    [Authorize(Roles = nameof(RoleEnum.Member))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<BalanceResponse>> GetAsync([FromQuery] int? lci, [FromQuery] int? ldi, CancellationToken token = default)
    {
        var uid = UserId();

        if (!_balanceService.IsModelValid(uid))
            return UnsupportedMediaType();

        var credits = await _balanceService.ListCreditsAsync(uid, lci ?? 0, token);
        var debits = await _balanceService.ListDebitsAsync(uid, ldi ?? 0, token);

        if (!credits.Any() && !debits.Any())
            return NotFound();

        return Ok(new BalanceResponse(credits, debits));
    }
}