namespace Monetizacao.Providers.Contexts.Entities;

public class GroupEntity
    : BaseTypeEntity<long>
{
    public string?                              Logotype        { get; protected set; }
    public string?                              Poster          { get; protected set; }
    public string                               Label           { get; protected set; } = null!;
    public bool                                 Active          { get; protected set; }

    public ICollection<GroupPlayerEntity>?      GroupPlayers    { get; protected set; }

    public GroupEntity(){ }
}