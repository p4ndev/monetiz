using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts;

public static class AccountRelationalContextSetup
{
    public static void AddAccountRelationalContext(this IServiceCollection services)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

        var settings = BuildConfiguration(environment.Equals("Development", StringComparison.OrdinalIgnoreCase));

        services.AddDbContextPool<AccountRelationalContext>(options =>
            options.UseMySQL(settings.ConnectionString, m => m.MigrationsAssembly(settings.AssemblyName))
        );

        services
            .AddHealthChecks()
            .AddDbContextCheck<AccountRelationalContext>("Account");
    }

    internal static DbContextOptions<AccountRelationalContext> CreateDbContextOptions(bool isDevelopment)
    {
        var settings = BuildConfiguration(isDevelopment);

        var optionsBuilder = new DbContextOptionsBuilder<AccountRelationalContext>();

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
            .AddJsonFile("AccountRelationalContextSettings" + filenameSuffix + ".json", optional: false, reloadOnChange: true)
            .Build();

        var assemblyname = typeof(AccountRelationalContext).Assembly.FullName!;

        var connectionString = config.GetConnectionString("Account")!;

        return (config!, assemblyname, connectionString);
    }
}