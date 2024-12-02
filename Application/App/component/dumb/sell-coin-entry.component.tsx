import { Text, View, Image } from "react-native";

import { usePluralize, usePrice } from "../../provider/handlers";
import { CoinStyle, HelperStyle } from "../../provider/styles";
import i18n from "../../provider/locales";

import { SellCoinEntryPropsInterface } from "../../shared/interfaces";
import { useAsset } from "../../shared/constants";

import Button from "./button.component";

export default function SellCoinEntry(props : SellCoinEntryPropsInterface){
  return (
    <View style={[CoinStyle.stage, CoinStyle.sellStage]}>
      <View style={CoinStyle.leftColumn}>
        <View style={CoinStyle.fourthWrapper}>
          <Image 
            resizeMode='contain'
            style={CoinStyle.fourthIcon}
            source={{ uri: useAsset('https://res.cloudinary.com/ds7es4cwb/image/upload/v1726526323/withdraw_po9lkc.png') }} />
        </View>
      </View>
      <View style={CoinStyle.centerColumn} id={'lblWithdrawAmount-' + props.id}>
        <Text style={[CoinStyle.amount, HelperStyle.bold]}>{ props.amount }</Text>
        <Text style={[CoinStyle.label, HelperStyle.light]}>{ usePluralize(i18n.t('global.coin'), props.amount) }</Text>
      </View>
      <View style={CoinStyle.rightColumn}>
        <Button.Secondary onClick={props.onClicked} label={ usePrice(props.total) } id={'btnWithdraw-' + props.id} />
      </View>
    </View>
  );
}