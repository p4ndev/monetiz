namespace Monetizacao.Providers.Contexts.Entities;

public abstract class BasePeriodicEntity
    : BaseEntity<long>
{
    public required DateTime    StartsAt { get; set; }
    public DateTime?            EndsAt { get; set; }
}