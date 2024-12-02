using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class AppAccessAccountClaimEntity(long uid)
    : AccountClaimEntity(uid, ClaimEnum.HasAppAccess);