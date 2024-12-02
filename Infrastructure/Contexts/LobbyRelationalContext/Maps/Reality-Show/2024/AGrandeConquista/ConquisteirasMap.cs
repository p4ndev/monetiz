using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class AGrandeConquista2024ConquisteirasMap
{
    public static long Seed(long i, EntityTypeBuilder<PlayerEntity> e)
    {
        List<PlayerDto> a = [
            new(){      Active = true,      Label = "Conquisteira",        Name = "Amanda Martins",            Poster = "17138238036626e03bb2067_1713823803_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Anahí Rodrighero",          Poster = "17138238146626e046bafb3_1713823814_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Aline Bina Black",          Poster = "17138238156626e047ae250_1713823815_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Ana Paula Oliveira",        Poster = "17138238256626e0510935b_1713823825_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Ana K",                     Poster = "17138238266626e0526998b_1713823826_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Andreia de Andrade",        Poster = "17138238346626e05ad482a_1713823834_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Bifão",                     Poster = "17138238046626e03cbea16_1713823804_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Brunna Bernardy",           Poster = "17138270516626eceb7514b_1713827051_3x4_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Catia Pagnote",             Poster = "17138238356626e05bb65b1_1713823835_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Cacau Luz",                 Poster = "17138238456626e0651713d_1713823845_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Claudia Carmo",             Poster = "17138238456626e065f2b6d_1713823845_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Carolina Roland",           Poster = "17138238556626e06f2dda9_1713823855_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Cibelle Mestre",            Poster = "17138238556626e06fe9f7d_1713823855_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Claudia Baronesa",          Poster = "17138238646626e078dd661_1713823864_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Dani Bavoso",               Poster = "17138238656626e079a5fac_1713823865_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Dona Geni",                 Poster = "17138238756626e083187db_1713823875_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Edlaine Barboza",           Poster = "17138238766626e08415221_1713823876_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Flavia Cheirosinha",        Poster = "17138238856626e08d126f6_1713823885_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Fran Sabino",               Poster = "17138238866626e08e1d3dd_1713823886_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Graci Zermiani",            Poster = "17138238956626e09785788_1713823895_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Gabriela Rossi",            Poster = "17138238966626e09887675_1713823896_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Gaby Fontenelle",           Poster = "17138239056626e0a1bf432_1713823905_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Hanniy Boni",               Poster = "17138239066626e0a286a34_1713823906_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Ingrid Caravellas",         Poster = "17138225456626db51db04c_1713822545_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Mc Jey Jey",                Poster = "17138225466626db5286c40_1713822546_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Jaline Araújo",             Poster = "17138225556626db5bde503_1713822555_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Jessica Marisol",           Poster = "17138225566626db5c85af7_1713822556_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Lizi Gutierrez",            Poster = "17138225666626db6608078_1713822566_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Luciana Mirihad",           Poster = "17138225666626db66b6ceb_1713822566_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Jordana Guimarães",         Poster = "17138225766626db7049eab_1713822576_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Luiza Aragão",              Poster = "17138225776626db71416d9_1713822577_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Maizy Magalhães",           Poster = "17138225856626db798d9e4_1713822585_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Marcia Barroz",             Poster = "17138225866626db7a809fa_1713822586_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Mc Mari",                   Poster = "17138225956626db83b2e9f_1713822595_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Maysa Reis",                Poster = "17138225966626db8463a1e_1713822596_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Michelle Heiden",           Poster = "17138226066626db8eeda3a_1713822606_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Nadya França",              Poster = "17138226086626db90072af_1713822608_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Nathana Britto",            Poster = "17138226196626db9bdbabf_1713822619_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Neuma Carolina",            Poster = "17138226216626db9d5a8cd_1713822621_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Poliana Roberta",           Poster = "17138226306626dba685ccb_1713822630_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Preta Praiana",             Poster = "17138226316626dba7977ea_1713822631_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Rita Assumpção",            Poster = "17138226416626dbb12bda7_1713822641_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Stephany Carvalho",         Poster = "17138226426626dbb2c141e_1713822642_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Thay Sampaio",              Poster = "17138226516626dbbb14d0e_1713822651_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Taty Pink",                 Poster = "17138226526626dbbc02253_1713822652_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Vanessa Di Santo",          Poster = "17138226606626dbc4d6125_1713822660_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Wellen Rocha",              Poster = "17138226616626dbc56f061_1713822661_3x2_md.jpg" },
            new(){      Active = true,      Label = "Conquisteira",        Name = "Ysani",                     Poster = "17138226706626dbcec0832_1713822670_3x2_md.jpg" }
        ];

        return PlayerMap.Seed(i, a, e);
    }
}