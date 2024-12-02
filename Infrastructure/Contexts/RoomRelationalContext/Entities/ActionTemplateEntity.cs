namespace Monetizacao.Providers.Contexts.Entities;

public class ActionTemplateEntity
    : BaseEntity<long>
{
    public long?                GroupId                 { get; protected set; }
    public long?                PlayerId                { get; protected set; }
    public long                 TemplateId              { get; protected set; }
    public DateTime?            ModifiedAt              { get; protected set; }

    public ActionTemplateEntity(){ }

    public void Remove(DateTime modifiedAt)
    {
        ModifiedAt = modifiedAt;
    }
}