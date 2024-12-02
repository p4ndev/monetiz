using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public class AnswerEntity
    : BaseReadOnlyTrackableEntity
{
    public long                                     ActionId                { get; protected set; }
    public long                                     AccountId               { get; protected set; }
    public AnswerTypeEnum                           AnswerTypeId            { get; protected set; }
    public string                                   Content                 { get; protected set; } = null!;

    public ActionEntity?                            Action                  { get; protected set; }
    public AnswerTypeEntity?                        AnswerType              { get; protected set; }

    public AnswerEntity(){ }

    protected AnswerEntity(long uid, long aid, string content, AnswerTypeEnum ati)
        : base()
    {        
        AccountId           = uid;
        ActionId            = aid;
        Content             = content;
        AnswerTypeId        = ati;
    }
}