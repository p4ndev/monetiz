using Monetizacao.Providers.Contexts.Templates;
using Monetizacao.Providers.Contexts.Dtos;
using FluentEmail.Core;

namespace Monetizacao.Providers.Contexts;

public sealed class AccountEmailContext : EmailBuilder
{
    private readonly string _appHost;

    public AccountEmailContext(IFluentEmail _provider, string appHost)
        : base(_provider)
    {
        _appHost = appHost;
    }

    public void Registration(AccountEmailDto dto, CancellationToken token = default)
    {
        AddTo(dto.email);

        AddSubject(ActivationTemplate.Subject);

        AddBody(
            ActivationTemplate.RenderHtml(dto.uid, _appHost, dto.stamp),
            ActivationTemplate.RenderText(dto.uid, _appHost, dto.stamp)
        );
    }

    public void Recovery(AccountEmailDto dto, CancellationToken token = default)
    {
        AddTo(dto.email);

        AddSubject(RecoveryTemplate.Subject);

        AddBody(
            RecoveryTemplate.RenderHtml(dto.uid, dto.stamp, _appHost),
            RecoveryTemplate.RenderText(dto.uid, dto.stamp, _appHost)
        );
    }

    public void Purchase(FinancialEmailDto dto, CancellationToken token = default)
    {
        AddTo(dto.email);

        AddSubject(PurchaseTemplate.Subject);

        var trackFormatted      = $"{dto.trackId}";
        var totalFormatted      = "R$ " + dto.total;
        var coinFormatted       = dto.coins.ToString();
        var periodFormatted     = dto.createdAt.ToString();

        AddBody(
            PurchaseTemplate.RenderHtml(trackFormatted, coinFormatted, totalFormatted, periodFormatted),
            PurchaseTemplate.RenderText(trackFormatted, coinFormatted, totalFormatted, periodFormatted)
        );        
    }

    public async Task<bool> SendAsync(CancellationToken token = default)
        => await SendEmailAsync(token);
}