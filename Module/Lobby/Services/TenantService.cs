using Monetizacao.Modules.Lobby.Responses;
using Monetizacao.Providers.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Modules.Lobby.Services;

public sealed class TenantService
(
    LobbyRelationalContext _lobbyRelationalContext
)
{
    public async Task<IEnumerable<TenantResponse>> ListAsync(CancellationToken token = default)
        => await _lobbyRelationalContext
            .Tenants
                .Include(tc => tc.TenantColors)
                .Include(c => c.Categories)
                    .AsNoTracking()
                        .Select(t => new TenantResponse(
                                t.Id,
                                t.Name,
                                t.Logotype,
                                t.TenantColors == null ? null : t.TenantColors!.OrderBy(tc => tc.Id).Select(tc => tc.Rgb),
                                t.Categories == null ? null : t.Categories!.OrderBy(c => c.Id).LastOrDefault()!.EndsAt
                            )
                        ).ToListAsync(token);
}