import { ScrollView, FlatList } from 'react-native';
import React, { useEffect, useState } from 'react';
import { timer } from 'rxjs';

import { ActionService, AnalyticService, CategoryService, FloatPanelService } from '../../../provider/services';
import { useFloatPanelContext, useLobbyContext, useRoomContext } from '../../../provider/contexts';
import { CategoryStyle, HelperStyle } from '../../../provider/styles';
import { useParser } from '../../../provider/handlers';

import { CategoryInterface, LobbyStateInterface } from '../../../shared/interfaces';
import { Millis } from '../../../shared/constants';

import CategoryEntry from '../../../component/smart/category-entry.component';
import Headline from '../../../component/dumb/headline.component';

export default function Category() {
  
  const { room, setRoom }                       = useRoomContext();
  const { lobby }                               = useLobbyContext();
  const { floatPanel, setFloatPanel }           = useFloatPanelContext();

  const [ data, setData ]                       = useState<Array<CategoryInterface>>([]);
  
  const { tenantId }                            = useParser<LobbyStateInterface>(lobby);

  const actionService                           = new ActionService();
  const analyticService                         = new AnalyticService();
  const categoryService                         = new CategoryService();
  const floatPanelService                       = new FloatPanelService(floatPanel, setFloatPanel);

  const loadAsync = async () => {
    try
    {
      floatPanelService.ShowLoaderModal();

      await categoryService.LoadAsync();

      const results = categoryService.FilterBy(tenantId);

      setData(results);

      setRoom({
        ...room,
        speak: await actionService.CanSpeakAsync()
      });

      timer(Millis.CloseInitialModal).subscribe(floatPanelService.HideLoaderModal);
    }
    catch(e)
    {
      floatPanelService.ShowConfirmationModal(categoryService.name, categoryService.content);
    }
  };

  useEffect(() => {   
    analyticService.Open('/lobby/category', 'Categories');

    loadAsync();

    return () => {
      setData([]);
    };
  }, [tenantId]);

  return (
    <ScrollView style={HelperStyle.topSpace}>
      <Headline.Colorful i18n='lobby.category.headline' id='hdCategory' />

      <FlatList
        data={data}
        numColumns={3}
        horizontal={false}
        keyExtractor={item => item.id.toString()}
        columnWrapperStyle={CategoryStyle.wrapper}
        contentContainerStyle={CategoryStyle.stage}
        renderItem={e => <CategoryEntry source={e.item} />} />
    </ScrollView>
  );
}