using Monetizacao.Modules.Financial.Requests;

namespace Monetizacao.Modules.Financial.Interfaces;

public interface ExternalPaymentServiceInterface<T>
{
    string ExternalReference(long uid);
    bool IsSuccessful(T model);
    DateTime ExpirationTransationDate();

    Task<T?> AddAsync(long uid, CancellationToken token = default);
    Task<T?> RemoveAsync(long transactionId, CancellationToken token = default);
    Task<T?> FindAsync(long transactionId, CancellationToken token = default);

    void AddProductInfo(PaymentRequest request);
    void AddPaymentInfo(long ipi, string idempotencyKey);
    void AddAccountInfo((string first, string last) userNames, string email);
}