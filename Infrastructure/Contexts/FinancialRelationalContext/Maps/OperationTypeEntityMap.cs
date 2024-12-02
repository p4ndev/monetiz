using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Enums;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public static class OperationTypeEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<OperationTypeEntity>(e =>
        {
            e.ToTable("OperationType");

            e.HasKey(ot => ot.Id);
            e.Property(ot => ot.Id).ValueGeneratedOnAdd();

            e.Property(ot => ot.Name).HasMaxLength(10);

            e.Property(ot => ot.Name).IsRequired();
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<OperationTypeEntity>(e =>
        {
            // In
            e.HasData(new {
                Id      = OperationTypeEnum.In,
                Name    = OperationTypeEnum.In.ToString()
            });

            // Out
            e.HasData(new {
                Id      = OperationTypeEnum.Out,
                Name    = OperationTypeEnum.Out.ToString()
            });
        });
}