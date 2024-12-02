using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class Loud2024ValorantPlayerMap
{
    public static long Seed(long i, EntityTypeBuilder<PlayerEntity> e)
    {
        List<PlayerDto> a = [
            new(){ Active = true,      Label = "Sentinel",         Name = "Less",          Poster = "less_doelcv.jpg" },                   
            new(){ Active = true,      Label = "Initiator",        Name = "cauanzin",      Poster = "cauanzin_kdgiaz.jpg" },
            new(){ Active = true,      Label = "Initiator",        Name = "aspas",         Poster = "aspas_myzlff.png" },                   
            new(){ Active = true,      Label = "Duelist",          Name = "pANcada",       Poster = "pancada_ydp3mp.png" },                   
            new(){ Active = true,      Label = "Controller",       Name = "tuyz",          Poster = "tuyz_hmwr7g.jpg" },
        ];

        return PlayerMap.Seed(i, a, e);
    }
}