using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class ManualDeclineBrazilianPaymentHistoryEntity(long uid, long epi, long ipi)
    : MercadoPagoHistoryEntity(uid, epi, ipi, "declined", "cancelled")
{
    public void AddInformation(string ticketUrl, string description)
    {
        QrCode          = "";
        PaymentMethodId = "Manual";
        IssuerId        = "System";
        TicketUrl       = ticketUrl;
        Description     = description;
        CurrencyId      = CurrencyTypeEnum.BRL.ToString();
        PaymentTypeId   = PaymentTypeEnum.MercadoPago.ToString();
    }
}