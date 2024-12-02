using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class ActivationAccountClaimEntity(long uid)
    : AccountClaimEntity(uid, ClaimEnum.HasEmailConfirmed);