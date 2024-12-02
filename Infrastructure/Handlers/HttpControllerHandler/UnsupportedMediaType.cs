using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Providers.Handlers;

public partial class HttpControllerHandler : ControllerBase
{
    /// <summary>
    /// Creates a <see cref="ActionResult"/> object that produces a <see cref="StatusCodes.Status415UnsupportedMediaType"/> response.
    /// </summary>
    /// <returns>The created <see cref="ActionResult"/> for the response.</returns>
    [NonAction]
    public ActionResult UnsupportedMediaType(object? ouput = null)
        => StatusCode(StatusCodes.Status415UnsupportedMediaType, ouput);
}