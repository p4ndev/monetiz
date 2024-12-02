import { View } from 'react-native';
import { timer } from 'rxjs';

import { useAccountContext, useFinancialContext, useFloatPanelContext } from '../../provider/contexts';
import { AnalyticService, CheckoutService, FloatPanelService } from '../../provider/services';
import { PixActionButtonsStyle } from '../../provider/styles';
import { useParser } from '../../provider/handlers';

import { AccountStateInterface, FinancialStateInterface, RemoveCheckoutRequestInterface } from '../../shared/interfaces';
import { AppMap, Millis } from '../../shared/constants';

import Button from '../dumb/button.component';

export default function CheckoutCancel(){

  const { account } = useAccountContext();
  const { financial, setFinancial } = useFinancialContext();
  const { floatPanel, setFloatPanel } = useFloatPanelContext();
  
  const { nameid, role, token } = useParser<AccountStateInterface>(account);
  const { checkout } = useParser<FinancialStateInterface>(financial);
  
  const analyticService = new AnalyticService();
  const checkoutService = new CheckoutService('buy');
  const floatPanelService = new FloatPanelService(floatPanel, setFloatPanel);  

  const onClickAsync = async () => {
    try
    {
      floatPanelService.ShowLoaderModal();

      const model : RemoveCheckoutRequestInterface = {
        internalPaymentId: checkout.innerPaymentId,
        externalPaymentId: checkout.outerPaymentId
      };

      await checkoutService.CancelAsync(model, token);

      floatPanelService
        .ShowInformationModal(
          checkoutService.name,
          checkoutService.content
        );

      setFinancial({
        ...financial,
        checkout: undefined
      });

      analyticService.TrackEvent('Cancel Checkout', { UID: nameid, RID: role, IPI: model.internalPaymentId, EPI: model.externalPaymentId });

      timer(Millis.CancelPixTransaction)
        .subscribe(() => {
          floatPanelService.HideInformationModal();
          AppMap.Financial.ShoppingCart();
        });
    }
    catch(e)
    {
      floatPanelService
        .ShowConfirmationModal(
          checkoutService.name,
          checkoutService.content
        );
    }    
  };

  if(token !== undefined && token !== null && token !== '')
    return (
      <View style={PixActionButtonsStyle.stage}>
        <Button.Danger onClick={onClickAsync} i18n='financial.pix.cancel' id='btnCancelTransaction' />
      </View>
    );
}