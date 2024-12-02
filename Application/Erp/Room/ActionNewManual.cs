using Monetizacao.Modules.Lobby.Services;
using Monetizacao.Modules.Room.Responses;
using Monetizacao.Modules.Room.Services;
using Monetizacao.Providers.Contexts;
using Monetizacao.Providers.Handlers;

namespace ERP.Room;

public partial class ActionNewManual : Form
{
    private readonly ValidationHandler      _validationHandler;
    private readonly CategoryService        _categoryService;
    private readonly TimezoneHandler        _timezoneHandler;
    private readonly UUIDHandler            _uuidHandler;

    private readonly ActionService          _actionService;
    private readonly PlayerService          _playerService;
    private readonly GroupService           _groupService;
    private readonly GameService            _gameService;

    private IEnumerable<GameResponse>?      _gameEntities;
    private readonly string                 _environment;
    private Dictionary<long, string>        _source;
    private readonly long                   _uid;

    public ActionNewManual(long uid)
    {
        _uid                    = uid;
        _source                 = new();
        _validationHandler      = new();
        _timezoneHandler        = new();
        _uuidHandler            = new();

        _environment            = Properties.Settings.Default.Environment.ToString();

        var ctx0                = (new RoomRelationalContextFactory()).CreateDbContext(["--environment=" + _environment]);
        var ctx1                = (new LobbyRelationalContextFactory()).CreateDbContext(["--environment=" + _environment]);
        
        _groupService           = new(ctx1);
        _playerService          = new(ctx1);
        _gameService            = new(_validationHandler, ctx0);
        _actionService          = new(_timezoneHandler, _validationHandler, ctx0);
        _categoryService        = new(_timezoneHandler, _validationHandler, ctx1);

        InitializeComponent();
    }

    private async void ActionNewManual_Load(object sender, EventArgs e)
    {
        _source.Clear();
        _source.Add(0, "Select");
        _gameEntities = await _gameService.ListAsync();

        if (_gameEntities is not null)
        {
            List<long> groupIds = new();

            foreach (var item in _gameEntities)
            {
                groupIds.Add(item.firstGroupId);

                if (item.secondGroupId.HasValue)
                    groupIds.Add(item.secondGroupId.Value);
            }

            var categoryIds = _gameEntities.Select(g => g.categoryId).Distinct().OrderBy(g => g).AsEnumerable();
            var categories = await _categoryService.ListAsync(categoryIds);
            var players = await _playerService.ListAsync(groupIds);

            if (categories is not null && players is not null)
                foreach (var item in _gameEntities)
                {
                    var lastItem = players.FirstOrDefault(g => g.id.Equals(item.secondGroupId));

                    _source.Add(
                        item.id,
                        String.Format(
                            "{0} # {1} | {2} {3} | {4}",
                            item.id,
                            categories.FirstOrDefault(c => c.Id.Equals(item.categoryId))?.Name,
                            players.FirstOrDefault(g => g.id.Equals(item.firstGroupId))?.name,
                            (lastItem == null ? "" : (" x " + lastItem.name)),
                            item.name
                        )
                    );
                }
        }

        cbGames.DataSource = _source.ToList();
        cbGames.DisplayMember = "Value";
        cbGames.ValueMember = "Key";
    }

    private async void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Validation
        bool hasGameError = (cbGames.SelectedIndex <= 0);
        if(hasGameError)
        {
            MessageBox.Show("Select a game");
            return;
        }

        bool hasActionError = !_validationHandler.IsActionValid(txtAction.Text);
        if (hasActionError)
        {
            MessageBox.Show("Your action is invalid");
            return;
        }

        bool hasImageError = !_validationHandler.IsPictureValid(txtImage.Text);
        if (hasImageError)
        {
            MessageBox.Show("Your image is invalid");
            return;
        }

        bool hasStartDateError = !_validationHandler.IsDateStringValid(dtpStarts.Text);
        bool hasStartTimeError = !_validationHandler.IsTimeStringValid(mtbStarts.Text);
        if (hasStartDateError || hasStartTimeError)
        {
            MessageBox.Show("Your start date or time is/are invalid");
            return;
        }

        bool hasEndDateError = !_validationHandler.IsDateStringValid(dtpEnds.Text);
        bool hasEndTimeError = !_validationHandler.IsTimeStringValid(mtbEnds.Text);
        if (hasEndDateError || hasEndTimeError)
        {
            MessageBox.Show("Your end date or time is/are invalid");
            return;
        }

        DateTime starts = Convert.ToDateTime(dtpStarts.Text + " " + mtbStarts.Text);
        DateTime ends = Convert.ToDateTime(dtpEnds.Text + " " + mtbEnds.Text);
        var hasIntervalError = !_validationHandler.IsActionPeriodValid(starts, ends);
        if (hasIntervalError)
        {
            MessageBox.Show("Your interval is invalid");
            return;
        }
        #endregion

        var gid = Convert.ToInt64(cbGames.SelectedValue);

        var confirmed = MessageBox
            .Show(
                String
                .Format(
                    "Game Id: {0}\nAction: {1}\nStarts: {2}\nEnds: {3}",
                    gid, txtAction.Text.ToString(), starts, ends
                ),
                "Confirm action below",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

        if(confirmed == DialogResult.Yes)
        {
            await _actionService.AddAsync(_uid, gid, 0, txtAction.Text, txtImage.Text, starts, ends, _uuidHandler.Generate());

            if (await _actionService.PersistRoomAsync())
            {
                txtAction.Text = "";
                txtImage.Text = "";

                dtpStarts.Text = "";
                dtpEnds.Text = "";

                mtbStarts.Text = "";
                mtbEnds.Text = "";

                txtAction.Focus();
                MessageBox.Show("Action registered", "Success");
            }
        }        
    }
}