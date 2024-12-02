import { BalanceEntryResponse } from "../../../shared/interfaces";
import { BalanceManagerService } from "./balance-manager.service";

export class BalanceEgressService extends BalanceManagerService
{
    constructor(lastId : number, source : Array<BalanceEntryResponse>) {
        super(lastId, source);        
    }
}