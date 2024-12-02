using Monetizacao.Modules.Financial.Requests;
using Monetizacao.Modules.Financial.Services;
using Monetizacao.Modules.Account.Services;
using Monetizacao.Providers.Contexts.Enums;
using Monetizacao.Providers.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Modules.Financial.Controllers.Pix;

[ApiController]
[Route("Financial/Pix")]
public sealed class RegistrationController(
    PixService _pixServices,
    ClaimService _claimService,
    AccessService _accessService,
    ActivityService _activityService
) : HttpControllerHandler
{
    [HttpPost]
    [Authorize(Roles = nameof(RoleEnum.Member))]
    [Authorize(Policy = nameof(ClaimEnum.HasEmailConfirmed))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PostAsync([FromBody] PixRequest model, CancellationToken token = default)
    {
        var uid = UserId();

        if (!_pixServices.IsModelValid(uid, model))
            return UnsupportedMediaType();

        if (await _pixServices.FindAsync(uid, model, token))
            return Conflict();

        if(await _pixServices.AddAsync(uid, model, token))
        {
            string stamp = _activityService.GenerateStamp();
            await _claimService.AddPixAsync(uid, token);
            string pixTypeName = _pixServices.FriendlyName(model.type);
            await _activityService.AddPixAsync(uid, pixTypeName, stamp, token);

            if(!await _accessService.PersistRelationalAccountAsync(token, 2))
                return PartialContent();
                
            return Created(string.Empty, null);
        }

        return BadRequest();
    }
}