using Microsoft.Extensions.DependencyInjection;
using Monetizacao.Modules.Lobby.Services;

namespace Monetizacao.Modules.Lobby;

public static class LobbyModuleSetup
{
    public static void AddLobbyModule(this IServiceCollection services)
    {
        services.AddTransient<TenantService>();
        services.AddTransient<CategoryService>();
        services.AddTransient<GroupService>();
        services.AddTransient<PlayerService>();
    }
}