using Monetizacao.Modules.Financial.Responses;
using Monetizacao.Modules.Financial.Requests;
using Monetizacao.Providers.Contexts;
using Monetizacao.Providers.Handlers;

namespace Monetizacao.Modules.Financial.Services;

public class CheckoutService
(
    UUIDHandler                     _uuidHandler,
    ValidationHandler               _validationHandler,
    FinancialRelationalContext      _financialRelationalContext
)
{
    public string GenerateIdempotencyKey()
        => _uuidHandler.Generate();

    public CheckoutResponse? ToResponse(InternalPaymentResponse internalModel, HistoryPaymentResponse historyModel)
        => new CheckoutResponse(
            internalModel.id,
            internalModel.coins,
            internalModel.total,

            historyModel.id,
            historyModel.qrCode,
            historyModel.status,
            historyModel.ticketUrl,
            historyModel.createdAt,
            historyModel.expiresAt
        );

    public bool IsModelValid(long? id)
    {
        if (!_validationHandler.IsIdValid(id))
            return false;

        return true;
    }

    public bool IsModelValid(long uid, long? ipi)
    {
        if (!IsModelValid(uid) ||
                !IsModelValid(ipi))
            return false;

        return true;
    }

    public bool IsModelValid(long uid, long? ipi, long? epi)
    {
        if (!IsModelValid(uid) ||
                !IsModelValid(ipi) ||
                    !IsModelValid(epi))
            return false;

        return true;
    }

    public bool IsBuyModelValid(long uid, PaymentRequest model)
    {
        if (!IsModelValid(uid))
            return false;

        decimal purchaseTotal = (model.coins * _financialRelationalContext.BuyPrice);

        return purchaseTotal.Equals(model.total);
    }

    public bool IsSellModelValid(long uid, PaymentRequest model)
    {
        if (!IsModelValid(uid))
            return false;

        decimal purchaseTotal = (model.coins * _financialRelationalContext.SellPrice);

        return purchaseTotal.Equals(model.total);
    }

    public async Task<bool> PersistFinancialAsync(CancellationToken token = default, int expected = 1)
        => (await _financialRelationalContext.SaveChangesAsync(token) >= expected);
}