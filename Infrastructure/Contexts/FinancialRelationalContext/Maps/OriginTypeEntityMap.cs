using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Enums;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public static class OriginTypeEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<OriginTypeEntity>(e =>
        {
            e.ToTable("OriginType");

            e.HasKey(ot => ot.Id);
            e.Property(ot => ot.Id).ValueGeneratedOnAdd();

            e.Property(ot => ot.Name).HasMaxLength(10);

            e.Property(ot => ot.Name).IsRequired();
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<OriginTypeEntity>(e =>
        {
            // Payment
            e.HasData(new {
                Id      = OriginTypeEnum.Payment,
                Name    = OriginTypeEnum.Payment.ToString()
            });

            // Action
            e.HasData(new {
                Id      = OriginTypeEnum.Action,
                Name    = OriginTypeEnum.Action.ToString()
            });
        });
}