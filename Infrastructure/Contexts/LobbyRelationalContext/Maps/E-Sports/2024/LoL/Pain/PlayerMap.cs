using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class Pain2024LoLPlayerMap
{
    public static long Seed(long i, EntityTypeBuilder<PlayerEntity> e)
    {
        List<PlayerDto> a = [
            new(){ Active = true,      Label = "Top-Lane",         Name = "Hidan",         Poster = "1717436108409_Hidan.png" },
            new(){ Active = true,      Label = "Top-Lane",         Name = "Wizer",         Poster = "1717084303792_Wizer.png" },                   
            new(){ Active = true,      Label = "Mid-Lane",         Name = "Nallari",       Poster = "1718063649158_Nallari.png" },
            new(){ Active = true,      Label = "Mid-Lane",         Name = "dyNquedo",      Poster = "1717436189223_dyNquedo.png" },
            new(){ Active = true,      Label = "Mid-Lane",         Name = "Qats",          Poster = "1717436072202_Qats.png" },                   
            new(){ Active = true,      Label = "Bot-Lane",         Name = "TitaN",         Poster = "1717084345380_TitaN.png" },
            new(){ Active = true,      Label = "Bot-Lane",         Name = "Marvin",        Poster = "1718065242237_Marvin.png" },                   
            new(){ Active = true,      Label = "Jungle",           Name = "Tatu",          Poster = "1717435794804_Tatu.png" },
            new(){ Active = true,      Label = "Jungle",           Name = "CarioK",        Poster = "1717084627166_Cariok.png" },                   
            new(){ Active = true,      Label = "Support",          Name = "Luna",          Poster = "1718061790710_Luna.png" },
            new(){ Active = true,      Label = "Support",          Name = "Guigs",         Poster = "1717435971799_Guigs.png" },
            new(){ Active = true,      Label = "Support",          Name = "Kuri",          Poster = "1717084765561_Kuri.png" },
        ];

        return PlayerMap.Seed(i, a, e);
    }
}