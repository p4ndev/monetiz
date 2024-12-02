using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Modules.Account.Requests;
using Monetizacao.Providers.Contexts.Dtos;
using Monetizacao.Providers.Contexts;
using Monetizacao.Providers.Handlers;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Modules.Account.Services;

public sealed class RecoveryService
(
    ValidationHandler           _validationHandler,
    Md5CryptoHandler            _md5CryptoHandler,
    TimezoneHandler             _timezoneHandler,
    UUIDHandler                 _uuidHandler,
    AccountRelationalContext    _accountRelationalContext,
    AccountEmailContext         _accountEmailContext
)
{
    public async Task<bool> SendEmailAsync(string email, CancellationToken token = default)
    {
        var account = await _accountRelationalContext
            .Accounts
                .AsNoTracking()
                    .Select(a => new { a.Id, a.Email, a.PasswordStamp })
                        .FirstOrDefaultAsync(a => a.Email.Equals(email.ToLower()), token);

        if (account == null)
            return false;

        _accountEmailContext.Recovery(new AccountEmailDto(account.Id, account.Email, account.PasswordStamp));

        return true;
    }

    public async Task<AccountEntity?> EditAsync(RecoveryRequest model, CancellationToken token = default)
    {
        var entity = await _accountRelationalContext
            .Accounts
                .FirstOrDefaultAsync(a =>
                    a.Id.Equals(model.id) &&
                    a.Email.Equals(model.email.ToLower()) &&
                    a.PasswordStamp.Equals(model.stamp.ToLower()),
                    token
                );

        if (entity == null)
            return null;

        var date = _timezoneHandler.RightNow();
        entity.AddModifiedAt(date);

        var stamp = _uuidHandler.Generate();
        entity.AddPasswordStamp(stamp);

        var pwd = _md5CryptoHandler.Parse(model.password);
        entity.AddSecurePassword(pwd);

        return entity;
    }

    public bool IsModelValid(string email)
    {
        if (!_validationHandler.IsEmailValid(email))
            return false;

        return true;
    }

    public bool IsModelValid(RecoveryRequest model)
    {
        if (!_validationHandler.IsIdValid(model.id))
            return false;

        if (!_validationHandler.IsEmailValid(model.email))
            return false;

        if (!_validationHandler.IsPasswordValid(model.password))
            return false;

        if (!_validationHandler.IsStampValid(model.stamp))
            return false;

        return true;
    }

    public async Task<bool> PersistRelationalAccountAsync(CancellationToken token = default, int expected = 1)
        => (await _accountRelationalContext.SaveChangesAsync(token) >= expected);

    public async Task<bool> PersistEmailAccountAsync(CancellationToken token = default)
        => (await _accountEmailContext.SendEmailAsync(token));
}