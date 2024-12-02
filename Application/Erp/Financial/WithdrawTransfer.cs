using Monetizacao.Modules.Financial.Responses;
using Monetizacao.Modules.Financial.Services;
using Monetizacao.Modules.Account.Services;
using Monetizacao.Providers.Contexts;
using Monetizacao.Providers.Handlers;
using System.Runtime.Versioning;

namespace ERP.Financial;

[SupportedOSPlatform("windows")]
public partial class WithdrawTransfer
    : Form
{
    private readonly WithdrawResponse               _model;
    private readonly string                         _environment;
    private readonly UUIDHandler                    _uuidHandler;
    private readonly TimezoneHandler                _timezoneHandler;
    private readonly AccessService                  _accessService;
    private readonly BalanceService                 _balanceService;
    private readonly CheckoutService                _checkoutService;
    private readonly ActivityService                _activityService;
    private readonly HistoryPixPaymentService       _historyPaymentService;
    private readonly InternalPaymentService         _internalPaymentService;

    public WithdrawTransfer(WithdrawResponse model)
    {
        _model                      = model;
        _environment                = Properties.Settings.Default.Environment.ToString();

        _timezoneHandler            = new();
        _uuidHandler                = new UUIDHandler();

        var md5                     = new Md5CryptoHandler();
        var val                     = new ValidationHandler();

        var ctx0                    = (new FinancialRelationalContextFactory()).CreateDbContext(["--environment=" + _environment]);
        _historyPaymentService      = new(_timezoneHandler, ctx0);
        _balanceService             = new(_uuidHandler, val, ctx0);
        _checkoutService            = new(_uuidHandler, val, ctx0);
        _internalPaymentService     = new(_uuidHandler, _timezoneHandler, ctx0);

        var ctx1                    = (new AccountRelationalContextFactory()).CreateDbContext(["--environment=" + _environment]);
        _accessService              = new(val, md5, _uuidHandler, _timezoneHandler, ctx1);
        _activityService            = new(_uuidHandler, ctx1);


        InitializeComponent();
    }

    private async void btnDecline_Click(object sender, EventArgs e)
    {
        long                ipi         = _model.ipi;
        long                uid         = _model.uid;
        string              reason      = txtMessage.Text.ToString();
        string              receipt     = txtReceiptUrl.Text.ToString();
        long                epi         = Convert.ToInt64(txtTransactionId.Text.ToString());
        string?             stamp       = await _internalPaymentService.StampAsync(ipi);

        if(stamp is null)
        {
            MessageBox.Show("We cannot identify the payment");
            return;
        }

        await _activityService.AddWithdrawAsync(uid, _model.coins, ipi, epi, stamp!);
        await _activityService.PersistAccountAsync();

        await _balanceService.AddAfterPaymentAsync(uid, ipi, _model.coins, stamp!);
        await _balanceService.PersistFinancialAsync();

        await _internalPaymentService.RemoveAsync(uid, ipi);
        await _historyPaymentService.DeclineBrazilianManualPaymentAsync(uid, ipi, epi, receipt, reason);
        await _historyPaymentService.PersistFinancialAsync(default, 2);

        MessageBox.Show("Withdraw was declined", "Decline", MessageBoxButtons.OK, MessageBoxIcon.Error);

        this.Close();
    }

    private async void btnTransfer_Click(object sender, EventArgs e)
    {
        long                ipi         = _model.ipi;
        long                uid         = _model.uid;
        string              information = txtMessage.Text.ToString();
        string              receipt     = txtReceiptUrl.Text.ToString();
        long                epi         = Convert.ToInt64(txtTransactionId.Text.ToString());
        string?             stamp       = await _internalPaymentService.StampAsync(ipi);

        if (stamp is null)
        {
            MessageBox.Show("We cannot identify the payment");
            return;
        }

        await _activityService.AddWithdrawAsync(uid, _model.coins, ipi, epi, stamp!);
        await _activityService.PersistAccountAsync();
        
        await _internalPaymentService.RemoveAsync(uid, ipi);
        await _historyPaymentService.DeclineBrazilianManualPaymentAsync(uid, ipi, epi, receipt, information);
        await _historyPaymentService.PersistFinancialAsync(default, 2);

        MessageBox.Show("Withdraw was completed", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);

        this.Close();
    }
}