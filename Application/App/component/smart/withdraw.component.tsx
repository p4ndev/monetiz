import { View } from "react-native";
import { timer } from "rxjs";

import { useAccountContext, useFinancialContext, useFloatPanelContext } from "../../provider/contexts";
import { AnalyticService, CheckoutService, FloatPanelService } from "../../provider/services";
import { useParser, usePluralize } from "../../provider/handlers";
import { CoinStyle } from "../../provider/styles";
import i18n from "../../provider/locales";

import { AccountStateInterface, FinancialStateInterface, PaymentRequestInterface } from "../../shared/interfaces";
import { AppMap, Millis } from "../../shared/constants";
import { BalancePhaseEnum } from "../../shared/enums";

import SellCoinEntry from "../dumb/sell-coin-entry.component";
import Headline from "../dumb/headline.component";

export default function Withdraw() {
  
  const { account } = useAccountContext();
  const { financial, setFinancial } = useFinancialContext();
  const { floatPanel, setFloatPanel } = useFloatPanelContext();

  const { nameid, role, token } = useParser<AccountStateInterface>(account);
  const { coin } = useParser<FinancialStateInterface>(financial);

  const analyticService = new AnalyticService();
  const checkoutService = new CheckoutService('sell');
  const floatPanelService = new FloatPanelService(floatPanel, setFloatPanel);
  
  const onClickAsync  = async () => {
    try
    {
      floatPanelService.ShowLoaderModal();

      const model : PaymentRequestInterface = {
        id        : '',
        coins     : coin,
        total     : Number(checkoutService.PriceToSell(coin).toFixed(2)),
        product   : (coin + ' ' + usePluralize(i18n.t('global.coin'), coin))
      };

      await checkoutService.InitializeAsync(model, token);

      setFinancial({ ...financial, phase: BalancePhaseEnum.Sync });

      floatPanelService.ShowInformationModal('financial.sell.successName', 'financial.sell.successMessage');

      analyticService.TrackDetailed('Sell Coins', { UID: nameid, RID: role, coins: coin });

      timer(Millis.InitialWithdraw)
        .subscribe(() => {
          floatPanelService.HideInformationModal();
          AppMap.Lobby.Tenant();
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

  if(coin !== undefined && coin !== null && coin > 0)
    return (
      <View id='pnWithdraw' style={CoinStyle.stageWrapper}>
        <Headline.Light i18n='financial.sell.headline' id='hdWithdraw' />
        <SellCoinEntry
          id={1}
          amount={coin}
          total={checkoutService.PriceToSell(coin)}
          onClicked={async () => await onClickAsync()} />
      </View>
    );
}