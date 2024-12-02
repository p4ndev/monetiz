using Microsoft.EntityFrameworkCore.Design;

namespace Monetizacao.Providers.Contexts;

public class AccountRelationalContextFactory : IDesignTimeDbContextFactory<AccountRelationalContext>
{
    public AccountRelationalContext CreateDbContext(string[] args)
    {
        string environment = "Production";

        if (args != null && args.Length > 0)
        {
            var envArg = args.FirstOrDefault(arg => arg.StartsWith("--environment"));
            if (envArg != null)
            {
                var splitEnv = envArg.Split('=', StringSplitOptions.RemoveEmptyEntries);
                if (splitEnv.Length == 2)
                {
                    environment = splitEnv[1];
                }
            }
        }

        bool isDevelopment = environment.Equals("Development", StringComparison.OrdinalIgnoreCase);

        var options = AccountRelationalContextSetup.CreateDbContextOptions(isDevelopment);

        return new AccountRelationalContext(options);
    }
}