using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class PixAccountClaimEntity(long uid)
    : AccountClaimEntity(uid, ClaimEnum.HasPixKey);