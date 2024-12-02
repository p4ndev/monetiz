using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public class PixEntity
    : BaseReadOnlyTrackableEntity
{
    public long                                             AccountId               { get; protected set; }
    public PixTypeEnum                                      PixTypeId               { get; protected set; }
    public byte[]                                           Content                 { get; protected set; } = null!;
    public bool                                             Active                  { get; protected set; }

    public PixTypeEntity?                                   PixType                 { get; protected set; }

    public PixEntity() { }

    protected PixEntity(long uid, PixTypeEnum pit, byte[] content)
        : base()
    {
        AccountId           = uid;
        PixTypeId           = pit;
        Content             = content;
    }
}