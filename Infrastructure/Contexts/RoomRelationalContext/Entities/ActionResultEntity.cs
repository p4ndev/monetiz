namespace Monetizacao.Providers.Contexts.Entities;

public class ActionResultEntity
    : BaseReadOnlyTrackableEntity
{
    public long                                     AccountId               { get; protected set; }
    public long                                     ActionId                { get; protected set; }
    public string                                   Content                 { get; protected set; } = null!;
    public string                                   Description             { get; protected set; } = null!;
    public string                                   Stamp                   { get; protected set; } = null!;

    public ActionEntity?                            Action                  { get; protected set; }

    public ActionResultEntity() { }

    protected ActionResultEntity(long uid, long aid, string result, string description, string stamp)
        : base()
    {
        AccountId       = uid;
        ActionId        = aid;
        Stamp           = stamp;
        Content         = result;
        Description     = description;
    }
}