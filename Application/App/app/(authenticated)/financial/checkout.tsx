import { View } from "react-native";
import { useEffect } from "react";

import { AnalyticService, CheckoutService, FloatPanelService } from "../../../provider/services";
import { useFinancialContext, useFloatPanelContext } from "../../../provider/contexts";
import { HelperStyle } from "../../../provider/styles";
import { useParser } from "../../../provider/handlers";

import { FinancialStateInterface } from "../../../shared/interfaces";
import { BalancePhaseEnum, RoleEnum } from '../../../shared/enums';
import { AppMap } from "../../../shared/constants";

import PixTransactionDetails from "../../../component/smart/pix-transaction-details.component";
import PixCodeClipboard from "../../../component/smart/pix-code-clipboard.component";
import CheckoutExpired from "../../../component/smart/checkout-expired.component";
import CheckoutCancel from "../../../component/smart/checkout-cancel.component";
import CheckoutSettle from "../../../component/smart/checkout-settle.component";
import RestrictRoles from "../../../component/smart/restrict-roles.component";
import Headline from "../../../component/dumb/headline.component";

export default function Pix() {
  
  const { financial, setFinancial }       = useFinancialContext();
  const { floatPanel, setFloatPanel }     = useFloatPanelContext();

  const { checkout }                      = useParser<FinancialStateInterface>(financial);

  const analyticService                   = new AnalyticService();
  const checkoutService                   = new CheckoutService('buy');
  const floatPanelService                 = new FloatPanelService(floatPanel, setFloatPanel);

  useEffect(() => {    
    analyticService.Open('/financial/pix', 'Pix Information');

    if(checkout === undefined || checkout === null)
      return;
    
    if(checkoutService.IsIncomplete(checkout.status))
    {
      setFinancial({ ...financial, checkout: undefined, phase: BalancePhaseEnum.None });
      AppMap.Financial.UnSuccessfulCheckout();
      return;
    }
    
    floatPanelService.ShowConfirmationModal('financial.pix.qrCodeTitle', 'financial.pix.qrCodeMessage')
  }, [checkout]);

  if(checkout !== undefined && checkout !== null)
    return (
      <View style={[HelperStyle.fully, HelperStyle.topSpace]} id="custom2">
        <Headline.Light i18n="financial.pix.headlineCopy" id='hdCheckout' />
        <PixCodeClipboard />
        <PixTransactionDetails />
        <CheckoutCancel />
      
        <CheckoutExpired />
        <CheckoutSettle />
        <RestrictRoles source={RoleEnum.Guest} />
      </View>
    );
}