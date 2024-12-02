using Monetizacao.Providers.Contexts.Constants;
using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Modules.Room.Services;

public sealed class AnswerService(RoomRelationalContext _roomRelationalContext)
{
    public async Task<IEnumerable<AnswerEntity>> ListAsync(long uid, CancellationToken token = default)
        => await _roomRelationalContext
            .Answers
                .Include(ac => ac.Action)
                    .ThenInclude(g => g.Game)
                        .AsNoTracking()
                            .Where(a => a.AccountId.Equals(uid))
                                .ToListAsync(token);

    public async Task<IEnumerable<long>?> ListUserIdsAsync(long aid, bool isPositive = true, CancellationToken token = default)
    {
        var answer = isPositive ? ActionAnswerConst.Boolean.Positive : ActionAnswerConst.Boolean.Negative;

        var entities = await _roomRelationalContext
            .Answers
                .AsNoTracking()
                    .Select(an => new { an.ActionId, an.Content, an.AccountId })
                        .Where(an =>  an.ActionId.Equals(aid) && an.Content.ToLower().Equals(answer))
                            .ToListAsync(token);

        if (!entities.Any())
            return null;

        return entities.Select(u => u.AccountId);
    }

    public async Task<bool> HasAnsweredAsync(long uid, long aid, CancellationToken token = default)
        => await _roomRelationalContext
            .Answers
                .AsNoTracking()
                    .AnyAsync(
                        a => a.AccountId.Equals(uid) && 
                             a.ActionId.Equals(aid),
                        token
                    );

    public async Task<AnswerEntity?> AddBooleanAnswerAsync(long uid, long aid, string content, CancellationToken token = default)
    {
        switch (content.ToLower())
        {
            case ActionAnswerConst.Boolean.Positive:
                return await AddPositiveAnswerAsync(uid, aid, token);

            case ActionAnswerConst.Boolean.Negative:
                return await AddNegativeAnswerAsync(uid, aid, token);
        }

        return null;
    }

    private async Task<AnswerEntity> AddPositiveAnswerAsync(long uid, long aid, CancellationToken token = default)
    {
        var entity = new BooleanPositiveAnswerEntity(uid, aid);

        await _roomRelationalContext.Answers.AddAsync(entity, token);

        return entity;
    }

    private async Task<AnswerEntity> AddNegativeAnswerAsync(long uid, long aid, CancellationToken token = default)
    {
        var entity = new BooleanNegativeAnswerEntity(uid, aid);

        await _roomRelationalContext.Answers.AddAsync(entity, token);

        return entity;
    }

    public async Task<ActionResultEntity> AddPositiveAnswerResultAsync(long oid, long aid, string fact, string stamp, CancellationToken token = default)
    {
        var entity = new BooleanPositiveActionResult(oid, aid, fact, stamp);

        await _roomRelationalContext.ActionResults.AddAsync(entity, token);

        return entity;
    }

    public async Task<ActionResultEntity> AddNegativeAnswerResultAsync(long oid, long aid, string fact, string stamp, CancellationToken token = default)
    {
        var entity = new BooleanNegativeActionResult(oid, aid, fact, stamp);

        await _roomRelationalContext.ActionResults.AddAsync(entity, token);

        return entity;
    }

    public async Task<bool> PersistRoomAsync(CancellationToken token = default, int expected = 1)
        => (await _roomRelationalContext.SaveChangesAsync(token) >= expected);
}