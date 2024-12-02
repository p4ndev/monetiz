using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FluentEmail.Core;

namespace Monetizacao.Providers.Contexts;

public static class EmailContextSetup
{
    public static void AddEmailContext(this IServiceCollection services)
    {
        string filenameSuffix = IsDevelopment() ? "" : ".Production";

        var internalConfiguration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("EmailContextSettings" + filenameSuffix + ".json", false, true)
            .Build();

        var settings = internalConfiguration.GetRequiredSection("Email")!;
        var appHost = internalConfiguration.GetRequiredSection("AppHost").Value!;

        if (String.IsNullOrEmpty(settings["Password"]) || String.IsNullOrEmpty(settings["Password"]))
            services
                .AddFluentEmail(settings["From"])
                .AddSmtpSender(settings["Host"], Convert.ToInt32(settings["Port"]));
        else
            services
                .AddFluentEmail(settings["From"])
                .AddSmtpSender(settings["Host"], Convert.ToInt32(settings["Port"]), settings["From"], settings["Password"]);

        services
            .AddScoped(p => {
                var emailProvider = p.GetRequiredService<IFluentEmail>();
                return new AccountEmailContext(emailProvider, appHost);
            });
    }

    private static bool IsDevelopment()
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

        return environment.Equals("Development", StringComparison.OrdinalIgnoreCase);
    }
}