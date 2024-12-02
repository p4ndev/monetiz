using Monetizacao.Providers.Handlers;

namespace Monetizacao.Providers.Contexts.Entities;

public abstract class BaseReadOnlyTrackableEntity
    : BaseEntity<long>
{
    private readonly TimezoneHandler _timezoneHandler;
    public DateTime CreatedAt { get; protected set; }

    public BaseReadOnlyTrackableEntity()
    {
        _timezoneHandler = new();
        CreatedAt = _timezoneHandler.RightNow();
    }
}