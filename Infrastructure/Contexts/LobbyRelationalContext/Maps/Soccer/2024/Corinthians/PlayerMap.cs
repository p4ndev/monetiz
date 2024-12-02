using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public partial class Corinthians2024PlayerMap
{
    public static long Seed(long i, EntityTypeBuilder<PlayerEntity> e)
    {
        List<PlayerDto> a = [
            new(){      Active = true,      Label = "Goleiro",              Name = "Felipe Longo",              Poster = "felipe-longo-fernandes-da-silva-no-corinthians_eg.jpg" },
            new(){      Active = true,      Label = "Goleiro",              Name = "Hugo Souza",                Poster = "hugo-de-souza-nogueira-no-corinthians_0g.jpg" },
            new(){      Active = true,      Label = "Goleiro",              Name = "Matheus Donelli",           Poster = "matheus-planelles-donelli-no-corinthians_10g.jpg" },            
            new(){      Active = true,      Label = "Lateral",              Name = "Diego Palacios",            Poster = "diego-jose-palacios-espinoza-no-corinthians_vg.jpg" },
            new(){      Active = true,      Label = "Lateral",              Name = "Hugo Farias",               Poster = "hugo-ferreira-de-farias-no-corinthians_qg.jpg" },
            new(){      Active = true,      Label = "Lateral",              Name = "Matheus Bidu",              Poster = "matheus-lima-beltrao-oliveira-no-corinthians_sg.jpg" },
            new(){      Active = true,      Label = "Lateral",              Name = "Fagner",                    Poster = "fagner-conserva-lemos-no-corinthians_og.jpg" },
            new(){      Active = true,      Label = "Lateral",              Name = "Matheuzinho",               Poster = "matheus-franca-da-silva-no-corinthians_og.jpg" },            
            new(){      Active = true,      Label = "Zagueiro",             Name = "André Ramalho",             Poster = "andre-ramalho-silva-no-corinthians_og.jpg" },
            new(){      Active = true,      Label = "Zagueiro",             Name = "Cacá",                      Poster = "carlos-de-menezes-junior-no-corinthians_dg.jpg" },
            new(){      Active = true,      Label = "Zagueiro",             Name = "Caetano",                   Poster = "joao-victor-andrade-caetano-no-corinthians_xg.jpg" },
            new(){      Active = true,      Label = "Zagueiro",             Name = "Félix Torres",              Poster = "felix-eduardo-torres-caicedo-no-corinthians_6g.jpg" },
            new(){      Active = true,      Label = "Zagueiro",             Name = "Gustavo Henrique",          Poster = "gustavo-henrique-vernes-no-corinthians_10g.jpg" },            
            new(){      Active = true,      Label = "Meio-campista",        Name = "Alex Santana",              Poster = "alex-paulo-menezes-santana-no-corinthians_bg.jpg" },
            new(){      Active = true,      Label = "Meio-campista",        Name = "Breno Bidon",               Poster = "breno-de-souza-bidon-no-corinthians_gg.jpg" },
            new(){      Active = true,      Label = "Meio-campista",        Name = "Charles",                   Poster = "charles-rigon-matos-no-corinthians_7g.jpg" },
            new(){      Active = true,      Label = "Meio-campista",        Name = "José Martínez",             Poster = "jose-andres-martinez-torres-no-corinthians_tg.jpg" },
            new(){      Active = true,      Label = "Meio-campista",        Name = "Maycon",                    Poster = "maycon-de-andrade-barberan-no-corinthians_8g.jpg" },
            new(){      Active = true,      Label = "Meio-campista",        Name = "Raniele",                   Poster = "raniele-almeida-melo-no-corinthians_wg.jpg" },
            new(){      Active = true,      Label = "Meio-campista",        Name = "Ryan",                      Poster = "ryan-gustavo-de-lima-no-corinthians_2g.jpg" },
            new(){      Active = true,      Label = "Meio-campista",        Name = "Biro",                      Poster = "guilherme-sucigan-mafra-cunha-no-corinthians_pg.jpg" },
            new(){      Active = true,      Label = "Meio-campista",        Name = "Igor Coronado",             Poster = "igor-caique-coronado-no-corinthians_7g.jpg" },
            new(){      Active = true,      Label = "Meio-campista",        Name = "Matheus Araújo",            Poster = "matheus-de-araujo-andrade-no-corinthians_ag.jpg" },
            new(){      Active = true,      Label = "Meio-campista",        Name = "Rodrigo Garro",             Poster = "rodrigo-garro-no-corinthians_7g.jpg" },            
            new(){      Active = true,      Label = "Atacante",             Name = "Giovane",                   Poster = "giovane-santana-do-nascimento-no-corinthians_rg.jpg" },
            new(){      Active = true,      Label = "Atacante",             Name = "Héctor Hernández",          Poster = "hector-jose-hernandez-marrero-no-corinthians_wg.jpg" },
            new(){      Active = true,      Label = "Atacante",             Name = "Pedro Henrique",            Poster = "pedro-henrique-konzen-medina-da-silva-no_ug.jpg" },
            new(){      Active = true,      Label = "Atacante",             Name = "Pedro Raul",                Poster = "pedro-raul-garay-da-silva-no-corinthians_1g.jpg" },
            new(){      Active = true,      Label = "Atacante",             Name = "Romero",                    Poster = "angel-rodrigo-romero-villamayor-no-corinthians_bg.jpg" },
            new(){      Active = true,      Label = "Atacante",             Name = "Ruan Oliveira",             Poster = "ruan-de-oliveira-ferreira-no-corinthians_bg.jpg" },
            new(){      Active = true,      Label = "Atacante",             Name = "Talles Magno",              Poster = "talles-magno-bacelar-martins-no-corinthians_pg.jpg" },
            new(){      Active = true,      Label = "Atacante",             Name = "Yuri Alberto",              Poster = "yuri-alberto-monteiro-da-silva-no-corinthians_5g.jpg" }
        ];

        return PlayerMap.Seed(i, a, e);
    }
}