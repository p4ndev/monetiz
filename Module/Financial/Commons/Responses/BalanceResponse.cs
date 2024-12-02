namespace Monetizacao.Modules.Financial.Responses;

public record BalanceResponse(IList<BalanceEntryResponse> credits, IList<BalanceEntryResponse> debits);