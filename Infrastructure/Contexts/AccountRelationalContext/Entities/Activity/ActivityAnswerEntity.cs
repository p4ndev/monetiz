using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class ActivityAnswerEntity(long uid, string game, string action, string leftContent, string stamp)
    : ActivityEntity(uid, ActivityTypeEnum.Game, game, action, "- 1", leftContent, stamp);