using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Enums;
using Monetizacao.Providers.Handlers;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public static class AccountEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<AccountEntity>(e =>
        {
            e.ToTable("Account");

            e.HasKey(a => a.Id);
            e.Property(a => a.Id).ValueGeneratedOnAdd();

            e.Property(a => a.Email).HasMaxLength(50);
            e.Property(a => a.Password).HasMaxLength(50);
            e.Property(a => a.FullName).HasMaxLength(30);
            e.Property(a => a.PasswordStamp).HasMaxLength(50);
            e.Property(a => a.ActivationStamp).HasMaxLength(50);
            e.Property(a => a.CreatedAt).HasColumnType("datetime(6)");

            e.Property(a => a.Email).IsRequired();
            e.Property(a => a.Password).IsRequired();
            e.Property(a => a.FullName).IsRequired();
            e.Property(a => a.CreatedAt).IsRequired();
            e.Property(a => a.PasswordStamp).IsRequired();
            e.Property(a => a.ActivationStamp).IsRequired();

            e.HasIndex(a => a.Email).IsUnique();
            e.HasIndex(a => a.PasswordStamp).IsUnique();
            e.HasIndex(a => a.ActivationStamp).IsUnique();

            e.Property(a => a.Active).HasDefaultValue(true);

            e.HasQueryFilter(a => a.Active);
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<AccountEntity>(e =>
        {
            var uuid = new UUIDHandler();
            var tmz = new TimezoneHandler();
            var md5 = new Md5CryptoHandler();

            // 1 # Accountant Manual Active
            e.HasData(new {
                Id                  = 1L,
                CreatedAt           = tmz.RightNow(),
                PasswordStamp       = uuid.Generate(),
                ActivationStamp     = uuid.Generate(),
                FullName            = "Accountant",
                RoleId              = RoleEnum.Accountant,
                AccountTypeId       = AccountTypeEnum.Manual,
                Email               = "accountant@monetiz.fun",
                Password            = md5.Parse("XWeckdIkL4d8l")
            });

            // 2 # Publisher Manual Active
            e.HasData(new {
                Id                  = 2L,
                CreatedAt           = tmz.RightNow(),
                PasswordStamp       = uuid.Generate(),
                ActivationStamp     = uuid.Generate(),
                FullName            = "Publisher",
                RoleId              = RoleEnum.Publisher,
                AccountTypeId       = AccountTypeEnum.Manual,
                Email               = "publisher@monetiz.fun",
                Password            = md5.Parse("i8KNJ62ukL26b")
            });

            // 3 # Guest Manual Active
            e.HasData(new {
                Id                  = 3L,
                CreatedAt           = tmz.RightNow(),
                PasswordStamp       = uuid.Generate(),
                ActivationStamp     = uuid.Generate(),
                FullName            = "Guest",
                RoleId              = RoleEnum.Guest,
                AccountTypeId       = AccountTypeEnum.Manual,
                Email               = "guest@monetiz.fun",
                Password            = md5.Parse("b5kAXSCbQYTLS")
            });

            // 4 # Member Manual Active
            e.HasData(new
            {
                Id                  = 4L,
                CreatedAt           = tmz.RightNow(),
                PasswordStamp       = uuid.Generate(),
                ActivationStamp     = uuid.Generate(),
                FullName            = "Member",
                RoleId              = RoleEnum.Member,
                AccountTypeId       = AccountTypeEnum.Manual,
                Email               = "member@monetiz.fun",
                Password            = md5.Parse("0TdQBTriTof5s")
            });
        });
}