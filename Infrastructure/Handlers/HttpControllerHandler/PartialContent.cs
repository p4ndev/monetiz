using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monetizacao.Providers.Handlers;

public partial class HttpControllerHandler : ControllerBase
{
    /// <summary>
    /// Creates a <see cref="ActionResult"/> object that produces a <see cref="StatusCodes.Status206PartialContent"/> response.
    /// </summary>
    /// <returns>The created <see cref="ActionResult"/> for the response.</returns>
    [NonAction]
    public ActionResult PartialContent(object? output = null)
        => StatusCode(StatusCodes.Status206PartialContent, output);
}