using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Modules.Account.Responses;
using Monetizacao.Providers.Contexts.Enums;
using System.Runtime.Versioning;
using ERP.Financial;
using ERP.Account;
using ERP.Room;

namespace ERP;

[SupportedOSPlatform("windows")]
public partial class Stage
    : Form
{
    public BasicAccountResponse Account { get; private set; } = null!;
    public IEnumerable<ClaimEntity>? Claims { get; private set; } = null!;
    public RoleEntity Role { get; private set; } = null!;

    #region Stage
    public Stage()
    {
        InitializeComponent();
    }

    private void Stage_Load(object sender, EventArgs e)
    {
        HideMenus();
        var sn = new SignIn(this);
        sn.ShowDialog();
    }

    public void InitializeAccount(BasicAccountResponse account, RoleEntity role, IEnumerable<ClaimEntity>? claims)
    {
        Account = account;
        Role = role;
        Claims = claims;

        ShowMenus();

        lblUser.Text = "Welcome " + Account.fullName + "!";
    }

    private void HideMenus()
    {
        msAccount.Visible = false;
        msUserSearch.Visible = false;

        msLobby.Visible = false;

        msRoom.Visible = false;
        msAction.Visible = false;
        msAnswers.Visible = false;

        msFinancial.Visible = false;
        msWithdraw.Visible = false;
    }

    private void ShowMenus()
    {
        msAccount.Visible = true;

        if (Claims != null && Claims.Any(c => c.Id.Equals(ClaimEnum.CanSearchUsers)))
            msUserSearch.Visible = true;

        //msLobby.Visible = true;

        if (Claims != null && Claims.Any(c => c.Id.Equals(ClaimEnum.CanCheckAnswers) || c.Id.Equals(ClaimEnum.CanCreateActions)))
        {
            msRoom.Visible = true;

            if (Claims.Any(c => c.Id.Equals(ClaimEnum.CanCheckAnswers)))
                msAnswers.Visible = true;

            if (Claims.Any(c => c.Id.Equals(ClaimEnum.CanCreateActions)))
                msAction.Visible = true;
        }

        if (Claims != null && Claims.Any(c => c.Id.Equals(ClaimEnum.CanWithdraw)))
        {
            msFinancial.Visible = true;
            msWithdraw.Visible = true;
        }
    }
    #endregion

    #region Menu
    private void msExit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void msWithdraw_Click(object sender, EventArgs e)
    {
        var wd = new Withdraw();
        wd.Show();
    }

    private void searchToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var se = new Search();
        se.Show();
    }

    private void msAction_Click(object sender, EventArgs e)
    {
        var nma = new ActionNewManual(Account.id);
        nma.Show();
    }

    private void msAnswers_Click(object sender, EventArgs e)
    {
        var canConsolidate = (Claims is not null && Claims.Any(c => c.Id.Equals(ClaimEnum.CanConsolidate)));
        var ac = new Answers(Account.id, canConsolidate);
        ac.Show();
    }
    #endregion
}