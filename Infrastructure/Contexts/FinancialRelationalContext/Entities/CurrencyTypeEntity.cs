using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public class CurrencyTypeEntity
    : BaseTypeEntity<CurrencyTypeEnum>
{
    public ICollection<PaymentEntity>? Payments { get; protected set; }

    public CurrencyTypeEntity() { }
}