import { SafeAreaView, ScrollView, FlatList, Pressable, View, Text } from 'react-native';
import React, { useEffect, useState } from 'react';
import { MaterialIcons } from '@expo/vector-icons';
import { timer } from 'rxjs';

import { AnalyticService, FloatPanelService, HowToPlayService } from '../../provider/services';
import { useAccountContext, useFloatPanelContext } from '../../provider/contexts';
import { HelperStyle, HowToPlayStyle } from '../../provider/styles';
import { useParser } from '../../provider/handlers';

import { AccountStateInterface, HowToPlayInterface } from '../../shared/interfaces';
import { AppMap, Millis } from '../../shared/constants';

import HowToPlayEntry from '../../component/dumb/how-to-play-entry.component';
import Headline from '../../component/dumb/headline.component';
import i18n from '../../provider/locales';

export default function HowToPlay() {

  const { account }                       = useAccountContext();
  const { floatPanel, setFloatPanel }     = useFloatPanelContext();

  const [ data, setData ]                 = useState<Array<HowToPlayInterface>>([]);
  const { token }                         = useParser<AccountStateInterface>(account);
  
  const analyticService                   = new AnalyticService();
  var howToPlayService                    = new HowToPlayService();
  const floatPanelService                 = new FloatPanelService(floatPanel, setFloatPanel);

  const loadAsync = async () => {
    try
    {
      floatPanelService.ShowLoaderModal();
      
      const results = await howToPlayService.LoadAsync();

      setData(results);

      timer(Millis.CloseInitialModal).subscribe(() => floatPanelService.HideLoaderModal());
    }
    catch(e)
    {
      floatPanelService.ShowInformationModal(howToPlayService.name, howToPlayService.content);
    }
  };

  const isAuthenticated = () => (token !== undefined && token !== null && token !== '');

  const onHomeClicked = async () => {
    if(isAuthenticated())
      AppMap.Lobby.Tenant();
    else
      AppMap.Splash();

    analyticService.Track('How to Play > Home');
  };

  const onQuestionClicked = async (id : number) => {
    const updatedItems = data.map(item => {
      item.opened = (item.id === id);
      return item;
    });

    setData(updatedItems);

    analyticService.Track(id + ' # Question');
  };

  useEffect(() => {
    analyticService.Open('/how-to-play', 'How To Play');

    loadAsync();
  }, []);

  return (
    <SafeAreaView style={[HelperStyle.fully, HelperStyle.topSpace, HowToPlayStyle.stage]} id='howToPlay'>
      <View style={HelperStyle.headerStage}>
        <View style={HelperStyle.headerLeft}>
          <Headline.Colorful i18n='howToPlay.headline' />
        </View>
        <View style={HelperStyle.headerRight}>
          <Pressable onPress={async () => await onHomeClicked()} id='btnHome'>
            <MaterialIcons name={isAuthenticated() ? "menu" : "home"} size={34} color={'#AAA'} />
          </Pressable>
        </View>
      </View>
      <ScrollView>
          <FlatList
            data={data}
            id='flQAs'
            keyExtractor={e => e.id.toString()}
            renderItem={e => <HowToPlayEntry source={e.item} onClick={async (id : number) => await onQuestionClicked(id)} />} />
          <View style={HowToPlayStyle.inquiryStage}>
            <Text style={[HelperStyle.opaque, HelperStyle.light, HowToPlayStyle.inquiryTitle]}>{i18n.t('howToPlay.inquiryTitle')}</Text>
            <Text style={[HelperStyle.light, HowToPlayStyle.inquiryMessage]}>{i18n.t('howToPlay.inquiryMessage')} <Text id='mailto' style={HowToPlayStyle.inquiryEmail}>{i18n.t('howToPlay.inquiryEmail')}</Text></Text>
          </View>
      </ScrollView>
    </SafeAreaView>
  );
}