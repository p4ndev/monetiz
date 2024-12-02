using Microsoft.AspNetCore.Http;

namespace Monetizacao.Providers.Handlers;

public class ExceptionHandlerSetup(RequestDelegate _next)
{
    public async Task InvokeAsync(HttpContext context)
    {
		try
		{
            await _next(context);
		}
		catch (Exception ex)
		{
            await context.Response.WriteAsync(ex.Message);
        }
    }
}
