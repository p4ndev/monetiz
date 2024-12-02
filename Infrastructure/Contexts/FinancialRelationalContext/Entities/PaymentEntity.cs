using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public class PaymentEntity
    : BaseTrackableEntity
{
    public long                                             AccountId               { get; protected set; }    
    public PaymentTypeEnum                                  PaymentTypeId           { get; protected set; }
    public CurrencyTypeEnum                                 CurrencyTypeId          { get; protected set; }
    public decimal                                          Coins                   { get; protected set; }
    public decimal                                          Total                   { get; protected set; }
    public bool                                             Active                  { get; protected set; }
    public string?                                          Stamp                   { get; protected set; } = null!;

    public PaymentTypeEntity?                               PaymentType             { get; protected set; }
    public CurrencyTypeEntity?                              CurrencyType            { get; protected set; }
    public ICollection<MercadoPagoHistoryEntity>?           MercadoPagoHistories    { get; protected set; }

    public PaymentEntity() { }

    protected PaymentEntity(long uid, decimal amount, decimal total, CurrencyTypeEnum currencyType, PaymentTypeEnum paymentType, string stamp)
        : base()
    {
        AccountId           = uid;
        Coins               = amount;
        Total               = total;
        CurrencyTypeId      = currencyType;
        PaymentTypeId       = paymentType;
        Active              = true;
        Stamp               = stamp;
    }

    public void Remove(DateTime modifiedAt)
    {
        Active              = false;        
        ModifiedAt          = modifiedAt;
    }
}