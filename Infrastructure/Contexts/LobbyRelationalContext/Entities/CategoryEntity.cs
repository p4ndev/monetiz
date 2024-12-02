namespace Monetizacao.Providers.Contexts.Entities;

public class CategoryEntity
    : BasePeriodicEntity
{
    public long                                 TenantId        { get; protected set; }
    public string                               Name            { get; protected set; } = null!;
    public string                               Summary         { get; protected set; } = null!;
    public string?                              Logotype        { get; protected set; }
    public bool                                 Active          { get; protected set; }

    public TenantEntity?                        Tenant          { get; protected set; }

    public CategoryEntity(){ }
}