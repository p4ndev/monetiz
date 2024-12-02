#region Namespaces
using Monetizacao.Providers.Contexts;
using Monetizacao.Providers.Handlers;

using Monetizacao.Modules.Financial;
using Monetizacao.Modules.Account;
using Monetizacao.Modules.Lobby;
using Monetizacao.Modules.Room;

using Newtonsoft.Json;
#endregion

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddHealthChecks();

#region Handlers
builder.Services.AddUUIDHandler();
builder.Services.AddCorsHandler();
builder.Services.AddCryptoHandler();
builder.Services.AddTimezoneHandler();
builder.Services.AddValidationHandler();
#endregion

#region Contexts
builder.Services.AddEmailContext();
builder.Services.AddMercadoPagoContext();
builder.Services.AddAccountRelationalContext();
builder.Services.AddLobbyRelationalContext();
builder.Services.AddRoomRelationalContext();
builder.Services.AddFinancialRelationalContext();
#endregion

#region Modules
builder.Services.AddAccountModule();
builder.Services.AddLobbyModule();
builder.Services.AddRoomModule();
builder.Services.AddFinancialModule();
#endregion

builder
    .Services
    .AddControllers()
    .AddNewtonsoftJson(o => {
        o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddProblemDetails();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen(c => {
    c.TagActionsBy(api => new List<string> { api.RelativePath });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
    app.UseHsts();
}

app.UseMiddleware<ExceptionHandlerSetup>();
app.UseHealthChecks("/Health");
app.UseStatusCodePages();
app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors();
app.Run();