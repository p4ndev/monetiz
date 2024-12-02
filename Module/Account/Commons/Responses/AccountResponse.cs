using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Modules.Account.Responses;

public record AccountResponse(BasicAccountResponse basicAccount, KeyValuePair<RoleEnum, string> role, IEnumerable<KeyValuePair<ClaimEnum, string>>? claims);