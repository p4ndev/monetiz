using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class ActivityPixKeyEntity(long uid, string content, string stamp)
    : ActivityEntity(uid, ActivityTypeEnum.Account, "account.profile.pix.headline", "account.profile.pix.summary", "key", content, stamp);