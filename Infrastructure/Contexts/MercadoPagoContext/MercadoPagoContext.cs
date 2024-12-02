using MercadoPago.Resource.Payment;
using MercadoPago.Client.Payment;
using MercadoPago.Client;

namespace Monetizacao.Providers.Contexts;

public class MercadoPagoContext
{
    public readonly string?                             StatementDescription;
    public readonly int                                 ExpirationHours;
    public readonly (string Status, string Details)     Success;

    private readonly RequestOptions?                    _options;
    private readonly PaymentClient                      _client;

    public MercadoPagoContext()
    {
        _client                 = new();
    }

    public MercadoPagoContext(short expirationHours, string? statementDescription, string? accessToken, string? successStatus, string? successDetail)
        : this ()
    {
        if (accessToken is null || successStatus is null || successDetail is null)
            return;

        ExpirationHours         = expirationHours;
        StatementDescription    = statementDescription;
        _options                = new(){ AccessToken = accessToken! };
        Success                 = (successStatus!, successDetail!);
    }

    public async Task<Payment> AddAsync(PaymentCreateRequest request, CancellationToken token = default, string? idempotencyKey = null, string? deviceId = null)
    {
        if(idempotencyKey is not null)
            _options?.CustomHeaders.Add("x-idempotency-key", idempotencyKey);

        if (deviceId is not null)
            _options?.CustomHeaders.Add("X-meli-session-id", deviceId);

        return await _client.CreateAsync(request, _options, token);
    }

    public async Task<Payment> RemoveAsync(long paymentId, CancellationToken token = default)
        => await _client.CancelAsync(paymentId, _options, token);

    public async Task<Payment> FindAsync(long paymentId, CancellationToken token = default)
        => await _client.GetAsync(paymentId, _options, token);
}