using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Providers.Handlers;

public partial class HttpControllerHandler : ControllerBase
{
    /// <summary>
    /// Creates a <see cref="ActionResult"/> object that produces a <see cref="StatusCodes.Status499ClientClosedRequest"/> response.
    /// </summary>
    /// <returns>The created <see cref="ActionResult"/> for the response.</returns>
    [NonAction]
    public ActionResult ClientClosedRequest(object? ouput = null)
        => StatusCode(StatusCodes.Status499ClientClosedRequest, ouput);
}