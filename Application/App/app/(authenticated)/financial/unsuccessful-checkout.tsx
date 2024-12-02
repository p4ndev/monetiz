import { View, Text, Image } from 'react-native';
import { useEffect } from 'react';
import { timer } from 'rxjs';

import { AnalyticService, FloatPanelService } from '../../../provider/services';
import { HelperStyle, IllustrationStyle } from '../../../provider/styles';
import { useFloatPanelContext } from '../../../provider/contexts';
import i18n from '../../../provider/locales';

import { Millis, useAsset } from '../../../shared/constants';

export default function UnSuccessfulCheckout() {
  
  const { floatPanel, setFloatPanel }   = useFloatPanelContext();
  
  const analyticService                 = new AnalyticService();
  const floatPanelService               = new FloatPanelService(floatPanel, setFloatPanel);

  useEffect(() => {    
    analyticService.Open('/financial/unsuccessful-checkout', 'Failed Checkout');

    timer(Millis.CloseInitialModal * 2).subscribe(floatPanelService.HideLoaderModal);
  }, []);

  return (
    <View style={HelperStyle.fullyCentered}>
      
      <Image
        resizeMode='contain'
        style={IllustrationStyle.icon}
        source={{ uri: useAsset('https://res.cloudinary.com/ds7es4cwb/image/upload/v1726526323/unsuccessful-checkout_b81n2o.png') }} />

      <Text style={IllustrationStyle.headline} id="hdUnsuccessCheckout">
        { i18n.t('global.restriction.unsuccessCheckout') }
      </Text>

    </View>
  );
}