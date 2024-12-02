using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class AGrandeConquista2024ConquisteirosMap
{
    public static long Seed(long i, EntityTypeBuilder<PlayerEntity> e)
    {
        List<PlayerDto> a = [
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Will Rambo",                Poster = "17138222176626da096d119_1713822217_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Clevinho Santana",          Poster = "17138229346626dcd6f0396_1713822934_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Charles Daves",             Poster = "17138229436626dcdfe11d8_1713822943_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Cel",                       Poster = "17138229446626dce0d1c8f_1713822944_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Bruno Cardoso",             Poster = "17138229256626dccd435b6_1713822925_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Di Silva",                  Poster = "17138229546626dceaa8eaa_1713822954_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Fabio Gontijo",             Poster = "17138229636626dcf3e132b_1713822963_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Fellipe Villas",            Poster = "17138229646626dcf4bb5e3_1713822964_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Fernando Sampaio",          Poster = "17138229746626dcfe83a8a_1713822974_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Fabricio Almeida",          Poster = "17138229756626dcff4fef5_1713822975_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Guipa",                     Poster = "17138229856626dd0962b7a_1713822985_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Gustavo Mastafe",           Poster = "17138229866626dd0a20aeb_1713822986_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Hadad",                     Poster = "17138229966626dd14571d8_1713822996_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Heitor Ximenis",            Poster = "17138229976626dd153dd86_1713822997_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Hideo",                     Poster = "17138230066626dd1e89fce_1713823006_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Izumed",                    Poster = "17138230076626dd1f66ab8_1713823007_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Jonas Bento",               Poster = "17138230176626dd295ef66_1713823017_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Nelsão",                    Poster = "17138230186626dd2a1e4c7_1713823018_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Brenno Pavarini",           Poster = "17138229056626dcb944ede_1713822905_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Kaio Perroni",              Poster = "17138221136626d9a1a1c37_1713822113_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Kadu Rodrigues",            Poster = "17138221186626d9a64575f_1713822118_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Luciano Rodrigues",         Poster = "17138221226626d9aa99488_1713822122_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Lucas de Albú",             Poster = "17138221286626d9b0a71d4_1713822128_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Lippe Rodrigues",           Poster = "17138221326626d9b41b295_1713822132_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Leonardo Saavedra",         Poster = "17138221396626d9bb76ad2_1713822139_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Michael Calasans",          Poster = "17138221426626d9be0bba7_1713822142_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Manoelzinho",               Poster = "17138221496626d9c57c085_1713822149_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Madshow",                   Poster = "17138221516626d9c7a7e9a_1713822151_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Matheus Destri",            Poster = "17138221586626d9cee4614_1713822158_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Marcus Cowboy",             Poster = "17138221616626d9d109f17_1713822161_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Jo Werner",                 Poster = "17138221046626d9988082a_1713822104_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "João Pinto",                Poster = "17138221096626d99d330c9_1713822109_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Nemo",                      Poster = "17138221686626d9d8920ba_1713822168_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Ricardo Costa",             Poster = "17138221706626d9daeaab0_1713822170_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Ratinho",                   Poster = "17138221766626d9e0a840e_1713822176_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Raphinha",                  Poster = "17138221806626d9e482851_1713822180_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Sandrão",                   Poster = "17138221876626d9eb07823_1713822187_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Thiago Luz",                Poster = "17138221886626d9ecd5d16_1713822188_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Uarzancler Zuckerman",      Poster = "17138221976626d9f52fa24_1713822197_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Theo Black",                Poster = "17138221986626d9f690116_1713822198_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Thiago Cirillo",            Poster = "17138222066626d9fe7c1a6_1713822206_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Vini Sassone",              Poster = "17138222076626d9ff70e9c_1713822207_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteiro",        Name = "Vinigram",                  Poster = "17138222166626da08bec9b_1713822216_3x2_md.jpg" }
        ];

        return PlayerMap.Seed(i, a, e);
    }
}