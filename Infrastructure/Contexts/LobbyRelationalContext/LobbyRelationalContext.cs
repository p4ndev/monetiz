using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Maps;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts;

public sealed class LobbyRelationalContext : DbContext
{
    public DbSet<TenantEntity>                    Tenants           { get; set; }
    public DbSet<TenantColorEntity>               TenantColors      { get; set; }
    public DbSet<CategoryEntity>                  Categories        { get; set; }
    
    public DbSet<GroupEntity>                     Groups            { get; set; }
    public DbSet<PlayerEntity>                    Players           { get; set; }

    public DbSet<GroupPlayerEntity>               GroupPlayers      { get; set; }

    public LobbyRelationalContext(DbContextOptions<LobbyRelationalContext> options)
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
        TenantEntityMap.Definition(builder);
        CategoryEntityMap.Definition(builder);
        TenantColorEntityMap.Definition(builder);

        // Raw
        GroupEntityMap.Definition(builder);
        PlayerEntityMap.Definition(builder);

        // Possibilities
        GroupPlayerEntityMap.Definition(builder);
    }

    private void Seed(ModelBuilder builder)
    {
        // Core
        TenantEntityMap.Seed(builder);
        CategoryEntityMap.Seed(builder);
        TenantColorEntityMap.Seed(builder);

        // Raw
        GroupEntityMap.Seed(builder);
        PlayerEntityMap.Seed(builder);

        // Possibilities
        GroupPlayerEntityMap.Seed(builder);
    }
}
