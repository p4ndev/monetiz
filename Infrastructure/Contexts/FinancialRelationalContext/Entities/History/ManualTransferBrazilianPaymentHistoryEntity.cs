using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class ManualTransferBrazilianPaymentHistoryEntity(long uid, long epi, long ipi)
    : MercadoPagoHistoryEntity(uid, epi, ipi, "approved", "accredited")
{
    public void AddInformation(string ticketUrl, string description)
    {
        QrCode          = "";
        PaymentMethodId = "Pix";
        IssuerId        = "System";
        TicketUrl       = ticketUrl;
        Description     = description;
        CurrencyId      = CurrencyTypeEnum.BRL.ToString();
        PaymentTypeId   = PaymentTypeEnum.MercadoPago.ToString();
    }
}