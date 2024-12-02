using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Modules.Lobby.Responses;
using Monetizacao.Providers.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Modules.Lobby.Services;

public sealed class PlayerService
(
    LobbyRelationalContext _lobbyRelationalContext
)
{
    public async Task<IEnumerable<PlayerResponse>?> ListAsync(CancellationToken token = default)
        => await _lobbyRelationalContext
            .Groups
                .AsNoTracking()
                    .OrderBy(g => g.Id)
                        .Select(g => new PlayerResponse(g.Id, g.Name, g.Logotype))
                            .ToListAsync(token);

    public async Task<PlayerEntity?> FindAsync(long pid, CancellationToken token = default)
        => await _lobbyRelationalContext
            .Players
                .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id.Equals(pid), token);

    public async Task<IEnumerable<PlayerResponse>?> ListAsync(IEnumerable<long> groupIds, CancellationToken token = default)
        => await _lobbyRelationalContext
            .Groups
                .AsNoTracking()
                    .Where(g => groupIds.Contains(g.Id))
                        .Select(g => new PlayerResponse(g.Id, g.Name, g.Logotype))
                            .ToListAsync(token);

    public async Task<IEnumerable<long>> ListIdsAsync(IEnumerable<long> groupIds, CancellationToken token = default)
        => await _lobbyRelationalContext
                .GroupPlayers
                    .Include(p => p.Player)
                        .AsNoTracking()
                            .Where(gp => groupIds.Contains(gp.GroupId))
                                .Select(gp => gp.PlayerId)
                                    .ToListAsync(token);
}