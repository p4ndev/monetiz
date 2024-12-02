import { View, Image, Text } from "react-native";

import { usePluralize, usePrice } from "../../provider/handlers";
import { CoinStyle, HelperStyle } from "../../provider/styles";
import i18n from "../../provider/locales/translation";

import { BuyCoinEntryPropsInterface } from "../../shared/interfaces";
import { useAsset } from "../../shared/constants";

import Button from "./button.component";

export default function BuyCoinEntry(props : BuyCoinEntryPropsInterface){
  return (
    <View style={props.stageStyle}>
      <View style={CoinStyle.leftColumn}>
        <View style={props.iconWrapperStyle}>
          <Image 
            resizeMode='contain'
            style={props.iconStyle}
            source={{ uri: useAsset(props.iconSource) }} />
        </View>
      </View>
      <View style={CoinStyle.centerColumn}>
        <Text style={[CoinStyle.amount, HelperStyle.bold]}>{ props.amount }</Text>
        <Text style={[CoinStyle.label, HelperStyle.light]}>{ usePluralize(i18n.t('global.coin'), props.amount) }</Text>
      </View>
      <View style={CoinStyle.rightColumn}>
        <Button.Primary onClick={props.onClicked} label={usePrice(props.total)} id={'btn' + props.id} />
      </View>
    </View>
  );
}