using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class ApiAccessAccountClaimEntity(long uid)
    : AccountClaimEntity(uid, ClaimEnum.HasApiAccess);