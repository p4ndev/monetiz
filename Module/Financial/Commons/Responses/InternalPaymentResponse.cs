namespace Monetizacao.Modules.Financial.Responses;

public record InternalPaymentResponse(long id, decimal coins, decimal total, string stamp, DateTime createdAt);