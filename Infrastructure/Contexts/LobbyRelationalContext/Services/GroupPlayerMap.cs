using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monetizacao.Providers.Contexts.Entities;

namespace Monetizacao.Providers.Contexts.Maps;

public static class GroupPlayerMap
{
    public static void Seed(long gid, long pMin, long pMax, EntityTypeBuilder<GroupPlayerEntity> e)
    {
        for (long pid = pMin; pid <= pMax; pid++)
            e.HasData(new { Id = pid, PlayerId = pid, GroupId = gid });
    }
}