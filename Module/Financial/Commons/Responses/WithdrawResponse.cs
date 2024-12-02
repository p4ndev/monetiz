namespace Monetizacao.Modules.Financial.Responses;

public record WithdrawResponse(long uid, long ipi, decimal coins, decimal total, DateTime createdAt);