using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public class OriginTypeEntity
    : BaseTypeEntity<OriginTypeEnum>
{
    public ICollection<BalanceEntity>? Balances { get; protected set; }

    public OriginTypeEntity(){ }
}