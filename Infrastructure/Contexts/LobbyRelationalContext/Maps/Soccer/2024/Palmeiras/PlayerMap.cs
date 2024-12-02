using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class Palmeiras2024PlayerMap
{
    public static long Seed(long i, EntityTypeBuilder<PlayerEntity> e)
    {
        List<PlayerDto> a = [
            new(){      Active = true,      Label = "Goleiro",              Name = "Marcelo Lomba",             Poster = "0003_lomba.1.png" },
            new(){      Active = true,      Label = "Goleiro",              Name = "Mateus",                    Poster = "0001_Mateus.1.png" },
            new(){      Active = true,      Label = "Goleiro",              Name = "Weverton",                  Poster = "0000_Weverton.1.png" },            
            new(){      Active = true,      Label = "Zagueiro",             Name = "Gustavo Gómez",             Poster = "0018_Gomez.png" },
            new(){      Active = true,      Label = "Zagueiro",             Name = "Michel",                    Poster = "michel-03.png" },
            new(){      Active = true,      Label = "Zagueiro",             Name = "Murilo",                    Poster = "0011_Murilo.png" },
            new(){      Active = true,      Label = "Zagueiro",             Name = "Naves",                     Poster = "0010_Naves.png" },
            new(){      Active = true,      Label = "Zagueiro",             Name = "Vitor Reis",                Poster = "Vitor-Reis-SITE.png" },            
            new(){      Active = true,      Label = "Lateral",              Name = "Agustín Giay",              Poster = "Giay_SITE.png" },
            new(){      Active = true,      Label = "Lateral",              Name = "Marcos Rocha",              Poster = "0013_Rocha.png" },
            new(){      Active = true,      Label = "Lateral",              Name = "Mayke",                     Poster = "0012_Mayke.png" },
            new(){      Active = true,      Label = "Lateral",              Name = "Caio Paulista",             Poster = "0025_Caio.png" },
            new(){      Active = true,      Label = "Lateral",              Name = "Joaquín Piquerez",          Poster = "0009_Piquerez.png" },
            new(){      Active = true,      Label = "Lateral",              Name = "Vanderlan",                 Poster = "0004_Vanderlan.png" },            
            new(){      Active = true,      Label = "Meio-campista",        Name = "Aníbal Moreno",             Poster = "0029_Anibal.png" },
            new(){      Active = true,      Label = "Meio-campista",        Name = "Fabinho",                   Poster = "0022_Fabinho.png" },
            new(){      Active = true,      Label = "Meio-campista",        Name = "Felipe Anderson",           Poster = "Felipe_anderson_SITE.png" },
            new(){      Active = true,      Label = "Meio-campista",        Name = "Gabriel Menino",            Poster = "0020_Menino.png" },
            new(){      Active = true,      Label = "Meio-campista",        Name = "Mauricio",                  Poster = "Mauricio_SITE.png" },
            new(){      Active = true,      Label = "Meio-campista",        Name = "Raphael Veiga",             Poster = "0008_Veiga.png" },
            new(){      Active = true,      Label = "Meio-campista",        Name = "Richard Ríos",              Poster = "0007_Rios.png" },
            new(){      Active = true,      Label = "Meio-campista",        Name = "Rômulo",                    Poster = "0020_Romulo.png" },
            new(){      Active = true,      Label = "Meio-campista",        Name = "Zé Rafael",                 Poster = "0005_Ze.png" },            
            new(){      Active = true,      Label = "Atacante",             Name = "Bruno Rodrigues",           Poster = "0026_Bruno.png" },
            new(){      Active = true,      Label = "Atacante",             Name = "Dudu",                      Poster = "0024_Dudu.png" },
            new(){      Active = true,      Label = "Atacante",             Name = "Estêvão",                   Poster = "0023_Estevao.png" },
            new(){      Active = true,      Label = "Atacante",             Name = "Lázaro",                    Poster = "0000_Lazaro.png" },
            new(){      Active = true,      Label = "Atacante",             Name = "López",                     Poster = "0021_Flaco.png" },
            new(){      Active = true,      Label = "Atacante",             Name = "Rony",                      Poster = "0006_Rony.png" }
        ];

        return PlayerMap.Seed(i, a, e);
    }
}