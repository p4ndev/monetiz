namespace Monetizacao.Providers.Contexts.Entities;

public sealed class MercadoPagoBrazilianPaymentHistoryEntity(long uid, long epi, long ipi, string status, string statusDetail, DateTime expiresAt)
    : MercadoPagoHistoryEntity(uid, epi, ipi, status, statusDetail, expiresAt)
{
    public void AddProviderInfo(string issuerId, string currencyId, long collectorId)
    {
        IssuerId            = issuerId;
        CurrencyId          = currencyId;
        CollectorId         = collectorId;
    }

    public void AddPaymentInfo(string paymentTypeId, string paymentMethodId, string description)
    {
        PaymentTypeId       = paymentTypeId;
        PaymentMethodId     = paymentMethodId;
        Description         = description;
    }

    public void AddTransactionInfo(string qrCode, string ticketUrl)
    {
        QrCode              = qrCode;
        TicketUrl           = ticketUrl;
    }

    public void AddCommunicationInfo(string? eTag, string? xCallerId)
    {
        if(eTag is not null)
            ETag = eTag;

        if (xCallerId is not null)
            XCallerId = xCallerId;
    }
}