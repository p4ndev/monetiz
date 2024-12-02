using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Modules.Lobby.Responses;
using Monetizacao.Providers.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Modules.Lobby.Services;

public sealed class GroupService
(
    LobbyRelationalContext _lobbyRelationalContext
)
{
    public async Task<GroupEntity?> FindAsync(long gid, CancellationToken token)
        => await _lobbyRelationalContext.Groups.AsNoTracking().FirstOrDefaultAsync(g => g.Id.Equals(gid), token);

    public string Headline(IEnumerable<PlayerResponse> responses)
    {
        if (responses is null)
            return string.Empty;

        PlayerResponse? firstGroup = responses.FirstOrDefault();
        PlayerResponse? lastGroup = null;
        string cross = "";

        if (responses.Count() > 1)
        {
            lastGroup = responses.LastOrDefault();
            cross = lastGroup is null ? "" : " x ";
        }
        
        return $"{firstGroup?.name}{cross}{lastGroup?.name}";
    }
}