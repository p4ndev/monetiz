using Monetizacao.Modules.Financial.Services;
using Monetizacao.Modules.Account.Responses;
using Monetizacao.Modules.Account.Services;
using Monetizacao.Modules.Room.Services;
using Monetizacao.Providers.Handlers;
using Monetizacao.Providers.Contexts;
using System.Runtime.Versioning;

namespace ERP.Shared;

[SupportedOSPlatform("windows")]
public partial class Player
    : Form
{    
    private readonly BasicAccountResponse       _model;
    private string                              _waiting;
    private readonly List<string>               _headlines;
    private readonly string                     _environment;

    private readonly InternalPaymentService     _internalPaymentService;
    private readonly BalanceService             _balanceService;
    private readonly AccessService              _accessService;
    private readonly ActionService              _actionService;
    private readonly AnswerService              _answerService;
    private readonly ClaimService               _claimService;
    private readonly RoleService                _roleService;
    private readonly PixService                 _pixService;

    private readonly TreeNode                   _accountNode;
    private readonly TreeNode                   _roleNode;
    private readonly TreeNode                   _claimsNode;

    private readonly TreeNode                   _bankNode;
    private readonly TreeNode                   _purchaseNode;
    private readonly TreeNode                   _withdrawsNode;

    private readonly TreeNode                   _answersNode;

    private readonly TreeNode                   _creditsNode;
    private readonly TreeNode                   _debitsNode;

    private bool 
        accountLoaded,      roleLoaded,         claimLoaded,
        bankLoaded,         purchaseLoaded,     withdrawLoaded,
        answersLoaded,      creditsLoaded,      debitsLoaded;

    public Player(BasicAccountResponse model)
    {
        _waiting                    = "Aguardando...";

        _model                      = model;

        _headlines                  = new() {
            "Account",
            "Role",
            "Claims",
            "Pix",
            "Active Purchase (IPI.EPI)",
            "Active Withdraw (IPI.EPI)",
            "Answers (GID.AID # AID)",
            "Credits (BID)",
            "Debits (BID)"
        };

        _accountNode                = new TreeNode(_headlines[0]);
        _roleNode                   = new TreeNode(_headlines[1]);
        _claimsNode                 = new TreeNode(_headlines[2]);

        _bankNode                   = new TreeNode(_headlines[3]);
        _purchaseNode               = new TreeNode(_headlines[4]);
        _withdrawsNode              = new TreeNode(_headlines[5]);

        _answersNode                = new TreeNode(_headlines[6]);

        _creditsNode                = new TreeNode(_headlines[7]);
        _debitsNode                 = new TreeNode(_headlines[8]);

        _environment                = Properties.Settings.Default.Environment.ToString();

        var val                     = new ValidationHandler();
        var md5                     = new Md5CryptoHandler();
        var uuid                    = new UUIDHandler();
        var tmz                     = new TimezoneHandler();

        var ctx0                    = (new AccountRelationalContextFactory()).CreateDbContext(["--environment=" + _environment]);
        _accessService              = new(val, md5, uuid, tmz, ctx0);
        _roleService                = new(ctx0);
        _claimService               = new(ctx0);

        var ctx1                    = (new FinancialRelationalContextFactory()).CreateDbContext(["--environment=" + _environment]);
        _internalPaymentService     = new(uuid, tmz, ctx1);
        _balanceService             = new(uuid, val, ctx1);
        _pixService                 = new(tmz, val, ctx1);

        var ctx2                    = (new RoomRelationalContextFactory()).CreateDbContext(["--environment=" + _environment]);
        _actionService              = new(tmz, val, ctx2);
        _answerService              = new(ctx2);

        accountLoaded               = false;
        roleLoaded                  = false;
        claimLoaded                 = false;
        bankLoaded                  = false;
        purchaseLoaded              = false;
        withdrawLoaded              = false;
        answersLoaded               = false;
        creditsLoaded               = false;
        debitsLoaded                = false;

        InitializeComponent();
    }

    private void Pix_Load(object sender, EventArgs e)
    {
        this.Text = _model.fullName;

        FillHeadlines();
    }

    private void FillHeadlines()
    {
        tvPix.Nodes.Clear();

        // ================================================
        // ================================================
        // ================================================

        _accountNode.Nodes.Add(new TreeNode(_waiting));
        _roleNode.Nodes.Add(new TreeNode(_waiting));
        _claimsNode.Nodes.Add(new TreeNode(_waiting));

        _bankNode.Nodes.Add(new TreeNode(_waiting));
        _purchaseNode.Nodes.Add(new TreeNode(_waiting));
        _withdrawsNode.Nodes.Add(new TreeNode(_waiting));

        _answersNode.Nodes.Add(new TreeNode(_waiting));

        _creditsNode.Nodes.Add(new TreeNode(_waiting));
        _debitsNode.Nodes.Add(new TreeNode(_waiting));

        // ================================================
        // ================================================
        // ================================================

        tvPix.Nodes.Add(_accountNode);
        tvPix.Nodes.Add(_roleNode);
        tvPix.Nodes.Add(_claimsNode);

        tvPix.Nodes.Add(_bankNode);
        tvPix.Nodes.Add(_purchaseNode);
        tvPix.Nodes.Add(_withdrawsNode);

        tvPix.Nodes.Add(_answersNode);

        tvPix.Nodes.Add(_creditsNode);
        tvPix.Nodes.Add(_debitsNode);
    }

    private void tvPix_DoubleClick(object sender, EventArgs e)
    {
        if (tvPix.SelectedNode == null)
            return;

        string selectedNodeText = tvPix.SelectedNode.Text;

        Clipboard.SetText(selectedNodeText);

        MessageBox.Show("Item copied to the clipboard.");
    }

    private void tvPix_AfterExpand(object sender, TreeViewEventArgs e)
    {
        if (e.Node is null)
            return;

        string  t = e.Node!.Text;
        int     i = 0;

        foreach (var h in _headlines)
        {
            if (h.Equals(t))
                break;

            i++;
        }

        switch (i)
        {
            case 0:     LoadAccountAsync();             break;
            case 1:     LoadRoleAsync();                break;
            case 2:     LoadClaimsAsync();              break;

            case 3:     LoadPixAsync();                 break;
            case 4:     LoadPendingPurchaseAsync();     break;
            case 5:     LoadWithdrawAsync();            break;

            case 6:     LoadAnswersAsync();             break;

            case 7:     LoadCreditsAsync();             break;
            case 8:     LoadDebitsAsync();              break;
        }
    }

    public async void LoadAccountAsync()
    {
        if (accountLoaded)
            return;

        var entity = await _accessService.FindAsync(_model.id);

        if (entity is null)
            return;

        _accountNode.Nodes.Clear();

        _accountNode.Nodes.Add(new TreeNode(entity.id.ToString()));
        _accountNode.Nodes.Add(new TreeNode(entity.fullName));
        _accountNode.Nodes.Add(new TreeNode(entity.email));

        accountLoaded = true;
    }

    public async void LoadRoleAsync()
    {
        if (roleLoaded)
            return;

        var entities = await _roleService.ListAsync(_model.id);

        if(!entities.Any())
            return;

        _roleNode.Nodes.Clear();

        foreach(var item in entities)
            _roleNode.Nodes.Add(new TreeNode(item.Name));

        roleLoaded = true;
    }

    public async void LoadClaimsAsync()
    {
        if (claimLoaded)
            return;

        var entities = await _claimService.ListAsync(_model.id);

        if (!entities.Any())
            return;

        _claimsNode.Nodes.Clear();

        foreach (var item in entities)
            _claimsNode.Nodes.Add(new TreeNode(item.Name));

        claimLoaded = true;
    }

    public async void LoadPixAsync()
    {
        if (bankLoaded)
            return;

        var entities = await _pixService.ListAsync(_model.id);

        if (!entities.Any())
            return;

        _bankNode.Nodes.Clear();

        foreach (var item in entities)
        {
            _bankNode.Nodes.Add(new TreeNode(item.content));
            _bankNode.Nodes.Add(new TreeNode("Format: " + item.type.ToString()));
            _bankNode.Nodes.Add(new TreeNode(item.createdAt.ToString()));
        }

        bankLoaded = true;
    }

    public async void LoadPendingPurchaseAsync()
    {
        if (purchaseLoaded)
            return;

        var entities = await _internalPaymentService.FindPurchasesAsync(_model.id);

        if (!entities.Any())
            return;

        _purchaseNode.Nodes.Clear();

        decimal coi = 0;
        string tmp = "";
        decimal sub = 0;

        foreach (var internalPayment in entities)
        {
            if(internalPayment.MercadoPagoHistories is not null)
            {
                foreach (var externalPayment in internalPayment.MercadoPagoHistories)
                {
                    tmp = $"{internalPayment.Id}.{externalPayment.Id} | ";
                    tmp += (internalPayment.Active ? "ACTIVE" : "INACTIVE") + " | ";
                    tmp += internalPayment.Coins + " coins | ";
                    tmp += internalPayment.Total + " BRL | ";
                    tmp += externalPayment.Status + " @ " + internalPayment.CreatedAt;

                    coi += internalPayment.Coins;
                    sub += internalPayment.Total;

                    _purchaseNode.Nodes.Add(new TreeNode(tmp));
                }
            }
        }

        tmp = "Sub total: " + coi + " coins | R$ " + sub;
        _purchaseNode.Nodes.Add(new TreeNode(tmp));

        coi = 0;
        sub = 0;

        purchaseLoaded = true;
    }

    public async void LoadWithdrawAsync()
    {
        if (withdrawLoaded)
            return;

        var entities = await _internalPaymentService.FindWithdrawsAsync(_model.id);

        if (!entities.Any())
            return;

        _withdrawsNode.Nodes.Clear();

        decimal coi = 0;
        string tmp = "";
        decimal sub = 0;
        bool hasContent = false;

        foreach (var internalPayment in entities)
        {
            if (internalPayment.MercadoPagoHistories is not null && internalPayment.MercadoPagoHistories.Any())
            {
                foreach (var externalPayment in internalPayment.MercadoPagoHistories)
                {
                    tmp = $"{internalPayment.Id}.{externalPayment.Id} | ";
                    tmp += (internalPayment.Active ? "ACTIVE" : "INACTIVE") + " | ";
                    tmp += internalPayment.Coins + " coins | ";
                    tmp += internalPayment.Total + " BRL | ";
                    tmp += externalPayment.Status + " @ " + internalPayment.CreatedAt;

                    coi += internalPayment.Coins;
                    sub += internalPayment.Total;

                    _withdrawsNode.Nodes.Add(new TreeNode(tmp));
                }

                tmp = "Sub total: " + coi + " coins | R$ " + sub;
                _withdrawsNode.Nodes.Add(new TreeNode(tmp));

                coi = 0;
                sub = 0;
                hasContent = false;
            }
            else
            {
                tmp = $"{internalPayment.Id} | ";
                tmp += (internalPayment.Active ? "ACTIVE" : "INACTIVE") + " | ";
                tmp += internalPayment.Coins + " coins | ";
                tmp += internalPayment.Total + " BRL | ";
                tmp += internalPayment.CreatedAt;

                coi += internalPayment.Coins;
                sub += internalPayment.Total;

                _withdrawsNode.Nodes.Add(new TreeNode(tmp));
                hasContent = true;
            }
        }

        if (hasContent)
        {
            tmp = "Sub total: " + coi + " coins | R$ " + sub;
            _withdrawsNode.Nodes.Add(new TreeNode(tmp));
        }

        withdrawLoaded = true;
    }

    public async void LoadAnswersAsync()
    {
        if (answersLoaded)
            return;

        var entities = await _answerService.ListAsync(_model.id);

        if (!entities.Any())
            return;

        _answersNode.Nodes.Clear();

        string tmp = "";
        int countPositive = 0;
        int countNegative = 0;

        foreach (var answer in entities)
        {
            if (answer.Action is null)
                continue;

            tmp  = String.Format("{0}.{1} # {2}", answer.Action!.GameId, answer.ActionId, answer.Id);
            tmp += " | " + answer.Content + " @ " + answer.CreatedAt;

            _answersNode.Nodes.Add(new TreeNode(tmp));

            if (answer.Content.ToLower().Equals("no"))      countNegative++;
            else                                            countPositive++;
        }

        tmp = String.Format("Sub total: {0} YES | {1} NO", countPositive, countNegative);
        _answersNode.Nodes.Add(new TreeNode(tmp));

        answersLoaded = true;
    }

    public async void LoadCreditsAsync()
    {
        if (creditsLoaded)
            return;

        var entities = await _balanceService.ListCreditsAsync(_model.id, 0);

        if (!entities.Any())
            return;

        _creditsNode.Nodes.Clear();

        string tmp = "";
        decimal sum = 0;

        foreach (var item in entities)
        {
            tmp = String.Format("{0} # {1} Coin(s)", item.bid, item.amount);
            _creditsNode.Nodes.Add(new TreeNode(tmp));
            sum += item.amount;
        }

        _creditsNode.Nodes.Add(new TreeNode("Sub total: " + sum + " Coins"));

        creditsLoaded = true;
    }

    public async void LoadDebitsAsync()
    {
        if (debitsLoaded)
            return;

        var entities = await _balanceService.ListDebitsAsync(_model.id, 0);

        if (!entities.Any())
            return;

        _debitsNode.Nodes.Clear();

        string tmp = "";
        decimal sum = 0;

        foreach (var item in entities)
        {
            tmp = String.Format("{0} # {1} Coin(s)", item.bid, item.amount);
            _debitsNode.Nodes.Add(new TreeNode(tmp));
            sum += item.amount;
        }

        _debitsNode.Nodes.Add(new TreeNode("Sub total: " + sum + " Coins"));

        debitsLoaded = true;
    }
}