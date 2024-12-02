using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Enums;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public static class AccountClaimEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<AccountClaimEntity>(e =>
        {
            e.ToTable("AccountClaim");

            e.HasKey(ac => ac.Id);
            e.Property(ac => ac.Id).ValueGeneratedOnAdd();
            e.Property(ac => ac.ClaimId).ValueGeneratedNever();
            e.Property(ac => ac.AccountId).ValueGeneratedNever();

            e.HasOne(ac => ac.Account)
                .WithMany(a => a.AccountClaims)
                    .HasForeignKey(ac => ac.AccountId)
                    .HasPrincipalKey(a => a.Id)
                        .IsRequired(false);

            e.HasOne(ac => ac.Claim)
                .WithMany(c => c.AccountClaims)
                    .HasForeignKey(ac => ac.ClaimId)
                    .HasPrincipalKey(c => c.Id);
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<AccountClaimEntity>(e =>
        {
            #region 1 # Accountant
            // HasErpAccess
            e.HasData(new {
                Id          = 1L,
                AccountId   = 1L,
                ClaimId     = ClaimEnum.HasErpAccess
            });

            //CanSearchUsers
            e.HasData(new {
                Id          = 2L,
                AccountId   = 1L,
                ClaimId     = ClaimEnum.CanSearchUsers
            });

            //CanCheckAnswers
            e.HasData(new {
                Id          = 3L,
                AccountId   = 1L,
                ClaimId     = ClaimEnum.CanCheckAnswers
            });

            // CanWithdraw
            e.HasData(new {
                Id          = 4L,
                AccountId   = 1L,
                ClaimId     = ClaimEnum.CanWithdraw
            });
            #endregion

            #region 2 # Publisher
            // HasErpAccess
            e.HasData(new {
                Id          = 5L,
                AccountId   = 2L,
                ClaimId     = ClaimEnum.HasErpAccess
            });

            // CanCheckAnswers
            e.HasData(new {
                Id          = 6L,
                AccountId   = 2L,
                ClaimId     = ClaimEnum.CanCheckAnswers
            });

            // CanCreateActions
            e.HasData(new {
                Id          = 7L,
                AccountId   = 2L,
                ClaimId     = ClaimEnum.CanCreateActions
            });

            // CanConsolidate
            e.HasData(new {
                Id          = 8L,
                AccountId   = 2L,
                ClaimId     = ClaimEnum.CanConsolidate
            });
            #endregion

            #region 3 # Guest
            // HasApiAccess
            e.HasData(new
            {
                Id          = 9L,
                AccountId   = 3L,
                ClaimId     = ClaimEnum.HasApiAccess
            });

            // HasAppAccess
            e.HasData(new
            {
                Id          = 10L,
                AccountId   = 3L,
                ClaimId     = ClaimEnum.HasAppAccess
            });
            #endregion

            #region 4 # Member
            // HasApiAccess
            e.HasData(new
            {
                Id          = 11L,
                AccountId   = 4L,
                ClaimId     = ClaimEnum.HasApiAccess
            });

            // HasAppAccess
            e.HasData(new
            {
                Id          = 12L,
                AccountId   = 4L,
                ClaimId     = ClaimEnum.HasAppAccess
            });

            // HasEmailConfirmed
            e.HasData(new
            {
                Id          = 13L,
                AccountId   = 4L,
                ClaimId     = ClaimEnum.HasEmailConfirmed
            });
            #endregion
        });
}