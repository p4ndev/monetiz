using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts.Maps;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Monetizacao.Providers.Contexts;

public sealed class FinancialRelationalContext : DbContext
{
    public readonly decimal                         SellPrice;
    public readonly decimal                         BuyPrice;
    public readonly string                          AesKey;

    public DbSet<OriginTypeEntity>                  OriginTypes             { get; set; }
    public DbSet<PaymentTypeEntity>                 PaymentTypes            { get; set; }
    public DbSet<CurrencyTypeEntity>                CurrencyTypes           { get; set; }
    public DbSet<OperationTypeEntity>               OperationTypes          { get; set; }

    public DbSet<BalanceEntity>                     Balances                { get; set; }
    public DbSet<PaymentEntity>                     Payments                { get; set; }
    public DbSet<MercadoPagoHistoryEntity>          MercadoPagoHistories    { get; set; }

    public DbSet<PixEntity>                         Pixes                   { get; set; }
    public DbSet<PixTypeEntity>                     PixTypes                { get; set; }

    public FinancialRelationalContext(DbContextOptions<FinancialRelationalContext> options)
        : base(options)
    {
        var config = FinancialRelationalContextSetup.BuildConfiguration().Configuration;
        SellPrice = Convert.ToDecimal(config.GetRequiredSection("Price:Sell").Value);
        BuyPrice = Convert.ToDecimal(config.GetRequiredSection("Price:Buy").Value);
        AesKey = config.GetRequiredSection("Aes:Key").Value!;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        Schema(builder);

        Seed(builder);

        base.OnModelCreating(builder);
    }

    private void Schema(ModelBuilder builder)
    {
        // Taxonomy
        OriginTypeEntityMap.Definition(builder);
        PaymentTypeEntityMap.Definition(builder);
        CurrencyTypeEntityMap.Definition(builder);
        OperationTypeEntityMap.Definition(builder);

        // Core
        BalanceEntityMap.Definition(builder);
        PaymentEntityMap.Definition(builder);
        MercadoPagoHistoryEntityMap.Definition(builder);

        // Pix
        PixTypeEntityMap.Definition(builder);
        PixEntityMap.Definition(builder);
    }

    private void Seed(ModelBuilder builder)
    {
        // Taxonomy
        OriginTypeEntityMap.Seed(builder);
        PaymentTypeEntityMap.Seed(builder);
        CurrencyTypeEntityMap.Seed(builder);
        OperationTypeEntityMap.Seed(builder);

        // Core
        BalanceEntityMap.Seed(builder);
        PaymentEntityMap.Seed(builder);
        MercadoPagoHistoryEntityMap.Seed(builder);

        // Pix
        PixTypeEntityMap.Seed(builder);
        PixEntityMap.Seed(builder);
    }
}