import { BalanceEntryResponse } from "../../../shared/interfaces";

export abstract class BalanceManagerService
{    
    public LastId   : number;
    public Total    : number;

    constructor(lastId : number, source : Array<BalanceEntryResponse>) {
        this.LastId = 0;
        this.Total  = 0;

        if(source.length === 0){
            this.LastId = lastId;
            return;
        }

        for(let item of source){
            this.Total  += Number(item.amount);
            this.LastId  = Number(item.bid);
        }
    }
}