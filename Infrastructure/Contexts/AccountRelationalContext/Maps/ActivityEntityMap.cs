using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Enums;
using Monetizacao.Providers.Handlers;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public static class ActivityEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<ActivityEntity>(e =>
        {
            e.ToTable("Activity");

            e.HasKey(a => a.Id);
            e.Property(a => a.Id).ValueGeneratedOnAdd();

            e.Property(a => a.Icon).HasMaxLength(150);
            e.Property(a => a.Name).HasMaxLength(150);
            e.Property(a => a.Stamp).HasMaxLength(50);
            e.Property(a => a.Summary).HasMaxLength(150);
            e.Property(a => a.LeftContent).HasMaxLength(150);
            e.Property(a => a.CenterContent).HasMaxLength(150);
            e.Property(a => a.CreatedAt).HasColumnType("datetime(6)");

            e.Property(a => a.Icon).IsRequired();
            e.Property(a => a.Name).IsRequired();
            e.Property(a => a.Stamp).IsRequired();
            e.Property(a => a.Summary).IsRequired();
            e.Property(a => a.CreatedAt).IsRequired();

            e.HasOne(act => act.Account)
                .WithMany(acc => acc.Activities)
                    .HasForeignKey(act => act.AccountId)
                    .HasPrincipalKey(acc => acc.Id)
                        .IsRequired(false);
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<ActivityEntity>(e =>
        {
            var tmz = new TimezoneHandler();

            // 4 # Member has registered his/her account through the email confirmation
            e.HasData(new
            {
                Id              = 1L,
                AccountId       = 4L,
                ActivityTypeId  = ActivityTypeEnum.Account,
                Name            = "account.profile.account.headline",
                Summary         = "account.profile.account.summary",
                Icon            = "mark-email-read",
                Stamp           = "8c96fac8-f53e-459e-bf58-393d9fc1342d",
                CreatedAt       = tmz.RightNow()
            });
        });
}