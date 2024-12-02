using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class PlayerMap
{
    public static long Seed(long i, List<PlayerDto> a, EntityTypeBuilder<PlayerEntity> e)
    {
        foreach (var s in a)
        {
            e.HasData(new { Id = i, s.Active, s.Label, s.Name, s.Poster });
            i++;
        }

        return i;
    }
}