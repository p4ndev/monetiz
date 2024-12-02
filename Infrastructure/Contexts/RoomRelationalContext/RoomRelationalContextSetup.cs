using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Monetizacao.Providers.Contexts;

public static class RoomRelationalContextSetup
{
    public static void AddRoomRelationalContext(this IServiceCollection services)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

        var settings = BuildConfiguration(environment.Equals("Development", StringComparison.OrdinalIgnoreCase));

        services.AddDbContextPool<RoomRelationalContext>(options =>
            options.UseMySQL(settings.ConnectionString, m => m.MigrationsAssembly(settings.AssemblyName))
        );

        services
            .AddHealthChecks()
            .AddDbContextCheck<RoomRelationalContext>("Room");
    }

    internal static DbContextOptions<RoomRelationalContext> CreateDbContextOptions(bool isDevelopment)
    {
        var settings = BuildConfiguration(isDevelopment);

        var optionsBuilder = new DbContextOptionsBuilder<RoomRelationalContext>();

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
            .AddJsonFile("RoomRelationalContextSettings" + filenameSuffix + ".json", optional: false, reloadOnChange: true)
            .Build();

        var assemblyname = typeof(RoomRelationalContext).Assembly.FullName!;

        var connectionString = config.GetConnectionString("Room")!;

        return (config!, assemblyname, connectionString);
    }
}