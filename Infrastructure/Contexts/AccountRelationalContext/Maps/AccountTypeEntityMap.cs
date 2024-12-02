using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Enums;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public static class AccountTypeEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<AccountTypeEntity>(e =>
        {
            e.ToTable("AccountType");

            e.HasKey(at => at.Id);
            e.Property(at => at.Id).ValueGeneratedOnAdd();

            e.Property(at => at.Name).HasMaxLength(50);

            e.HasIndex(at => at.Name).IsUnique();

            e.Property(at => at.Name).IsRequired();

            e.HasMany(at => at.Accounts)
                .WithOne(ac => ac.AccountType)
                    .HasForeignKey(ac => ac.AccountTypeId)
                    .HasPrincipalKey(at => at.Id);
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<AccountTypeEntity>(e =>
        {
            // Manual
            e.HasData(new {
                Id      = AccountTypeEnum.Manual,
                Name    = AccountTypeEnum.Manual.ToString()
            });

            // Regular
            e.HasData(new {
                Id      = AccountTypeEnum.Regular,
                Name    = AccountTypeEnum.Regular.ToString()
            });
        });
}