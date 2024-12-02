import { Keyboard, TextInput, View } from 'react-native';
import * as Clipboard from 'expo-clipboard';

import { useFinancialContext, useFloatPanelContext } from '../../provider/contexts';
import { AnalyticService, FloatPanelService } from '../../provider/services';
import { HelperStyle, PixCodeFormStyle } from '../../provider/styles';
import { useParser } from '../../provider/handlers';

import { FinancialStateInterface } from '../../shared/interfaces';

import Button from '../dumb/button.component';

export default function PixCodeClipboard(){

  const { financial } = useFinancialContext();
  const { floatPanel, setFloatPanel } = useFloatPanelContext();

  const { checkout } = useParser<FinancialStateInterface>(financial);

  const analyticService = new AnalyticService();
  const floatPanelService = new FloatPanelService(floatPanel, setFloatPanel);
  
  const onClickAsync = async () => {
    Keyboard.dismiss();
    
    const result = await Clipboard.setStringAsync(checkout.code);

    if(result === true)
      floatPanelService.ShowConfirmationModal(
        'financial.pix.clipboardName',
        'financial.pix.clipboardMessage'
      );

      analyticService.Track('Pix > Clipboard');
  };

  if(checkout !== undefined && checkout !== null)
    return(
      <View style={PixCodeFormStyle.stageClipboard}>
        <View style={PixCodeFormStyle.leftCell}>
          <View style={HelperStyle.inputWrap}>
            <TextInput value={checkout.code} style={[HelperStyle.input, HelperStyle.regular]} readOnly={true} />
          </View>
        </View>
        <View style={PixCodeFormStyle.rightCell}>
          <Button.Primary onClick={onClickAsync} icon='content-copy' />
        </View>
      </View>
    );
}