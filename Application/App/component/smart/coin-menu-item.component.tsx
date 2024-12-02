import { View, Text, Image } from 'react-native';

import { HelperStyle, CoinMenuItemStyle } from '../../provider/styles';
import { useFinancialContext } from '../../provider/contexts';
import { useParser } from '../../provider/handlers';

import { FinancialStateInterface } from '../../shared/interfaces';
import { useAsset } from '../../shared/constants';

export default function CoinMenuItem() { 

  const { financial } = useFinancialContext();

  const { coin } = useParser<FinancialStateInterface>(financial);

  const coinSource = { uri: useAsset('https://res.cloudinary.com/ds7es4cwb/image/upload/v1726526323/coin_ubc2lr.png') };
  
  if(coin !== undefined)
    return (
      <View style={CoinMenuItemStyle.stage}>      
        <Text style={[HelperStyle.semiBold, CoinMenuItemStyle.label]} id='coinWallet'>
          { coin <= 0 ? 0 : coin }
        </Text>
        <View id={coin <= 0 ? 'emptyWallet' : 'wallet'}>
          <Image source={coinSource} style={CoinMenuItemStyle.centerCoin} />
          <Image source={coinSource} style={CoinMenuItemStyle.leftCoin} />
          <Image source={coinSource} style={CoinMenuItemStyle.rightCoin} />
        </View>
      </View>
    );
}