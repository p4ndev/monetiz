import React, { useEffect } from 'react';

import { useAccountContext, useFinancialContext } from '../../../provider/contexts';
import { AccessService, AnalyticService } from '../../../provider/services';

import { AccountState, FinancialState } from '../../../shared/states';
import { AppMap } from '../../../shared/constants';
import { useParser } from '../../../provider/handlers';
import { AccountStateInterface } from '../../../shared/interfaces';

export default function SignOut() {

  const { setFinancial } = useFinancialContext();
  const { account, setAccount } = useAccountContext();
  
  const { nameid, role } = useParser<AccountStateInterface>(account);

  const analyticService = new AnalyticService();
  const accessService = new AccessService();
  
  const loadAsync = async () => {
    analyticService.TrackEvent('User Signed Out', { UID: nameid, RID: role });
    
    await accessService.SignOutAsync();
    setFinancial(FinancialState);    
    setAccount(AccountState);        
    AppMap.Splash();
  };

  useEffect(() => {
    loadAsync();
  }, [account]);

  return (<></>);
}