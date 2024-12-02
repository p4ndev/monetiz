import { BalanceResponse, CoinMenuStateItemInterface } from "../../../shared/interfaces";
import { StorageHandler } from "../../handlers";
import { BaseService } from "../base.service";
import { BalanceManagerService } from "./balance-manager.service";

export class BalanceService extends BaseService
{  
  private readonly storageHandler : StorageHandler;
  private readonly apiAddress : string;  

  constructor(){
    super();

    this.storageHandler = new StorageHandler();

    this.apiAddress     = `${process.env.EXPO_PUBLIC_API_ADDRESS}/financial/balance`;
  }

  async LoadAsync(token : string, lci? : number, ldi? : number) : Promise<BalanceResponse> {
    return new Promise(async (resolve, reject) => {
      const usp = new URLSearchParams();
  
      if(ldi !== undefined && ldi !== null && ldi !== 0)
        usp.append('ldi', ldi.toString());
  
      if(lci !== undefined && lci !== null && lci !== 0)
        usp.append('lci', lci.toString());
  
      let endpointSuffix : string = '';
  
      if(usp.size > 0)
        endpointSuffix = "?" + usp.toString();
  
      const response = await fetch(`${this.apiAddress}${endpointSuffix}`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `bearer ${token}`
        }
      });

      if(this.CatchExceptions(response.status))
        return reject();

      const data = await response.json();
  
      return resolve(data as BalanceResponse);
    });
  }

  async LastOfflineIdsAsync() : Promise<CoinMenuStateItemInterface>{
    return {
      lci : await this.storageHandler.FindAsync<number>('lci'),
      ldi : await this.storageHandler.FindAsync<number>('ldi')
    };
  }

  async OfflineCoinsAsync() : Promise<number>{
    return await this.storageHandler.FindAsync<number>('coin');
  }

  async SaveOfflineDataAsync(ldi : number | null, lci : number | null, coins : number | null) : Promise<void>{    
    if(ldi !== null)
      await this.storageHandler.AddAsync('ldi', ldi, false);

    if(lci !== null)
      await this.storageHandler.AddAsync('lci', lci, false);

    if(coins != null)
      await this.storageHandler.AddAsync('coin', coins, false);
  }

  Total(ingress : BalanceManagerService, egress : BalanceManagerService) : number{
    const credits = Number(ingress.Total);
    const debits  = Number(egress.Total);
    const total   = Number(credits - debits);

    return total;
  }
}