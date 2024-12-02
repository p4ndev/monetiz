using Microsoft.Extensions.DependencyInjection;
using Monetizacao.Modules.Account.Services;

namespace Monetizacao.Modules.Account;

public static class AccountModuleSetup
{
    public static void AddAccountModule(this IServiceCollection services)
    {
        services.AddTransient<RoleService>();
        services.AddTransient<ClaimService>();
        services.AddTransient<AccessService>();
        services.AddTransient<ActivityService>();
        services.AddTransient<RecoveryService>();
    }
}