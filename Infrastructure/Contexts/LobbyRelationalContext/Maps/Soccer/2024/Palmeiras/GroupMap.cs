using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class Palmeiras2024GroupMap
{
    public static void Seed(long id, EntityTypeBuilder<GroupEntity> e)
    {
        e.HasData(new {
            Id          = id,
            Active      = true,
            Label       = "Time",
            Name        = "Palmeiras",
            Logotype    = "palmeiras_nudz50.png",
            Poster      = "palmeiras-papel-parede-celular1-575x1024.jpg"
        });
    }
}
