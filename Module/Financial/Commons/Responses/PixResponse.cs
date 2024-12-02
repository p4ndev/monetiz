using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Modules.Financial.Responses;

public record PixResponse(long id, string? content, PixTypeEnum type, DateTime createdAt);