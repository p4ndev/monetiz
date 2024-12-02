using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class ValorantMap
{
    public static long Seed(long i, EntityTypeBuilder<TemplateEntity> e)
    {
        List<TemplateDto> a = [
            #region Sentinel
            new (){ Name = "Irá {Sentinel} defender o Spike site A até o final do round?",                                            Label = "Sentinel",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Conseguirá {Sentinel} desarmar a bomba a tempo, mesmo sob fogo inimigo?",                                 Label = "Sentinel",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Conseguirá {Sentinel} se posicionar para um flanco inesperado e derrubar dois adversários?",              Label = "Sentinel",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Conseguirá {Sentinel} se posicionar para um flanco inesperado e derrubar todos os adversários?",          Label = "Sentinel",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Defenderá {Sentinel} o ponto B com sucesso, impedindo o avanço inimigo por 30 segundos?",                 Label = "Sentinel",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Usará {Sentinel} sua ultimate para retomar o controle do site?",                                          Label = "Sentinel",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será bem-sucedido o lurking de {Sentinel} para obter informação crucial?",                                Label = "Sentinel",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Um ninja defuse será executado por {Sentinel} enquanto o time inimigo está distraído?",                   Label = "Sentinel",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Sentinel} vai neutralizar uma armadilha antes de entrar no site?",                                       Label = "Sentinel",          SkipMinutes = 0,        DurationMinutes = 18000 },
            #endregion

            #region Initiator
            new (){ Name = "{Initiator} vai utilizar uma habilidade para cegar um oponente, facilitando a entrada no site?",          Label = "Initiator",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será {Initiator} capaz de garantir uma eliminação com um ultimate bem-timed?",                            Label = "Initiator",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Vai acertar {Initiator} uma Shock Dart decisiva para eliminar o spike carrier?",                          Label = "Initiator",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que o uso estratégico da ultimate de {Initiator} vai virar o jogo?",                                 Label = "Initiator",         SkipMinutes = 0,        DurationMinutes = 18000 },
            #endregion

            #region Duelist
            new (){ Name = "{Duelist} será capaz de eliminar dois inimigos com headshots consecutivos enquanto flanqueia?",           Label = "Duelist",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Duelist} será capaz de eliminar dois inimigos com headshots?",                                           Label = "Duelist",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Duelist} irá eliminar o operador inimigo durante o avanço no meio?",                                     Label = "Duelist",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Conseguirá {Duelist} um 4k com apenas uma carga da Vandal?",                                              Label = "Duelist",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Duelist} vai executar um cross-hair placement perfeito em todos os duelos?",                             Label = "Duelist",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Um headshot duplo será realizado por {Duelist} ao defender o spike?",                                     Label = "Duelist",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Duelist} fará um flanco surpresa e eliminará um adversário importante nesse round?",                     Label = "Duelist",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que um ace será conquistado por {Duelist} nesta partida?",                                           Label = "Duelist",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Duelist} conseguirá fazer um clutch 1v3 no site A?",                                                     Label = "Duelist",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Duelist} vai acertar uma Operator no adversário através da smoke?",                                      Label = "Duelist",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Um spray transfer para três eliminações será feito por {Duelist}?",                                       Label = "Duelist",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Um clutch impressionante será realizado por {Duelist} no overtime?",                                      Label = "Duelist",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Duelist} conseguirá um collateral com a Operator através da parede fina?",                               Label = "Duelist",           SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Conseguirá {Duelist} um ace usando apenas a pistola clássica?",                                           Label = "Duelist",           SkipMinutes = 0,        DurationMinutes = 18000 },
            #endregion

            #region Controller
            new (){ Name = "{Controller} conseguirá plantar a bomba sem ser detectado pelo time adversário?",                         Label = "Controller",        SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Controller} será o último sobrevivente e clutchará o round para sua equipe?",                            Label = "Controller",        SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Conseguirá {Controller} um wallbang kill através da caixa no meio?",                                      Label = "Controller",        SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Conseguirá {Controller} interceptar com sucesso uma rotação inimiga sozinho?",                            Label = "Controller",        SkipMinutes = 0,        DurationMinutes = 18000 },
            #endregion

            #region Equipe
            new (){ Name = "{Equipe} proverá a cobertura necessária para plantar a bomba no ponto B?",                                Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Conseguirá {Equipe} defender o ponto B sem perder nenhum jogador?",                                       Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que {Equipe} será capaz de fazer um retake com sucesso após o plant no site C?",                     Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} eliminará o último oponente enquanto defende o site A?",                                         Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Irá {Equipe} segurar o bomb site até o timer do round acabar?",                                           Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Conseguirá {Equipe} executar uma estratégia de fake no ponto A?",                                         Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será {Equipe} capaz de fazer um eco round vitorioso?",                                                    Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} vai rotacionar rapidamente após o primeiro pick?",                                               Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Poderá {Equipe} defender o plant sem perder nenhum jogador?",                                             Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será providenciado pela {Equipe} a cobertura para um colega plantar a spike?",                            Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} executará com sucesso uma estratégia 'fake' no site B?",                                         Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} conseguirá um 'eco round win' com armas leves?",                                                 Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} fará uma rotação rápida para surpreender os oponentes?",                                         Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Um 'retake' bem-sucedido do site A será realizado pela {Equipe}?",                                        Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Conseguirá {Equipe} manter o controle do mapa durante toda a rodada?",                                    Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} vai garantir o first blood em 3 rounds consecutivos?",                                           Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} garantirá o first blood?",                                                                       Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que {Equipe} vai optar por uma composição agressiva com 3 duelistas?",                               Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Uma defesa perfeita será mantida pela {Equipe} no primeiro half?",                                        Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} utilizará uma combinação de ultimates para vencer o round decisivo?",                            Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} executará uma estratégia de rush bem-sucedida no pistol round?",                                 Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que {Equipe} conseguirá um 'flawless round' na rodada decisiva?",                                    Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} vai manter uma economia perfeita ao longo de todo o primeiro half?",                             Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Uma defesa impenetrável do spike será mantida pela {Equipe} por 3 rounds seguidos?",                      Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Conseguirá {Equipe} executar um 'retake' perfeito sem perder nenhum jogador?",                            Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} vai surpreender os adversários com uma composição não-meta?",                                    Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} ganhará todos os duelos iniciais em um half inteiro?",                                           Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Uma estratégia de 'double fake' será executada com sucesso pela {Equipe}?",                               Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "{Equipe} conseguirá vencer a partida sem perder um único round de eco?",                                  Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Vai {Equipe} manter o controle do 'orb' central durante toda a partida?",                                 Label = "Equipe",            SkipMinutes = 0,        DurationMinutes = 18000 }
            #endregion
        ];

        return TemplateMap.Seed(i, a, e);
    }
}