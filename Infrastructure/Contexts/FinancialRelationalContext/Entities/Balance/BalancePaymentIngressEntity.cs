using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class BalancePaymentIngressEntity(long uid, long pid, decimal amount, string stamp)
    : BalanceEntity(uid, pid, amount, OperationTypeEnum.In, OriginTypeEnum.Payment, stamp);