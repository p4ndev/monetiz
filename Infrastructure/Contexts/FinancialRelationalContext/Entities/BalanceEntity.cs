using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public class BalanceEntity
    : BaseReadOnlyTrackableEntity
{
    public long                                             AccountId               { get; protected set; }
    public long                                             EntityId                { get; protected set; }
    public OriginTypeEnum                                   OriginTypeId            { get; protected set; }
    public OperationTypeEnum                                OperationTypeId         { get; protected set; }
    public decimal                                          Amount                  { get; protected set; }
    public string                                           Stamp                   { get; protected set; } = null!;

    public OriginTypeEntity?                                OriginType              { get; protected set; }
    public OperationTypeEntity?                             OperationType           { get; protected set; }

    public BalanceEntity(){}

    protected BalanceEntity(long uid, long eid, decimal amount, OperationTypeEnum opt, OriginTypeEnum ogt, string stamp)
        : base()
    {
        AccountId           = uid;
        EntityId            = eid;
        Amount              = amount;
        OperationTypeId     = opt;
        OriginTypeId        = ogt;
        Stamp               = stamp;
    }
}