using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class Furia2024LoLGroupMap
{
    public static void Seed(long id, EntityTypeBuilder<GroupEntity> e)
    {
        e.HasData(new {
            Id          = id,
            Active      = true,
            Label       = "Equipe",
            Name        = "FURIA",
            Logotype    = "v1726527745/FURIA_edsfdd.png",
            Poster      = "v1725715014/furia-poster_nxmlmt.jpg"
        });
    }
}