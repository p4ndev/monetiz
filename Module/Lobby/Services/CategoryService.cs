using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Modules.Lobby.Responses;
using Monetizacao.Providers.Contexts;
using Monetizacao.Providers.Handlers;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Modules.Lobby.Services;

public sealed class CategoryService
(
    TimezoneHandler             _timezoneHandler,
    ValidationHandler           _validationHandler,
    LobbyRelationalContext      _lobbyRelationalContext
)
{
    public async Task<IEnumerable<CategoryEntity>> ListAsync(IEnumerable<long> ids, CancellationToken token = default)
        => await _lobbyRelationalContext.Categories.AsNoTracking().Where(c => ids.Contains(c.Id)).ToListAsync(token);

    public async Task<IEnumerable<CategoryResponse>> ListAsync(CancellationToken token = default)
        => await _lobbyRelationalContext
            .Categories
                .AsNoTracking()
                    .Where(c => c.StartsAt <= _timezoneHandler.RightNow() && c.EndsAt   >= _timezoneHandler.RightNow())
                        .Select(c => new CategoryResponse(c.Id, c.TenantId, c.Name, c.Summary, c.Logotype, c.StartsAt, c.EndsAt))
                            .ToListAsync(token);

    public async Task<CategoryEntity?> FindAsync(long cid, CancellationToken token = default)
        => await _lobbyRelationalContext.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id.Equals(cid), token);

    public bool IsModelValid(long? tid)
    {
        if (!_validationHandler.IsIdValid(tid))
            return false;

        return true;
    }
}