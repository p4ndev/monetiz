using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public class PixTypeEntity
    : BaseTypeEntity<PixTypeEnum>
{
    public ICollection<PixEntity>? Pixes { get; protected set; }

    public PixTypeEntity() { }
}