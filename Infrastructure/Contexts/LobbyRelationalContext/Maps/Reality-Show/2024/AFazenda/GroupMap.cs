using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class AFazenda2024GroupMap
{
    public static void Seed(long id, EntityTypeBuilder<GroupEntity> e)
    {
        e.HasData(new {
            Id          = id,
            Active      = true,
            Label       = "Edição",
            Name        = "Edição 16 - 2024",
            Poster      = "1_galo_novo-12485787.jpg",
            Logotype    = "fazenda-edicao-16_zu6xbk.png"
        });
    }
}
