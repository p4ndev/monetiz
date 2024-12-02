namespace Monetizacao.Providers.Contexts.Templates;

public static class RecoveryTemplate
{
    public static string Subject = "Recupere sua senha";

    private static string HtmlGreetings = "<p>Olá,<br />Clique no link abaixo para atualizar sua senha.<p>";

    private static string TextGreetings = "Clique no link para atualizar sua senha:";

    private static string Footer = "<br /><p>Atenciosamente,<br />MonetizAção</p>";

    private static string BuildLink(long uid, string host, string stamp)
        => $"{host}/?id={uid}&stamp={stamp}&op=recovery";

    private static string BuildHref(long uid, string host, string stamp)
        => $"<a href='{BuildLink(uid, host, stamp)}' target='_blank'>{BuildLink(uid, host, stamp)}</a>";

    public static string RenderHtml(long uid, string stamp, string host)
        => $"{HtmlGreetings}{BuildHref(uid, host, stamp)}{Footer}";

    public static string RenderText(long uid, string stamp, string host)
        => $"{TextGreetings} {BuildHref(uid, host, stamp)}";
}