import { useEffect } from "react";

import { useAccountContext, useFinancialContext } from "../../provider/contexts";
import { AnalyticService, CheckoutService } from "../../provider/services";
import { useParser } from "../../provider/handlers";

import { AccountStateInterface } from "../../shared/interfaces";
import { AppMap } from "../../shared/constants";
import { RoleEnum } from "../../shared/enums";

export default function CheckoutLoad(){
  
  const { financial, setFinancial } = useFinancialContext();
  const { account } = useAccountContext();
  
  const { token, role, nameid } = useParser<AccountStateInterface>(account);
  
  const analyticService = new AnalyticService();
  const checkoutService = new CheckoutService('buy');

  const loadAsync = async () => {
    try
    {
      const result = await checkoutService.LoadAsync(token);
      
      analyticService.TrackEvent('Available Checkout', { UID: nameid, RID: role, IPI: result.innerPaymentId, EPI: result.outerPaymentId });

      setFinancial({ ...financial, checkout: result });
      
      AppMap.Financial.Checkout();
    }
    catch(e)
    {
      AppMap.Financial.ShoppingCart();
    }
  }

  useEffect(() => {
    if(token === null || token === undefined || token === '' ||
         role === undefined || role === null || role !== RoleEnum.Member)
           return;

    loadAsync();
  }, [token, role]);
  
  return (<></>);
}