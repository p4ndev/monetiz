using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class Cuiaba2024GroupMap
{
    public static void Seed(long id, EntityTypeBuilder<GroupEntity> e)
    {
        e.HasData(new {
            Id          = id,
            Active      = true,
            Label       = "Time",
            Name        = "Cuiabá",
            Logotype    = "cuiaba_xr2crp.png",
            Poster      = "b93a4a698a5763333d3fd22899afedb4.jpg"
        });
    }
}
