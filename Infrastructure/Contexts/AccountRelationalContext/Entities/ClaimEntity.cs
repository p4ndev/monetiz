using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public class ClaimEntity
    : BaseTypeEntity<ClaimEnum>
{
    public ICollection<AccountClaimEntity>? AccountClaims { get; private set; }

    public ClaimEntity() { }

    public ClaimEntity(ClaimEnum claim)
    {
        Id      = claim;
        Name    = claim.ToString();
    }
}