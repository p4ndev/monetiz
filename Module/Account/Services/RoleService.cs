using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Enums;
using Monetizacao.Providers.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Modules.Account.Services;

public class RoleService
(
    AccountRelationalContext _accountRelationalContext
)
{
    public RoleEntity? Find(RoleEnum role)
    {
        if (role.Equals(RoleEnum.None))
            return null;

        return new RoleEntity(role);
    }

    public async Task<IEnumerable<RoleEntity>> ListAsync(long uid, CancellationToken token = default)
        => await _accountRelationalContext
            .Accounts
            .Include(r => r.Role)
                .AsNoTracking()
                    .Where(a => a.Id.Equals(uid))
                    .Select(a => a.Role!)
                        .ToListAsync(token);
}