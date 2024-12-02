using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class LoLMap
{
    public static long Seed(long i, EntityTypeBuilder<TemplateEntity> e)
    {
        List<TemplateDto> a = [
            #region Top-Lane
            new (){ Name = "Vai splitpushar com sucesso {Top-Lane} na top lane?",                                                      Label = "Top-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Top-Lane} usará o TP para uma jogada bot?",                                                               Label = "Top-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Top-Lane} conseguirá uma vantagem de 50 cs sobre o adversário?",                                          Label = "Top-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Top-Lane} terminará a partida sem morrer uma única vez?",                                                 Label = "Top-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que {Top-Lane} vai farmar mais de 200 minions em 20 minutos?",                                        Label = "Top-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O MVP hoje vai ser {Top-Lane}?",                                                                           Label = "Top-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O próximo abate será feito por {Top-Lane}?",                                                               Label = "Top-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será {Top-Lane} que destruirá o Nexus?",                                                                   Label = "Top-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Hoje, {Top-Lane} comprará Item Mítico antes dos 10 minutos?",                                              Label = "Top-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Top-Lane} conseguirá dar mais de 10 kills?",                                                              Label = "Top-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            #endregion

            #region Mid-Lane
            new (){ Name = "{Mid-Lane} pegará o primeiro abate na rota do meio?",                                                      Label = "Mid-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que {Mid-Lane} usará flash defensivamente nos primeiros 10 minutos?",                                 Label = "Mid-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Conseguirá {Mid-Lane} um quadra kill nos primeiros 15 minutos?",                                           Label = "Mid-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Mid-Lane} terá o maior dano da partida?",                                                                 Label = "Mid-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que {Mid-Lane} vai farmar mais de 200 minions em 20 minutos?",                                        Label = "Mid-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O MVP hoje vai ser {Mid-Lane}?",                                                                           Label = "Mid-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O próximo abate será feito por {Mid-Lane}?",                                                               Label = "Mid-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será {Mid-Lane} que destruirá o Nexus?",                                                                   Label = "Mid-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Hoje, {Mid-Lane} comprará Item Mítico antes dos 10 minutos?",                                              Label = "Mid-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Mid-Lane} conseguirá dar mais de 10 kills?",                                                              Label = "Mid-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            #endregion

            #region Bot-Lane
            new (){ Name = "{Bot-Lane} destruirá a torre inimiga em até 5 minutos de jogo?",                                           Label = "Bot-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Vai rolar um penta kill de {Bot-Lane} hoje?",                                                              Label = "Bot-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Bot-Lane} dará assist na first blood?",                                                                   Label = "Bot-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Bot-Lane} usará ultimate defensivamente mais de 3 vezes?",                                                Label = "Bot-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que {Bot-Lane} vai farmar mais de 200 minions em 20 minutos?",                                        Label = "Bot-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O MVP hoje vai ser {Bot-Lane}?",                                                                           Label = "Bot-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O próximo abate será feito por {Bot-Lane}?",                                                               Label = "Bot-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será {Bot-Lane} que destruirá o Nexus?",                                                                   Label = "Bot-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Hoje, {Bot-Lane} comprará Item Mítico antes dos 10 minutos?",                                              Label = "Bot-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Bot-Lane} conseguirá dar mais de 10 kills?",                                                              Label = "Bot-Lane",         SkipMinutes = 0,        DurationMinutes = 18000 },
            #endregion

            #region Jungle
            new (){ Name = "O Barão será o objetivo principal de {Jungle} nesta partida?",                                             Label = "Jungle",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Jungle} roubará o Barão na próxima tentativa?",                                                           Label = "Jungle",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Jungle} fará um roubo de buff vermelho level 1?",                                                         Label = "Jungle",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Jungle} roubará o Barão Nashor com smite?",                                                               Label = "Jungle",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que {Jungle} vai farmar mais de 200 minions em 20 minutos?",                                          Label = "Jungle",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O MVP hoje será {Jungle}?",                                                                                Label = "Jungle",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O próximo abate será feito por {Jungle}?",                                                                 Label = "Jungle",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será {Jungle} que destruirá o Nexus?",                                                                     Label = "Jungle",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Hoje, {Jungle} comprará Item Mítico antes dos 10 minutos?",                                                Label = "Jungle",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Jungle} conseguirá dar mais de 10 kills?",                                                                Label = "Jungle",           SkipMinutes = 0,        DurationMinutes = 18000 },
            #endregion

            #region Support
            new (){ Name = "{Support} vai focar no suporte adversário durante a próxima luta?",                                        Label = "Support",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Support} usará a ultimate para iniciar a luta decisiva?",                                                 Label = "Support",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que {Support} terminará a partida sem morrer uma única vez?",                                         Label = "Support",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Support} morrerá pelo menos duas vezes nessa partida?",                                                   Label = "Support",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que {Support} vai farmar mais de 200 minions em 20 minutos?",                                         Label = "Support",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O MVP hoje será {Support}?",                                                                               Label = "Support",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O próximo abate será feito por {Support}?",                                                                Label = "Support",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será {Support} que destruirá o Nexus?",                                                                    Label = "Support",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Hoje, {Support} comprará Item Mítico antes dos 10 minutos?",                                               Label = "Support",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Support} conseguirá dar mais de 10 kills?",                                                               Label = "Support",          SkipMinutes = 0,        DurationMinutes = 18000 },
            #endregion

            #region Equipe
            new (){ Name = "{Equipe} vai derrubar a primeira torre?",                                                                  Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} conquistará o arauto antes dos 15 minutos?",                                                      Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que {Equipe} vai garantir a alma do dragão?",                                                         Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} vai lutar pelo Barão com todos os membros?",                                                      Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O Nexus inimigo cairá devido {Equipe}?",                                                                   Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} vai começar uma luta na selva?",                                                                  Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que {Equipe} pegará o próximo dragão?",                                                               Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} vai derrubar a torre do meio antes dos 15 minutos?",                                              Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} vai fazer um engage decisivo no Barão?",                                                          Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Vai ser {Equipe} que levará o arauto para a rota do topo?",                                                Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} derrotará o dragão em 30 minutos?",                                                               Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} conseguirá fazer o first blood?",                                                                 Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Vai acontecer uma virada épica envolvendo {Equipe}?",                                                      Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} destruirá um inibidor antes dos 20 minutos?",                                                     Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que {Equipe} conseguirá pegar 3 dragões seguidos?",                                                   Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} finalizará o jogo sem perder nenhuma torre?",                                                     Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} fará uma jogada surpreendente no mid game?",                                                      Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} terminarão com KDA positivo para todos os seus jogadores?",                                       Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} conseguirá fazer um ace antes dos 25 minutos?",                                                   Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} executará um dive perfeito na bot lane?",                                                         Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} ganhará sem perder nenhum inibidor?",                                                             Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que {Equipe} irá counterjungling com eficiência adversária?",                                         Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} fará uma composição poke hoje?",                                                                  Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} vencerá a partida com mais de 10k de vantagem de ouro?",                                          Label = "Equipe",           SkipMinutes = 0,        DurationMinutes = 18000 }
            #endregion
        ];

        return TemplateMap.Seed(i, a, e);
    }
}