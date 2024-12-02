using Monetizacao.Providers.Contexts.Constants;
using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Enums;
using Microsoft.Extensions.Configuration;
using Monetizacao.Providers.Contexts;
using Monetizacao.Providers.Handlers;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Modules.Account.Services;

public sealed class ActivityService
{
    private readonly int                        _ipp;
    private readonly UUIDHandler                _uuidHandler;
    private readonly AccountRelationalContext   _accountRelationalContext;

    public ActivityService(UUIDHandler uuid, AccountRelationalContext arc)
    {
        _uuidHandler = uuid;
        _accountRelationalContext = arc;
    }

    public ActivityService(IConfiguration cfg, UUIDHandler uuid, AccountRelationalContext arc)
        : this(uuid, arc)
    {
        var entity = cfg.GetRequiredSection("ItemsPerPage");

        if(entity is not null)
            _ipp = Convert.ToInt32(entity.Value);
    }

    public async Task<IList<ActivityEntity>> ListAsync(long uid, int page, CancellationToken token = default)
        => await _accountRelationalContext
            .Activities
                .AsNoTracking()
                    .OrderByDescending(a => a.Id)
                        .Where(a => a.AccountId.Equals(uid))
                            .Skip(page * _ipp)
                                .Take(_ipp)
                                    .ToListAsync(token);

    public async Task<bool> ExistsRegistrationAsync(long uid, CancellationToken token = default)
        => await _accountRelationalContext
            .Activities
                .AsNoTracking()
                    .AnyAsync(
                        a => 
                            a.AccountId.Equals(uid) &&
                            a.ActivityTypeId.Equals(ActivityTypeEnum.Account),
                        token
                    );

    public async Task<ActivityEntity> AddWithdrawAsync(long uid, decimal coins, long ipi, long epi, string stamp, CancellationToken token = default)
    {
        var entity = new ActivityWithdrawEntity(uid, coins, $"{ipi}.{epi}", stamp);

        await _accountRelationalContext.Activities.AddAsync(entity, token);

        return entity;
    }

    public async Task<ActivityEntity> AddRegistrationAsync(long uid, string stamp, CancellationToken token = default)
    {
        var entity = new ActivityRegistrationEntity(uid, stamp);

        await _accountRelationalContext.Activities.AddAsync(entity, token);

        return entity;
    }

    public async Task<ActivityEntity> AddPixAsync(long uid, string content, string stamp, CancellationToken token = default)
    {
        var entity = new ActivityPixKeyEntity(uid, content, stamp);

        await _accountRelationalContext.Activities.AddAsync(entity, token);

        return entity;
    }

    public async Task<ActivityEntity> AddPaymentAsync(long uid, long ipi, long epi, decimal coins, string stamp, CancellationToken token = default)
    {
        var entity = new ActivityPurchaseEntity(uid, coins, $"{ipi}.{epi}", stamp);

        await _accountRelationalContext.Activities.AddAsync(entity, token);

        return entity;
    }

    public async Task<ActivityEntity> AddAnswerAsync(long uid, string game, string action, string content, string stamp, CancellationToken token = default)
    {
        string parsedAnswer = "";
        ActivityEntity entity;

        switch (content.ToLower())
        {
            case ActionAnswerConst.Boolean.Positive:
                parsedAnswer = "global.yes";
                break;

            case ActionAnswerConst.Boolean.Negative:
                parsedAnswer = "global.no";
                break;
        }

        entity = new ActivityAnswerEntity(uid, game, action, parsedAnswer, stamp);

        await _accountRelationalContext.Activities.AddAsync(entity);

        return entity;
    }

    public async Task<ActivityEntity> AddPositiveResultAsync(long uid, string game, string action, decimal total, string stamp, CancellationToken token = default)
    {
        var entity = new ActivityPositiveRewardEntity(uid, game, action, total, stamp);

        await _accountRelationalContext.Activities.AddAsync(entity, token);

        return entity;
    }

    public async Task<ActivityEntity> AddNegativeResultAsync(long uid, string game, string action, decimal total, string stamp, CancellationToken token = default)
    {
        var entity = new ActivityNegativeRewardEntity(uid, game, action, total, stamp);
        
        await _accountRelationalContext.Activities.AddAsync(entity, token);

        return entity;
    }

    public async Task UpdatePositiveActionResultAsync(string stamp, CancellationToken token = default)
    {
        var entities = await _accountRelationalContext
            .Activities
                .Where(a => a.Stamp.ToLower().Equals(stamp.ToLower()))
                    .ToListAsync(token);

        foreach (var item in entities)
            item.RegisterPositiveResult();
    }

    public async Task UpdateNegativeActionResultAsync(string stamp, CancellationToken token = default)
    {
        var entities = await _accountRelationalContext
            .Activities
                .Where(a => a.Stamp.ToLower().Equals(stamp.ToLower()))
                    .ToListAsync(token);

        foreach (var item in entities)
            item.RegisterNegativeResult();
    }

    public async Task<bool> IsLastPageAsync(long uid, int page, CancellationToken token = default)
    {
        var count = await _accountRelationalContext
            .Activities
                .AsNoTracking()
                    .CountAsync(a => a.AccountId.Equals(uid), token);

        if (count <= _ipp) return true;

        int totalPages = ((count % _ipp) == 0 ? -1 : 0);

        totalPages += (count / _ipp);

        return (page == totalPages);
    }

    public bool IsModelValid(int page)
    {
        if (page < 0)
            return false;

        return true;
    }

    public string GenerateStamp() => _uuidHandler.Generate();

    public async Task<bool> PersistAccountAsync(CancellationToken token = default, int expected = 1)
        => (await _accountRelationalContext.SaveChangesAsync(token) >= expected);
}