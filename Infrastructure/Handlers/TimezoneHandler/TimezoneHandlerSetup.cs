using Microsoft.Extensions.DependencyInjection;

namespace Monetizacao.Providers.Handlers;

public static class TimezoneHandlerSetup
{
    public static void AddTimezoneHandler(this IServiceCollection services)
    {
        services.AddSingleton<TimezoneHandler>();
    }
}
