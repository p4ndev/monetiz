using Monetizacao.Providers.Contexts.Constants;
using Monetizacao.Modules.Financial.Services;
using Monetizacao.Modules.Account.Services;
using Monetizacao.Modules.Room.Responses;
using Monetizacao.Modules.Room.Services;
using Monetizacao.Providers.Contexts;
using Monetizacao.Providers.Handlers;
using System.Diagnostics;

namespace ERP.Consolidation;

public partial class BooleanResult
    : Form
{
    private readonly TimezoneHandler            _timezoneHandler;
    private readonly UUIDHandler                _uuidHandler;
        
    private readonly ActivityService            _activityService;
    private readonly BalanceService             _balanceService;
    private readonly ActionService              _actionService;
    private readonly AnswerService              _answerService;

    private long                                _negativeAnswers,
                                                _positiveAnswers;

    private bool                                _positiveReward,
                                                _negativeReward;

    private decimal                             _positiveEach,
                                                _negativeEach,
                                                _totalAnswers;

    private string                              _gameName;
    private TimeSpan                            _period;
    private string?                             _stamp;

    private readonly string                     _environment;
    private readonly BooleanActionResponse      _model;
    private readonly long                       _oid;

    public BooleanResult(long oid, BooleanActionResponse model, string gameName)
    {
        _oid = oid;
        _model = model;
        _gameName = gameName;

        _timezoneHandler = new();
        _uuidHandler = new();

        _positiveReward = false;
        _negativeReward = false;

        _negativeAnswers = 0;
        _positiveAnswers = 0;
        _totalAnswers = 0;
        _positiveEach = 0;
        _negativeEach = 0;

        _stamp = null;

        _environment = Properties.Settings.Default.Environment.ToString();

        var uuid = new UUIDHandler();
        var md5 = new Md5CryptoHandler();
        var val = new ValidationHandler();

        var ctx0 = (new RoomRelationalContextFactory()).CreateDbContext(["--environment=" + _environment]);
        _actionService = new(_timezoneHandler, val, ctx0);
        _answerService = new(ctx0);

        var ctx2 = (new FinancialRelationalContextFactory()).CreateDbContext(["--environment=" + _environment]);
        _balanceService = new(uuid, val, ctx2);

        var ctx3 = (new AccountRelationalContextFactory()).CreateDbContext(["--environment=" + _environment]);
        _activityService = new(_uuidHandler, ctx3);

        InitializeComponent();
    }

    private void BooleanResult_Load(object sender, EventArgs e)
    {
        InitializeAnswers();
        InitializeDeadlines();

        InitializePositiveAnswers();
        InitializeNegativeAnswers();

        txtName.Text = _model.name;
    }

    private void InitializeAnswers()
    {
        _negativeAnswers = _model.negative;
        _positiveAnswers = _model.positive;

        _totalAnswers = Convert.ToDecimal(_negativeAnswers + _positiveAnswers);
    }

    private void InitializeDeadlines()
    {
        if (!_model.ends.HasValue)
            return;

        lblStartDate.Text = _model.starts.ToShortDateString();
        lblStartTime.Text = _model.starts.ToShortTimeString();

        lblEndDate.Text = _model.ends.Value.ToShortDateString();
        lblEndTime.Text = _model.ends.Value.ToShortTimeString();

        if (!_model.ends.HasValue)
            return;

        var rightNow = _timezoneHandler.RightNow();
        _period = _model.ends.Value.Subtract(rightNow);

        lblDays.ForeColor = (_period.TotalDays <= 0) ? Color.Red : Color.Blue;
        lblDays.Text = (_period.TotalDays <= 0) ? "Expired" : _period.TotalDays.ToString("F0");

        lblHours.ForeColor = (_period.TotalHours <= 0) ? Color.Red : Color.Blue;
        lblHours.Text = (_period.TotalHours <= 0) ? "Expired" : _period.TotalHours.ToString("F0");

        lblMinutes.ForeColor = (_period.TotalMinutes <= 0) ? Color.Red : Color.Blue;
        lblMinutes.Text = (_period.TotalMinutes <= 0) ? "Expired" : _period.TotalMinutes.ToString("F0");
    }

    private void InitializePositiveAnswers()
    {
        if (_positiveAnswers <= 0)
            return;

        _positiveEach = (_totalAnswers / _positiveAnswers);
        decimal positiveTotal = _positiveEach * _positiveAnswers;
        _positiveReward = true;

        lblYesAnswers.Text = _positiveAnswers.ToString() + " answers";
        lblYesRewards.Text = _positiveEach.ToString("F2") + " coins / each";
        lblYesTotal.Text = positiveTotal.ToString("F2") + " coins / total";
    }

    private void InitializeNegativeAnswers()
    {
        if (_negativeAnswers <= 0)
            return;

        _negativeEach = (_totalAnswers / _negativeAnswers);
        decimal negativeTotal = _negativeEach * _negativeAnswers;
        _negativeReward = true;

        lblNoAnswers.Text = _negativeAnswers.ToString() + " answers";
        lblNoRewards.Text = _negativeEach.ToString("F2") + " coins / each";
        lblNoTotal.Text = negativeTotal.ToString("F2") + " coins / total";
    }

    private async Task PersistAsync(bool isPositive = true)
    {
        await _actionService.RemoveAsync(_model.aid);

        _stamp = await _actionService.StampAsync(_model.aid);

        if(_stamp is null)
        {
            MessageBox.Show("We cannot identify the action");
            return;
        }

        if (isPositive)
        {
            await _activityService.UpdatePositiveActionResultAsync(_stamp);
            await _answerService.AddPositiveAnswerResultAsync(_oid, _model.aid, txtSupport.Text.ToString(), _stamp!);
        }
        else
        {
            await _activityService.UpdateNegativeActionResultAsync(_stamp);
            await _answerService.AddNegativeAnswerResultAsync(_oid, _model.aid, txtSupport.Text.ToString(), _stamp!);
        }

        await _activityService.PersistAccountAsync();
        await _answerService.PersistRoomAsync();
    }

    private async Task PersistPositiveAnsweredAsync()
    {
        _stamp = await _actionService.StampAsync(_model.aid);

        if (_stamp is null)
            return;

        var accountIds = await _answerService.ListUserIdsAsync(_model.aid);

        if (accountIds is null)
            return;

        foreach (var uid in accountIds)
        {
            await _balanceService.AddAfterResultAsync(uid, _model.aid, _positiveEach, _stamp);
            await _activityService.AddPositiveResultAsync(uid, _gameName, _model.name, _positiveEach, _stamp);
        }

        await _actionService.RemoveAsync(_model.aid);
        await _activityService.UpdatePositiveActionResultAsync(_stamp);
        await _answerService.AddPositiveAnswerResultAsync(_oid, _model.aid, txtSupport.Text.ToString(), _stamp);

        await _balanceService.PersistFinancialAsync();
        await _activityService.PersistAccountAsync();
        await _actionService.PersistRoomAsync();
    }

    private async Task PersistNegativeAnsweredAsync()
    {
        _stamp = await _actionService.StampAsync(_model.aid);

        if (_stamp is null)
            return;

        var accountIds = await _answerService.ListUserIdsAsync(_model.aid, false);

        if (accountIds is null)
            return;
        
        foreach (var uid in accountIds)
        {
            await _balanceService.AddAfterResultAsync(uid, _model.aid, _negativeEach, _stamp);
            await _activityService.AddNegativeResultAsync(uid, _gameName, _model.name, _negativeEach, _stamp);
        }

        await _actionService.RemoveAsync(_model.aid);
        await _activityService.UpdateNegativeActionResultAsync(_stamp);
        await _answerService.AddNegativeAnswerResultAsync(_oid, _model.aid, txtSupport.Text.ToString(), _stamp);

        await _balanceService.PersistFinancialAsync();
        await _activityService.PersistAccountAsync();
        await _actionService.PersistRoomAsync();
    }

    private void lnkImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = _model.image,
            UseShellExecute = true
        });
    }

    private async void btnYes_Click(object sender, EventArgs e)
    {
        if (_positiveReward)
            await PersistPositiveAnsweredAsync();
        else
            await PersistAsync();

        MessageBox.Show("Positive result | " + (_positiveReward ? "C" : "No C") + "oins distributed.");
        this.Close();
    }

    private async void btnNo_Click(object sender, EventArgs e)
    {
        if (_negativeReward)
            await PersistNegativeAnsweredAsync();
        else
            await PersistAsync(false);

        MessageBox.Show("Negative result | " + (_negativeReward ? "C" : "No C") + "oins distributed.");
        this.Close();
    }
}