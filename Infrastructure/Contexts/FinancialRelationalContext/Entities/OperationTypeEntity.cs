using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public class OperationTypeEntity
    : BaseTypeEntity<OperationTypeEnum>
{
    public ICollection<BalanceEntity>? Balances { get; protected set; }

    public OperationTypeEntity(){ }
}