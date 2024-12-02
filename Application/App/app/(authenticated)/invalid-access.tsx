import { View, Text, Image, Pressable } from 'react-native';
import { MaterialIcons } from '@expo/vector-icons';
import { useEffect } from 'react';
import { timer } from 'rxjs';

import { AnalyticService, FloatPanelService } from '../../provider/services';
import { HelperStyle, IllustrationStyle } from '../../provider/styles';
import { useFloatPanelContext } from '../../provider/contexts';
import i18n from '../../provider/locales';

import { AppMap, Millis, useAsset } from '../../shared/constants';

export default function InvalidAccess() {
  
  const { floatPanel, setFloatPanel }   = useFloatPanelContext();

  const analyticService = new AnalyticService();
  const floatPanelService = new FloatPanelService(floatPanel, setFloatPanel);

  const onSignOutClicked = async () => {
    analyticService.Track('Sign Out From Invalid Access');

    AppMap.Account.SignOut();
  };

  useEffect(() => {    
    analyticService.Open('/invalid-access', 'Invalid Access');

    timer(Millis.CloseInitialModal * 2).subscribe(floatPanelService.HideLoaderModal);
  }, []);

  return (
    <View style={HelperStyle.fullyCentered}>
      
      <Image
        resizeMode='contain'
        style={IllustrationStyle.icon}
        source={{ uri: useAsset('https://res.cloudinary.com/ds7es4cwb/image/upload/v1726526322/restrict-access_vmxryw.png') }} />

      <Text style={IllustrationStyle.headline} id='hdInvalidAccess'>
        { i18n.t('global.restriction.access') }
      </Text>

      <Pressable onPress={async () => await onSignOutClicked()}>
        <MaterialIcons name="login" size={34} color={'#AAA'} />
      </Pressable>
    </View>
  );
}