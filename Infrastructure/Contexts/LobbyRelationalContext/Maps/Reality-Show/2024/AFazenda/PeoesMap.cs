using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class AFazenda2024PeoesMap
{
    public static long Seed(long i, EntityTypeBuilder<PlayerEntity> e)
    {
        List<PlayerDto> a = [
            new(){      Active = true,      Label = "Peao",     Name = "Fernando",       Poster = "captura-de-tela-2024-09-17-001007.png" },
            new(){      Active = true,      Label = "Peao",     Name = "Gilson",         Poster = "gilson.png" },
            new(){      Active = true,      Label = "Peao",     Name = "Gui",            Poster = "captura-de-tela-2024-09-17-010927.png" },
            new(){      Active = true,      Label = "Peao",     Name = "Juninho",        Poster = "captura-de-tela-2024-09-17-002744.png" },
            new(){      Active = true,      Label = "Peao",     Name = "Sacha",          Poster = "captura-de-tela-2024-09-17-003410.png" },
            new(){      Active = true,      Label = "Peao",     Name = "Sidney",         Poster = "sidney_e87wvx.jpg" },
            new(){      Active = true,      Label = "Peao",     Name = "Yuri",           Poster = "captura-de-tela-2024-09-17-005812.png" },
            new(){      Active = true,      Label = "Peao",     Name = "Zaac",           Poster = "captura-de-tela-2024-09-16-234048.png" },
            new(){      Active = true,      Label = "Peao",     Name = "Zé Love",        Poster = "captura-de-tela-2024-09-16-232555.png" },
            new(){      Active = true,      Label = "Peao",     Name = "Albert",         Poster = "captura-de-tela-2024-09-17-012510.png" },
            new(){      Active = true,      Label = "Peao",     Name = "Cauê",           Poster = "captura-de-tela-2024-09-17-015324.png" },
            new(){      Active = false,     Label = "Peao",     Name = "D'Black",        Poster = "captura-de-tela-2024-09-17-012103.png" },
            new(){      Active = false,     Label = "Peao",     Name = "Michael",        Poster = "captura-de-tela-2024-09-17-013734.png" }
        ];

        return PlayerMap.Seed(i, a, e);
    }
}