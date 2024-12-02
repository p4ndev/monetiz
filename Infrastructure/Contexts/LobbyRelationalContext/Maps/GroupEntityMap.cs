using Monetizacao.Providers.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public class GroupEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<GroupEntity>(e =>
        {
            e.ToTable("Group");

            e.HasKey(g => g.Id);
            e.Property(g => g.Id).ValueGeneratedOnAdd();

            e.Property(g => g.Name).HasMaxLength(255);
            e.Property(g => g.Label).HasMaxLength(255);
            e.Property(g => g.Poster).HasColumnType("text");
            e.Property(g => g.Logotype).HasColumnType("text");

            e.Property(g => g.Name).IsRequired();
            e.Property(g => g.Label).IsRequired();

            e.HasQueryFilter(g => g.Active);
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<GroupEntity>(e =>
        {
            // Reality Show
            AFazenda2024GroupMap.Seed(1L, e);
        });
}