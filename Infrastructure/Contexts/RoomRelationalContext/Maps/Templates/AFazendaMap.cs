using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class AFazendaMap
{
    public static long Seed(long i, EntityTypeBuilder<TemplateEntity> e)
    {
        List<TemplateDto> a = [
            #region Peões
            new (){ Name = "As tarefas envolvendo a vaca e o touro serão destinados ao {Peao}?",                    Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "Será que as ovelhas serão cuidadas pelo {Peao}?",                                       Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "As mini-cabras serão cuidadas pelo {Peao}?",                                            Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "Hortas e plantas serão cuidadas pelo {Peao}?",                                          Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "As tarefas do lixo serão destinadas à {Peao}?",                                         Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "O {Peao} cuidará dos porcos?",                                                          Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "O {Peao} será expulsa?",                                                                Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "O {Peao} desistirá do programa?",                                                       Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "O {Peao} vai para baia?",                                                               Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "O {Peao} formará um casal na edição?",                                                  Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "O {Peao} ganhará imunidade?",                                                           Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "O {Peao} vai parar na roça?",                                                           Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "Haverá discussão envolvendo {Peao}?",                                                   Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "O {Peao} irá reclamar de fazer alguma tarefa?",                                         Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "O {Peao} vai cair em lágrimas?",                                                        Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "O {Peao} causará confusão durante a festa?",                                            Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "O {Peao} ficará isolada dos grupos?",                                                   Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "O {Peao} será a mais votada essa semana pela fazenda?",                                 Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "A punição dessa semana será causada pelo {Peao}?",                                      Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "Algum participante vai consider o {Peao} a planta da edição?",                          Label = "Peao",     SkipMinutes = 0,    DurationMinutes = 2880 },
            #endregion

            #region Peoas            
            new (){ Name = "As tarefas envolvendo a vaca e o touro serão destinados a {Peoa}?",                     Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "Será que as ovelhas serão cuidadas pela {Peoa}?",                                       Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "As mini cabras serão cuidadas pela {Peoa}?",                                            Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "Hortas e plantas serão cuidadas pela {Peoa}?",                                          Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "As tarefas do lixo serão destinadas à {Peoa}?",                                         Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "A {Peoa} cuidará dos porcos?",                                                          Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "A {Peoa} será expulsa?",                                                                Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "A {Peoa} desistirá do programa?",                                                       Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "A {Peoa} vai para baia?",                                                               Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "A {Peoa} formará um casal na edição?",                                                  Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "A {Peoa} ganhará imunidade?",                                                           Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "A {Peoa} vai parar na roça?",                                                           Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "Haverá discussão envolvendo {Peoa}?",                                                   Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "A {Peoa} irá reclamar de fazer alguma tarefa?",                                         Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "A {Peoa} vai cair em lágrimas?",                                                        Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "A {Peoa} causará confusão durante a festa?",                                            Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "A {Peoa} ficará isolada dos grupos?",                                                   Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "A {Peoa} será a mais votada essa semana pela fazenda?",                                 Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "A punição dessa semana será causada pela {Peoa}?",                                      Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            new (){ Name = "Algum participante vai consider a {Peoa} a planta da edição?",                          Label = "Peoa",     SkipMinutes = 0,    DurationMinutes = 2880 },
            #endregion
        ];

        return TemplateMap.Seed(i, a, e);
    }
}