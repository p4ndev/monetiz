using Monetizacao.Providers.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public class ActionTemplateEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<ActionTemplateEntity>(e =>
        {
            e.ToTable("ActionTemplate");

            e.HasKey(t => t.Id);
            e.Property(t => t.Id).ValueGeneratedOnAdd();

            e.Property(t => t.TemplateId).IsRequired();
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<ActionTemplateEntity>(e =>
        {
            long lid = 1;

            // A Fazenda > Peões
            lid = PlayerTemplateMap.Seed(lid, 1L, 13L, 1L, 20L, e);

            // A Fazenda > Peoas
            lid = PlayerTemplateMap.Seed(lid, 14L, 28L, 21L, 40L, e);            
        });
}