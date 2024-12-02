using Monetizacao.Providers.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public class GameEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<GameEntity>(e =>
        {
            e.ToTable("Game");

            e.HasKey(g => g.Id);
            e.Property(g => g.Id).ValueGeneratedOnAdd();

            e.Property(g => g.Name).HasMaxLength(150);

            e.Property(g => g.Name).IsRequired();
            e.Property(g => g.StartsAt).IsRequired();
            e.Property(g => g.TenantId).IsRequired();
            e.Property(g => g.CategoryId).IsRequired();
            e.Property(g => g.FirstGroupId).IsRequired();
            
            e.HasQueryFilter(g => g.Active);
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<GameEntity>(e =>
        {
            e.HasData(new
            {
                Id = 1L,
                Name = "Semana 4",
                Active = true,
                TenantId = 1L,
                CategoryId = 1L,
                FirstGroupId = 1L,
                StartsAt = new DateTime(2024, 10, 6),
                EndsAt = new DateTime(2024, 10, 12)
            });
        });
}