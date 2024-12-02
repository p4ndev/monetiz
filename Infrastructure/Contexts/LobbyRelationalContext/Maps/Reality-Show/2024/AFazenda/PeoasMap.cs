using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class AFazenda2024PeoasMap
{
    public static long Seed(long i, EntityTypeBuilder<PlayerEntity> e)
    {
        List<PlayerDto> a = [
            new(){      Active = true,      Label = "Peoa",     Name = "Babi",          Poster = "captura-de-tela-2024-09-16-230117.png" },
            new(){      Active = true,      Label = "Peoa",     Name = "Camila",        Poster = "camilamoura225-1713566247-3349958946950832435-4159720905.jpg" },
            new(){      Active = true,      Label = "Peoa",     Name = "Fernanda",      Poster = "captura-de-tela-2024-09-17-004005.png" },
            new(){      Active = true,      Label = "Peoa",     Name = "Flora",         Poster = "captura-de-tela-2024-09-16-234905.png" },
            new(){      Active = true,      Label = "Peoa",     Name = "Flor",          Poster = "captura-de-tela-2024-09-16-225924.png" },
            new(){      Active = true,      Label = "Peoa",     Name = "Júlia",         Poster = "captura-de-tela-2024-09-17-005121.png" },
            new(){      Active = false,     Label = "Peoa",     Name = "Larissa",       Poster = "captura-de-tela-2024-09-16-233511.png" },
            new(){      Active = true,      Label = "Peoa",     Name = "Luana",         Poster = "captura-de-tela-2024-09-17-002253.png" },
            new(){      Active = true,      Label = "Peoa",     Name = "Raquel",        Poster = "captura-de-tela-2024-09-17-001449.png" },
            new(){      Active = true,      Label = "Peoa",     Name = "Suelen",        Poster = "captura-de-tela-2024-09-17-010231.png" },
            new(){      Active = true,      Label = "Peoa",     Name = "Vanessa",       Poster = "captura-de-tela-2024-09-17-004714.png" },
            new(){      Active = false,     Label = "Peoa",     Name = "Vivi",          Poster = "captura-de-tela-2024-09-17-014713.png" },
            new(){      Active = true,      Label = "Peoa",     Name = "Gizelly",       Poster = "captura-de-tela-2024-09-17-015635.png" },
            new(){      Active = false,     Label = "Peoa",     Name = "Gabi",          Poster = "captura-de-tela-2024-09-17-013139.png" },
            new(){      Active = false,     Label = "Peoa",     Name = "Geovana",       Poster = "captura-de-tela-2024-09-17-020617.png" }
        ];

        return PlayerMap.Seed(i, a, e);
    }
}