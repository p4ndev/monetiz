using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public class AccountTypeEntity
    : BaseTypeEntity<AccountTypeEnum>
{
    public ICollection<AccountEntity>? Accounts { get; protected set; }

    public AccountTypeEntity(){ }
}