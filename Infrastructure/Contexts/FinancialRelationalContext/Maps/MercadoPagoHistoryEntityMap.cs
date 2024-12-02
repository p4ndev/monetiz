using Monetizacao.Providers.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public static class MercadoPagoHistoryEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<MercadoPagoHistoryEntity>(e =>
        {
            e.ToTable("MercadoPagoHistory");

            e.HasKey(mph => mph.Id);
            e.Property(mph => mph.Id).ValueGeneratedOnAdd();

            e.Property(mph => mph.Status).HasMaxLength(20);
            e.Property(mph => mph.IssuerId).HasMaxLength(50);
            e.Property(mph => mph.PaymentMethodId).HasMaxLength(50);
            e.Property(mph => mph.PaymentTypeId).HasMaxLength(50);
            e.Property(mph => mph.CurrencyId).HasMaxLength(50);
            e.Property(mph => mph.PayerId).HasMaxLength(50);
            e.Property(mph => mph.StatusDetail).HasMaxLength(50);
            e.Property(mph => mph.Description).HasMaxLength(100);
            e.Property(mph => mph.QrCode).HasMaxLength(255);
            e.Property(mph => mph.TicketUrl).HasMaxLength(255);
            e.Property(mph => mph.CreatedAt).HasColumnType("datetime(6)");

            e.Property(mph => mph.IssuerId).IsRequired();
            e.Property(mph => mph.PaymentMethodId).IsRequired();
            e.Property(mph => mph.PaymentTypeId).IsRequired();
            e.Property(mph => mph.CurrencyId).IsRequired();
            e.Property(mph => mph.PayerId).IsRequired();
            e.Property(mph => mph.Status).IsRequired();
            e.Property(mph => mph.StatusDetail).IsRequired();
            e.Property(mph => mph.QrCode).IsRequired();
            e.Property(mph => mph.TicketUrl).IsRequired();
            e.Property(mph => mph.Description).IsRequired();
            e.Property(mph => mph.CreatedAt).IsRequired();
            e.Property(mph => mph.CollectorId).IsRequired();
            e.Property(mph => mph.TransactionId).IsRequired();
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<MercadoPagoHistoryEntity>(e => { });
}
