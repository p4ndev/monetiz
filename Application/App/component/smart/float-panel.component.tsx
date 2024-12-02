import { View, Modal } from 'react-native';

import { FloatPanelStyle, HelperStyle } from '../../provider/styles';
import { FloatPanelStateInterface } from '../../shared/interfaces';
import { FloatPanelEnum } from '../../shared/enums';

import { useFloatPanelContext } from '../../provider/contexts';
import Information from '../dumb/information.component';
import { useParser } from '../../provider/handlers';
import Confirmation from './confirmation.component';
import Loader from '../dumb/loader.component';

export default function FloatPanel(){

    const { floatPanel } = useFloatPanelContext();
    
    const { isVisible, which, name, content } = useParser<FloatPanelStateInterface>(floatPanel);

    return (
        <Modal animationType="fade" transparent={true} visible={isVisible} id='pnModal'>
            <View style={[ HelperStyle.fullyCentered, FloatPanelStyle.stage ]}>
                {(() => {
                    switch(which){

                        case FloatPanelEnum.Information:
                            return <Information name={name} content={content} />;
                        
                        case FloatPanelEnum.Confirmation:
                            return <Confirmation name={name} content={content} />;
                        
                        default:
                        case FloatPanelEnum.Loading:
                            return <Loader />;
                        
                        }
                })()}
            </View>
        </Modal>
    );
}