import { View, Text, TextInput, Keyboard } from 'react-native';
import React, { useEffect, useState } from 'react';
import { timer } from 'rxjs';

import { AccessService, AnalyticService, FloatPanelService, ValidationService } from '../../../provider/services';
import { useAccountContext, useFinancialContext, useFloatPanelContext } from '../../../provider/contexts';
import { HelperStyle, AccountStyle } from '../../../provider/styles';
import i18n from '../../../provider/locales/translation';

import { SignInRequestInterface } from '../../../shared/interfaces';
import { BalancePhaseEnum, ClaimEnum } from '../../../shared/enums';
import { AccountSignInModel } from '../../../shared/states';
import { AppMap, Millis } from '../../../shared/constants';

import Headline from '../../../component/dumb/headline.component';
import Button from '../../../component/dumb/button.component';

export default function SignIn() {

  const { setAccount }                          = useAccountContext();
  const { financial, setFinancial }             = useFinancialContext();
  const { floatPanel, setFloatPanel }           = useFloatPanelContext();

  const [model, setModel]                       = useState<SignInRequestInterface>(AccountSignInModel);
  
  const analyticService                         = new AnalyticService();
  const accessService                           = new AccessService();
  const validationService                       = new ValidationService();
  const floatPanelService                       = new FloatPanelService(floatPanel, setFloatPanel);

  const onFormSubmitAsync = async (e) => {
    if(e !== undefined || e !== null)
      e.preventDefault();

    await onSubmitAsync();
  };

  const onSubmitAsync = async () => {
    try
    {
      Keyboard.dismiss();
      
      if(
        !validationService.IsValidEmail(model.email) || 
          !validationService.IsValidPassword(model.password)
      ) {
        analyticService.TrackEvent('Sign In > Validation Error', { FIELDS: validationService.from, INPUTS: validationService.data });
        floatPanelService.ShowConfirmationModal(validationService.name, validationService.content);        
        validationService.Reset();
        return;
      }
      
      let hasInvalidAccess = false;
      floatPanelService.ShowLoaderModal();
      const accountData = await accessService.SignInAsync(model);
      floatPanelService.ShowInformationModal(accessService.name, accessService.content);

      if(accountData)
      {
        const playerData = await accessService.SaveAccountOfflineAsync(accountData);

        if(playerData.claims.indexOf(ClaimEnum.HasAppAccess) === -1)
          hasInvalidAccess = true;

        analyticService.TrackEvent('User Signed In', { UID: playerData.nameid, RID: playerData.role });
        setAccount(playerData);
      }

      setFinancial({ ...financial, phase: BalancePhaseEnum.Sync});      
      setModel(AccountSignInModel);

      timer(Millis.SignInSuccessful)
        .subscribe(() => {
          if(hasInvalidAccess)    AppMap.InvalidAccess();
          else                    AppMap.Lobby.Tenant();
        });
    }
    catch(e)
    {
      floatPanelService.ShowConfirmationModal(accessService.name, accessService.content);
    }
  };

  useEffect(() => {
    analyticService.Open('/account/sign-in', 'Sign In');

    timer(Millis.CloseInitialModal).subscribe(floatPanelService.HideLoaderModal);
  }, []);

  return (
    <View style={[HelperStyle.fully, HelperStyle.topSpace, AccountStyle.stage]} id='custom'>
      <Headline.Light i18n='account.signIn.headline' id='hdSignIn' />
      <View style={AccountStyle.form} id='frSignIn'>
        <form onSubmit={onFormSubmitAsync}>
          <Text style={AccountStyle.label}>{i18n.t('global.emailLabel')} *</Text>
          <View style={HelperStyle.inputWrap}>
            <TextInput
              tabIndex={0}
              id='txtEmail'
              maxLength={80}
              inputMode='email'
              value={model.email}
              style={[HelperStyle.input, HelperStyle.regular]}
              placeholderTextColor={'#b1b1b1'}
              placeholder={i18n.t('global.placeholderEmail')}
              onChangeText={(t) => setModel({ ...model, email: t })} />
          </View>
          <Text style={AccountStyle.label}>{i18n.t('global.passwordLabel')} *</Text>
          <View style={HelperStyle.inputWrap}>
            <TextInput
              tabIndex={0}
              maxLength={30}
              id='txtPassword'
              secureTextEntry={true}
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
              <Button.Secondary onClick={onSubmitAsync} i18n='account.signIn.submit' />
              <input type="submit" hidden />
            </View>
          </View>
        </form>
      </View>
    </View>
  );
}