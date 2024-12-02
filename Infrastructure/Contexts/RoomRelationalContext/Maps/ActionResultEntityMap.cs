using Monetizacao.Providers.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public class ActionResultEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<ActionResultEntity>(e =>
        {
            e.ToTable("ActionResult");

            e.HasKey(ar => ar.Id);
            e.Property(ar => ar.Id).ValueGeneratedOnAdd();

            e.Property(ar => ar.Stamp).HasMaxLength(50);
            e.Property(ar => ar.Content).HasMaxLength(255);
            e.Property(ar => ar.Description).HasMaxLength(255);
            e.Property(ar => ar.CreatedAt).HasColumnType("datetime(6)");

            e.Property(ar => ar.Stamp).IsRequired();
            e.Property(ar => ar.Content).IsRequired();
            e.Property(ar => ar.CreatedAt).IsRequired();
            e.Property(ar => ar.AccountId).IsRequired();
            e.Property(ar => ar.Description).IsRequired();

            e.HasOne(ar => ar.Action)
             .WithOne(ac => ac.ActionResult)
                .HasForeignKey<ActionResultEntity>(ar => ar.ActionId)
                .HasPrincipalKey<ActionEntity>(ac => ac.Id)
                    .IsRequired(false);
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<ActionResultEntity>(e => { });
}