using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class ActivityWithdrawEntity(long uid, decimal coins, string leftContent, string stamp)
    : ActivityEntity(uid, ActivityTypeEnum.Withdraw, "account.profile.withdraw.headline", "account.profile.withdraw.summary", ActivityEntity.ParseThousandItems(coins, false), leftContent, stamp);