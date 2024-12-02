using Monetizacao.Providers.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public class ActionEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<ActionEntity>(e =>
        {
            e.ToTable("Action");

            e.HasKey(ac => ac.Id);
            e.Property(ac => ac.Id).ValueGeneratedOnAdd();

            e.Property(ac => ac.Stamp).HasMaxLength(50);
            e.Property(ac => ac.Name).HasMaxLength(255);
            e.Property(ac => ac.Image).HasColumnType("text");

            e.Property(ac => ac.Name).IsRequired();
            e.Property(ac => ac.Image).IsRequired();
            e.Property(ac => ac.Stamp).IsRequired();
            e.Property(ac => ac.EndsAt).IsRequired();
            e.Property(ac => ac.StartsAt).IsRequired();
            e.Property(ac => ac.AccountId).IsRequired();
            
            e.HasOne(ac => ac.Game)
             .WithMany(g => g.Actions)
                .HasForeignKey(ac => ac.GameId)
                .HasPrincipalKey(g => g.Id)
                    .IsRequired(false);

            e.HasQueryFilter(ac => ac.Active);
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<ActionEntity>(e => { });
}