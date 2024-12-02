namespace Monetizacao.Modules.Financial.Requests;

public struct ExternalPaymentRequest
{
    public long paymentId;
    public string paymentType;
    public bool paymentCapture;
    public string idempotencyKey;
    public string deviceId;
    public int paymentInstallments;    
}