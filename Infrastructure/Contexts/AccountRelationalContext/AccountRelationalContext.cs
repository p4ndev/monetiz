using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Maps;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts;

public sealed class AccountRelationalContext : DbContext
{
    public DbSet<AccountEntity>                   Accounts          { get; set; }
    public DbSet<AccountTypeEntity>               AccountTypes      { get; set; }
    
    public DbSet<RoleEntity>                      Role              { get; set; }
    public DbSet<ClaimEntity>                     Claims            { get; set; }
    public DbSet<AccountClaimEntity>              AccountClaims     { get; set; }

    public DbSet<ActivityEntity>                  Activities        { get; set; }
    public DbSet<ActivityTypeEntity>              ActivityTypes     { get; set; }

    public AccountRelationalContext(DbContextOptions<AccountRelationalContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        Schema(builder);

        Seed(builder);

        base.OnModelCreating(builder);
    }

    private void Schema(ModelBuilder builder)
    {
        // Core
        AccountEntityMap.Definition(builder);
        AccountTypeEntityMap.Definition(builder);

        // Privileges
        RoleEntityMap.Definition(builder);
        ClaimEntityMap.Definition(builder);
        AccountClaimEntityMap.Definition(builder);

        // Activity
        ActivityEntityMap.Definition(builder);
        ActivityTypeEntityMap.Definition(builder);
    }

    private void Seed(ModelBuilder builder)
    {
        // Core
        AccountEntityMap.Seed(builder);
        AccountTypeEntityMap.Seed(builder);

        // Privileges
        RoleEntityMap.Seed(builder);
        ClaimEntityMap.Seed(builder);
        AccountClaimEntityMap.Seed(builder);

        // Activity
        ActivityEntityMap.Seed(builder);
        ActivityTypeEntityMap.Seed(builder);
    }
}