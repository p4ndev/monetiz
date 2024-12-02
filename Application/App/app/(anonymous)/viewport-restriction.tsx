import { View, Text, Image } from 'react-native';
import { useEffect } from 'react';
import { timer } from 'rxjs';

import { AnalyticService, DeviceService, FloatPanelService } from '../../provider/services';
import { HelperStyle, IllustrationStyle } from '../../provider/styles';
import { useFloatPanelContext } from '../../provider/contexts';
import i18n from '../../provider/locales';

import { AppMap, Millis, useAsset } from '../../shared/constants';

export default function ViewportRestriction() {
  
  const { floatPanel, setFloatPanel }   = useFloatPanelContext();

  const analyticService = new AnalyticService();
  const deviceService                   = new DeviceService();
  const floatPanelService               = new FloatPanelService(floatPanel, setFloatPanel);

  useEffect(() => {
    timer(Millis.CloseInitialModal * 2)
      .subscribe(() => {
        if(!deviceService.IsLandscape()){
          AppMap.Splash();
          return;
        }          

        floatPanelService.HideLoaderModal();
      });
    
      analyticService.Open('/viewport-restriction', 'Viewport Restriction');
  }, []);

  return (
    <View style={HelperStyle.fullyCentered}>
      
      <Image
        resizeMode='contain'
        style={IllustrationStyle.icon}
        source={{ uri: useAsset('https://res.cloudinary.com/ds7es4cwb/image/upload/v1726526322/orientation-issue_zmn39i.png') }} />

      <Text style={IllustrationStyle.headline} id='hdViewportRestriction'>
        { i18n.t('global.restriction.viewport') }
      </Text>

    </View>
  );
}