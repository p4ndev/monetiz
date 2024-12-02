using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Modules.Financial.Responses;

public class ActionResponse : BasePeriodicEntity
{
    public long                     GameId          { get; set; }
    public required string          Name            { get; set; }
    public string?                  Image           { get; set; }
    public bool                     HasAnswered     { get; set; }
}