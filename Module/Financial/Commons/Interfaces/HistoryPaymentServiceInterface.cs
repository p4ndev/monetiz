using Monetizacao.Modules.Financial.Responses;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Modules.Financial.Interfaces;

public interface HistoryPaymentServiceInterface<T>
{
    Task<MercadoPagoHistoryEntity>  AddAsync(long paymentId, T model, CancellationToken token = default);
    Task<bool>                      IsExpiredAsync(long userId, long paymentId, long transactionId, CancellationToken token = default);
    Task<HistoryPaymentResponse?>   FindAsync(long paymentId, CancellationToken token = default, long? transactionId = null);
    Task                            DeclineBrazilianManualPaymentAsync(long uid, long ipi, long epi, string receipt, string reason, CancellationToken token = default);
    Task                            AcceptBrazilianManualPaymentAsync(long uid, long ipi, long epi, string receipt, string reason, CancellationToken token = default);
    Task<bool>                      PersistFinancialAsync(CancellationToken token = default, int expected = 1);
}