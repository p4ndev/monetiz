using Monetizacao.Providers.Contexts.Constants;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class BooleanNegativeActionResult(long uid, long aid, string fact, string stamp)
    : ActionResultEntity(uid, aid, ActionAnswerConst.Boolean.Negative, fact, stamp);