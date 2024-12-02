using Monetizacao.Providers.Contexts.Constants;
using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Modules.Room.Responses;
using Monetizacao.Providers.Contexts;
using Monetizacao.Providers.Handlers;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Modules.Room.Services;

public sealed class ActionService
(
    TimezoneHandler             _timezoneHandler,
    ValidationHandler           _validationHandler,
    RoomRelationalContext       _roomRelationalContext
)
{
    public async Task<IEnumerable<BooleanActionResponse>?> FindByGroupAsync(long gid, CancellationToken token = default)
        => await _roomRelationalContext
            .Actions
                .Include(an => an.Answers)
                    .AsNoTracking()
                        .Select(a => new {
                            a.GameId,
                            Output = new BooleanActionResponse(
                                a.Id,
                                a.Name,
                                a.Image,
                                a.StartsAt,
                                a.EndsAt,
                                a.EndsAt.Subtract(_timezoneHandler.RightNow()).TotalHours.ToString("F0"),
                                a.Answers != null ? a.Answers.LongCount(an => an.Content.ToLower().Equals(ActionAnswerConst.Boolean.Positive)) : 0,
                                a.Answers != null ? a.Answers.LongCount(an => an.Content.ToLower().Equals(ActionAnswerConst.Boolean.Negative)) : 0,
                                a.Answers != null ? a.Answers.LongCount() : 0
                            )
                        })
                        .Where(a => a.GameId.Equals(gid))
                                .Select(bar => bar.Output)
                                    .ToListAsync(token);

    public async Task<ActionEntity?> FindByIdAsync(long aid, CancellationToken token = default)
        => await _roomRelationalContext
            .Actions
                .Include(g => g.Game)
                    .AsNoTracking()
                        .FirstOrDefaultAsync(a => a.Id.Equals(aid), token);

    public async Task<ArenaResponse?> FindByIdForArenaAsync(long aid, CancellationToken token = default)
    {
        var entity = await _roomRelationalContext
            .Actions
                .AsNoTracking()
                    .Select(a => new { a.Id, a.Name, a.Image, a.StartsAt, a.EndsAt, a.Active })
                        .Where(a => a.Id.Equals(aid))
                            .FirstOrDefaultAsync(token);

        if (entity is null)
            return null;

        return new ArenaResponse(entity.Id, entity.Name, entity.Image, entity.StartsAt, entity.EndsAt);
    }

    public async Task<string?> StampAsync(long aid, CancellationToken token = default)
    {
        var entity = await _roomRelationalContext
            .Actions
                .AsNoTracking()
                    .Select(a => new { a.Id, a.Stamp })
                        .FirstOrDefaultAsync(a => a.Id.Equals(aid), token);

        if (entity is null)
            return null;

        return entity.Stamp;
    }

    public async Task<ActionEntity> AddAsync(long uid, long gid, long tid, string action, string image, DateTime starts, DateTime ends, string stamp, CancellationToken token = default)
    {
        var entity = new RegularActionEntity(uid, gid, tid, action, image, starts, ends, stamp);
        
        await _roomRelationalContext.Actions.AddAsync(entity, token);
        
        return entity;
    }

    public async Task RemoveAsync(long aid, CancellationToken token = default)
    {
        var entity = await _roomRelationalContext.Actions.FindAsync(aid, token);

        if (entity is null)
            return;

        entity.Remove();
    }

    public bool IsModelValid(long? id)
    {
        if (!_validationHandler.IsIdValid(id))
            return false;

        return true;
    }

    public bool IsModelValid(long? uid, long? eid)
    {
        if (!IsModelValid(uid) || !IsModelValid(eid))
            return false;

        return true;
    }

    public bool IsModelValid(string? answer)
    {
        if (String.IsNullOrEmpty(answer) || String.IsNullOrWhiteSpace(answer))
            return false;

        answer = answer.ToLower();

        if (!ActionAnswerConst.Boolean.Positive.Equals(answer) &&
                !ActionAnswerConst.Boolean.Negative.Equals(answer))
                    return false;

        return true;
    }

    public bool IsModelValid(long? uid, long? aid, string? answer)
    {
        if (!IsModelValid(uid, aid) || !IsModelValid(answer))
            return false;

        return true;
    }

    public async Task<bool> PersistRoomAsync(CancellationToken token = default, int expected = 1)
        => (await _roomRelationalContext.SaveChangesAsync(token) >= expected);
}