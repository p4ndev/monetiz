using Monetizacao.Providers.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public class TemplateEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<TemplateEntity>(e =>
        {
            e.ToTable("Template");

            e.HasKey(t => t.Id);
            e.Property(t => t.Id).ValueGeneratedOnAdd();

            e.Property(t => t.Name).HasMaxLength(255);
            e.Property(t => t.Label).HasMaxLength(255);

            e.Property(t => t.Name).IsRequired();
            e.Property(t => t.Label).IsRequired();
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<TemplateEntity>(e =>
        {
            long lid = 1;
            lid = AFazendaMap.Seed(lid, e);            
        });
}