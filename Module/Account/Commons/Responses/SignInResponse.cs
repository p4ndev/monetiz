namespace Monetizacao.Modules.Account.Responses;

public class SignInResponse
{
    public DateTime?    expiresIn;
    public string?      fullName;
    public string?      token;

    public SignInResponse(DateTime? expiresIn, string? fullName, string? token)
    {
        this.expiresIn  = expiresIn;
        this.fullName   = fullName;
        this.token      = token;
    }
}