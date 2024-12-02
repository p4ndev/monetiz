import React, { useEffect } from 'react'

import { useAccountContext } from '../../provider/contexts';
import { AnalyticService } from '../../provider/services';
import { useParser } from '../../provider/handlers';

import { AccountStateInterface } from '../../shared/interfaces';
import { AppMap } from '../../shared/constants';

export default function RedirectPlayer() {
    
    const { account } = useAccountContext();

    const { token } = useParser<AccountStateInterface>(account);

    const analyticService = new AnalyticService();
    
    useEffect(() => {
        if(token === undefined || token === null || token === ''){
            analyticService.TrackEvent('Block User Access');
            return;
        }

        analyticService.TrackEvent('Redirect to Tenant');
        AppMap.Lobby.Tenant();
    }, [token]);

    return (<></>);
}