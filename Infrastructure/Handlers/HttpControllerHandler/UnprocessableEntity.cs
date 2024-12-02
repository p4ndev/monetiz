using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Providers.Handlers;

public partial class HttpControllerHandler : ControllerBase
{
    /// <summary>
    /// Creates a <see cref="ActionResult"/> object that produces a <see cref="StatusCodes.Status208AlreadyReported"/> response.
    /// </summary>
    /// <returns>The created <see cref="ActionResult"/> for the response.</returns>
    [NonAction]
    public ActionResult UnprocessableEntity(object? ouput = null)
        => StatusCode(StatusCodes.Status422UnprocessableEntity, ouput);
}