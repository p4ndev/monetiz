using EmailContext.Dtos;

namespace Monetizacao.Providers.Contexts.Dtos;

public record AccountEmailDto(long uid, string email, string stamp)
    : BaseEmailDto(uid, email);