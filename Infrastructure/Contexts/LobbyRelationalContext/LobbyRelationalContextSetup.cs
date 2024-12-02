using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Monetizacao.Providers.Contexts;

public static class LobbyRelationalContextSetup
{
    public static void AddLobbyRelationalContext(this IServiceCollection services)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

        var settings = BuildConfiguration(environment.Equals("Development", StringComparison.OrdinalIgnoreCase));

        services.AddDbContextPool<LobbyRelationalContext>(options => {
            options.UseMySQL(settings.ConnectionString, m => m.MigrationsAssembly(settings.AssemblyName));
        });

        services
            .AddHealthChecks()
            .AddDbContextCheck<LobbyRelationalContext>("Lobby");
    }

    internal static DbContextOptions<LobbyRelationalContext> CreateDbContextOptions(bool isDevelopment)
    {
        var settings = BuildConfiguration(isDevelopment);

        var optionsBuilder = new DbContextOptionsBuilder<LobbyRelationalContext>();

        optionsBuilder.UseMySQL(settings.ConnectionString, m => m.MigrationsAssembly(settings.AssemblyName));

        if(isDevelopment)
            optionsBuilder.EnableSensitiveDataLogging();

        return optionsBuilder.Options;
    }

    internal static (IConfiguration Configuration, string AssemblyName, string ConnectionString) BuildConfiguration(bool isDevelopment = true)
    {
        string filenameSuffix = isDevelopment ? "" : ".Production";

        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("LobbyRelationalContextSettings" + filenameSuffix + ".json", optional: false, reloadOnChange: true)
            .Build();

        var assemblyname = typeof(LobbyRelationalContext).Assembly.FullName!;

        var connectionString = config.GetConnectionString("Lobby")!;

        return (config!, assemblyname, connectionString);
    }
}