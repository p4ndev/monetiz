using Monetizacao.Providers.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public class CategoryEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<CategoryEntity>(e =>
        {
            e.ToTable("Category");

            e.HasKey(c => c.Id);
            e.Property(c => c.Id).ValueGeneratedOnAdd();
            
            e.Property(c => c.Name).HasMaxLength(100);
            e.Property(c => c.Summary).HasMaxLength(255);
            e.Property(c => c.Logotype).HasColumnType("text");
            e.Property(c => c.EndsAt).HasColumnType("datetime(6)");
            e.Property(c => c.StartsAt).HasColumnType("datetime(6)");

            e.Property(c => c.Name).IsRequired();
            e.Property(c => c.Summary).IsRequired();
            e.Property(c => c.StartsAt).IsRequired();

            e.HasQueryFilter(c => c.Active);
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<CategoryEntity>(e =>
        {
            // A Fazenda
            e.HasData(new {
                Id              = 1L,
                TenantId        = 1L,
                Active          = true,
                Name            = "A Fazenda",
                Summary         = "Edição 16 | Record | 2024",
                Logotype        = "a-fazenda-10_bv5zic.jpg",
                StartsAt        = new DateTime(2024, 9, 16),
                EndsAt          = new DateTime(2024, 12, 16)
            });
        });
}