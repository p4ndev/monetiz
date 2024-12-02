using Monetizacao.Providers.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public class TenantEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<TenantEntity>(e =>
        {
            e.ToTable("Tenant");

            e.HasKey(t => t.Id);
            e.Property(t => t.Id).ValueGeneratedOnAdd();

            e.Property(t => t.Name).HasMaxLength(100);
            e.Property(t => t.Logotype).HasColumnType("text");

            e.Property(t => t.Name).IsRequired();

            e.HasMany(t => t.Categories)
                .WithOne(c => c.Tenant)
                    .HasForeignKey(c => c.TenantId)
                    .HasPrincipalKey(t => t.Id)
                        .IsRequired(false);

            e.HasMany(t => t.TenantColors)
                .WithOne(tc => tc.Tenant)
                    .HasForeignKey(tc => tc.TenantId)
                    .HasPrincipalKey(t => t.Id)
                        .IsRequired(false);

            e.HasQueryFilter(t => t.Active);
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<TenantEntity>(e =>
        {
            // 3 # Reality Show
            e.HasData(new {
                Id              = 1L,
                Active          = true,
                Name            = "Reality Show",
                Logotype        = "reality-show_yfa5zd.svg"
            });
        });
}