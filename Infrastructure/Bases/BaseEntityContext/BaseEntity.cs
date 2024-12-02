namespace Monetizacao.Providers.Contexts.Entities;

public abstract class BaseEntity<T>
{
    public T? Id { get; protected set; } = default!;
}