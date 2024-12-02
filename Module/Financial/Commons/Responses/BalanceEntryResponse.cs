using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Modules.Financial.Responses;

public record BalanceEntryResponse(long bid, long eid, OriginTypeEnum ogt, decimal amount, DateTime createdAt);