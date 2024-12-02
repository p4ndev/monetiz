using Microsoft.Extensions.DependencyInjection;

namespace Monetizacao.Providers.Handlers;

public static class ValidationHandlerSetup
{
    public static void AddValidationHandler(this IServiceCollection services)
    {
        services.AddSingleton<ValidationHandler>();
    }
}
