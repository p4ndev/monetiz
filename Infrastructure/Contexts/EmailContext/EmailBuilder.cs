using FluentEmail.Core;

namespace Monetizacao.Providers.Contexts;

public abstract class EmailBuilder
{
    private readonly IFluentEmail _provider;

    public EmailBuilder(IFluentEmail provider)
    {
        _provider = provider;
    }

    public void AddTo(string email)
        => _provider.To(email);

    public void AddSubject(string content)
        => _provider.Subject(content);

    public void AddBody(string htmlContent, string? plainContent = null)
    {
        _provider.Body(htmlContent, true);

        if(plainContent is not null)
            _provider.PlaintextAlternativeBody(plainContent);
    }

    public async Task<bool> SendEmailAsync(CancellationToken token = default)
    {
        var output = await _provider.SendAsync(token);

        return (output is not null && output.Successful);
    }
}