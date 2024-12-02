using Monetizacao.Providers.Contexts.Enums;

namespace Monetizacao.Providers.Contexts.Entities;

public class ActivityEntity
    : BaseReadOnlyTrackableEntity
{
    public long                                             AccountId               { get; protected set; }
    public ActivityTypeEnum                                 ActivityTypeId          { get; protected set; }
    public string                                           Icon                    { get; protected set; } = null!;
    public string                                           Name                    { get; protected set; } = null!;
    public string                                           Summary                 { get; protected set; } = null!;
    public string?                                          LeftContent             { get; protected set; }
    public string?                                          CenterContent           { get; protected set; }
    public string                                           Stamp                   { get; protected set; } = null!;

    public ActivityTypeEntity?                              ActivityType            { get; protected set; }
    public AccountEntity?                                   Account                 { get; protected set; }

    public ActivityEntity() { }

    protected ActivityEntity(long uid, ActivityTypeEnum act, string name, string summary, string iconContent, string stamp)
        : base()
    {
        AccountId           = uid;
        ActivityTypeId      = act;
        Name                = name;
        Stamp               = stamp;
        Summary             = summary;
        Icon                = iconContent;
    }

    protected ActivityEntity(long uid, ActivityTypeEnum act, string name, string summary, string iconContent, string leftContent, string stamp)
        : this(uid, act, name, summary, iconContent, stamp)
    {
        LeftContent         = leftContent;
    }

    protected ActivityEntity(long uid, ActivityTypeEnum act, string name, string summary, string iconContent, string leftContent, string centerContent, string stamp)
        : this(uid, act, name, summary, iconContent, leftContent, stamp)
    {
        CenterContent       = centerContent;
    }

    public static string ParseThousandItems(decimal total, bool isPositive = true)
    {
        string output = "";
        var pure = Math.Floor(total);
        var fractional = total - pure;

        output += (isPositive ? "+ " : "- ");

        if (pure >= 1000)
        {
            output += Math.Floor(pure / 1000).ToString("0.#");
            output += "k";
        }
        else
            output += pure.ToString();

        if (fractional > 0)
            output += fractional.ToString(".#");

        return output;
    }

    public void RegisterPositiveResult()
        => CenterContent = "global.yes";

    public void RegisterNegativeResult()
        => CenterContent = "global.no";
}