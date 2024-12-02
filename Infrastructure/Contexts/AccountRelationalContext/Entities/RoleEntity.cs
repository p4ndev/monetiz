using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public class RoleEntity
    : BaseTypeEntity<RoleEnum>
{    
    public ICollection<AccountEntity>? Accounts { get; private set; }

    public RoleEntity() { }

    public RoleEntity(RoleEnum role)
    {
        Id      = role;
        Name    = role.ToString();
    }
}