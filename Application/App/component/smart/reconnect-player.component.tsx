import { useEffect } from "react";

import { AccessService, AnalyticService } from "../../provider/services";
import { useAccountContext } from "../../provider/contexts";

export default function ReconnectPlayer(){

    const { setAccount } = useAccountContext();

    const analyticService = new AnalyticService();
    const accessService = new AccessService();

    const loadAsync = async () => {
        const storedAccount = await accessService.OfflineSignInAsync();

        setAccount(storedAccount);

        analyticService
            .TrackEvent(
                'Offline Signed In', {
                    UID: storedAccount.nameid,
                    RID: storedAccount.role
                }
            );
    };

    useEffect(() => {
        loadAsync();
    }, []);

    return (<></>);
}