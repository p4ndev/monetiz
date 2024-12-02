using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class BalanceActionIngressEntity(long uid, long aid, decimal coins, string stamp)
    : BalanceEntity(uid, aid, coins, OperationTypeEnum.In, OriginTypeEnum.Action, stamp);