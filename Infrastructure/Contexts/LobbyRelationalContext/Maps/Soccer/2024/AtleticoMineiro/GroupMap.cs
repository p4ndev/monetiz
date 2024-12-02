using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class AtleticoMineiro2024GroupMap
{
    public static void Seed(long id, EntityTypeBuilder<GroupEntity> e)
    {
        e.HasData(new {
            Id          = id,
            Active      = true,
            Label       = "Time",
            Name        = "Atlético MG",
            Logotype    = "atletico-mineiro_zjdtpi.png",
            Poster      = "atletico-mineiro-poster_xquif3.jpg"
        });
    }
}
