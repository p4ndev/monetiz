using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Modules.Financial.Responses;
using Monetizacao.Providers.Contexts.Enums;
using Monetizacao.Providers.Handlers;
using Monetizacao.Providers.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Modules.Financial.Services;

public sealed class BalanceService
(
    UUIDHandler                     _uuidHandler,
    ValidationHandler               _validationHandler,
    FinancialRelationalContext      _financialRelationalContext
)
{
    private async Task<IList<BalanceEntryResponse>> ListAsync(long uid, long lid, OperationTypeEnum opt, CancellationToken token = default)
        => await _financialRelationalContext
            .Balances
                .AsNoTracking()
                    .OrderBy(b => b.Id)
                        .Where(b => b.Id > lid && b.AccountId.Equals(uid) && b.OperationTypeId.Equals(opt))
                            .Select(b => new BalanceEntryResponse(b.Id, b.EntityId, b.OriginTypeId, b.Amount, b.CreatedAt))
                                .ToListAsync(token);

    private async Task<decimal> SumAsync(long uid, OperationTypeEnum opt, CancellationToken token = default)
        => await _financialRelationalContext
            .Balances
                .AsNoTracking()
                    .Where(b => b.AccountId.Equals(uid) && b.OperationTypeId.Equals(opt))
                        .SumAsync(b => b.Amount, token);
    
    private async Task AddAsync(BalanceEntity entity, CancellationToken token = default)
        => await _financialRelationalContext.Balances.AddAsync(entity, token);

    public async Task<IList<BalanceEntryResponse>> ListDebitsAsync(long uid, long lid, CancellationToken token = default)
        => await ListAsync(uid, lid, OperationTypeEnum.Out, token);

    public async Task<decimal> TotalDebitsAsync(long uid, CancellationToken token = default)
        => await SumAsync(uid, OperationTypeEnum.Out, token);

    public async Task<IList<BalanceEntryResponse>> ListCreditsAsync(long uid, long lid, CancellationToken token = default)
        => await ListAsync(uid, lid, OperationTypeEnum.In, token);

    public async Task<decimal> TotalCreditsAsync(long uid, CancellationToken token = default)
        => await SumAsync(uid, OperationTypeEnum.In, token);

    public async Task<BalanceEntity> AddAfterResultAsync(long uid, long aid, decimal coins, string stamp, CancellationToken token = default)
    {
        var entity = new BalanceActionIngressEntity(uid, aid, coins, stamp);
        
        await AddAsync(entity, token);

        return entity;
    }

    public async Task<BalanceEntity> AddAfterPaymentAsync(long uid, long pid, decimal coins, string stamp, CancellationToken token = default)
    {
        var entity = new BalancePaymentIngressEntity(uid, pid, coins, stamp);
        
        await AddAsync(entity, token);

        return entity;
    }

    public async Task<BalanceEntity> AddAfterAnswerAsync(long uid, long aid, string stamp, CancellationToken token = default)
    {
        var entity = new BalanceActionEgressEntity(uid, aid, stamp);

        await AddAsync(entity, token);

        return entity;
    }

    public async Task<BalanceEntity> RemoveOnWithdrawAsync(long uid, long eid, decimal coins, CancellationToken token = default)
    {
        var entity = new BalancePaymentEgressEntity(uid, eid, coins, _uuidHandler.Generate());

        await AddAsync(entity, token);
        
        return entity;
    }

    public async Task<bool> ExistsAsync(long uid, CancellationToken token = default)
        => ((await TotalCreditsAsync(uid, token)) - (await TotalDebitsAsync(uid, token))) >= 1;
    
    public bool IsModelValid(long uid)
        => _validationHandler.IsIdValid(uid);

    public async Task<bool> PersistFinancialAsync(CancellationToken token = default, int expected = 1)
        => (await _financialRelationalContext.SaveChangesAsync(token) >= expected);
}