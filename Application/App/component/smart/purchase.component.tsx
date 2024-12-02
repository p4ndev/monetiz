import { useAccountContext, useFinancialContext, useFloatPanelContext } from '../../provider/contexts';
import { AnalyticService, CheckoutService, FloatPanelService } from '../../provider/services';
import { useParser, usePluralize } from '../../provider/handlers';
import { CoinStyle } from '../../provider/styles';
import i18n from '../../provider/locales';

import { AccountStateInterface, PaymentRequestInterface } from '../../shared/interfaces';
import { AppMap } from '../../shared/constants';

import BuyCoinEntry from '../dumb/buy-coin-entry.component';
import Headline from '../dumb/headline.component';
import { View } from 'react-native';

export default function Purchase() {
  
  const { account } = useAccountContext();
  const { financial, setFinancial } = useFinancialContext();
  const { floatPanel, setFloatPanel } = useFloatPanelContext();

  const { nameid, role, token } = useParser<AccountStateInterface>(account);

  const analyticService = new AnalyticService();
  const checkoutService = new CheckoutService('buy');
  const floatPanelService = new FloatPanelService(floatPanel, setFloatPanel);

  const onClickAsync  = async (id : number, amount : number) => {
    try
    {
      floatPanelService.ShowLoaderModal();

      const model : PaymentRequestInterface = {
        coins     : amount,
        id        : id.toString(),
        total     : checkoutService.PriceToBuy(amount),
        product   : (amount + ' ' + usePluralize(i18n.t('global.coin'), amount))
      };

      await checkoutService.InitializeAsync(model, token);
      const result = await checkoutService.LoadAsync(token);

      analyticService.TrackDetailed('Buy Coins', { UID: nameid, RID: role, coins: amount });
      setFinancial({ ...financial, checkout: result });
      floatPanelService.HideLoaderModal();
      AppMap.Financial.Checkout();
    }
    catch(err)
    {
      setFinancial({
        ...financial,
        checkout : undefined
      });

      floatPanelService
        .ShowConfirmationModal(
          checkoutService.name,
          checkoutService.content
        );
    }
  };

  return (
    <>
      <Headline.Light i18n='financial.buy.headline' id='hdCheckout' />
      <View id='pnCart'>
        <BuyCoinEntry
          id = 'FirstPackage'
          amount={checkoutService.coinPackages[0]}
          total={checkoutService.PriceToBuy(checkoutService.coinPackages[0])}
          stageStyle={CoinStyle.stage}
          iconStyle={CoinStyle.firstIcon}
          iconSource='https://res.cloudinary.com/ds7es4cwb/image/upload/v1726526322/first_dl9vzl.png'
          iconWrapperStyle = {CoinStyle.firstWrapper}
          onClicked={async () => await onClickAsync(1, checkoutService.coinPackages[0])} />

        <BuyCoinEntry 
          id = 'SecondPackage'
          amount={checkoutService.coinPackages[1]}
          total={checkoutService.PriceToBuy(checkoutService.coinPackages[1])}
          stageStyle={[CoinStyle.stage, CoinStyle.middleStage]}
          iconStyle={CoinStyle.secondIcon}
          iconSource='https://res.cloudinary.com/ds7es4cwb/image/upload/v1726526323/second_sgu8bg.png'
          iconWrapperStyle = {CoinStyle.secondWrapper}
          onClicked={async () => await onClickAsync(2, checkoutService.coinPackages[1])} />

        <BuyCoinEntry
          id = 'ThirdPackage'
          amount={checkoutService.coinPackages[2]}
          total={checkoutService.PriceToBuy(checkoutService.coinPackages[2])}
          stageStyle={CoinStyle.stage}
          iconStyle={CoinStyle.thirdIcon}
          iconSource='https://res.cloudinary.com/ds7es4cwb/image/upload/v1726526322/third_hr7jw2.png'
          iconWrapperStyle = {CoinStyle.thirdWrapper}
          onClicked={async () => await onClickAsync(3, checkoutService.coinPackages[2])} />
        </View>
    </>
  )
}