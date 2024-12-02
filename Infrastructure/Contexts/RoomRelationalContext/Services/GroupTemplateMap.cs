using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class GroupTemplateMap
{
    public static long Seed(long id, long gid, long tmin, long tmax, EntityTypeBuilder<ActionTemplateEntity> e)
    {
        for (long tid = tmin; tid <= tmax; id++, tid++)
            e.HasData(new { Id = id, GroupId = gid, TemplateId = tid });

        return id;
    }
}