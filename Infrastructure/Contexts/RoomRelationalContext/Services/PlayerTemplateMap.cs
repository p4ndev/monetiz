using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class PlayerTemplateMap
{
    public static long Seed(long id, long pMin, long pMax, long tMin, long tMax, EntityTypeBuilder<ActionTemplateEntity> e)
    {
        for (long pid = pMin; pid <= pMax; pid++)
            for (long tid = tMin; tid <= tMax; id++, tid++)
                e.HasData(new { Id = id, PlayerId = pid, TemplateId = tid });

        return id;
    }
}