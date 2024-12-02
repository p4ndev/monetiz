using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public class AccountEntity
    : BaseTrackableEntity
{
    public string                                           Email                   { get; protected set; } = null!;
    public string                                           Password                { get; protected set; } = null!;

    public string                                           FullName                { get; protected set; } = null!;
    public string                                           PasswordStamp           { get; protected set; } = null!;
    public string                                           ActivationStamp         { get; protected set; } = null!;

    public bool                                             Active                  { get; protected set; }

    public AccountTypeEntity?                               AccountType             { get; protected set; }
    public AccountTypeEnum                                  AccountTypeId           { get; protected set; }

    public RoleEntity?                                      Role                    { get; protected set; }
    public RoleEnum                                         RoleId                  { get; protected set; }

    public ICollection<ActivityEntity>?                     Activities              { get; protected set; }
    public ICollection<AccountClaimEntity>?                 AccountClaims           { get; protected set; }

    public AccountEntity() { }

    protected AccountEntity(string email, string password)
    {
        Active              = true;
        Password            = password;
        Email               = email.ToLower();
        AccountTypeId       = AccountTypeEnum.Regular;
    }

    public void AddPasswordStamp(string data)
        => PasswordStamp = data;

    public void AddActivationStamp(string data)
        => ActivationStamp = data;

    public void AddModifiedAt(DateTime data)
        => ModifiedAt = data;

    public void AddSecurePassword(string data)
        => Password = data;

    public void AddMemberRole()
        => RoleId = RoleEnum.Member;

    public void AddGuestRole()
        => RoleId = RoleEnum.Guest;
}