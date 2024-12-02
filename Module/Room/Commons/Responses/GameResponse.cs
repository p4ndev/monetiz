namespace Monetizacao.Modules.Room.Responses;

public record GameResponse(long id, long tenantId, long categoryId, string name, long firstGroupId, long? secondGroupId, IEnumerable<long>? actionIds);