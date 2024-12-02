import { useEffect, useState } from "react";

import { AnalyticService, BalanceEgressService, BalanceIngressService, BalanceService } from "../../provider/services";
import { useAccountContext, useFinancialContext } from "../../provider/contexts";
import { useParser } from "../../provider/handlers";

import { AccountStateInterface, CoinMenuStateItemInterface, FinancialStateInterface } from "../../shared/interfaces";
import { BalancePhaseEnum, RoleEnum } from "../../shared/enums";
import { CoinMenuItemState } from "../../shared/states";

export default function BalanceLoad(){

  const { account } = useAccountContext();
  const { financial, setFinancial } = useFinancialContext();
  
  const { token, role, nameid } = useParser<AccountStateInterface>(account);
  const { phase, coin } = useParser<FinancialStateInterface>(financial);

  const [ config, setConfig ] = useState<CoinMenuStateItemInterface>(CoinMenuItemState);
  
  const analyticService = new AnalyticService();
  const balanceService = new BalanceService();
  var creditService : BalanceIngressService;
  var debitService : BalanceEgressService;
  
  var _coin : number | null = null,
      _lci  : number | null = null,
      _ldi  : number | null = null;
  
  const loadAsync = async () => {
    switch(phase)
    {
      case undefined:
        await startAsync();
        break;

      case BalancePhaseEnum.OfflineHistory:
        await offlineHistoryAsync();
        break;

      case BalancePhaseEnum.OfflineTotal:
        await offlineTotalAsync();
        break;

      case BalancePhaseEnum.Sync:
        await synchronizeAsync();
        break;
    }
  }

  const startAsync = async () => {
    setFinancial({ ...financial, phase: BalancePhaseEnum.OfflineHistory });
  }

  const offlineHistoryAsync = async () => {
    const balanceHistory = await balanceService.LastOfflineIdsAsync();

    setConfig(balanceHistory);
    
    setFinancial({ ...financial, phase: BalancePhaseEnum.OfflineTotal });
  };

  const offlineTotalAsync = async () => {
    let balanceCalculated = await balanceService.OfflineCoinsAsync();

    balanceCalculated = (balanceCalculated === null ? 0 : balanceCalculated);
    
    setFinancial({
      ...financial,
      coin  : balanceCalculated,
      phase : BalancePhaseEnum.Sync
    });
  };

  const synchronizeAsync = async () => {
    try
    {
      _coin = Number(await balanceService.OfflineCoinsAsync());

      const { lci, ldi } = await balanceService.LastOfflineIdsAsync();

      _lci = (lci === null ? config.lci : lci);
      _ldi = (ldi === null ? config.ldi : ldi);

      const data = await balanceService.LoadAsync(token, _lci, _ldi);
      
      this.creditService = new BalanceIngressService(_lci, data.credits);
      this.debitService  = new BalanceEgressService(_ldi, data.debits);
      
      _coin += balanceService.Total(this.creditService, this.debitService);

      _lci = this.creditService.LastId;
      _ldi = this.debitService.LastId;
    }
    catch(e) { }
    finally
    {
      await balanceService.SaveOfflineDataAsync(
        _ldi === 0 ? null : _ldi,
        _lci === 0 ? null : _lci,
        (_coin === undefined || _coin === null) ? 0 : _coin
      );

      setConfig({
        ...config,
        lci : _lci,
        ldi : _ldi
      });

      let tmpCoin = (_coin === undefined || _coin === null ? 0 : _coin);

      setFinancial({
        ...financial,
        coin  : tmpCoin,
        phase : BalancePhaseEnum.Waiting
      });

      if(tmpCoin > 0)
        analyticService.TrackEvent('Client', { UID: nameid });
    }
  };

  useEffect(() => {
    if(token === undefined || token === null || token === '' || 
        nameid === undefined || nameid === null || 
          role === undefined || role === null || 
            config === undefined || config === null)
              return;

    if(role === RoleEnum.Member)
      loadAsync();
  }, [token, role, phase, coin, config]);
  
  return (<></>);
}