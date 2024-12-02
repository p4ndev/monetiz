using EmailContext.Dtos;

namespace Monetizacao.Providers.Contexts.Dtos;

public record FinancialEmailDto(long uid, string email, string trackId, decimal coins, decimal total, DateTime createdAt)
    : BaseEmailDto(uid, email);