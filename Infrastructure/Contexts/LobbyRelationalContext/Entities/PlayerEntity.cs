namespace Monetizacao.Providers.Contexts.Entities;

public class PlayerEntity
    : BaseTypeEntity<long>
{
    public string?                              Poster          { get; protected set; }
    public string                               Label           { get; protected set; } = null!;
    public bool                                 Active          { get; protected set; }

    public ICollection<GroupPlayerEntity>?      GroupPlayers    { get; protected set; }

    public PlayerEntity(){ }
}