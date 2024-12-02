using Monetizacao.Modules.Financial.Interfaces;
using Monetizacao.Modules.Financial.Requests;
using Monetizacao.Providers.Handlers;
using Monetizacao.Providers.Contexts;
using MercadoPago.Resource.Payment;
using MercadoPago.Client.Payment;

namespace Monetizacao.Modules.Financial.Services;

public sealed class ExternalPixPaymentService
(
    TimezoneHandler                 _timezoneHandler,
    MercadoPagoContext              _mercadoPagoContext
) : ExternalPaymentServiceInterface<Payment>
{
    private List<PaymentItemRequest>    _items    = new();
    private ExternalPaymentRequest      _model    = new();
    private PaymentPayerRequest?        _payer    = null;

    public async Task<Payment?> FindAsync(long tid, CancellationToken token = default)
    {
        var entity = await _mercadoPagoContext.FindAsync(tid, token);

        return entity;
    }

    public async Task<Payment?> AddAsync(long uid, CancellationToken token = default)
    {
        if (_payer is null || !_items.Any())
            return null;

        var providerRequest = new PaymentCreateRequest()
        {
            Payer                       = _payer,

            ExternalReference           = ExternalReference(uid),
            DateOfExpiration            = ExpirationTransationDate(),
            StatementDescriptor         = _mercadoPagoContext.StatementDescription,
            
            Description                 = _items[0].Title,
            TransactionAmount           = _items[0].UnitPrice,

            PaymentMethodId             = _model.paymentType,
            Capture                     = _model.paymentCapture,
            Installments                = _model.paymentInstallments,
            
            //NotificationUrl           = "https://api.monetiz.fun/Mpa",
            AdditionalInfo              = new() { Items = _items }
        };

        var entity = await _mercadoPagoContext.AddAsync(providerRequest, token, _model.idempotencyKey);

        _items.Clear();
        _payer = null;

        return entity;
    }

    public async Task<Payment?> RemoveAsync(long tid, CancellationToken token = default)
    {
        var entity = await _mercadoPagoContext.RemoveAsync(tid, token);

        return entity;
    }

    public bool IsSuccessful(Payment model)
        => (model.Status.ToLower().Equals(_mercadoPagoContext.Success.Status) &&
                model.StatusDetail.ToLower().Equals(_mercadoPagoContext.Success.Details));

    public string ExternalReference(long uid)
        => $"PAY{_model.paymentId}-USR{uid}";

    public DateTime ExpirationTransationDate()
        => _timezoneHandler.RightNow().AddHours(_mercadoPagoContext.ExpirationHours);

    public void AddPaymentInfo(long ipi, string idempotencyKey)
    {
        _model.paymentInstallments  = 1;
        _model.paymentId            = ipi;
        _model.paymentCapture       = true;
        _model.paymentType          = "pix";
        _model.idempotencyKey       = idempotencyKey;
    }

    public void AddProductInfo(PaymentRequest request)
    {
        _items
            .Add(
                new PaymentItemRequest() {
                    Quantity        = 1,
                    CategoryId      = "games",
                    Id              = request.id,
                    UnitPrice       = request.total,
                    Title           = request.product,
                    Description     = "Online Games & Credits"
                }
            );
    }

    public void AddAccountInfo((string first, string last) userNames, string email)
    {
        _payer = new PaymentPayerRequest()
        {
            Email       = email,

            LastName    = userNames.last,
            FirstName   = userNames.first,

            Type        = "customer",
            EntityType  = "individual"
        };
    }
}