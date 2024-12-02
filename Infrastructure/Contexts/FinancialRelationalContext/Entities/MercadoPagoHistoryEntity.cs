namespace Monetizacao.Providers.Contexts.Entities;

public class MercadoPagoHistoryEntity
    : BaseReadOnlyTrackableEntity
{
    public long                                             PayerId                 { get; protected set; }
    public long                                             TransactionId           { get; protected set; }
    public long                                             PaymentId               { get; protected set; }
    public string                                           IssuerId                { get; protected set; } = null!;
    public string                                           CurrencyId              { get; protected set; } = null!;
    public long                                             CollectorId             { get; protected set; }
    public string                                           PaymentTypeId           { get; protected set; } = null!;
    public string                                           PaymentMethodId         { get; protected set; } = null!;
    public string?                                          XCallerId               { get; protected set; }
    public string                                           Status                  { get; protected set; } = null!;
    public string                                           StatusDetail            { get; protected set; } = null!;
    public string                                           QrCode                  { get; protected set; } = null!;
    public string                                           TicketUrl               { get; protected set; } = null!;
    public string                                           Description             { get; protected set; } = null!;
    public string?                                          ETag                    { get; protected set; }
    public DateTime?                                        ExpiresAt               { get; protected set; }

    public PaymentEntity?                                   Payment                 { get; protected set; }

    public MercadoPagoHistoryEntity() { }

    protected MercadoPagoHistoryEntity(long uid, long epi, long ipi, string status, string statusDetail, DateTime? expiresAt = null)
        : base()
    {
        PayerId             = uid;
        TransactionId       = epi;
        PaymentId           = ipi;
        Status              = status;
        StatusDetail        = statusDetail;
        ExpiresAt           = expiresAt;
    }
}