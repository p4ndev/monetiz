using Monetizacao.Providers.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public class PlayerEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<PlayerEntity>(e =>
        {
            e.ToTable("Player");

            e.HasKey(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();

            e.Property(p => p.Name).HasMaxLength(255);
            e.Property(p => p.Label).HasMaxLength(255);
            e.Property(p => p.Poster).HasColumnType("text");

            e.Property(p => p.Name).IsRequired();
            e.Property(p => p.Label).IsRequired();

            e.HasQueryFilter(p => p.Active);
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<PlayerEntity>(e =>
        {
            long lid = 1L;

            // Peões : 1 to 13
            lid = AFazenda2024PeoesMap.Seed(lid, e);

            // Peoas : 14 to 28
            lid = AFazenda2024PeoasMap.Seed(lid, e);
        });
}