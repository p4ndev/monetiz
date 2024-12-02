import { useEffect } from "react";
import { timer } from "rxjs";

import { AnalyticService, AccessService } from "../../provider/services";
import { useAccountContext } from "../../provider/contexts";
import { useParser } from "../../provider/handlers";

import { AccountStateInterface } from "../../shared/interfaces";
import { Millis } from "../../shared/constants";

export default function ActivatePlayer() {

    const { account, setAccount } = useAccountContext();

    const { nameid, token } = useParser<AccountStateInterface>(account);
    
    const accessService = new AccessService();
    const analyticService = new AnalyticService();

    const loadAsync = async () => {
        try
        {
            const { accountId, stamp, operation } = await accessService.FindQuerystringAsync();

            if(operation !== undefined && operation !== null &&
                operation.toString().toLowerCase() !== 'activation')
                  return;

            if(accountId.toString() !== nameid.toString())
                return;

            await accessService.ClearQuerystringAsync();
            await accessService.ActivateAsync(nameid, stamp, token);
            analyticService.TrackEvent('User Activated Member', { UID: nameid });
            
            timer(Millis.ActivationSuccess)
                .subscribe(() => {
                    setAccount({ ...account, refresh: true });
                });
        }
        catch(e)
        {
            analyticService.TrackEvent('Failed User Activation', { UID: nameid });
        }
    };
    
    useEffect(() => {
        if(nameid === undefined || nameid === null ||
            token === undefined || token === null || token === '')
                return;

        loadAsync();
    }, [nameid, token]);

    return (<></>);
}