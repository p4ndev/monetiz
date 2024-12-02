namespace Monetizacao.Providers.Contexts.Entities;

public class ActionEntity
    : BaseTypeEntity<long>
{
    public long                                 AccountId           { get; protected set; }
    public long                                 GameId              { get; protected set; }
    public long                                 TemplateId          { get; protected set; }
    public string                               Image               { get; protected set; } = null!;
    public DateTime                             StartsAt            { get; protected set; }
    public DateTime                             EndsAt              { get; protected set; }
    public bool                                 Active              { get; protected set; }
    public string                               Stamp               { get; protected set; } = null!;

    public GameEntity?                          Game                { get; protected set; }
    public ICollection<AnswerEntity>?           Answers             { get; protected set; }
    public ActionResultEntity?                  ActionResult        { get; protected set; }

    public ActionEntity(){ }

    protected ActionEntity(long uid, long gid, long tid, string action, string image, DateTime starts, DateTime ends, string stamp)
    {
        AccountId   = uid;
        GameId      = gid;
        TemplateId  = tid;
        Name        = action;
        Image       = image;
        StartsAt    = starts;
        EndsAt      = ends;
        Active      = true;
        Stamp       = stamp;
    }

    public void Remove()
        => Active = false;
}