using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class SoccerTemplatMap
{
    public static long Seed(long i, EntityTypeBuilder<TemplateEntity> e)
    {
        List<TemplateDto> a = [
            #region Goleiro
            new() { Name = "{Goleiro} defenderá um chute de fora da área hoje?",                                                    Label = "Goleiro",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Goleiro} pegará dois pênaltis seguidos?",                                                              Label = "Goleiro",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "Haverá um gol de cabeça que {Goleiro} levará?",                                                         Label = "Goleiro",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "Haverá uma defesa espetacular feita por {Goleiro}?",                                                    Label = "Goleiro",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Goleiro} fará uma defesa decisiva nos últimos minutos?",                                               Label = "Goleiro",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Goleiro} sofrerá um gol de falta no primeiro tempo?",                                                  Label = "Goleiro",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Goleiro} sofrerá um gol de falta no segundo tempo?",                                                   Label = "Goleiro",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "Será que {Goleiro} será MVP hoje?",                                                                     Label = "Goleiro",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "Será que {Goleiro} vai fazer o gol da vitória nos últimos minutos?",                                    Label = "Goleiro",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Goleiro} levará um cartão amarelo por atrasar o tiro de meta?",                                        Label = "Goleiro",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Goleiro} levará um cartão amarelo por reclamar com o árbitro?",                                        Label = "Goleiro",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "Hoje, {Goleiro} dará uma assistência com um chutão do gol?",                                            Label = "Goleiro",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "Veremos {Goleiro} jogando de atacante nos minutos finais na área adversária?",                          Label = "Goleiro",          SkipMinutes = 0,        DurationMinutes = 18000 },
            #endregion

            #region Atacante
            new() { Name = "Hoje o bandeirinha anulará ao menos um gol de {Atacante}?",                                             Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} marcará no primeiro tempo?",                                                                 Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} marcará no segundo tempo?",                                                                  Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} marcará no hoje?",                                                                           Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} será MVP hoje?",                                                                             Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} ficará em branco na partida?",                                                               Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} marcará pelo menos um gol hoje?",                                                            Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} marcará um gol de calcanhar hoje?",                                                          Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} marcará um gol de perna esquerda hoje?",                                                     Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} marcará um gol de perna direita hoje?",                                                      Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} fará um gol de cabeça hoje?",                                                                Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "Veremos {Atacante} fazer um gol de bicicleta nessa partida?",                                           Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "Vai rolar um hat-trick hoje dos pés de {Atacante}?",                                                    Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} vai acertar um chute no travessão hoje?",                                                    Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} não sairá hoje?",                                                                            Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} sairá no segundo tempo?",                                                                    Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} sairá no primeiro tempo?",                                                                   Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} levará um cartão amarelo hoje?",                                                             Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} levará um cartão amarelo no primeiro tempo?",                                                Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} levará um cartão amarelo no segundo tempo?",                                                 Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} levará um cartão vermelho hoje?",                                                            Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} levará um cartão vermelho no primeiro tempo?",                                               Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Atacante} levará um cartão vermelho no segundo tempo?",                                                Label = "Atacante",         SkipMinutes = 0,        DurationMinutes = 18000 },
            #endregion

            #region Meio-campista
            new() { Name = "Será que {Meio-campista} dará uma assistência para o gol de hoje?",                                     Label = "Meio-campista",    SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "Veremos uma caneta feita por {Meio-campista} no jogo de hoje?",                                         Label = "Meio-campista",    SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Meio-campista} marcará no hoje?",                                                                      Label = "Meio-campista",    SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Meio-campista} será MVP hoje?",                                                                        Label = "Meio-campista",    SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Meio-campista} fará um gol de cabeça hoje?",                                                           Label = "Meio-campista",    SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Meio-campista} vai acertar um chute no travessão hoje?",                                               Label = "Meio-campista",    SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Meio-campista} não sairá hoje?",                                                                       Label = "Meio-campista",    SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Meio-campista} sairá no segundo tempo?",                                                               Label = "Meio-campista",    SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Meio-campista} sairá no primeiro tempo?",                                                              Label = "Meio-campista",    SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Meio-campista} levará um cartão amarelo hoje?",                                                        Label = "Meio-campista",    SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Meio-campista} levará um cartão amarelo no primeiro tempo?",                                           Label = "Meio-campista",    SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Meio-campista} levará um cartão amarelo no segundo tempo?",                                            Label = "Meio-campista",    SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Meio-campista} levará um cartão vermelho hoje?",                                                       Label = "Meio-campista",    SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Meio-campista} levará um cartão vermelho no primeiro tempo?",                                          Label = "Meio-campista",    SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Meio-campista} levará um cartão vermelho no segundo tempo?",                                           Label = "Meio-campista",    SkipMinutes = 0,        DurationMinutes = 18000 },
            #endregion

            #region Lateral
            new() { Name = "Vai rolar um gol olímpico dos pés de {Lateral}?",                                                       Label = "Lateral",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Lateral} marcará no hoje?",                                                                            Label = "Lateral",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Lateral} será MVP hoje?",                                                                              Label = "Lateral",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Lateral} fará um gol de cabeça hoje?",                                                                 Label = "Lateral",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Lateral} cometerá uma falta perigosa dentro da área?",                                                 Label = "Lateral",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Lateral} cometerá uma falta perigosa fora da área?",                                                   Label = "Lateral",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Lateral} não sairá hoje?",                                                                             Label = "Lateral",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Lateral} sairá no segundo tempo?",                                                                     Label = "Lateral",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Lateral} sairá no primeiro tempo?",                                                                    Label = "Lateral",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Lateral} levará um cartão amarelo hoje?",                                                              Label = "Lateral",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Lateral} levará um cartão amarelo no primeiro tempo?",                                                 Label = "Lateral",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Lateral} levará um cartão amarelo no segundo tempo?",                                                  Label = "Lateral",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Lateral} levará um cartão vermelho hoje?",                                                             Label = "Lateral",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Lateral} levará um cartão vermelho no primeiro tempo?",                                                Label = "Lateral",          SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Lateral} levará um cartão vermelho no segundo tempo?",                                                 Label = "Lateral",          SkipMinutes = 0,        DurationMinutes = 18000 },
            #endregion

            #region Zagueiro
            new() { Name = "{Zagueiro} marcará no hoje?",                                                                           Label = "Zagueiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Zagueiro} fará ao menos um desarme com gol ao final?",                                                 Label = "Zagueiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Zagueiro} será MVP hoje?",                                                                             Label = "Zagueiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Zagueiro} fará um gol de cabeça hoje?",                                                                Label = "Zagueiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Zagueiro} cometerá uma falta perigosa dentro da área?",                                                Label = "Zagueiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Zagueiro} não sairá hoje?",                                                                            Label = "Zagueiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Zagueiro} sairá no segundo tempo?",                                                                    Label = "Zagueiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Zagueiro} sairá no primeiro tempo?",                                                                   Label = "Zagueiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Zagueiro} levará um cartão amarelo hoje?",                                                             Label = "Zagueiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Zagueiro} levará um cartão amarelo no primeiro tempo?",                                                Label = "Zagueiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Zagueiro} levará um cartão amarelo no segundo tempo?",                                                 Label = "Zagueiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Zagueiro} levará um cartão vermelho hoje?",                                                            Label = "Zagueiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Zagueiro} levará um cartão vermelho no primeiro tempo?",                                               Label = "Zagueiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Zagueiro} levará um cartão vermelho no segundo tempo?",                                                Label = "Zagueiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Zagueiro} cometerá um penalty?",                                                                       Label = "Zagueiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            #endregion
        
            #region Time
            new() { Name = "Terá um pênalti para equipe do {Time} no segundo tempo?",                                               Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "Terá um pênalti para equipe do {Time} no primeiro tempo?",                                              Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Time} marcará um gol de bola parada hoje?",                                                            Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Time} marcará um gol no primeiro tempo?",                                                              Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Time} marcará um gol no segundo tempo?",                                                               Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "Hoje a equipe do {Time} não marcará um gol?",                                                           Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Time} cometerá pênalti hoje?",                                                                         Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Time} errará um gol feito hoje?",                                                                      Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Time} vai errar um pênalti hoje?",                                                                     Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "Haverá mais de duas substituições na equipe do {Time} hoje?",                                           Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Time} terminará o jogo com maior posse de bola?",                                                      Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Time} terminará o jogo com menor posse de bola?",                                                      Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Time} vai ganhar mesmo tendo menor posse de bola?",                                                    Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Time} vai perder mesmo tendo maior posse de bola?",                                                    Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "O capitão do {Time} será substituído nessa partida?",                                                   Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Time} vai iniciar o jogo perdendo, mas terminará vencedora?",                                          Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Time} vai iniciar o jogo ganhando, mas terminará perdedora?",                                          Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Time} terminará o jogo com apenas 8 jogadores em campo?",                                              Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Time} terminará o jogo com apenas 9 jogadores em campo?",                                              Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 },
            new() { Name = "{Time} terminará o jogo com apenas 10 jogadores em campo?",                                             Label = "Time",             SkipMinutes = 0,        DurationMinutes = 18000 }
            #endregion
        ];

        return TemplateMap.Seed(i, a, e);
    }
}