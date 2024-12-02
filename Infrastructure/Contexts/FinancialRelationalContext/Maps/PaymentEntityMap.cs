using Monetizacao.Providers.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public static class PaymentEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<PaymentEntity>(e =>
        {
            e.ToTable("Payment");

            e.HasKey(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();

            e.Property(b => b.Stamp).HasMaxLength(50);
            e.Property(p => p.CreatedAt).HasColumnType("datetime(6)");
            e.Property(p => p.ModifiedAt).HasColumnType("datetime(6)");

            e.Property(p => p.AccountId).IsRequired();
            e.Property(p => p.CreatedAt).IsRequired();
            e.Property(p => p.Coins).IsRequired();
            e.Property(p => p.Total).IsRequired();
            e.Property(b => b.Stamp).IsRequired();

            e.HasOne(p => p.PaymentType)
                .WithMany(pt => pt.Payments)
                    .HasForeignKey(p => p.PaymentTypeId)
                    .HasPrincipalKey(pt => pt.Id)
                        .IsRequired(false);

            e.HasOne(p => p.CurrencyType)
                .WithMany(ct => ct.Payments)
                    .HasForeignKey(p => p.CurrencyTypeId)
                    .HasPrincipalKey(ct => ct.Id)
                        .IsRequired(false);

            e.HasMany(p => p.MercadoPagoHistories)
                .WithOne(mph => mph.Payment)
                    .HasForeignKey(mph => mph.PaymentId)
                    .HasPrincipalKey(p => p.Id)
                        .IsRequired(false);

            e.HasQueryFilter(p => p.Active);
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<PaymentEntity>(e => { });
}
