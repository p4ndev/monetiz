using Monetizacao.Modules.Room.Responses;
using Monetizacao.Modules.Lobby.Services;
using Monetizacao.Modules.Room.Services;
using Monetizacao.Providers.Contexts;
using Monetizacao.Providers.Handlers;
using System.Runtime.Versioning;
using ERP.Consolidation;

namespace ERP.Room;

[SupportedOSPlatform("windows")]
public partial class Answers : Form
{
    private readonly ValidationHandler              _validationHandler;
    private readonly CategoryService                _categoryService;
    private readonly ActionService                  _actionService;
    private readonly PlayerService                  _playerService;
    private readonly GroupService                   _groupService;
    private readonly GameService                    _gameService;

    private IEnumerable<BooleanActionResponse>?     _actionEntities;
    private IEnumerable<GameResponse>?              _gameEntities;
    private readonly string                         _environment;
    private bool                                    _consolidate;
    private Dictionary<long, string>                _source;
    private string                                  _gname;
    private readonly long                           _uid;
    private long?                                   _gid;

    public Answers(long uid, bool canConsolidate)
    {
        _uid                = uid;
        _consolidate        = canConsolidate;
        _validationHandler  = new ValidationHandler();
        _environment        = Properties.Settings.Default.Environment.ToString();

        var uuid            = new UUIDHandler();
        var tmz             = new TimezoneHandler();
        var md5             = new Md5CryptoHandler();
        var val             = new ValidationHandler();
        var ctx0            = (new RoomRelationalContextFactory()).CreateDbContext(["--environment=" + _environment]);
        var ctx1            = (new LobbyRelationalContextFactory()).CreateDbContext(["--environment=" + _environment]);

        _source             = new();
        _groupService       = new(ctx1);
        _playerService      = new(ctx1);
        _categoryService    = new(tmz, val, ctx1);
        _gameService        = new(_validationHandler, ctx0);
        _actionService      = new(tmz, _validationHandler, ctx0);

        _gid                = null;
        _gameEntities       = null;
        _actionEntities     = null;        
        _gname              = string.Empty;

        InitializeComponent();
    }

    private async void Action_Load(object sender, EventArgs e)
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

                if(item.secondGroupId.HasValue)
                    groupIds.Add(item.secondGroupId.Value);
            }

            var categoryIds = _gameEntities.Select(g => g.categoryId).Distinct().OrderBy(g => g).AsEnumerable();
            var categories = await _categoryService.ListAsync(categoryIds);
            var players = await _playerService.ListAsync(groupIds);

            if(categories is not null && players is not null)
                foreach (var item in _gameEntities)
                {
                    var category = categories.FirstOrDefault(c => c.Id.Equals(item.categoryId));
                    var firstPlayer = players.FirstOrDefault(g => g.id.Equals(item.firstGroupId));
                    var secondPlayer = players.FirstOrDefault(g => g.id.Equals(item.secondGroupId));

                    _source.Add(
                        item.id,
                        String.Format(
                            "{0} # {1} | {2} {3} | {4}",
                            item.id,
                            (category == null ? "" : category.Name),
                            (firstPlayer == null ? "" : firstPlayer.name),
                            (secondPlayer == null ? "" : (" x " + secondPlayer.name)),
                            item.name
                        )
                    );
                }  
        }

        cbGame.DataSource = _source.ToList();
        cbGame.DisplayMember = "Value";
        cbGame.ValueMember = "Key";
    }

    private bool FillGameModel()
    {
        if (cbGame.SelectedIndex != 0)
        {
            var selectedItem = cbGame.SelectedItem as KeyValuePair<long, string>?;

            _gname = "";
            if (selectedItem.HasValue)
                _gname = selectedItem.Value.Value;

            if (!String.IsNullOrEmpty(_gname) && !String.IsNullOrWhiteSpace(_gname))
                _gname = _gname.Substring(_gname.IndexOf("@") + 3);

            if (_gname.IndexOf("x") == -1)
                _gname = _gname.Split('|')[0];
            else
                _gname = _gname.Split('|')[1];

            _gname = _gname.Substring(1);

            _gid = Convert.ToInt64(cbGame.SelectedValue);
        }
        else
            MessageBox.Show("Please select a game to load");

        return true;
    }

    private async void btnSearch_Click(object sender, EventArgs e)
    {
        if (!FillGameModel() || _gid is null)
            return;

        _actionEntities = await _actionService.FindByGroupAsync(_gid!.Value);
        dgvAction.DataSource = _actionEntities;        
        dgvAction.Columns[2].Visible = false;
    }

    private void dgvAction_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || _actionEntities is null || !_actionEntities.Any() || !_consolidate)
            return;

        var idx = e.RowIndex;

        var item = _actionEntities.ElementAt(idx);

        if (item is null)
            return;

        var bar = new BooleanResult(_uid, item, _gname);

        bar.Show();
    }
}