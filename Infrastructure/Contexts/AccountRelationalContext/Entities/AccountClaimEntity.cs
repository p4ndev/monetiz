using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public class AccountClaimEntity
    : BaseEntity<long>
{
    public long                     AccountId       { get; private set; }
    public ClaimEnum                ClaimId         { get; private set; }

    public AccountEntity?           Account         { get; private set; }
    public ClaimEntity?             Claim           { get; private set; }

    public AccountClaimEntity() { }

    protected AccountClaimEntity(long uid, ClaimEnum claim)
    {
        AccountId   = uid;
        ClaimId     = claim;
    }

    public AccountClaimEntity(long id, long uid, ClaimEnum claim)
        : this(uid, claim)
    {
        Id          = id;
    }
}