using Microsoft.Extensions.DependencyInjection;
using Monetizacao.Modules.Financial.Interfaces;
using Monetizacao.Modules.Financial.Services;
using MercadoPago.Resource.Payment;

namespace Monetizacao.Modules.Financial;

public static class FinancialModuleSetup
{
    public static void AddFinancialModule(this IServiceCollection services)
    {
        services.AddTransient<PixService>();
        services.AddTransient<BalanceService>();
        services.AddTransient<CheckoutService>();

        services.AddTransient<InternalPaymentServiceInterface,           InternalPaymentService>();
        services.AddTransient<HistoryPaymentServiceInterface<Payment>,   HistoryPixPaymentService>();
        services.AddTransient<ExternalPaymentServiceInterface<Payment>,  ExternalPixPaymentService>();
    }
}