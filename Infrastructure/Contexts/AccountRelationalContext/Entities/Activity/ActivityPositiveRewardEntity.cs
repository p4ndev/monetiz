using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class ActivityPositiveRewardEntity(long uid, string game, string action, decimal coins, string stamp)
    : ActivityEntity(uid, ActivityTypeEnum.Game, game, action, ActivityEntity.ParseThousandItems(coins), "global.yes", "global.yes", stamp);