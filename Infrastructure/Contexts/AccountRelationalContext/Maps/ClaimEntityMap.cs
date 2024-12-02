using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Enums;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public static class ClaimEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<ClaimEntity>(e =>
        {
            e.ToTable("Claim");

            e.HasKey(c => c.Id);
            e.Property(c => c.Id).ValueGeneratedOnAdd();

            e.Property(c => c.Name).HasMaxLength(50);

            e.HasIndex(c => c.Name).IsUnique();

            e.Property(c => c.Name).IsRequired();
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<ClaimEntity>(e =>
        {
            foreach (var item in Enum.GetValues(typeof(ClaimEnum)))
            {
                if (item.Equals(ClaimEnum.None))
                    continue;

                e.HasData(new { Id = item, Name = item.ToString() });
            }                
        });
}