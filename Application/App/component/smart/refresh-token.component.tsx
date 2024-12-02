import { useEffect } from "react";

import { AccessService, AnalyticService } from "../../provider/services";
import { useAccountContext } from "../../provider/contexts";
import { useParser } from "../../provider/handlers";

import { AccountStateInterface } from "../../shared/interfaces";

export default function RefreshToken(){

    const { account, setAccount } = useAccountContext();

    const { token, refresh } = useParser<AccountStateInterface>(account);
    
    const analyticService = new AnalyticService();
    const accessService = new AccessService();
    
    const initializeAsync = async () => {
        try
        {
            const accountData           = await accessService.RefreshTokenAsync(token);

            if(!accountData)            return;

            const accountState          = await accessService.SaveAccountOfflineAsync(accountData);

            setAccount(accountState);

            analyticService
                .TrackEvent(
                    'Refresh Token', {
                        UID: accountState.nameid,
                        RID: accountState.role
                    }
                );
        }
        catch(e){ }
    };

    useEffect(() => {
        if(token === undefined || token === null || token === '' || 
            refresh !== true)
                return;

        initializeAsync();
    }, [refresh]);

    return (<></>);
}