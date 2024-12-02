using Monetizacao.Modules.Account.Requests;
using Monetizacao.Modules.Account.Services;
using Monetizacao.Providers.Contexts.Enums;
using Monetizacao.Providers.Contexts;
using Monetizacao.Providers.Handlers;
using System.Runtime.Versioning;

namespace ERP.Account;

[SupportedOSPlatform("windows")]
public partial class SignIn
    : Form
{
    private Stage               _stageForm;
    private readonly string     _environment;
    private RoleService         _roleService;
    private ClaimService        _claimService;
    private AccessService       _accessService;

    public SignIn(Stage stageForm)
    {
        _stageForm = stageForm;
        _environment = Properties.Settings.Default.Environment.ToString();

        var uuid        = new UUIDHandler();
        var tmz         = new TimezoneHandler();
        var md5         = new Md5CryptoHandler();
        var val         = new ValidationHandler();

        var ctx         = (new AccountRelationalContextFactory()).CreateDbContext(["--environment=" + _environment]);

        _roleService    = new(ctx);
        _claimService   = new(ctx);
        _accessService  = new(val, md5, uuid, tmz, ctx);

        InitializeComponent();
    }

    private async void btnLogIn_Click(object sender, EventArgs e)
    {
        var securePassword = _accessService.EncryptPassword(txtPassword.Text);

        var model = new AccountRequest(txtEmail.Text, securePassword);

        if (!_accessService.IsModelValid(model))
        {
            MessageBox.Show("Your data is invalid, please review.", "Validation Error");
            return;
        }

        var entity = await _accessService.FindAsync(model.email, model.password);

        if (entity is null)
        {
            MessageBox.Show("User unavailable");
            return;
        }

        var claims = await _claimService.ListAsync(entity!.id);

        if (!claims.Any(c => c.Id.Equals(ClaimEnum.HasErpAccess)))
        {
            MessageBox.Show("You cannot access");
            return;
        }

        var role = _roleService.Find(entity!.roleId);

        if(role is not null)
            _stageForm.InitializeAccount(entity, role!, claims);

        this.Close();
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}