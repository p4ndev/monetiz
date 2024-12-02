namespace Monetizacao.Providers.Contexts.Maps;

public class TemplateDto
{
    public string Name { get; set; } = null!;
    public string Label { get; set; } = null!;
    public int SkipMinutes { get; set; }
    public int DurationMinutes { get; set; }
}