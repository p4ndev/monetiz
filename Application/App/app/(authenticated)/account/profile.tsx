import { FlatList, Pressable, SafeAreaView, ScrollView, Text, View } from 'react-native';
import React, { useEffect, useState } from 'react';
import { MaterialIcons } from '@expo/vector-icons';
import { timer } from 'rxjs';

import { ActivityService, AnalyticService, FloatPanelService } from '../../../provider/services';
import { useAccountContext, useFloatPanelContext } from '../../../provider/contexts';
import { HelperStyle, ProfileStyle } from '../../../provider/styles';
import i18n from '../../../provider/locales/translation';
import { useParser } from '../../../provider/handlers';

import { AccountStateInterface, ActivityEntryInterface } from '../../../shared/interfaces';
import { AppMap, Millis } from '../../../shared/constants';
import { RoleEnum } from '../../../shared/enums';

import ProfileActivityEntry from '../../../component/dumb/profile-activity-entry.component';
import Headline from '../../../component/dumb/headline.component';
import Button from '../../../component/dumb/button.component';

export default function Profile() {

  const { account }                               = useAccountContext();
  const { floatPanel, setFloatPanel }             = useFloatPanelContext();

  const [ page, setPage ]                         = useState(0);
  const [ lastPage, setLastPage ]                 = useState(false);
  const [ dataSource, setDataSource ]             = useState<Array<ActivityEntryInterface>>([]);

  const { unique_name, nameid, token, role }      = useParser<AccountStateInterface>(account);
  
  const analyticService                           = new AnalyticService();
  const activityService                           = new ActivityService();
  const floatPanelService                         = new FloatPanelService(floatPanel, setFloatPanel);
  
  const onSignOutClicked = async () => {
    analyticService.Track('Profile > Sign Out');

    AppMap.Account.SignOut();
  }

  const onLoadMoreClicked = async () => {
    analyticService.TrackEvent('Profile > Page Viewed', { UID: nameid, RID: role, PAGE: (page + 1) });

    setPage(p => p + 1);
  }

  const onHowToPlayClicked = () => {
    analyticService.Track('How To Play > Authenticated');
    AppMap.HowToPlay();
  }

  const loadAsync = async () => {
    try
    {
      floatPanelService.ShowLoaderModal();
            
      const result = await activityService.LoadAsync(page, token);

      if(result.length > 0)     result.map(e => setDataSource(p => [...p, e]));
      else                      AppMap.EmptyList();

      timer(Millis.CloseInitialModal).subscribe(floatPanelService.HideLoaderModal);
    }
    catch(e)
    {
      floatPanelService.ShowConfirmationModal(activityService.name, activityService.content);
    }
    finally
    {
      setLastPage(activityService.lastPage);
    }
  }

  useEffect(() => {    
    analyticService.Open('/account/profile', 'Profile');

    if(token === undefined || token === null || token === '')
      return;

    loadAsync();
  }, [token, page]);

  return (
    <SafeAreaView style={[HelperStyle.fully, HelperStyle.topSpace]}>
      <View style={HelperStyle.headerStage}>
          <View style={HelperStyle.headerLeft}>
            <Headline.Colorful content={unique_name + ','} id='hdProfile' />
            <Text style={HelperStyle.headerSummary}>
                { i18n.t(`account.profile.${role === RoleEnum.Guest ? 'guestSummary' : 'regularSummary'}`) }
            </Text>
          </View>
          <View style={HelperStyle.headerRight}>
            <Pressable onPress={async () => await onSignOutClicked()}>
              <MaterialIcons name="login" size={34} color={'#AAA'} />
            </Pressable>
          </View>
      </View>
      
      <ScrollView style={ProfileStyle.stage}>
        <FlatList
          data={dataSource}
          keyExtractor={e => e.id.toString()}
          renderItem={e => <ProfileActivityEntry source={e.item} />} />
        
        <View style={ProfileStyle.loaderStage}>
          { lastPage === false &&
            <Button.Disabled
              onClick={async () => await onLoadMoreClicked()}
              i18n='account.profile.loadMore' />
          }

          <Button.Disabled
            onClick={onHowToPlayClicked}
            i18n='index.help' />
        </View>
      </ScrollView>
    </SafeAreaView>
  );
}