using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class ActivityRegistrationEntity(long uid, string stamp)
    : ActivityEntity(uid, ActivityTypeEnum.Account, "account.profile.account.headline", "account.profile.account.summary", "mark-email-read", stamp);