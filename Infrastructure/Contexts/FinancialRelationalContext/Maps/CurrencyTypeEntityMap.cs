using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Enums;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public static class CurrencyTypeEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<CurrencyTypeEntity>(e =>
        {
            e.ToTable("CurrencyType");

            e.HasKey(ct => ct.Id);
            e.Property(ct => ct.Id).ValueGeneratedOnAdd();

            e.Property(ct => ct.Name).HasMaxLength(10);

            e.Property(ct => ct.Name).IsRequired();
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<CurrencyTypeEntity>(e =>
        {
            // BRL
            e.HasData(new {
                Id      = CurrencyTypeEnum.BRL,
                Name    = CurrencyTypeEnum.BRL.ToString()
            });
        });
}