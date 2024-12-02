using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Enums;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public class AnswerTypeEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<AnswerTypeEntity>(e =>
        {
            e.ToTable("AnswerType");

            e.HasKey(at => at.Id);
            e.Property(at => at.Id).ValueGeneratedOnAdd();

            e.Property(at => at.Name).HasMaxLength(10);

            e.Property(at => at.Name).IsRequired();
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<AnswerTypeEntity>(e =>
        {
            // Boolean
            e.HasData(new {
                Id      = AnswerTypeEnum.Boolean,
                Name    = AnswerTypeEnum.Boolean.ToString()
            });
        });
}