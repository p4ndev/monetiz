namespace Monetizacao.Modules.Account.Requests;

public record RecoveryRequest(long? id, string email, string password, string stamp);