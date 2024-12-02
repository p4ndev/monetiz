import { View, Text, Image, Pressable, Linking } from 'react-native';

import { useAccountContext, useFinancialContext } from '../../provider/contexts';
import i18n, { useShortestDate, useShortestTime } from "../../provider/locales";
import { AnalyticService, CheckoutService } from '../../provider/services';
import { HelperStyle, PixTransactionStyle } from "../../provider/styles";
import { useParser, usePrice } from '../../provider/handlers';

import { AccountStateInterface, FinancialStateInterface } from "../../shared/interfaces";
import { useAsset } from "../../shared/constants";

export default function PixTransactionDetails(){

  const { account } = useAccountContext();
  const { financial } = useFinancialContext();

  const { nameid, role } = useParser<AccountStateInterface>(account);
  const { checkout } = useParser<FinancialStateInterface>(financial);

  const analyticService = new AnalyticService();
  const checkoutService = new CheckoutService('buy');
  
  const openExternalUrlAsync = async () => {
    if(Linking.canOpenURL(checkout.ticketUrl)){
      analyticService.TrackDetailed('Pix > Mercado Pago > Checkout', { UID: nameid, RID: role });
      Linking.openURL(checkout.ticketUrl);
    }
  }

  if(checkout !== undefined && checkout !== null)
    return(
      <View style={PixTransactionStyle.stage} id='pnCheckoutDetails'>
        <Pressable onPress={async () => await openExternalUrlAsync()}>
          <Image source={{ uri: useAsset('https://res.cloudinary.com/ds7es4cwb/image/upload/v1726526322/mercado-pago_gy2zvz.svg') }} style={PixTransactionStyle.mercadoPago} />
        </Pressable>

        <Text style={PixTransactionStyle.info} id="lblInfo">&bull; { i18n.t('financial.pix.to') } <Text style={HelperStyle.bold}>{ checkoutService.companyName }</Text>;</Text>

        <Text style={PixTransactionStyle.info} id="lblProduct">&bull; <Text style={HelperStyle.bold}>{ checkout.coins }</Text> { i18n.t('financial.pix.what') } <Text style={HelperStyle.bold}>{ usePrice(checkout.total) }</Text>;</Text>

        <Text style={PixTransactionStyle.info} id="lblExpiration">&bull; { i18n.t('financial.pix.expiration') } <Text style={HelperStyle.bold}>{ useShortestDate(checkout.expiresAt) }</Text> { i18n.t('financial.pix.when') } <Text style={HelperStyle.bold}>{ useShortestTime(checkout.expiresAt) }</Text>;</Text>
        
        <Text style={PixTransactionStyle.info} id="lblTracking">&bull; { i18n.t('financial.pix.trackPurchase') } <Text style={HelperStyle.bold}>{ checkoutService.PurchaseTrackId(checkout) }</Text>;</Text>

        <Text style={PixTransactionStyle.info} id="lblTax">&bull; { i18n.t('financial.pix.taxes') } <Text style={HelperStyle.bold}>{ i18n.t('financial.pix.taxesCenter') }</Text> { i18n.t('financial.pix.taxesSuffix') };</Text>

        <Text style={PixTransactionStyle.info} id="lblRefresh">&bull; { i18n.t('financial.pix.autoRefresh') } <Text style={HelperStyle.bold}>{ i18n.t('financial.pix.autoRefreshSuffix') }</Text>;</Text>
      </View>
    );
}