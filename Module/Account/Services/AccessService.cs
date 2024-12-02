using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Modules.Account.Responses;
using Monetizacao.Providers.Contexts.Enums;
using Monetizacao.Modules.Account.Requests;
using Monetizacao.Providers.Contexts.Dtos;
using Monetizacao.Providers.Contexts;
using Monetizacao.Providers.Handlers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Monetizacao.Modules.Account.Services;

public sealed class AccessService
{
    private readonly UUIDHandler                _uuidHandler;
    private readonly TimezoneHandler            _timezoneHandler;
    private readonly Md5CryptoHandler           _md5CryptoHandler;
    private readonly ValidationHandler          _validationHandler;
    private readonly JwtCryptoHandler           _jwtCryptoHandler = null!;

    private AccountEntity?                      _accountEntity;
    private readonly AccountRelationalContext   _accountRelationalContext;
    private readonly AccountEmailContext        _accountEmailContext = null!;

    public AccessService(ValidationHandler val, Md5CryptoHandler md5, UUIDHandler uuid, TimezoneHandler tmz, AccountRelationalContext ctx0)
    {
        _validationHandler          = val;
        _md5CryptoHandler           = md5;
        _uuidHandler                = uuid;
        _timezoneHandler            = tmz;
        _accountRelationalContext   = ctx0;
        _accountEntity              = null;
    }

    public AccessService(ValidationHandler val, Md5CryptoHandler md5, UUIDHandler uuid, TimezoneHandler tmz, JwtCryptoHandler jwt, AccountRelationalContext ctx0, AccountEmailContext ctx1)
        : this(val, md5, uuid, tmz, ctx0)
    {
        _jwtCryptoHandler           = jwt;
        _accountEmailContext        = ctx1;
    }

    public async Task<BasicAccountResponse?> FindAsync(string email, string password, CancellationToken token = default)
        => await _accountRelationalContext
            .Accounts
                .AsNoTracking()
                    .Where(a => a.Email.Equals(email.ToLower()) && a.Password.Equals(password))
                        .Select(a => new BasicAccountResponse(a.Id, a.FullName, a.Email, a.Password, a.Active, a.RoleId))
                            .FirstOrDefaultAsync(token);

    public async Task<BasicAccountResponse?> FindAsync(string email, CancellationToken token = default)
        => await _accountRelationalContext
                .Accounts
                    .AsNoTracking()
                        .Where(a => a.Email.Contains(email))
                            .Select(a => new BasicAccountResponse(a.Id, a.FullName, a.Email, a.Password, a.Active, a.RoleId))
                                .FirstOrDefaultAsync(token);

    public async Task<BasicAccountResponse?> FindAsync(long uid, CancellationToken token = default)
        => await _accountRelationalContext
            .Accounts
                .AsNoTracking()
                    .Where(a => a.Id.Equals(uid))
                        .Select(a => new BasicAccountResponse(a.Id, a.FullName, a.Email, a.Password, a.Active, a.RoleId))
                            .FirstOrDefaultAsync(token);

    public async Task<bool> ExistsAsync(string email, CancellationToken token = default)
        => await _accountRelationalContext
                .Accounts
                    .AsNoTracking()
                        .AnyAsync(a => a.Email.ToLower().Equals(email.ToLower()), token);

    public AccountResponse AccountToResponse(BasicAccountResponse data, RoleEntity role, IEnumerable<ClaimEntity> claims)
        => new AccountResponse(
            data,
            new KeyValuePair<RoleEnum, string>(role.Id, role.Name),
            claims.Select(c => new KeyValuePair<ClaimEnum, string>(c.Id, c.Name))
        );

    public SignInResponse GenerateToken(ClaimsIdentity accountTokenClaims, string? fullName = null)
    {
        var expiresIn = _jwtCryptoHandler.Initialize(accountTokenClaims);
        
        var userToken = _jwtCryptoHandler.Build();

        return new SignInResponse(expiresIn, fullName, userToken);
    }

    public async Task<AccountEntity> AddGuestAsync(AccountRequest request, CancellationToken token = default)
    {
        var entity = new GuestAccountEntity(request.email, EncryptPassword(request.password), request.fullName ?? string.Empty);

        var passwordStamp   = _uuidHandler.Generate();
        var activationStamp = _uuidHandler.Generate();

        entity.AddPasswordStamp(passwordStamp);
        entity.AddActivationStamp(activationStamp);

        await _accountRelationalContext.Accounts.AddAsync(entity, token);

        return entity;
    }

    public void NotifyAfterRegister(long uid, string email, string stamp)
        => _accountEmailContext.Registration(new AccountEmailDto(uid, email, stamp));

    public void NotifyAfterPurchase(long uid, string email, string trackId, decimal coins, decimal total, DateTime createdAt, CancellationToken token = default)
        => _accountEmailContext.Purchase(new FinancialEmailDto(uid, email, trackId, coins, total, createdAt));

    public async Task<bool> ActivateUserAsync(long uid, string stamp, CancellationToken token = default)
    {
        _accountEntity = await 
            _accountRelationalContext
                .Accounts
                    .FirstOrDefaultAsync(u => 
                        u.Id.Equals(uid) && 
                        u.ActivationStamp.Equals(stamp),
                        token
                    );
        
        if (_accountEntity == null)
            return false;

        var date     = _timezoneHandler.RightNow();
        var newStamp = _uuidHandler.Generate();
        
        _accountEntity.AddActivationStamp(newStamp);
        _accountEntity.AddModifiedAt(date);
        _accountEntity.AddMemberRole();

        return true;
    }

    public string EncryptPassword(string password) => _md5CryptoHandler.Parse(password);

    public string ActivationStamp() => (_accountEntity is not null ? _accountEntity!.ActivationStamp : "");

    public bool IsModelValid(long? aid, long uid, string? stamp)
    {
        if (!_validationHandler.IsIdValid(aid) || !aid.Equals(uid) || !_validationHandler.IsStampValid(stamp))
            return false;

        return true;
    }

    public bool IsModelValid(AccountRequest model)
    {
        if (!_validationHandler.IsEmailValid(model.email))
            return false;

        if (!_validationHandler.IsPasswordValid(model.password))
            return false;

        return true;
    }

    public async Task<bool> PersistRelationalAccountAsync(CancellationToken token = default, int expected = 1)
        => (await _accountRelationalContext.SaveChangesAsync(token) >= expected);

    public async Task<bool> PersistEmailAccountAsync(CancellationToken token = default)
        => await _accountEmailContext.SendAsync(token);
}