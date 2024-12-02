namespace Monetizacao.Modules.Financial.Responses;

// TODO: Rename inner, outer to internal
public record CheckoutResponse(long innerPaymentId, decimal coins, decimal total, long outerPaymentId, string code, string status, string ticketUrl, DateTime? createdAt, DateTime? expiresAt);