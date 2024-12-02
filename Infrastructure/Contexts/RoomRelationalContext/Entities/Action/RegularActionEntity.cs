namespace Monetizacao.Providers.Contexts.Entities;

public sealed class RegularActionEntity(long uid, long gid, long tid, string action, string image, DateTime starts, DateTime ends, string stamp)
    : ActionEntity(uid, gid, tid, action, image, starts, ends, stamp);