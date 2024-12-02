using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class ActivityPurchaseEntity(long uid, decimal coins, string leftContent, string stamp)
    : ActivityEntity(uid, ActivityTypeEnum.Buy, "account.profile.buy.headline", "account.profile.buy.summary", ActivityEntity.ParseThousandItems(coins), leftContent, stamp);