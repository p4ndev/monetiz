using Monetizacao.Modules.Account.Responses;
using Monetizacao.Modules.Account.Services;
using Monetizacao.Providers.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Modules.Account.Controllers.Access;

[ApiController]
[Route("Account/Access")]
public sealed class RefreshTokenController(
    RoleService _roleService,
    ClaimService _claimService,
    AccessService _accessService
) : HttpControllerHandler
{
    [HttpPut]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<SignInResponse>> PutAsync(CancellationToken token = default)
    {
        var uid = UserId();

        BasicAccountResponse? account = await _accessService.FindAsync(uid, token);

        if (account == null)
            return NotFound();

        var role = _roleService.Find(account!.roleId);

        if (role == null)
            return Forbid();

        var claims = await _claimService.ListAsync(account!.id, token);
        var accountResponse = _accessService.AccountToResponse(account!, role!, claims);
        var tokenClaims = _claimService.Attach(accountResponse);
        var response = _accessService.GenerateToken(tokenClaims, accountResponse.basicAccount.fullName);

        return Ok(response);
    }
}