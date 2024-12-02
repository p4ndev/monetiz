using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class AGrandeConquistaMap
{
    public static long Seed(long i, EntityTypeBuilder<TemplateEntity> e)
    {
        List<TemplateDto> a = [
            #region Conquisteira        
            new (){ Name = "A {Conquisteira} se tornará dona?",                                                     Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A casa votará na {Conquisteira} para zona de risco?",                                   Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A {Conquisteira} vai esquecer o microfone causando punição?",                           Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Vai rolar uma paquera entre a {Conquisteira}?",                                         Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que a {Conquisteira} vai desistir do programa?",                                   Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A {Conquisteira} formará uma aliança forte?",                                           Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que o público vai salvar a {Conquisteira} da eliminação?",                         Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A {Conquisteira} vai ganhar a prova bate e volta?",                                     Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A {Conquisteira} será expulso por quebrar regras?",                                     Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que a {Conquisteira} vai ganhar imunidade?",                                       Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A {Conquisteira} vai causar uma treta na casa?",                                        Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A {Conquisteira} vai desistir do reality show?",                                        Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A {Conquisteira} vai trair sua aliança?",                                               Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A {Conquisteira} será a mais votada?",                                                  Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A eliminação envolverá a {Conquisteira}?",                                              Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A {Conquisteira} conseguirá escapar da zona de risco?",                                 Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O público escolherá a {Conquisteira} para continuar no jogo?",                          Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A {Conquisteira} vai manipular outro participante para evitar a zona de risco?",        Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A {Conquisteira} irá reclamar sobre comida?",                                           Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A {Conquisteira} será indicado pelo dono da casa?",                                     Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A {Conquisteira} vai salvar alguém da eliminação?",                                     Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A {Conquisteira} conseguirá imunidade ao vencer a prova?",                              Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A {Conquisteira} mudará de estratégia para permanecer no jogo?",                        Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A {Conquisteira} vai sofrer uma lesão durante a prova?",                                Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Haverá uma discussão e a {Conquisteira} fará parte?",                                   Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A casa votará na {Conquisteira} para sair?",                                            Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Haverá fala polêmica no jogo, e a {Conquisteira} participará?",                         Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Não haverá posicionamento vindo da {Conquisteira}?",                                    Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que a {Conquisteira} ganhará uma viagem durante a prova?",                         Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que a {Conquisteira} ganhará um carro durante a prova?",                           Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A casa inteira vai se virar contra a {Conquisteira}?",                                  Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Uma briga feia vai rolar entre a {Conquisteira}?",                                      Label = "Conquisteira",         SkipMinutes = 0,        DurationMinutes = 18000 },
            #endregion

            #region Conquisteiro
            new (){ Name = "O {Conquisteiro} se tornará dono?",                                                     Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A casa votará no {Conquisteiro} pra zona de risco?",                                    Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O {Conquisteiro} vai esquecer o microfone causando punição?",                           Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Vai rolar uma paquera entre o {Conquisteiro}?",                                         Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que o {Conquisteiro} vai desistir?",                                               Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O {Conquisteiro} formará uma aliança forte?",                                           Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que o público vai salvar o {Conquisteiro} da eliminação?",                         Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O {Conquisteiro} vai ganhar a prova bate e volta?",                                     Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O {Conquisteiro} será expulso por quebrar regras?",                                     Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que o {Conquisteiro} vai ganhar uma imunidade?",                                   Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O {Conquisteiro} vai causar uma treta?",                                                Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O {Conquisteiro} vai desistir?",                                                        Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O {Conquisteiro} vai trair a aliança?",                                                 Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O {Conquisteiro} será o mais votado pela casa?",                                        Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A eliminação será entre o {Conquisteiro}?",                                             Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O {Conquisteiro} conseguirá escapar da zona de risco?",                                 Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O público escolherá o {Conquisteiro} para continuar no jogo?",                          Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O {Conquisteiro} vai manipular outro participante para evitar a zona de risco?",        Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O {Conquisteiro} irá reclamar de alguma sobre comida?",                                 Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O {Conquisteiro} será indicado pelo dono da casa?",                                     Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O {Conquisteiro} vai salvar um amigo da eliminação?",                                   Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O {Conquisteiro} conseguirá imunidade ao vencer a prova?",                              Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O {Conquisteiro} mudará de estratégia para permanecer no jogo?",                        Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "O {Conquisteiro} vai sofrer uma lesão durante a prova?",                                Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Haverá uma discussão envolvendo o {Conquisteiro}?",                                     Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A casa votará no {Conquisteiro} para sair na zona de risco?",                           Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Haverá fala polêmica no jogo, e o {Conquisteiro} participará?",                         Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Haverá posicionamento do {Conquisteiro}?",                                              Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que o {Conquisteiro} ganhará uma viagem durante a prova?",                         Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Será que o {Conquisteiro} ganhará um carro durante a prova?",                           Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "A casa toda vai se virar contra o {Conquisteiro}?",                                     Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 },
            new (){ Name = "Uma briga feia vai rolar entre o {Conquisteiro} e outro participante?",                 Label = "Conquisteiro",         SkipMinutes = 0,        DurationMinutes = 18000 }
            #endregion
        ];

        return TemplateMap.Seed(i, a, e);
    }
}