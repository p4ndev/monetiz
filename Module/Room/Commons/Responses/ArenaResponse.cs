namespace Monetizacao.Modules.Room.Responses;

public record ArenaResponse(long id, string name, string image, DateTime startsAt, DateTime endsAt);