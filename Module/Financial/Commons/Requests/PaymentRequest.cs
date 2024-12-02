namespace Monetizacao.Modules.Financial.Requests;

public record PaymentRequest(string id, decimal coins, decimal total, string product);