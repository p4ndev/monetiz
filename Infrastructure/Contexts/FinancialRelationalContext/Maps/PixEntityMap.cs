using Monetizacao.Providers.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public static class PixEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<PixEntity>(e =>
        {
            e.ToTable("Pix");

            e.HasKey(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();

            e.Property(p => p.CreatedAt).HasColumnType("datetime(6)");
            
            e.Property(p => p.Content).IsRequired();
            e.Property(p => p.AccountId).IsRequired();
            e.Property(p => p.CreatedAt).IsRequired();

            e.HasOne(p => p.PixType)
                .WithMany(pt => pt.Pixes)
                    .HasForeignKey(p => p.PixTypeId)
                    .HasPrincipalKey(pt => pt.Id)
                        .IsRequired(false);

            //e.HasQueryFilter(p => p.Active);
        });


    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<PixEntity>(e => { });
}
