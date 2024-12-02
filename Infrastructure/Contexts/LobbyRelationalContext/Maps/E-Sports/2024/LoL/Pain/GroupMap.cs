using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class Pain2024LoLGroupMap
{
    public static void Seed(long id, EntityTypeBuilder<GroupEntity> e)
    {
        e.HasData(new {
            Id          = id,
            Active      = true,
            Label       = "Equipe",
            Name        = "paiN",
            Logotype    = "v1725307947/paiN_nhcrkp.png",
            Poster      = "v1725714695/pain-poster_ara2xg.jpg"
        });
    }
}