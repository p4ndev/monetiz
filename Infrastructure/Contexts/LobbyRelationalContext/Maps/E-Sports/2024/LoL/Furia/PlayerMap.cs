using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class Furia2024LoLPlayerMap
{
    public static long Seed(long i, EntityTypeBuilder<PlayerEntity> e)
    {
        List<PlayerDto> a = [
            new(){ Active = true,      Label = "Top-Lane",         Name = "Hakari",        Poster = "1718065606141_base.png" },
            new(){ Active = true,      Label = "Top-Lane",         Name = "xyno",          Poster = "1717429419617_Xyno.png" },
            new(){ Active = true,      Label = "Top-Lane",         Name = "Zzk",           Poster = "1716914901979_Zzk.png" },                   
            new(){ Active = true,      Label = "Mid-Lane",         Name = "Tutsz",         Poster = "1705515039385_Tutsz-1copy.png" },
            new(){ Active = true,      Label = "Mid-Lane",         Name = "lolo",          Poster = "1717429809195_Lolo.png" },                   
            new(){ Active = true,      Label = "Bot-Lane",         Name = "Ayu",           Poster = "1716915243781_Ayu.png" },
            new(){ Active = true,      Label = "Bot-Lane",         Name = "aikawa",        Poster = "1717429484162_Aikawa.png" },                   
            new(){ Active = true,      Label = "Jungle",           Name = "Vinicete",      Poster = "1718065637795_base.png" },
            new(){ Active = true,      Label = "Jungle",           Name = "stiner",        Poster = "1717430292061_Stiner.png" },
            new(){ Active = true,      Label = "Jungle",           Name = "Wiz",           Poster = "1717076306318_Wiz.png" },                   
            new(){ Active = true,      Label = "Support",          Name = "Manel",         Poster = "1717430231339_Manel.png" },
            new(){ Active = true,      Label = "Support",          Name = "JoJo",          Poster = "1717076641634_Jojo.png" },
        ];

        return PlayerMap.Seed(i, a, e);
    }
}