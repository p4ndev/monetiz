using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class MercadoPagoBrazilianInternalPaymentEntity(long uid, decimal coins, decimal total, string stamp)
    : PaymentEntity(uid, coins, total, CurrencyTypeEnum.BRL, PaymentTypeEnum.MercadoPago, stamp);