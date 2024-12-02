using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Modules.Financial.Responses;
using Monetizacao.Modules.Financial.Requests;

namespace Monetizacao.Modules.Financial.Interfaces;

public interface InternalPaymentServiceInterface
{
    Task<IList<WithdrawResponse>>       ListWithdrawAsync(CancellationToken token = default);
    Task<InternalPaymentResponse?>      FindAsync(long userId, CancellationToken token = default);
    Task<IEnumerable<PaymentEntity>>    FindPurchasesAsync(long uid, CancellationToken token = default);
    Task<IEnumerable<PaymentEntity>>    FindWithdrawsAsync(long uid, CancellationToken token = default);
    Task<PaymentEntity?>                RemoveAsync(long userId, long paymentId, CancellationToken token = default);
    Task<bool>                          IsOwnerAsync(long userId, long paymentId, CancellationToken token = default);
    Task<bool>                          IsBuyAvailableAsync(long userId, CancellationToken token = default);
    Task<PaymentEntity>                 PurchaseAsync(long userId, PaymentRequest model, CancellationToken token = default);
    Task<PaymentEntity>                 WithdrawAsync(long userId, PaymentRequest model, CancellationToken token = default);
    Task<bool>                          PersistFinancialAsync(CancellationToken token = default, int expected = 1);
    Task<string?>                       StampAsync(long pid, CancellationToken token = default);
}