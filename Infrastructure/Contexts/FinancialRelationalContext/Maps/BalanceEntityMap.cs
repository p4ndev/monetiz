using Monetizacao.Providers.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public static class BalanceEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<BalanceEntity>(e =>
        {
            e.ToTable("Balance");

            e.HasKey(b => b.Id);
            e.Property(b => b.Id).ValueGeneratedOnAdd();

            e.Property(b => b.Stamp).HasMaxLength(50);
            e.Property(b => b.CreatedAt).HasColumnType("datetime(6)");

            e.Property(b => b.AccountId).IsRequired();
            e.Property(b => b.CreatedAt).IsRequired();
            e.Property(b => b.EntityId).IsRequired();
            e.Property(b => b.Amount).IsRequired();
            e.Property(b => b.Stamp).IsRequired();

            e.HasOne(b => b.OperationType)
                .WithMany(op => op.Balances)
                    .HasForeignKey(b => b.OperationTypeId)
                    .HasPrincipalKey(op => op.Id);

            e.HasOne(b => b.OriginType)
                .WithMany(ot => ot.Balances)
                    .HasForeignKey(b => b.OriginTypeId)
                    .HasPrincipalKey(ot => ot.Id);
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<BalanceEntity>(e => { });
}