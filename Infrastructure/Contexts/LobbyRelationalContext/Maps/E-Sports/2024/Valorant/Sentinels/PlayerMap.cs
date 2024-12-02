using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class Sentinels2024ValorantPlayerMap
{
    public static long Seed(long i, EntityTypeBuilder<PlayerEntity> e)
    {
        List<PlayerDto> a = [
            new(){ Active = true,      Label = "Sentinel",         Name = "Zekken",        Poster = "zekken.jpg" },                   
            new(){ Active = true,      Label = "Initiator",        Name = "JohnQT",        Poster = "johnqt.jpg" },
            new(){ Active = true,      Label = "Initiator",        Name = "Zellsis",       Poster = "zellsis.jpg" },                   
            new(){ Active = true,      Label = "Duelist",          Name = "Tenz",          Poster = "tenz.jpg" },                   
            new(){ Active = true,      Label = "Controller",       Name = "Sacy",          Poster = "sacy.jpg" },
        ];

        return PlayerMap.Seed(i, a, e);
    }
}