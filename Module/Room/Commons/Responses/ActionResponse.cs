namespace Monetizacao.Modules.Room.Responses;

public record BooleanActionResponse(long aid, string name, string? image, DateTime starts, DateTime? ends, string hours, long positive, long negative, long answers);