import { FlatList, ScrollView } from 'react-native';
import React, { useEffect, useState } from 'react';
import { timer } from 'rxjs';

import { AnalyticService, FloatPanelService, TenantService } from '../../../provider/services';
import { HelperStyle, TenantStyle } from '../../../provider/styles';
import { useFloatPanelContext } from '../../../provider/contexts';

import { TenantInterface } from '../../../shared/interfaces';
import { Millis } from '../../../shared/constants';

import TenantEntry from '../../../component/smart/tenant-entry.component';
import Headline from '../../../component/dumb/headline.component';

export default function Tenant() {

  const { floatPanel, setFloatPanel }   = useFloatPanelContext();

  const [ data, setData ]               = useState<Array<TenantInterface>>([]);
  
  const tenantService                   = new TenantService();
  const analyticService                 = new AnalyticService();
  const floatPanelService               = new FloatPanelService(floatPanel, setFloatPanel);
  
  const loadAsync = async () => {
    try
    {
      floatPanelService.ShowLoaderModal();

      const results = await tenantService.LoadAsync();

      setData(results);

      timer(Millis.CloseInitialModal).subscribe(floatPanelService.HideLoaderModal);
    }
    catch(e)
    {
      floatPanelService.ShowConfirmationModal(tenantService.name, tenantService.content);
    }
  };

  useEffect(() => {
    analyticService.Open('/account/tenant', 'Tenants');

    loadAsync();

    return () => {
      setData([]);
    };
  }, []);

  return (
    <ScrollView style={HelperStyle.topSpace}>
      <Headline.Colorful i18n='lobby.tenant.headline' id='hdTenant' />
      
      <FlatList
        data={data}
        keyExtractor={e => e.id.toString()}
        contentContainerStyle={TenantStyle.stage}
        renderItem={e => <TenantEntry source={e.item} />} />
    </ScrollView>
  );
}