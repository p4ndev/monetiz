using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Modules.Room.Responses;
using Monetizacao.Providers.Handlers;
using Monetizacao.Providers.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Modules.Room.Services;

public sealed class GameService
(
    ValidationHandler           _validationHandler,
    RoomRelationalContext       _relationalRoomContext
)
{
    public async Task<IEnumerable<GameResponse>?> ListAsync(CancellationToken token = default)
    {
        var entities = await _relationalRoomContext
            .Games
                .Include(a => a.Actions)
                    .AsNoTracking()
                        .Select(g => 
                            new GameResponse(
                                g.Id,
                                g.TenantId,
                                g.CategoryId,
                                g.Name,
                                g.FirstGroupId,
                                g.SecondGroupId,
                                g.Actions != null && g.Actions.Any() ? g.Actions.OrderBy(r => EF.Functions.Random()).Select(a => a.Id) : null
                            )
                        )
                            .ToListAsync(token);

        if (!entities.Any())
            return null;

        return entities;
    }

    public async Task<IEnumerable<GameResponse>?> ListAsync(long tid, long cid, CancellationToken token = default)
    {
        var result = await _relationalRoomContext
            .Games
                .Include(a => a.Actions)
                    .AsNoTracking()
                        .Where(g =>
                            g.TenantId.Equals(tid) &&
                            g.CategoryId.Equals(cid)
                        )
                            .Select(g => 
                                new GameResponse(
                                    g.Id,
                                    g.TenantId,
                                    g.CategoryId,
                                    g.Name,
                                    g.FirstGroupId,
                                    g.SecondGroupId,
                                    g.Actions != null && g.Actions.Any() ? g.Actions.OrderBy(r => EF.Functions.Random()).Select(a => a.Id) : null
                                )
                            )
                                .ToListAsync(token);

        if (result == null)
            return null;

        return result;
    }

    public IEnumerable<long> ListGroupIds(GameEntity gameEntity)
    {
        yield return gameEntity.FirstGroupId;

        if (gameEntity.SecondGroupId.HasValue)
            yield return gameEntity.SecondGroupId.Value;
    }

    public async Task<GameEntity?> FindAsync(long gid, CancellationToken token = default)
        => await _relationalRoomContext.Games.AsNoTracking().FirstOrDefaultAsync(g => g.Id.Equals(gid), token);

    public bool IsModelValid(long? id)
    {
        if (!_validationHandler.IsIdValid(id))
            return false;

        return true;
    }

    public bool IsModelValid(long? tid, long? cid)
    {
        if (!IsModelValid(tid) || !IsModelValid(cid))
            return false;

        return true;
    }

    public bool IsModelValid(long? tid, long? cid, long? eid)
    {
        if (!IsModelValid(tid) || !IsModelValid(cid) || !IsModelValid(eid))
            return false;

        return true;
    }
}