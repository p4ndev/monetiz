namespace Monetizacao.Providers.Contexts.Entities;

public class GameEntity
    : BasePeriodicEntity
{
    public long                                 TenantId        { get; protected set; }
    public long                                 CategoryId      { get; protected set; }
    public long                                 FirstGroupId    { get; protected set; }
    public long?                                SecondGroupId   { get; protected set; }

    public string                               Name            { get; protected set; } = null!;
    public bool                                 Active          { get; protected set; }

    public ICollection<ActionEntity>?           Actions         { get; protected set; }

    public GameEntity(){ }
}