using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Monetizacao.Providers.Handlers;

public class JwtCryptoHandler : IDisposable
{
    private JwtSecurityTokenHandler?        _jwtSecurityHandler;
    private TimezoneHandler                 _timezoneHandler;
    private SigningCredentials?             _credentials;
    private SecurityTokenDescriptor?        _descriptor;
    
    private readonly byte[]?                PrivateKey;
    public readonly int                     ExpirationHours;

    public JwtCryptoHandler()
    {
        _timezoneHandler        = new();
        _jwtSecurityHandler     = new();
    }

    public JwtCryptoHandler(byte[] privateKey, int expirationHours)
        : this()
    {
        _credentials            = null;
        _descriptor             = null;

        PrivateKey              = privateKey;
        ExpirationHours         = expirationHours;
    }

    public DateTime Initialize(ClaimsIdentity accountTokenClaims)
    {
        var expiresIn = _timezoneHandler.RightNow().AddHours(ExpirationHours);

        _credentials = new SigningCredentials(
            new SymmetricSecurityKey(PrivateKey),
            SecurityAlgorithms.HmacSha256Signature
        );

        _descriptor = new SecurityTokenDescriptor
        {
            Expires             = expiresIn,
            SigningCredentials  = _credentials,
            Subject             = accountTokenClaims
        };

        return expiresIn;
    }

    public string? Build()
    {
        if (_jwtSecurityHandler is null)
            return null;

        var securityToken       = _jwtSecurityHandler.CreateToken(_descriptor);
        var userToken           = _jwtSecurityHandler.WriteToken(securityToken);

        return userToken;
    }

    public void Dispose()
    {
        _credentials            = null;
        _descriptor             = null;
        _jwtSecurityHandler     = null;
    }
}