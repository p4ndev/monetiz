using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class Sentinels2024ValorantGroupMap
{
    public static void Seed(long id, EntityTypeBuilder<GroupEntity> e)
    {
        e.HasData(new {
            Id          = id,
            Active      = true,
            Label       = "Equipe",
            Name        = "Sentinels",
            Logotype    = "sentinels_amgga1.png",
            Poster      = "sentinels-poster_uwbbcx.jpg"
        });
    }
}
