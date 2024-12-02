import { GameInterface } from "../../../shared/interfaces";
import { StorageHandler } from "../../handlers";
import { BaseService } from "../base.service";

export class GameService extends BaseService
{
  private readonly storageHandler : StorageHandler;
  private entities : Array<GameInterface> | undefined | null;

  constructor(){
    super();

    this.entities         = undefined;
    this.storageHandler   = new StorageHandler();
    this.content          = 'room.game.dataError';
    this.name             = 'global.serverErrorName';
  }

  async LoadAsync(tid : number, cid : number, token : string) : Promise<Array<GameInterface>>{
    const dictKey = 'tid-' + tid + '_cid-' + cid;

    this.entities = await this.storageHandler.FindAsync<Array<GameInterface>>(dictKey);

    if(this.entities !== undefined && this.entities !== null && this.entities.length !== 0)
      return (this.entities as Array<GameInterface>);

    const httpHeaders = { 'Content-Type': 'application/json', 'Authorization': `bearer ${token}` };

    const response = await fetch(
      `${process.env.EXPO_PUBLIC_API_ADDRESS}/room/${tid}/tenant/${cid}/category`, {
      headers : httpHeaders,
      method  : "GET"
    });

    if (!response.ok)
      throw new Error(`Http error: ${response.status}`);

    const data = await response.json();

    this.entities = (data as Array<GameInterface>);

    if(this.entities === undefined || this.entities === null || this.entities.length === 0)
      return null;

    await this.storageHandler.AddAsync(dictKey, this.entities, false);

    return (this.entities as Array<GameInterface>);
  }
}