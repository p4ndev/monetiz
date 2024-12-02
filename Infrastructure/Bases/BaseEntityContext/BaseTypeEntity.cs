namespace Monetizacao.Providers.Contexts.Entities;

public abstract class BaseTypeEntity<T>
    : BaseEntity<T>
{
    public string Name { get; protected set; } = null!;
}