using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class BalancePaymentEgressEntity(long uid, long pid, decimal amount, string stamp)
    : BalanceEntity(uid, pid, amount, OperationTypeEnum.Out, OriginTypeEnum.Payment, stamp);