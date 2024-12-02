import { CategoryInterface } from "../../../shared/interfaces";
import { StorageHandler } from "../../handlers";
import { BaseService } from "../base.service";

export class CategoryService extends BaseService
{
  private readonly apiAddress : string;
  private readonly storageHandler : StorageHandler;
  private entities : Array<CategoryInterface> | undefined | null;

  constructor() {
    super();

    this.storageHandler   = new StorageHandler();
    
    this.entities         = undefined;
    this.apiAddress       = 'lobby/category';
    this.name             = 'global.serverErrorName';
    this.content          = 'global.serverGeneralError';
  }

  async LoadAsync() : Promise<void>{
    this.entities = await this.storageHandler.FindAsync<Array<CategoryInterface>>('categories');

    if(this.entities !== undefined && this.entities !== null && this.entities.length !== 0)
      return;

    const response = await fetch(`${process.env.EXPO_PUBLIC_API_ADDRESS}/${this.apiAddress}`);

    if (!response.ok)
      throw new Error(`Http error: ${response.status}`);

    const data = await response.json();

    this.entities = (data as Array<CategoryInterface>);
    
    if(this.entities === undefined || this.entities === null || this.entities.length === 0)
      return;

    await this.storageHandler.AddAsync('categories', this.entities, false);
  }

  FilterBy(tenantId: number) : Array<CategoryInterface> {
    return this.entities.filter(e => e.tenantId === tenantId);
  }
}