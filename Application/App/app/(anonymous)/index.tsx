import { View, Image } from 'react-native';
import React, { useEffect } from 'react';
import { timer } from 'rxjs';

import { AnalyticService, FloatPanelService } from '../../provider/services';
import { HelperStyle, IndexStyle } from '../../provider/styles';
import { useFloatPanelContext } from '../../provider/contexts';

import { useAsset, AppMap, Millis } from '../../shared/constants';

import CaptureQuerystring from '../../component/smart/capture-querystring.component';
import Button from '../../component/dumb/button.component';

export default function Index() {

    const { floatPanel, setFloatPanel }     = useFloatPanelContext();
    
    const analyticService                   = new AnalyticService();
    const floatPanelService                 = new FloatPanelService(floatPanel, setFloatPanel);
  
    const stripes                           = { uri: useAsset('https://res.cloudinary.com/ds7es4cwb/image/upload/v1726526323/logotype-lights_l5quyl.svg') };
    const logotype                          = { uri: useAsset('https://res.cloudinary.com/ds7es4cwb/image/upload/v1726526323/v0.0.3-Regular_pclwyb.png') };

    const onSignInClicked = () => {
        analyticService.Track('Sign In');
        AppMap.Account.SignIn();
    }

    const onSignUpClicked = () => {
        analyticService.Track('Sign Up');
        AppMap.Account.SignUp();
    }

    const onHowToPlayClicked = () => {
        analyticService.Track('How To Play');
        AppMap.HowToPlay();
    }

    useEffect(() => {
        analyticService.Open('/', 'Splash');

        timer(Millis.CloseInitialModal)
            .subscribe(floatPanelService.HideLoaderModal);
    }, []);
      
    return (
        <>
            <CaptureQuerystring />
            <View style={[HelperStyle.fullyCentered]} id="custom">
                <View style={HelperStyle.fullyCentered} id="rounded">
                    <Image style={IndexStyle.logotypeBackground} source={stripes} />
                    <View style={[IndexStyle.panel, HelperStyle.fullyCentered]} id="splash">
                        <Image style={IndexStyle.logotype} source={logotype} />
                        <Button.Primary onClick={onSignInClicked} i18n='index.signIn' />                        
                        <Button.Primary onClick={onSignUpClicked} i18n='index.signUp' />
                        <Button.Secondary onClick={onHowToPlayClicked} i18n='index.help' />
                    </View>
                </View>
            </View>       
        </>
    );
}