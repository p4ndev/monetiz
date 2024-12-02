using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public class PaymentTypeEntity
    : BaseTypeEntity<PaymentTypeEnum>
{
    public ICollection<PaymentEntity>? Payments { get; protected set; }

    public PaymentTypeEntity(){ }
}