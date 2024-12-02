using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Monetizacao.Providers.Contexts.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Monetizacao.Providers.Handlers;

public static class CryptoHandlerSetup
{
    public static void AddCryptoHandler(this IServiceCollection services)
    {
        var internalConfiguration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("CryptoHandlerSettings.json", false, true)
            .Build();

        var privateKey              = Encoding.ASCII.GetBytes(internalConfiguration.GetRequiredSection("Tokenize:Private").Value!);
        var expirationHours         = Convert.ToInt32(internalConfiguration.GetRequiredSection("Tokenize:Hours").Value!);
        var tokenKey                = internalConfiguration.GetRequiredSection("Tokenize:Private").Value!;
        var key                     = internalConfiguration.GetRequiredSection("ETag:Key").Value;
        var initializationVector    = internalConfiguration.GetRequiredSection("ETag:Iv").Value;
        var parsedKey               = Encoding.ASCII.GetBytes(tokenKey);

        services
            .AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x => {
                x.SaveToken                     = true;
                x.IncludeErrorDetails           = true;
                x.RequireHttpsMetadata          = false;

                x.TokenValidationParameters = new() {

                    ValidateIssuer              = false,
                    ValidateAudience            = false,

                    ValidateLifetime            = true,
                    ValidateIssuerSigningKey    = true,

                    ClockSkew                   = TimeSpan.Zero,
                    IssuerSigningKey            = new SymmetricSecurityKey(parsedKey)
                };
            });

        var composeAssert = (AuthorizationHandlerContext context, string value) => {
            var claims = context.User.FindAll(c => c.Type == "claims");
            
            if (claims.Count() == 0) return false;

            return claims.Any(c => c.Value == value);
        };

        services
            .AddAuthorization(o => {
                foreach (var item in Enum.GetValues(typeof(RoleEnum)))
                {
                    if (item.Equals(RoleEnum.None))
                        continue;

                    o.AddPolicy(item.ToString()!, p => p.RequireRole(item.ToString()!));
                }

                foreach (var item in Enum.GetValues(typeof(ClaimEnum)))
                {
                    if (item.Equals(ClaimEnum.None))
                        continue;

                    o.AddPolicy(
                        item.ToString()!,
                        p => p.RequireAssertion(
                            c => composeAssert(c, item.ToString()!)
                        )
                    );
                }
            });

        services.AddSingleton<Md5CryptoHandler>();
        services.AddSingleton(p => new JwtCryptoHandler(privateKey, expirationHours));
    }
}
