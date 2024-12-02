using Microsoft.Extensions.DependencyInjection;

namespace Monetizacao.Providers.Handlers;

public static class CorsHandlerSetup
{
    private static bool IsDevelopment()
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

        return environment.Equals("Development", StringComparison.OrdinalIgnoreCase);
    }

    public static void AddCorsHandler(this IServiceCollection services)
    {
        services
            .AddCors(o => {
                o.AddDefaultPolicy(b => {
                    if (IsDevelopment())
                        b.AllowAnyOrigin();
                    else
                        b.WithOrigins("https://monetiz.fun");

                    b
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
    }
}
