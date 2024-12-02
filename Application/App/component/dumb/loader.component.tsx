import { View, ActivityIndicator, Text } from 'react-native';

import { FloatPanelStyle, HelperStyle } from '../../provider/styles';
import i18n from '../../provider/locales/translation';

export default function Loader(){  
  return(
    <View style={[FloatPanelStyle.box, FloatPanelStyle.loaderBox]}>
      <Text style={[FloatPanelStyle.loaderBoxName, HelperStyle.bold]}>
        { i18n.t('loader.name') }
      </Text>
      <ActivityIndicator size="large" color="#8600FF" testID='loaderBoxIndicator' />
    </View>
  );
}