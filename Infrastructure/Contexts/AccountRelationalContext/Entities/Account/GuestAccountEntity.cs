using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public sealed class GuestAccountEntity
    : AccountEntity
{
    public GuestAccountEntity(string email, string password, string fullName)
        : base(email, password)
    {
        FullName = fullName;
        RoleId = RoleEnum.Guest;
    }
}