namespace Monetizacao.Providers.Handlers;

public class TimezoneHandler
{
    public readonly int Utc = -3;

    public DateTime RightNow() => DateTime.UtcNow;
}
