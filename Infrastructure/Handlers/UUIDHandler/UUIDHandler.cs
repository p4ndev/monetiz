namespace Monetizacao.Providers.Handlers;

public class UUIDHandler
{
    public string Generate() => Guid.NewGuid().ToString().ToLower();
}