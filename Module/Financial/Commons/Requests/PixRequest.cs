using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Modules.Financial.Requests;

public record PixRequest(string content, PixTypeEnum type);