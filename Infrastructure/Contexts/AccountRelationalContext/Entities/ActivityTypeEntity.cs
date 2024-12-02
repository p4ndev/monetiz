using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public class ActivityTypeEntity
    : BaseTypeEntity<ActivityTypeEnum>
{
    public ICollection<ActivityEntity>? Activities { get; protected set; }

    public ActivityTypeEntity(){ }
}