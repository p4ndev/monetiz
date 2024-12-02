namespace Monetizacao.Modules.Account.Requests;

public record AccountRequest(string email, string password, string? fullName = null);