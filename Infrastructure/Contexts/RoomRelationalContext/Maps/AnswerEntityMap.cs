using Monetizacao.Providers.Contexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public class AnswerEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<AnswerEntity>(e =>
        {
            e.ToTable("Answer");

            e.HasKey(an => an.Id);
            e.Property(an => an.Id).ValueGeneratedOnAdd();

            e.Property(an => an.Content).HasMaxLength(255);
            e.Property(an => an.CreatedAt).HasColumnType("datetime(6)");

            e.Property(an => an.AccountId).IsRequired();
            e.Property(an => an.CreatedAt).IsRequired();

            e.HasOne(an => an.Action)
             .WithMany(ac => ac.Answers)
                .HasForeignKey(an => an.ActionId)
                .HasPrincipalKey(ac => ac.Id)
                    .IsRequired(false);
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<AnswerEntity>(e => { });
}
