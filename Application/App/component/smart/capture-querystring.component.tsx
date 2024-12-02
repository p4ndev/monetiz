import { useLocalSearchParams } from "expo-router";
import { useEffect } from "react";
import { timer } from "rxjs";

import { AccessService } from "../../provider/services";
import { AppMap, Millis } from "../../shared/constants";

export default function CaptureQuerystring() {
    
    const { id, stamp, op } = useLocalSearchParams<{ id : string, stamp : string, op : string }>();

    const accessService = new AccessService();

    useEffect(() => {
        accessService.StoreUserIdAsync(id);
    }, [id]);

    useEffect(() => {
        accessService.StoreStampAsync(stamp);
    }, [stamp]);

    useEffect(() => {
        accessService.StoreOperationAsync(op);

        if(op !== undefined && op !== null &&
            op.toString().toLowerCase() === 'recovery')
                timer(Millis.CloseInitialModal).subscribe(AppMap.Account.Reset);
    }, [op]);

    return (<></>);
}