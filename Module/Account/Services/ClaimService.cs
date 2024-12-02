using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Modules.Account.Responses;
using Monetizacao.Providers.Contexts.Enums;
using Monetizacao.Providers.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Monetizacao.Modules.Account.Services;

public class ClaimService
(
    AccountRelationalContext _accountRelationalContext
)
{
    public async Task<IEnumerable<ClaimEntity>> ListAsync(long uid, CancellationToken token = default)
    {
        var claimIds = await _accountRelationalContext
            .AccountClaims
                .AsNoTracking()
                    .Where(ac => ac.AccountId.Equals(uid))
                        .Select(ac => ac.ClaimId)
                            .ToListAsync(token);

        if (!claimIds.Any())
            return Enumerable.Empty<ClaimEntity>();

        return claimIds.Select(ci => new ClaimEntity(ci));
    }

    public async Task<bool> ExistsAsync(long uid, ClaimEnum claim, CancellationToken token = default)
        => await _accountRelationalContext
            .AccountClaims
                .AsNoTracking()
                    .AnyAsync(
                        ac => ac.AccountId.Equals(uid) &&
                              ac.ClaimId.Equals(claim),
                        token
                    );

    public async Task<AccountClaimEntity?> AddPixAsync(long uid, CancellationToken token = default)
    {
        if (await ExistsAsync(uid, ClaimEnum.HasPixKey, token))
            return null;

        var entity = new PixAccountClaimEntity(uid);

        await _accountRelationalContext.AccountClaims.AddAsync(entity, token);

        return entity;
    }

    public async Task<AccountClaimEntity?> AddConfirmedEmailAsync(long uid, CancellationToken token = default)
    {
        if (await ExistsAsync(uid, ClaimEnum.HasEmailConfirmed, token))
            return null;

        var entity = new ActivationAccountClaimEntity(uid);

        await _accountRelationalContext.AccountClaims.AddAsync(entity, token);

        return entity;
    }

    public async Task<AccountClaimEntity?> AddApiAccessAsync(long uid, CancellationToken token = default)
    {
        if (await ExistsAsync(uid, ClaimEnum.HasApiAccess, token))
            return null;

        var entity = new ApiAccessAccountClaimEntity(uid);

        await _accountRelationalContext.AccountClaims.AddAsync(entity, token);

        return entity;
    }

    public async Task<AccountClaimEntity?> AddAppAccessAsync(long uid, CancellationToken token = default)
    {
        if (await ExistsAsync(uid, ClaimEnum.HasAppAccess, token))
            return null;

        var entity = new AppAccessAccountClaimEntity(uid);

        await _accountRelationalContext.AccountClaims.AddAsync(entity, token);

        return entity;
    }

    public ClaimsIdentity Attach(AccountResponse account)
    {
        var claimManager = new ClaimsIdentity();

        claimManager.AddClaim(new Claim(ClaimTypes.Role, account.role.Value.ToString()));
        claimManager.AddClaim(new Claim(ClaimTypes.Name, account.basicAccount.fullName));
        claimManager.AddClaim(new Claim(ClaimTypes.Email, account.basicAccount.email));
        claimManager.AddClaim(new Claim(ClaimTypes.NameIdentifier, account.basicAccount.id.ToString()));

        if (account is not null && account.claims is not null)
            foreach (var c in account.claims)
                claimManager.AddClaim(new Claim("claims", c.Value.ToString()));

        return claimManager;
    }
}