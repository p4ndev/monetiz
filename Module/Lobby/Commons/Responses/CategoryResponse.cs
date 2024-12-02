namespace Monetizacao.Modules.Lobby.Responses;

public record CategoryResponse(long id, long tenantId, string name, string summary, string? logotype, DateTime start, DateTime? end);