namespace Monetizacao.Modules.Lobby.Responses;

public struct GroupResponse
{
    public long                 groupId;
    public List<long>           playerIds;

    public GroupResponse(long groupId)
        : this()
    {
        playerIds       = new();
        this.groupId    = groupId;
    }
}