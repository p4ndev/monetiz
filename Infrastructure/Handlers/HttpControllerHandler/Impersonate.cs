using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Monetizacao.Providers.Handlers;

public partial class HttpControllerHandler : ControllerBase
{
    [NonAction]
    public long UserId()
    {
        var id = User.FindFirst(ClaimTypes.NameIdentifier);

        if (id is null || id.ToString().Equals("0"))
            throw new InvalidCredentialException("Invalid user id requested");

        return Convert.ToInt64(id.Value);
    }

    [NonAction]
    public string UserEmail()
    {
        var email = User.FindFirst(ClaimTypes.Email);

        if (email is null)
            throw new InvalidCredentialException("Invalid user email requested");

        return email.Value;
    }

    [NonAction]
    public (string first, string last) UserNames()
    {
        var fullName = User.FindFirst(ClaimTypes.Name);

        if (fullName is null)
            throw new InvalidCredentialException("Invalid user names requested");

        var arr = fullName.Value.Split(' ');

        return (arr[0], (arr.Length > 1 ? arr[1] : ""));
    }
}
