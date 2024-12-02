using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class TemplateMap
{
    public static long Seed(long i, List<TemplateDto> a, EntityTypeBuilder<TemplateEntity> e)
    {
        foreach (var s in a)
        {
            e.HasData(new { Id = i, s.Name, s.Label, s.SkipMinutes, s.DurationMinutes });
            i++;
        }

        i++;

        return i;
    }
}