import { SafeAreaView, ScrollView } from 'react-native';
import React, { useEffect } from 'react';

import { useAccountContext, useFinancialContext, useFloatPanelContext } from '../../../provider/contexts';
import { AnalyticService, FloatPanelService } from '../../../provider/services';
import { HelperStyle } from '../../../provider/styles';
import { useParser } from '../../../provider/handlers';

import { AccountStateInterface, FinancialStateInterface } from '../../../shared/interfaces';
import { ClaimEnum, RoleEnum } from '../../../shared/enums';

import RestrictClaims from '../../../component/smart/restrict-claims.component';
import RestrictRoles from '../../../component/smart/restrict-roles.component';
import Withdraw from '../../../component/smart/withdraw.component';
import Purchase from '../../../component/smart/purchase.component';
import PixForm from '../../../component/smart/pix-form.component';

export default function ShoppingCart() {

  const { account }                       = useAccountContext();
  const { financial }                     = useFinancialContext();
  const { floatPanel, setFloatPanel }     = useFloatPanelContext();
  
  const { claims }                        = useParser<AccountStateInterface>(account);
  const { coin }                          = useParser<FinancialStateInterface>(financial);

  const analyticService                   = new AnalyticService();
  const floatPanelService                 = new FloatPanelService(floatPanel, setFloatPanel);

  const hasBalance                        = () => (coin !== undefined && coin !== null && coin > 0);
  const hasPix                            = () => (claims && claims.indexOf(ClaimEnum.HasPixKey) !== -1);

  useEffect(() => {
    analyticService.Open('/financial/checkout', 'Checkout');

    if(claims === undefined || claims === null)
      return;
    
    floatPanelService.HideLoaderModal();
  }, [claims]);

  return (
    <SafeAreaView style={[HelperStyle.fully, HelperStyle.topSpace]} id="custom2">
      <ScrollView>
        { (!hasPix() && hasBalance()) && <PixForm />}
        <Purchase />
        { hasPix() &&  <Withdraw /> }
        <RestrictRoles source={RoleEnum.Guest} />
        <RestrictClaims source={ClaimEnum.HasEmailConfirmed} />
      </ScrollView>
    </SafeAreaView>
  );
}