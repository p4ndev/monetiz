import { useAccountContext, useLobbyContext } from "../../provider/contexts";
import { AnalyticService } from "../../provider/services";
import { useDateExpired } from "../../provider/locales";
import { useParser } from "../../provider/handlers";

import { AccountStateInterface, TenantEntryInterface } from "../../shared/interfaces";
import { AppMap } from "../../shared/constants";

import Button from "../dumb/button.component";

export default function TenantEntry(props : TenantEntryInterface) {

    const { setLobby } = useLobbyContext();
    const { account } = useAccountContext();

    const { nameid, role } = useParser<AccountStateInterface>(account);

    const { id, name, logotype, rgbs, end } = props.source;

    const analyticService = new AnalyticService();
    
    const onTenantClicked = () => {
        setLobby({
            tenantId: id,
            colors: rgbs
        });

        analyticService.TrackEvent('Tenant Viewed By', { UID: nameid, RID: role, TID: id });

        AppMap.Lobby.Category();
    };

    if (useDateExpired(end) === false)
        return (<Button.Tenant onClick={onTenantClicked} label={name} colors={rgbs} icon={logotype} id={'btnTenant' + id} />);
}