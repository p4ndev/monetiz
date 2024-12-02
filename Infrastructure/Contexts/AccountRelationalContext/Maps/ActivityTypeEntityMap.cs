using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Enums;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public static class ActivityTypeEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<ActivityTypeEntity>(e =>
        {
            e.ToTable("ActivityType");

            e.HasKey(at => at.Id);
            e.Property(at => at.Id).ValueGeneratedOnAdd();

            e.Property(at => at.Name).HasMaxLength(50);

            e.Property(at => at.Name).IsRequired();

            e.HasMany(at => at.Activities)
                .WithOne(a => a.ActivityType)
                    .HasForeignKey(a => a.ActivityTypeId)
                    .HasPrincipalKey(at => at.Id);
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<ActivityTypeEntity>(e =>
        {
            // Account
            e.HasData(new { 
                Id      = ActivityTypeEnum.Account,
                Name    = ActivityTypeEnum.Account.ToString()
            });

            // Game
            e.HasData(new { 
                Id      = ActivityTypeEnum.Game,
                Name    = ActivityTypeEnum.Game.ToString()
            });

            // Buy
            e.HasData(new { 
                Id      = ActivityTypeEnum.Buy,
                Name    = ActivityTypeEnum.Buy.ToString()
            });

            // Withdraw
            e.HasData(new { 
                Id      = ActivityTypeEnum.Withdraw,
                Name    = ActivityTypeEnum.Withdraw.ToString()
            });
        });
}