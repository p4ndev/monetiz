using Monetizacao.Modules.Financial.Interfaces;
using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Modules.Financial.Responses;
using Monetizacao.Modules.Financial.Requests;
using Monetizacao.Providers.Contexts.Enums;
using Monetizacao.Providers.Handlers;
using Monetizacao.Providers.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Modules.Financial.Services;

public sealed class InternalPaymentService
(
    UUIDHandler                     _uuidHandler,
    TimezoneHandler                 _timezoneHandler,
    FinancialRelationalContext      _financialRelationalContext
) : InternalPaymentServiceInterface
{
    public async Task<InternalPaymentResponse?> FindAsync(long uid, CancellationToken token = default)
    {
        var entity = await _financialRelationalContext
            .Payments
                .AsNoTracking()
                    .Select(p => new {
                        p.AccountId,
                        p.PaymentTypeId,
                        Output = new InternalPaymentResponse(p.Id, p.Coins, p.Total, p.Stamp ?? string.Empty, p.CreatedAt)
                    })
                        .FirstOrDefaultAsync(
                            p =>
                                p.PaymentTypeId.Equals(PaymentTypeEnum.MercadoPago) &&
                                p.AccountId.Equals(uid),
                            token
                        );

        if (entity is null)
            return null;

        return entity.Output;
    }

    public async Task<IEnumerable<PaymentEntity>> FindPurchasesAsync(long uid, CancellationToken token = default)
        => await _financialRelationalContext
            .Payments
                .Include(mph => mph.MercadoPagoHistories)
                    .AsNoTracking()
                        .Where(p => p.PaymentTypeId.Equals(PaymentTypeEnum.MercadoPago) && p.AccountId.Equals(uid))
                            .ToListAsync(token);

    public async Task<IEnumerable<PaymentEntity>> FindWithdrawsAsync(long uid, CancellationToken token = default)
        => await _financialRelationalContext
            .Payments
                .Include(mph => mph.MercadoPagoHistories)
                    .AsNoTracking()
                        .Where(p => p.PaymentTypeId.Equals(PaymentTypeEnum.Manual) && p.AccountId.Equals(uid))
                            .ToListAsync(token);

    public async Task<PaymentEntity> PurchaseAsync(long uid, PaymentRequest model, CancellationToken token = default)
    {
        var entity = new MercadoPagoBrazilianInternalPaymentEntity(uid, model.coins, model.total, _uuidHandler.Generate());

        await _financialRelationalContext.Payments.AddAsync(entity, token);

        return entity;
    }

    public async Task<PaymentEntity> WithdrawAsync(long uid, PaymentRequest model, CancellationToken token = default)
    {
        var entity = new ManualBrazilianPaymentEntity(uid, model.coins, model.total, _uuidHandler.Generate());

        await _financialRelationalContext.Payments.AddAsync(entity, token);

        return entity;
    }

    public async Task<PaymentEntity?> RemoveAsync(long uid, long pid, CancellationToken token = default)
    {
        var entity = await _financialRelationalContext
            .Payments
                .FirstOrDefaultAsync(
                    p =>
                        p.Id.Equals(pid) &&
                        p.AccountId.Equals(uid),
                    token
                );

        if (entity is null)
            return null;

        entity.Remove(_timezoneHandler.RightNow());

        return entity;
    }

    public async Task<string?> StampAsync(long pid, CancellationToken token = default)
    {
        var entity = await _financialRelationalContext
            .Payments
                .AsNoTracking()
                    .Select(p => new { p.Id, p.Stamp })
                        .FirstOrDefaultAsync(p => p.Id.Equals(pid), token);

        if (entity is null)
            return null;

        return entity.Stamp;
    }

    public async Task<bool> IsBuyAvailableAsync(long uid, CancellationToken token = default)
        => await _financialRelationalContext
            .Payments
                .AsNoTracking()
                    .AnyAsync(p =>
                        p.PaymentTypeId.Equals(PaymentTypeEnum.MercadoPago) &&
                        p.AccountId.Equals(uid),
                        token
                    );

    public async Task<bool> IsOwnerAsync(long uid, long pid, CancellationToken token = default)
        => await _financialRelationalContext
            .Payments
                .AsNoTracking()
                    .AnyAsync(p => p.Id.Equals(pid) && p.AccountId.Equals(uid), token);

    public async Task<IList<WithdrawResponse>> ListWithdrawAsync(CancellationToken token = default)
    {
        var results = await _financialRelationalContext
            .Payments
                .AsNoTracking()
                    .Select(p => new {
                        p.Id,
                        p.PaymentTypeId,
                        Output = new WithdrawResponse(p.AccountId, p.Id, p.Coins, p.Total, p.CreatedAt)
                    })
                    .Where(
                        p => p.PaymentTypeId.Equals(PaymentTypeEnum.Manual)
                    )
                    .OrderBy(p => p.Id)
                        .ToListAsync(token);

        return results.Select(w => w.Output).ToList();
    }

    public async Task<bool> PersistFinancialAsync(CancellationToken token = default, int expected = 1)
        => (await _financialRelationalContext.SaveChangesAsync(token) >= expected);
}