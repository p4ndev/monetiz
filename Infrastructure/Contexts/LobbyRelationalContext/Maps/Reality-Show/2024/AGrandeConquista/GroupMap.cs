using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class AGrandeConquista2024GroupMap
{
    public static void Seed(long id, EntityTypeBuilder<GroupEntity> e)
    {
        e.HasData(new {
            Id          = id,
            Active      = true,
            Label       = "Ediição",
            Name        = "Edição 2 - 2024",
            Logotype    = "conquista-edicao-2-2024_prcack.png",
            Poster      = "a-grande-conquista-poster_jgajf4.jpg"
        });
    }
}
