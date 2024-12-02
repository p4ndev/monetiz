using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class Cuiaba2024PlayerMap
{
    public static long Seed(long i, EntityTypeBuilder<PlayerEntity> e)
    {
        List<PlayerDto> a = [
            new(){       Active = true,      Label = "Goleiro",              Name = "Mateus Pasinato",           Poster = "SITE_Mateus-Pasinato.png" },
            new(){       Active = true,      Label = "Goleiro",              Name = "Rhyan",                     Poster = "SITE_Rhyan.png" },
            new(){       Active = true,      Label = "Goleiro",              Name = "Walter",                    Poster = "SITE_Walter.png" },            
            new(){       Active = true,      Label = "Zagueiro",             Name = "Alan Empereur",             Poster = "SITE_Alan-Empereur.png" },
            new(){       Active = true,      Label = "Zagueiro",             Name = "Bruno Alves",               Poster = "SITE_Bruno-Alves.png" },
            new(){       Active = true,      Label = "Zagueiro",             Name = "Gabriel",                   Poster = "SITE_Gabriel-K..png" },
            new(){       Active = true,      Label = "Zagueiro",             Name = "Marllon",                   Poster = "SITE_Marllon.png" },            
            new(){       Active = true,      Label = "Lateral",              Name = "Juan Tavares",              Poster = "SITE_Juan-Tavares.png" },
            new(){       Active = true,      Label = "Lateral",              Name = "Matheus Alexandre",         Poster = "SITE_Matheus-Alexandre.png" },
            new(){       Active = true,      Label = "Lateral",              Name = "Ramon",                     Poster = "SITE_Ramon.png" },
            new(){       Active = true,      Label = "Lateral",              Name = "Raylan",                    Poster = "SITE_Raylan.png" },            
            new(){       Active = true,      Label = "Meio-campista",        Name = "Denilson",                  Poster = "SITE_Denilson.png" },
            new(){       Active = true,      Label = "Meio-campista",        Name = "Fernando Sobral",           Poster = "SITE_Fernando-Sobral.png" },
            new(){       Active = true,      Label = "Meio-campista",        Name = "Filipe Augusto",            Poster = "SITE_Filipe-Augusto.png" },
            new(){       Active = true,      Label = "Meio-campista",        Name = "Guilherme Madruga",         Poster = "SITE_Guilherme-Madruga.png" },
            new(){       Active = true,      Label = "Meio-campista",        Name = "Lucas Mineiro",             Poster = "SITE_Lucas-Mineiro.png" },
            new(){       Active = true,      Label = "Meio-campista",        Name = "Gustavo Sauer",             Poster = "GUSTAVO-SAUER_site.png" },
            new(){       Active = true,      Label = "Meio-campista",        Name = "Lucas Fernandes",           Poster = "SITE_Lucas-Fernandes.png" },
            new(){       Active = true,      Label = "Meio-campista",        Name = "Max",                       Poster = "SITE_Max.png" },            
            new(){       Active = true,      Label = "Atacante",             Name = "André Luís",                Poster = "SITE_Andre-Luis.png" },
            new(){       Active = true,      Label = "Atacante",             Name = "Clayson",                   Poster = "SITE_Clayson.png" },
            new(){       Active = true,      Label = "Atacante",             Name = "Derik Lacerda",             Poster = "SITE_Derik-Lacerda.png" },
            new(){       Active = true,      Label = "Atacante",             Name = "Eliel",                     Poster = "SITE_Eliel.png" },
            new(){       Active = true,      Label = "Atacante",             Name = "Isidro Pitta",              Poster = "SITE_Pitta.png" },
            new(){       Active = true,      Label = "Atacante",             Name = "Jonathan Cafú",             Poster = "SITE_Jonathan-Cafu.png" }
        ];

        return PlayerMap.Seed(i, a, e);
    }
}