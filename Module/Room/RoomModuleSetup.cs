using Microsoft.Extensions.DependencyInjection;
using Monetizacao.Modules.Room.Services;

namespace Monetizacao.Modules.Room;

public static class RoomModuleSetup
{
    public static void AddRoomModule(this IServiceCollection services)
    {
        services.AddTransient<GameService>();
        services.AddTransient<AnswerService>();
        services.AddTransient<ActionService>();
        services.AddTransient<TemplateService>();
    }
}
