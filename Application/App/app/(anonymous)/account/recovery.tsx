import { View, Text, TextInput, Keyboard } from 'react-native';
import React, { useEffect, useState } from 'react';
import { timer } from 'rxjs';

import { AnalyticService, FloatPanelService, RecoveryService, ValidationService } from '../../../provider/services';
import { HelperStyle, AccountStyle } from '../../../provider/styles';
import { useFloatPanelContext } from '../../../provider/contexts';
import i18n from '../../../provider/locales/translation';

import { AppMap, Millis } from '../../../shared/constants';

import Headline from '../../../component/dumb/headline.component';
import Button from '../../../component/dumb/button.component';

export default function Recovery() {

  const { floatPanel, setFloatPanel }       = useFloatPanelContext();

  const [ model, setModel ]                 = useState<string>('');
  
  const analyticService                     = new AnalyticService();
  const recoveryService                     = new RecoveryService();
  const validationService                   = new ValidationService();
  const floatPanelService                   = new FloatPanelService(floatPanel, setFloatPanel);
  
  const onFormSubmitAsync = async (e) => {
    if(e !== undefined || e !== null)
      e.preventDefault();

    await onSubmitAsync();
  };

  const onSubmitAsync = async () => {
    try
    {
      Keyboard.dismiss();
      
      if(!validationService.IsValidEmail(model)) {
        analyticService.TrackEvent('Recovery > Validation Error', { FIELDS: validationService.from, INPUTS: validationService.data });
        floatPanelService.ShowConfirmationModal(validationService.name, validationService.content);
        validationService.Reset();
        return;
      }

      floatPanelService.ShowLoaderModal();
      await recoveryService.SendRecoveryEmailAsync(model);
      setModel('');

      floatPanelService
        .ShowConfirmationModal(
          recoveryService.name,
          recoveryService.content
        );

      analyticService.TrackEvent('Email Recovery Requested', { EMAIL: model });

      timer(Millis.PasswordRecoverySuccessful)
        .subscribe(() => {
          AppMap.Account.SignIn();
        });
    }
    catch(e)
    {
      floatPanelService.ShowConfirmationModal(recoveryService.name, recoveryService.content);
    }
  };

  useEffect(() => {    
    analyticService.Open('/account/recovery', 'Recovery');

    timer(Millis.CloseInitialModal).subscribe(floatPanelService.HideLoaderModal);
  }, []);

  return (
    <View style={[HelperStyle.fully, HelperStyle.topSpace, AccountStyle.stage]} id="custom">
      <Headline.Light i18n='account.recovery.headline' id='hdRecovery' />
      <View style={AccountStyle.form} id='frRecovery'>
        <form onSubmit={onFormSubmitAsync}>
          <Text style={AccountStyle.label}>{i18n.t('global.emailLabel')} *</Text>
          <View style={HelperStyle.inputWrap}>
            <TextInput
              maxLength={80}
              inputMode='email'
              id='txtEmail'
              value={model}
              style={[HelperStyle.input, HelperStyle.regular]}
              placeholderTextColor={'#b1b1b1'}
              placeholder={i18n.t('global.placeholderEmail')}
              onChangeText={(t) => setModel(t)} />
          </View>
          <View style={AccountStyle.submitRow}>
            <View style={AccountStyle.submitLeft}>
              <Text style={AccountStyle.requirement}>{i18n.t('global.requiredLabel')}</Text>
            </View>
            <View style={AccountStyle.submitRight}>
              <Button.Secondary onClick={onSubmitAsync} i18n='account.recovery.submit' />
              <input type="submit" hidden />
            </View>
          </View>
        </form>
      </View>
    </View>
  );
}