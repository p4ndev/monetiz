namespace Monetizacao.Providers.Contexts.Entities;

public class GroupPlayerEntity
    : BaseEntity<long>
{
    public long             GroupId     { get; protected set; }
    public long             PlayerId    { get; protected set; }

    public GroupEntity?     Group       { get; protected set; }
    public PlayerEntity?    Player      { get; protected set; }

    public GroupPlayerEntity(){ }
}