import { View, Text, TextInput, Keyboard } from 'react-native';
import React, { useEffect, useState } from 'react';
import { timer } from 'rxjs';

import { AccessService, AnalyticService, FloatPanelService, RecoveryService, ValidationService } from '../../../provider/services';
import { HelperStyle, AccountStyle } from '../../../provider/styles';
import { useFloatPanelContext } from '../../../provider/contexts';
import i18n from '../../../provider/locales/translation';

import { RecoveryModelInterface, RecoveryRequestInterface } from '../../../shared/interfaces';
import { AccountRecoveryModel } from '../../../shared/states';
import { AppMap, Millis } from '../../../shared/constants';

import Headline from '../../../component/dumb/headline.component';
import Button from '../../../component/dumb/button.component';

export default function Reset() {

  const { floatPanel, setFloatPanel } = useFloatPanelContext();

  const [ model, setModel ]           = useState<RecoveryModelInterface>(AccountRecoveryModel);
  
  const accessService                 = new AccessService();
  const analyticService               = new AnalyticService();
  const recoveryService               = new RecoveryService();
  const validationService             = new ValidationService();
  const floatPanelService             = new FloatPanelService(floatPanel, setFloatPanel);

  const onFormSubmitAsync = async (e) => {
    if(e !== undefined || e !== null)
      e.preventDefault();

    await onSubmitAsync();
  };

  const onSubmitAsync = async () => {
    try
    {
      Keyboard.dismiss();
      
      const { accountId, stamp, operation } = await accessService.FindQuerystringAsync();

      if(operation !== undefined && operation !== null &&
          operation.toString().toLowerCase() !== 'recovery')
            return;

      floatPanelService.ShowLoaderModal();

      const request : RecoveryRequestInterface = {
        stamp     : stamp.toString(),
        id        : Number(accountId),
        password  : model.password,
        email     : model.email
      };

      if(
        !validationService.IsValidId(request.id) ||
        !validationService.IsValidGuid(request.stamp) ||
        !validationService.IsValidEmail(request.email) ||
        !validationService.IsValidPassword(request.password)
      ){
        analyticService.TrackEvent('Reset > Validation Error', { FIELDS: validationService.from, INPUTS: validationService.data });
        floatPanelService.ShowConfirmationModal(validationService.name, validationService.content);
        validationService.Reset();
        return;
      }

      await recoveryService.ResetPasswordAsync(request);
      await accessService.ClearQuerystringAsync();
      
      setModel(AccountRecoveryModel);
      analyticService.TrackEvent('User Resetted Password', { UID: request.id });
      floatPanelService.ShowConfirmationModal(recoveryService.name, recoveryService.content);
      
      timer(Millis.PasswordResetSuccessful).subscribe(AppMap.Account.SignOut);
    }
    catch(e)
    {
      floatPanelService
        .ShowConfirmationModal(
          recoveryService.name,
          recoveryService.content
        );
    }
  };

  useEffect(() => {    
    analyticService.Open('/account/reset', 'Reset');

    timer(Millis.CloseInitialModal).subscribe(floatPanelService.HideLoaderModal);
  }, []);

  return (
    <View style={[HelperStyle.fully, HelperStyle.topSpace, AccountStyle.stage]} id="custom">
      <Headline.Light i18n='account.reset.headline' id='hdReset' />
      <View style={AccountStyle.form} id='frReset'>
        <form onSubmit={onFormSubmitAsync}>
          <Text style={AccountStyle.label}>{i18n.t('global.emailLabel')} *</Text>
          <View style={HelperStyle.inputWrap}>
            <TextInput
              maxLength={80}
              inputMode='email'
              id='txtEmail'
              value={model.email}
              style={[HelperStyle.input, HelperStyle.regular]}
              placeholderTextColor={'#b1b1b1'}
              placeholder={i18n.t('global.placeholderEmail')}
              onChangeText={(t) => setModel({ ...model, email: t })} />
          </View>
          <Text style={AccountStyle.label}>{i18n.t('global.passwordLabel')} *</Text>        
          <View style={HelperStyle.inputWrap}>
            <TextInput
              maxLength={30}
              secureTextEntry={true}
              id='txtPassword'
              value={model.password}
              style={[HelperStyle.input, HelperStyle.regular]}
              placeholderTextColor={'#b1b1b1'}
              placeholder={i18n.t('global.placeholderPassword')}
              onChangeText={(t) => setModel({ ...model, password: t })} />
          </View>
          <View style={AccountStyle.submitRow}>
            <View style={AccountStyle.submitLeft}>
              <Text style={AccountStyle.requirement}>{i18n.t('global.requiredLabel')}</Text>
            </View>
            <View style={AccountStyle.submitRight}>
              <Button.Secondary onClick={onSubmitAsync} i18n='account.reset.submit' />
              <input type="submit" hidden />
            </View>
          </View>
        </form>
      </View>
    </View>
  );
}