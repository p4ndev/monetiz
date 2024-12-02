import { View, Text, Image, Pressable } from 'react-native';
import { MaterialIcons } from '@expo/vector-icons';
import { useEffect } from 'react';
import { timer } from 'rxjs';

import { AnalyticService, FloatPanelService } from '../../provider/services';
import { HelperStyle, IllustrationStyle } from '../../provider/styles';
import { useFloatPanelContext } from '../../provider/contexts';
import i18n from '../../provider/locales';

import { AppMap, Millis, useAsset } from '../../shared/constants';

export default function EmptyList() {
  
  const { floatPanel, setFloatPanel }   = useFloatPanelContext();

  const analyticService                 = new AnalyticService();
  const floatPanelService               = new FloatPanelService(floatPanel, setFloatPanel);

  const onSignOutClicked = async () => {
    analyticService.Track('Sign Out From Empty List');

    AppMap.Account.SignOut();
  };

  useEffect(() => {    
    analyticService.Open('/empty-list', 'Empty List');

    timer(Millis.CloseInitialModal * 2).subscribe(() => floatPanelService.HideLoaderModal());
  }, []);

  return (
    <View style={HelperStyle.fullyCentered}>      
      <Image
        resizeMode='contain'
        style={IllustrationStyle.icon}
        source={{ uri: useAsset('https://res.cloudinary.com/ds7es4cwb/image/upload/v1726526323/empty-result_wgegsr.png') }} />

      <Text style={IllustrationStyle.headline}>
        { i18n.t('global.restriction.emptyList') }
      </Text>

      <Pressable onPress={async () => await onSignOutClicked()}>
        <MaterialIcons name="login" size={34} color={'#AAA'} />
      </Pressable>
    </View>
  );
}