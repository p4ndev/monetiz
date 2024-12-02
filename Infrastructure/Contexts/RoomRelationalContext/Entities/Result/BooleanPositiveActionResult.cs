using Monetizacao.Providers.Contexts.Constants;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class BooleanPositiveActionResult(long uid, long aid, string fact, string stamp)
    : ActionResultEntity(uid, aid, ActionAnswerConst.Boolean.Positive, fact, stamp);