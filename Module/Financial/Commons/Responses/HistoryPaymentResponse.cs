namespace Monetizacao.Modules.Financial.Responses;

public record HistoryPaymentResponse(long id, string qrCode, string status, string ticketUrl, DateTime? createdAt, DateTime? expiresAt);