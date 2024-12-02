namespace Monetizacao.Providers.Contexts.Entities;

public class TemplateEntity
    : BaseTypeEntity<long>
{
    public string               Label                   { get; protected set; } = null!;
    public int                  SkipMinutes             { get; protected set; }
    public int                  DurationMinutes         { get; protected set; }

    public TemplateEntity(){ }
}