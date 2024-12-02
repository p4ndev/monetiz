import { PlayerInterface } from "../../../shared/interfaces";
import { StorageHandler } from "../../handlers";
import { BaseService } from "../base.service";

export class PlayerService extends BaseService
{
    private readonly apiAddress : string;
    private readonly storageHandler : StorageHandler;
    private entities : Array<PlayerInterface> | undefined | null;

    constructor(){
        super();

        this.storageHandler     = new StorageHandler();

        this.apiAddress         = 'lobby/player';
        this.name               = 'global.serverErrorName';
        this.content            = 'global.serverGeneralError';
    }

    async LoadAsync() : Promise<Array<PlayerInterface>>{
        this.entities = await this.storageHandler.FindAsync<Array<PlayerInterface>>('players');

        if(this.entities !== undefined && this.entities !== null && this.entities.length !== 0)
            return;

        const response = await fetch(`${process.env.EXPO_PUBLIC_API_ADDRESS}/${this.apiAddress}`);

        if (!response.ok)
            throw new Error(`Http error: ${response.status}`);
    
        const data = await response.json();
    
        this.entities = (data as Array<PlayerInterface>);

        if(this.entities === undefined || this.entities === null || this.entities.length === 0)
            return;

        await this.storageHandler.AddAsync('players', this.entities, false);
    }

    FilterBy(groupIds : Array<number>) : Array<PlayerInterface> {
        return this.entities.filter(e => groupIds.indexOf(e.id) !== -1);
    }
}