using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Monetizacao.Providers.Contexts;

public static class MercadoPagoContextSetup
{
    public static void AddMercadoPagoContext(this IServiceCollection services)
    {
        string filenameSuffix = IsDevelopment() ? "" : ".Production";

        var internalConfiguration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("MercadoPagoContextSettings" + filenameSuffix + ".json", false, true)
            .Build();

        var expirationHours         = Convert.ToInt16(internalConfiguration.GetRequiredSection("MercadoPago:ExpirationHours").Value!);
        var statementDescription    = internalConfiguration.GetRequiredSection("MercadoPago:Descriptor").Value!;
        var accessToken             = internalConfiguration.GetRequiredSection("MercadoPago:AccessToken").Value!;

        var successStatus           = internalConfiguration.GetRequiredSection("MercadoPago:PixTransaction:Success:Status").Value;
        var successDetail           = internalConfiguration.GetRequiredSection("MercadoPago:PixTransaction:Success:Detail").Value;

        services.AddScoped(p => new MercadoPagoContext(expirationHours, statementDescription, accessToken, successStatus, successDetail));
    }

    private static bool IsDevelopment()
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

        return environment.Equals("Development", StringComparison.OrdinalIgnoreCase);
    }
}