namespace Monetizacao.Providers.Contexts.Entities;

public class TenantColorEntity
    : BaseEntity<long>
{
    public long             TenantId    { get; protected set; }
    public string           Rgb         { get; protected set; } = null!;

    public TenantEntity?    Tenant      { get; protected set; }

    public TenantColorEntity(){ }
}
