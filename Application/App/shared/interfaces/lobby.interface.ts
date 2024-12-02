interface LobbyStateInterface{
    tenantId : number | undefined,
    categoryId : number | undefined,
    categoryName : string | undefined,
    categorySummary : string | undefined,
    colors : Array<string> | undefined
}

interface TenantInterface{
    id : number,
    name : string,
    logotype : string | undefined | null,
    rgbs : Array<string>,
    end : Date | undefined | null
}

interface TenantEntryInterface{
    source : TenantInterface
}

interface CategoryInterface{
    id : number,
    tenantId : number,
    categoryId : number,
    name : string,
    summary : string,
    logotype : string | undefined | null,
    start : Date,
    end : Date
}

interface CategoryEntryInterface{
    source : CategoryInterface
}

interface PlayerInterface {
    id : number,
    name : string,
    logotype : string,
}

export {
    LobbyStateInterface, TenantInterface, TenantEntryInterface,
    CategoryInterface, CategoryEntryInterface, PlayerInterface
}