using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class Corinthians2024GroupMap
{
    public static void Seed(long id, EntityTypeBuilder<GroupEntity> e)
    {
        e.HasData(new {
            Id          = id,
            Active      = true,
            Label       = "Time",
            Name        = "Corinthians",
            Logotype    = "corinthians_im68qr.png",
            Poster      = "b72ece0c-bcfe-4d0c-9e9d-c33ddef22782.jpeg"
        });
    }
}
