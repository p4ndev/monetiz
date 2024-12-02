import { View, Text, TextInput, Keyboard } from 'react-native';
import React, { useEffect, useRef, useState } from 'react';
import { timer } from 'rxjs';

import { AccessService, AnalyticService, FloatPanelService, ValidationService } from '../../../provider/services';
import { HelperStyle, AccountStyle } from '../../../provider/styles';
import { useFloatPanelContext } from '../../../provider/contexts';
import i18n from '../../../provider/locales/translation';

import { SignUpRequestInterface } from '../../../shared/interfaces';
import { AccountSignUpModel } from '../../../shared/states';
import { AppMap, Millis } from '../../../shared/constants';

import Headline from '../../../component/dumb/headline.component';
import Button from '../../../component/dumb/button.component';

export default function SignUp() {
  
  const { floatPanel, setFloatPanel }             = useFloatPanelContext();

  const [ model, setModel ]                       = useState<SignUpRequestInterface>(AccountSignUpModel);
  
  const emailFieldRef                             = useRef(null);

  const analyticService = new AnalyticService();
  const accessService                             = new AccessService();
  const validationService                         = new ValidationService();
  const floatPanelService                         = new FloatPanelService(floatPanel, setFloatPanel);

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
        !validationService.IsValidPassword(model.password) ||
        !validationService.IsValidConfirmation(model.password, model.confirmation)
      ) {
        analyticService.TrackEvent('Sign Out > Validation Error', { FIELDS: validationService.from, INPUTS: validationService.data });
        floatPanelService.ShowConfirmationModal(validationService.name, validationService.content);
        validationService.Reset();
        return;
      }

      floatPanelService.ShowLoaderModal();
      
      await accessService.SignUpAsync(model);

      floatPanelService
        .ShowInformationModal(
          accessService.name,
          accessService.content
        );
      
      setModel(AccountSignUpModel);

      analyticService.TrackEvent('User Registered', { EMAIL: AccountSignUpModel.email });

      timer(Millis.SignUpSuccessful)
        .subscribe(() => {
          floatPanelService.HideLoaderModal();
          AppMap.Account.SignIn();
        });
    }
    catch(e)
    {
      const name = validationService.name !== '' ? validationService.name : accessService.name;      
      const message = validationService.content !== '' ? validationService.content : accessService.content;

      floatPanelService.ShowConfirmationModal(name, message);
    }
  };

  useEffect(() => {        
    analyticService.Open('/account/sign-up', 'Sign Up');

    timer(Millis.CloseInitialModal).subscribe(floatPanelService.HideLoaderModal);
  }, []);

  return (
    <View style={[HelperStyle.fully, HelperStyle.topSpace, AccountStyle.stage]} id="custom">
      <Headline.Light i18n='account.signUp.headline' id='hdSignUp' />
      <View style={AccountStyle.form} id='frSignUp'>
        <form onSubmit={onFormSubmitAsync}>
          <Text style={AccountStyle.label}>{i18n.t('account.signUp.fullNameLabel')}</Text>
          <View style={HelperStyle.inputWrap}>
            <TextInput
              tabIndex={0}
              maxLength={60}
              id='txtFullName'
              inputMode='text'
              blurOnSubmit={true}
              returnKeyType='next'
              value={model.fullName}
              style={[HelperStyle.input, HelperStyle.regular]}
              placeholderTextColor={'#b1b1b1'}
              placeholder={i18n.t('account.signUp.placeholderFullName')}
              onChangeText={(t) => setModel({ ...model, fullName: t })}
              onSubmitEditing={() => emailFieldRef.current.focus()}/>
          </View>
          <Text style={AccountStyle.label}>{i18n.t('global.emailLabel')} *</Text>        
          <View style={HelperStyle.inputWrap}>
            <TextInput
              tabIndex={0}
              id='txtEmail'
              maxLength={80}
              inputMode='email'
              ref={emailFieldRef}
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
          <Text style={AccountStyle.label}>{i18n.t('account.signUp.passwordConfirmationLabel')} *</Text>        
          <View style={HelperStyle.inputWrap}>
            <TextInput
              tabIndex={0}
              maxLength={30}
              secureTextEntry={true}
              id='txtConfirmationPassword'
              style={[HelperStyle.input, HelperStyle.regular]}
              value={model.confirmation}
              placeholderTextColor={'#b1b1b1'}
              placeholder={i18n.t('account.signUp.placeholderPasswordConfirmation')}
              onChangeText={(t) => setModel({ ...model, confirmation: t })} />
          </View>
          <View style={AccountStyle.submitRow}>
            <View style={AccountStyle.submitLeft}>
              <Text style={AccountStyle.requirement}>{i18n.t('global.requiredLabel')}</Text>
            </View>
            <View style={AccountStyle.submitRight}>
              <Button.Secondary onClick={onSubmitAsync} i18n='account.signUp.submit' />
              <input type="submit" hidden />
            </View>
          </View>
        </form>
      </View>
    </View>
  );
}