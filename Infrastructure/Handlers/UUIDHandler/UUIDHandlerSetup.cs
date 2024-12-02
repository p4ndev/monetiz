using Microsoft.Extensions.DependencyInjection;

namespace Monetizacao.Providers.Handlers;

public static class UUIDHandlerSetup
{
    public static void AddUUIDHandler(this IServiceCollection services)
    {
        services.AddSingleton<UUIDHandler>();
    }
}
