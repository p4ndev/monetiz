using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Enums;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public static class RoleEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<RoleEntity>(e =>
        {
            e.ToTable("Role");

            e.HasKey(r => r.Id);
            e.Property(r => r.Id).ValueGeneratedOnAdd();

            e.Property(r => r.Name).HasMaxLength(50);

            e.HasIndex(r => r.Name).IsUnique();

            e.Property(r => r.Name).IsRequired();

            e.HasMany(a => a.Accounts)
                .WithOne(r => r.Role)
                    .HasForeignKey(r => r.RoleId)
                    .HasPrincipalKey(a => a.Id);
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<RoleEntity>(e =>
        {
            foreach (var item in Enum.GetValues(typeof(RoleEnum)))
            {
                if (item.Equals(RoleEnum.None))
                    continue;

                e.HasData(new { Id = item, Name = item.ToString() });
            }                
        });
}