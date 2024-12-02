using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class ManualBrazilianPaymentEntity(long uid, decimal coins, decimal total, string stamp)
    : PaymentEntity(uid, coins, total, CurrencyTypeEnum.BRL, PaymentTypeEnum.Manual, stamp);