namespace Monetizacao.Providers.Contexts.Entities;

public class TenantEntity
    : BaseTypeEntity<long>
{
    public string?                              Logotype        { get; protected set; }
    public bool                                 Active          { get; protected set; }

    public ICollection<CategoryEntity>?         Categories      { get; protected set; }
    public ICollection<TenantColorEntity>?      TenantColors    { get; protected set; }

    public TenantEntity(){ }
}