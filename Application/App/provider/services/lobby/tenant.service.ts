import { TenantInterface } from "../../../shared/interfaces";
import { StorageHandler } from "../../handlers";
import { BaseService } from "../base.service";

export class TenantService extends BaseService
{
  private readonly apiAddress : string;
  private readonly storageHandler : StorageHandler;

  constructor(){
    super();

    this.storageHandler   = new StorageHandler();

    this.apiAddress       = 'lobby/tenant';
    this.name             = 'global.serverErrorName';
    this.content          = 'global.serverGeneralError';
  }

  async LoadAsync() : Promise<Array<TenantInterface>>{
    const offlineEntities = await this.storageHandler.FindAsync<Array<TenantInterface>>('tenants');

    if(offlineEntities !== undefined && offlineEntities !== null && offlineEntities.length !== 0)
      return offlineEntities;

    const response = await fetch(`${process.env.EXPO_PUBLIC_API_ADDRESS}/${this.apiAddress}`);

    if (!response.ok)
      throw new Error(`Http error: ${response.status}`);

    const data = await response.json();

    const onlineEntities = (data as Array<TenantInterface>);
    
    if(onlineEntities === undefined || onlineEntities === null || onlineEntities.length === 0)
      return [];

    await this.storageHandler.AddAsync('tenants', onlineEntities, false);

    return onlineEntities;
  }
}