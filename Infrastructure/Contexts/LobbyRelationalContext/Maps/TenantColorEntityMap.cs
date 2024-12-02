using Monetizacao.Providers.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public class TenantColorEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<TenantColorEntity>(e =>
        {
            e.ToTable("TenantColor");

            e.HasKey(tc => tc.Id);
            e.Property(tc => tc.Id).ValueGeneratedOnAdd();

            e.Property(tc => tc.Rgb).IsRequired();
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<TenantColorEntity>(e =>
        {
            #region Reality Show            
            e.HasData(new {
                Id          = 1L,
                TenantId    = 1L,
                Rgb         = "#ffbd88"
            });
            e.HasData(new {
                Id          = 2L,
                TenantId    = 1L,
                Rgb         = "#ffe841"
            });
            e.HasData(new {
                Id          = 3L,
                TenantId    = 1L,
                Rgb         = "#bd8200"
            });
            #endregion
        });
}