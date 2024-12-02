using Monetizacao.Providers.Contexts.Entities;
using Monetizacao.Providers.Contexts;
using Monetizacao.Providers.Handlers;
using Microsoft.EntityFrameworkCore;
using Monetizacao.Modules.Room.Dtos;

namespace Monetizacao.Modules.Room.Services;

public sealed class TemplateService
(
    UUIDHandler                 _uuidHandler,
    TimezoneHandler             _timezoneHandler,
    ValidationHandler           _validationHandler,
    RoomRelationalContext       _roomRelationalContext
)
{
    private TemplateDto _dto;

    public async Task<IEnumerable<ActionTemplateEntity>> ListFiftyRandomicallyAsync(IEnumerable<long> gids, IEnumerable<long> pids, CancellationToken token = default)
        => await _roomRelationalContext
            .ActionTemplates
                .Where(
                    at => 
                        at.ModifiedAt == null &&
                        (
                            (at.GroupId != null  && gids.Contains(at.GroupId!.Value)) ||
                            (at.PlayerId != null && pids.Contains(at.PlayerId!.Value))
                        )
                )
                    .OrderBy(at => EF.Functions.Random())
                        .Take(50)
                            .ToListAsync(token);

    public async Task<IEnumerable<TemplateEntity>> ListAsync(IEnumerable<long> tids, CancellationToken token = default)
        => await _roomRelationalContext.Templates.AsNoTracking().Where(t => tids.Contains(t.Id)).ToListAsync(token);

    public TemplateService Initialize(long uid, long gid)
    {
        _dto        = new();
        
        _dto.gid    = gid;
        _dto.uid    = uid;
        _dto.stamp  = _uuidHandler.Generate();

        return this;
    }

    public TemplateService AttachName(string entityName, string templateName, string templateLabel, string entityLabel)
    {
        if (
            !_validationHandler.IsTemplateValid(templateName)       &&
            !_validationHandler.IsStringValid(entityName)           &&
            !(entityLabel == templateLabel)
        )
            return this;

        string slug = ('{' + templateLabel + '}').ToString();
        _dto.action = templateName.Replace(slug, entityName);

        return this;
    }

    public TemplateService AttachImage(string? content)
    {
        if (_validationHandler.IsStringValid(content))
            _dto.image = content!;

        return this;
    }

    public TemplateService AttachInterval(DateTime startsAt, DateTime? endsAt, int skipMinutes, int durationMinutes)
    {
        _dto.starts = startsAt;

        if (endsAt.HasValue)
        {
            var deadline = startsAt.AddMinutes(skipMinutes + durationMinutes);

            if (deadline <= endsAt.Value)
                _dto.ends = deadline;
        }

        return this;
    }

    public TemplateDto? Flush()
    {
        if (_dto.uid == 0)
            return null;

        return _dto;
    }

    public void Deactive(ActionTemplateEntity entity)
    {
        entity.Remove(_timezoneHandler.RightNow());

        _roomRelationalContext.Entry(entity).State = EntityState.Modified;
    }

    public async Task<bool> PersistRoomAsync(CancellationToken token = default, int expected = 1)
        => (await _roomRelationalContext.SaveChangesAsync(token) >= expected);
}