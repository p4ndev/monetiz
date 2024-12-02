using Monetizacao.Modules.Account.Responses;
using Monetizacao.Modules.Account.Requests;
using Monetizacao.Modules.Account.Services;
using Monetizacao.Providers.Contexts.Enums;
using Monetizacao.Providers.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Modules.Account.Controllers.Access;

[ApiController]
[Route("Account/Access")]
public sealed class SignInController(
    RoleService _roleService,
    ClaimService _claimService,
    AccessService _accessService
) : HttpControllerHandler
{
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<SignInResponse>> GetAsync([FromHeader] string email, [FromHeader] string password, CancellationToken token = default)
    {
        password = _accessService.EncryptPassword(password);

        var model = new AccountRequest(email, password);

        if (!_accessService.IsModelValid(model))
            return UnsupportedMediaType();

        var entity = await _accessService.FindAsync(model.email, model.password, token);

        if (entity == null)
            return NotFound();

        var claims = await _claimService.ListAsync(entity!.id, token);

        if (!claims.Any(c => c.Id.Equals(ClaimEnum.HasApiAccess)))
            return Forbid();

        var role = _roleService.Find(entity!.roleId);
        var accountResponse = _accessService.AccountToResponse(entity!, role!, claims);
        var tokenClaims = _claimService.Attach(accountResponse);
        var response = _accessService.GenerateToken(tokenClaims, accountResponse.basicAccount.fullName);

        return Ok(response);
    }
}