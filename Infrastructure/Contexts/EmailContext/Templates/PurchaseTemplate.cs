using System.Text;

namespace Monetizacao.Providers.Contexts.Templates;

public static class PurchaseTemplate
{
    public static string Subject = "Compra efetuada";

    private static string HtmlGreetings = "<p>Olá,<br />Sua compra foi efetuada com sucesso.<p>";

    private static string TextGreetings = "Sua compra foi efetuada com sucesso.";

    private static string Footer = "<br /><p>Atenciosamente,<br />MonetizAção</p>";

    private static string BuildList(string trackId, string coins, string total, string createdAt)
    {
        StringBuilder sb = new();

        sb.Append("<ul>");

            sb.Append($"<li><em>{coins}</em> moedas a <em>{total}</em>;</li>");
            sb.Append($"<li>Id: <strong>{trackId}</strong>;</li>");
            sb.Append($"<li>{createdAt};</li>");

        sb.Append("</ul>");

        return sb.ToString();
    }

    private static string BuildItem(string trackId, string coins, string total, string createdAt)
        => $"{coins} em moedas a {total}, id: {trackId} @ {createdAt}";

    public static string RenderHtml(string trackId, string coins, string total, string createdAt)
        => $"{HtmlGreetings}{BuildList(trackId, coins, total, createdAt)}{Footer}";

    public static string RenderText(string trackId, string coins, string total, string createdAt)
        => $"{TextGreetings} {BuildItem(trackId, coins, total, createdAt)}";
}