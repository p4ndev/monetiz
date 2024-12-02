using Monetizacao.Modules.Account.Responses;
using Monetizacao.Modules.Account.Services;
using Monetizacao.Providers.Contexts;
using Monetizacao.Providers.Handlers;
using System.Runtime.Versioning;
using ERP.Shared;

namespace ERP.Account;

[SupportedOSPlatform("windows")]
public partial class Search
    : Form
{
    private AccessService       _accessService;
    private readonly string     _environment;

    public Search()
    {
        var uuid = new UUIDHandler();
        var tmz = new TimezoneHandler();
        var md5 = new Md5CryptoHandler();
        var val = new ValidationHandler();

        _environment = Properties.Settings.Default.Environment.ToString();
        var ctx = (new AccountRelationalContextFactory()).CreateDbContext(["--environment=" + _environment]);

        _accessService = new(val, md5, uuid, tmz, ctx);

        InitializeComponent();
    }

    private async void btnSearch_Click(object sender, EventArgs e)
    {
        var uid = txtId.Text.ToString();
        var email = txtEmail.Text.ToString();

        BasicAccountResponse? entity = null;

        if (!String.IsNullOrEmpty(uid) && !String.IsNullOrWhiteSpace(uid))
            entity = await _accessService.FindAsync(Convert.ToInt64(uid));
        else if (!String.IsNullOrEmpty(email) && !String.IsNullOrWhiteSpace(email))
            entity = await _accessService.FindAsync(email);

        if(entity is null)
        {
            MessageBox.Show("User was not found");
            return;
        }

        var pl = new Player(entity!);
        pl.Show();
    }
}