using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class BalanceActionEgressEntity(long uid, long aid, string stamp)
    : BalanceEntity(uid, aid, 1, OperationTypeEnum.Out, OriginTypeEnum.Action, stamp);