using Monetizacao.Modules.Financial.Responses;
using Monetizacao.Modules.Financial.Services;
using Monetizacao.Providers.Contexts;
using Monetizacao.Providers.Handlers;
using System.Runtime.Versioning;

namespace ERP.Financial;

[SupportedOSPlatform("windows")]
public partial class Withdraw
    : Form
{
    private List<WithdrawResponse>              _source;
    private readonly string                     _environment;
    private readonly InternalPaymentService     _internalPaymentServices;

    public Withdraw()
    {
        _environment = Properties.Settings.Default.Environment.ToString();

        var uuid = new UUIDHandler();
        var tmz = new TimezoneHandler();
        var ctx = (new FinancialRelationalContextFactory()).CreateDbContext(["--environment=" + _environment]);

        _internalPaymentServices = new(uuid, tmz, ctx);
        _source = new();

        InitializeComponent();
    }

    private async void Withdraw_Load(object sender, EventArgs e)
    {
        _source.Clear();

        _source.AddRange(await _internalPaymentServices.ListWithdrawAsync());

        dgvList.DataSource = _source;
    }

    private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || _source is null || !_source.Any())
            return;

        var idx = e.RowIndex;
        var item = _source[idx];
        var wt = new WithdrawTransfer(item);

        wt.Show();
    }
}