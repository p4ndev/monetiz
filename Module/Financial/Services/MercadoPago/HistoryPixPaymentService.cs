using Monetizacao.Modules.Financial.Interfaces;
using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Modules.Financial.Responses;
using Monetizacao.Providers.Contexts;
using Monetizacao.Providers.Handlers;
using Microsoft.EntityFrameworkCore;
using MercadoPago.Resource.Payment;

namespace Monetizacao.Modules.Financial.Services;

public sealed class HistoryPixPaymentService
(
    TimezoneHandler                 _timezoneHandler,
    FinancialRelationalContext      _financialRelationalContext
) : HistoryPaymentServiceInterface<Payment>
{
    public async Task<HistoryPaymentResponse?> FindAsync(long pid, CancellationToken token = default, long? tid = null)
    {
        var entity = await _financialRelationalContext
            .MercadoPagoHistories
                .AsNoTracking()
                    .Where(mph =>
                        mph.PaymentId.Equals(pid) &&
                        (tid.HasValue ? mph.TransactionId.Equals(tid) : true)
                    )
                    .OrderBy(mph => mph.Id)
                    .Select(mph => 
                        new HistoryPaymentResponse(
                            mph.TransactionId,
                            mph.QrCode,
                            mph.Status,
                            mph.TicketUrl,
                            mph.CreatedAt,
                            mph.ExpiresAt
                        )
                    )
                    .LastOrDefaultAsync(token);

        return entity;            
    }

    public async Task<MercadoPagoHistoryEntity> AddAsync(long ipi, Payment model, CancellationToken token = default)
    {
        var uid = Convert.ToInt64(model.Payer.Id);
        var epi = Convert.ToInt64(model.Id);

        var entity = new MercadoPagoBrazilianPaymentHistoryEntity
        (
            uid,
            epi,
            ipi,

            model.Status,
            model.StatusDetail,

            model.DateOfExpiration is null ? new DateTime() : model.DateOfExpiration!.Value
        );

        entity.AddProviderInfo(model.IssuerId, model.CurrencyId, (model.CollectorId is null ? 0L : model.CollectorId!.Value));

        entity.AddPaymentInfo(model.PaymentTypeId, model.PaymentMethodId, model.Description);

        entity.AddTransactionInfo(model.PointOfInteraction.TransactionData.QrCode, model.PointOfInteraction.TransactionData.TicketUrl);

        string? eTag, xCaller;

        model.ApiResponse.Headers.TryGetValue("ETag", out eTag);
        model.ApiResponse.Headers.TryGetValue("x-caller-id", out xCaller);

        entity.AddCommunicationInfo(eTag, xCaller);

        await _financialRelationalContext.MercadoPagoHistories.AddAsync(entity, token);

        return entity;
    }

    public async Task<bool> IsExpiredAsync(long uid, long pid, long tid, CancellationToken token = default)
        => await _financialRelationalContext
            .MercadoPagoHistories
                .AsNoTracking()
                    .AnyAsync(mph =>
                        mph.PayerId.Equals(uid) &&
                        mph.PaymentId.Equals(pid) &&
                        mph.TransactionId.Equals(tid) &&
                        mph.ExpiresAt >= _timezoneHandler.RightNow(),
                        token
                    );

    public async Task DeclineBrazilianManualPaymentAsync(long uid, long ipi, long epi, string receipt, string reason, CancellationToken token = default)
    {
        var entity = new ManualDeclineBrazilianPaymentHistoryEntity(uid, epi, ipi);

        entity.AddInformation(receipt, reason);

        await _financialRelationalContext.MercadoPagoHistories.AddAsync(entity, token);
    }

    public async Task AcceptBrazilianManualPaymentAsync(long uid, long ipi, long epi, string receipt, string information, CancellationToken token = default)
    {
        var entity = new ManualTransferBrazilianPaymentHistoryEntity(uid, epi, ipi);

        entity.AddInformation(receipt, information);

        await _financialRelationalContext.MercadoPagoHistories.AddAsync(entity, token);
    }

    public async Task<bool> PersistFinancialAsync(CancellationToken token = default, int expected = 1)
        => (await _financialRelationalContext.SaveChangesAsync(token) >= expected);
}