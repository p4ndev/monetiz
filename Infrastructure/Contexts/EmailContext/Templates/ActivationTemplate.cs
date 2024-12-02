namespace Monetizacao.Providers.Contexts.Templates;

public static class ActivationTemplate
{
    public static string Subject = "Ative sua conta";

    private static string HtmlGreetings = "<p>Olá,<br />Entre com seu email e senha, em seguida clique no link para ativar sua conta.<p>";

    private static string TextGreetings = "Clique no link para ativar sua conta:";

    private static string Footer = "<br /><p>Atenciosamente,<br />MonetizAção</p>";

    private static string BuildLink(long uid, string host, string stamp)
        => $"{host}/?id={uid}&stamp={stamp}&op=activation";

    private static string BuildHref(long uid, string host, string stamp)
        => $"<a href='{BuildLink(uid, host, stamp)}' target='_blank'>{BuildLink(uid, host, stamp)}</a>";

    public static string RenderHtml(long uid, string host, string stamp)
        => $"{HtmlGreetings}{BuildHref(uid, host, stamp)}{Footer}";

    public static string RenderText(long uid, string host, string stamp)
        => $"{TextGreetings} {BuildLink(uid, host, stamp)}";
}