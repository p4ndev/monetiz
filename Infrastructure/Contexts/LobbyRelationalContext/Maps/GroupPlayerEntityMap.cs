using Monetizacao.Providers.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public class GroupPlayerEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<GroupPlayerEntity>(e =>
        {
            e.ToTable("GroupPlayer");

            e.HasKey(gp => gp.Id);
            e.Property(gp => gp.Id).ValueGeneratedOnAdd();

            e.HasOne(gp => gp.Group)
             .WithMany(g => g.GroupPlayers)
                .HasForeignKey(gp => gp.GroupId)
                .HasPrincipalKey(g => g.Id)
                    .IsRequired(false);

            e.HasOne(gp => gp.Player)
             .WithMany(g => g.GroupPlayers)
                .HasForeignKey(gp => gp.PlayerId)
                .HasPrincipalKey(p => p.Id)
                    .IsRequired(false);
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<GroupPlayerEntity>(e =>
        {
            // Reality Show > A Fazenda
            GroupPlayerMap.Seed(1L, 1, 28, e);
        });
}