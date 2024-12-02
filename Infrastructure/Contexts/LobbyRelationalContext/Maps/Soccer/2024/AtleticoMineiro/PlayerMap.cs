using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class AtleticoMineiro2024PlayerMap
{
    public static long Seed(long i, EntityTypeBuilder<PlayerEntity> e)
    {
        List<PlayerDto> a = [
            new(){       Active = true,      Label = "Goleiro",              Name = "Gabriel Delfim",            Poster = "Gabriel-Delfim.png" },
            new(){       Active = true,      Label = "Goleiro",              Name = "Everson",                   Poster = "Eversn.png" },
            new(){       Active = true,      Label = "Goleiro",              Name = "Matheus Mendes",            Poster = "Matheus-Mendes.png" },
            new(){       Active = true,      Label = "Goleiro",              Name = "Gabriel Átila",             Poster = "Gabriel-Atila.png" },            
            new(){       Active = true,      Label = "Zagueiro",             Name = "Lyanco",                    Poster = "Lyanco_site.png" },
            new(){       Active = true,      Label = "Zagueiro",             Name = "Bruno Fuchs",               Poster = "Bruno-Fuchs.png" },
            new(){       Active = true,      Label = "Zagueiro",             Name = "Lemos",                     Poster = "Lemos-3.png" },
            new(){       Active = true,      Label = "Zagueiro",             Name = "Alonso",                    Poster = "Alonso_site.png" },
            new(){       Active = true,      Label = "Zagueiro",             Name = "Igor Rabello",              Poster = "Igor-Rabello-1.png" },
            new(){       Active = true,      Label = "Zagueiro",             Name = "Rômulo",                    Poster = "Romulo.png" },            
            new(){       Active = true,      Label = "Lateral",              Name = "Guilherme Arana",           Poster = "Arana-2.png" },
            new(){       Active = true,      Label = "Lateral",              Name = "Mariano",                   Poster = "Mariano-2.png" },
            new(){       Active = true,      Label = "Lateral",              Name = "Saravia",                   Poster = "Saravia-2.png" },
            new(){       Active = true,      Label = "Lateral",              Name = "Rubens",                    Poster = "Rubens-1.png" },            
            new(){       Active = true,      Label = "Meio-campista",        Name = "Otávio",                    Poster = "Otavio-2.png" },
            new(){       Active = true,      Label = "Meio-campista",        Name = "Gustavo Scarpa",            Poster = "Scarpa.png" },
            new(){       Active = true,      Label = "Meio-campista",        Name = "Zaracho",                   Poster = "Zaracho-2.png" },
            new(){       Active = true,      Label = "Meio-campista",        Name = "Igor Gomes",                Poster = "Igor-Gomes-2.png" },
            new(){       Active = true,      Label = "Meio-campista",        Name = "Fausto Vera",               Poster = "Fausto-Vera-site.png" },
            new(){       Active = true,      Label = "Meio-campista",        Name = "Bernard",                   Poster = "Bernard-1.png" },
            new(){       Active = true,      Label = "Meio-campista",        Name = "Battaglia",                 Poster = "Battaglia-2.png" },
            new(){       Active = true,      Label = "Meio-campista",        Name = "Alan Franco",               Poster = "Franco-2.png" },
            new(){       Active = true,      Label = "Meio-campista",        Name = "Paulo Vitor",               Poster = "Paulo-Vitor-2.png" },
            new(){       Active = true,      Label = "Meio-campista",        Name = "Robert",                    Poster = "Robert_site.png" },            
            new(){       Active = true,      Label = "Atacante",             Name = "Hulk",                      Poster = "Hulk-2.png" },
            new(){       Active = true,      Label = "Atacante",             Name = "Deyverson",                 Poster = "Deyverson_site.png" },
            new(){       Active = true,      Label = "Atacante",             Name = "Paulinho",                  Poster = "Paulinho-2.png" },
            new(){       Active = true,      Label = "Atacante",             Name = "Vargas",                    Poster = "Vargas-2.png" },
            new(){       Active = true,      Label = "Atacante",             Name = "Alan Kardec",               Poster = "Alan-Kardec.png" },
            new(){       Active = true,      Label = "Atacante",             Name = "Palacios",                  Poster = "B.-Palacios.png" },
            new(){       Active = true,      Label = "Atacante",             Name = "Cadu",                      Poster = "Cadu-3.png" },
            new(){       Active = true,      Label = "Atacante",             Name = "Alisson",                   Poster = "Alisson-2.png" }
        ];

        return PlayerMap.Seed(i, a, e);
    }
}