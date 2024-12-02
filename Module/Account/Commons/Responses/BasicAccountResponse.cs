using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Modules.Account.Responses;

public record BasicAccountResponse(long id, string fullName, string email, string password, bool active, RoleEnum roleId);