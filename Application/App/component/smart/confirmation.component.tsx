import { View, Text } from 'react-native';

import { FloatPanelStyle, HelperStyle } from '../../provider/styles';
import { useFloatPanelContext } from '../../provider/contexts';
import { FloatPanelService } from '../../provider/services';
import i18n from '../../provider/locales/translation';

import { FloatPanelStateContent } from '../../shared/interfaces';

import Button from '../dumb/button.component';

export default function Confirmation(props : FloatPanelStateContent){

  const { floatPanel, setFloatPanel } = useFloatPanelContext();

  const floatPanelService = new FloatPanelService(floatPanel, setFloatPanel);
  
  return(
    <View style={[FloatPanelStyle.box, FloatPanelStyle.confirmationBox]}>
      <Text style={[FloatPanelStyle.confirmationBoxName, HelperStyle.bold]} id='txtTitle'>
        { props.name ? i18n.t(props.name) : '' }
      </Text>
      <Text style={FloatPanelStyle.confirmationBoxContent} id='txtContent'>
        { props.content ? i18n.t(props.content) : '' }
      </Text>
      <View style={FloatPanelStyle.informationSubmit}>
      <Button.Primary onClick={floatPanelService.HideConfirmationModal} label='Ok' />
      </View>
    </View>
  );
}