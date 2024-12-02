namespace Monetizacao.Providers.Contexts.Entities;

public abstract class BaseTrackableEntity
    : BaseReadOnlyTrackableEntity
{
    public DateTime? ModifiedAt { get; protected set; }

    public BaseTrackableEntity()
        : base() { }
}