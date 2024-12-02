using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Enums;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts.Maps;

public static class PixTypeEntityMap
{
    public static void Definition(ModelBuilder modelBuilder)
        => modelBuilder.Entity<PixTypeEntity>(e =>
        {
            e.ToTable("PixType");

            e.HasKey(pt => pt.Id);
            e.Property(pt => pt.Id).ValueGeneratedOnAdd();

            e.Property(pt => pt.Name).HasMaxLength(10);

            e.Property(pt => pt.Name).IsRequired();
        });

    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<PixTypeEntity>(e =>
        {
            // Email
            e.HasData(new {
                Id      = PixTypeEnum.Email,
                Name    = PixTypeEnum.Email.ToString()
            });

            // Cpf
            e.HasData(new {
                Id      = PixTypeEnum.Cpf,
                Name    = PixTypeEnum.Cpf.ToString()
            });

            // Cnpj
            e.HasData(new {
                Id      = PixTypeEnum.Cnpj,
                Name    = PixTypeEnum.Cnpj.ToString()
            });

            // Phone
            e.HasData(new {
                Id      = PixTypeEnum.Phone,
                Name    = PixTypeEnum.Phone.ToString()
            });

            // Random
            e.HasData(new {
                Id      = PixTypeEnum.Random,
                Name    = PixTypeEnum.Random.ToString()
            });
        });
}