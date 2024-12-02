import { View, Text } from 'react-native';

import { FloatPanelStateContent } from '../../shared/interfaces';
import { FloatPanelStyle, HelperStyle } from '../../provider/styles';
import i18n from '../../provider/locales/translation';

export default function Information(props : FloatPanelStateContent){
  return(
    <View style={[FloatPanelStyle.box, FloatPanelStyle.informationBox]}>
      <Text style={[FloatPanelStyle.informationBoxName, HelperStyle.bold]} id='txtTitle'>
        { props.name ? i18n.t(props.name) : '' }
      </Text>
      <Text style={FloatPanelStyle.informationBoxContent} id='txtContent'>
        { props.content ? i18n.t(props.content) : '' }
      </Text>
    </View>
  );
}