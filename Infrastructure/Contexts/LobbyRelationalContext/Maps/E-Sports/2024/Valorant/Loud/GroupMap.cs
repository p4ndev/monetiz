using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class Loud2024ValorantGroupMap
{
    public static void Seed(long id, EntityTypeBuilder<GroupEntity> e)
    {
        e.HasData(new {
            Id          = id,
            Active      = true,
            Label       = "Equipe",
            Name        = "LOUD",
            Logotype    = "LOUD_kpsaj0.png",
            Poster      = "loud-poster_pw8wqa.jpg"
        });
    }
}
