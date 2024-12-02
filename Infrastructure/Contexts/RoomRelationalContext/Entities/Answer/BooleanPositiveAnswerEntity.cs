using Monetizacao.Providers.Contexts.Constants;
using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class BooleanPositiveAnswerEntity(long uid, long aid)
    : AnswerEntity(uid, aid, ActionAnswerConst.Boolean.Positive, AnswerTypeEnum.Boolean);