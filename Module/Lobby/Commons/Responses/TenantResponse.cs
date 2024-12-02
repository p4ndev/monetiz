namespace Monetizacao.Modules.Lobby.Responses;

public record TenantResponse(long id, string name, string? logotype, IEnumerable<string>? rgbs, DateTime? end);