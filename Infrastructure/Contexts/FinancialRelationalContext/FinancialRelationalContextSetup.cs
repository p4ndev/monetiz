using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Monetizacao.Providers.Contexts;

public static class FinancialRelationalContextSetup
{
    public static void AddFinancialRelationalContext(this IServiceCollection services)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

        var settings = BuildConfiguration(environment.Equals("Development", StringComparison.OrdinalIgnoreCase));

        services.AddDbContext<FinancialRelationalContext>(options =>
            options.UseMySQL(settings.ConnectionString, m => m.MigrationsAssembly(settings.AssemblyName))
        );

        services
            .AddHealthChecks()
            .AddDbContextCheck<FinancialRelationalContext>("Financial");
    }

    internal static DbContextOptions<FinancialRelationalContext> CreateDbContextOptions(bool isDevelopment)
    {
        var settings = BuildConfiguration(isDevelopment);

        var optionsBuilder = new DbContextOptionsBuilder<FinancialRelationalContext>();

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
            .AddJsonFile("FinancialRelationalContextSettings" + filenameSuffix + ".json", optional: false, reloadOnChange: true)
            .Build();

        var assemblyname = typeof(FinancialRelationalContext).Assembly.FullName!;

        var connectionString = config.GetConnectionString("Financial")!;

        return (config!, assemblyname, connectionString);
    }
}