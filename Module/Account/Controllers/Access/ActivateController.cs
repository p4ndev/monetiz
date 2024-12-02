using Monetizacao.Modules.Account.Services;
using Monetizacao.Providers.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Modules.Account.Controllers.Access;

[ApiController]
[Route("Account/Access")]
public sealed class ActivateController(
    ClaimService _claimService,
    AccessService _accessService,
    ActivityService _activityService
) : HttpControllerHandler
{
    [HttpPatch]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status206PartialContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PatchAsync([FromQuery] long? id, [FromQuery] string? stamp, CancellationToken token = default)
    {
        var uid = UserId();

        if (!_accessService.IsModelValid(id, uid, stamp))
            return UnsupportedMediaType();

        int expected = 0;

        if (await _accessService.ActivateUserAsync(id!.Value, stamp!, token))
        {
            expected++;
            await _claimService.AddConfirmedEmailAsync(uid, token);
            expected++;
        }

        if (!await _activityService.ExistsRegistrationAsync(uid, token))
        {
            await _activityService.AddRegistrationAsync(uid, _accessService.ActivationStamp(), token);
            expected++;
        }

        if (expected == 0)
            return Conflict();

        if (!await _accessService.PersistRelationalAccountAsync(token, expected))
            return PartialContent();

        return Ok();
    }
}