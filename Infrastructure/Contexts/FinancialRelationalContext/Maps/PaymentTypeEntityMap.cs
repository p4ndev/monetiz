using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Enums;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public static class PaymentTypeEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<PaymentTypeEntity>(e =>
        {
            e.ToTable("PaymentType");

            e.HasKey(pt => pt.Id);
            e.Property(pt => pt.Id).ValueGeneratedOnAdd();

            e.Property(pt => pt.Name).HasMaxLength(30);
            
            e.Property(pt => pt.Name).IsRequired();
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<PaymentTypeEntity>(e =>
        {
            // MercadoPago
            e.HasData(new {
                Id      = PaymentTypeEnum.MercadoPago,
                Name    = PaymentTypeEnum.MercadoPago.ToString()
            });

            // Manual
            e.HasData(new {
                Id      = PaymentTypeEnum.Manual,
                Name    = PaymentTypeEnum.Manual.ToString()
            });
        });
}