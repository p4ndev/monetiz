import { useEffect } from "react";

import { useAccountContext } from "../../provider/contexts";
import { AnalyticService } from "../../provider/services";
import { useParser } from "../../provider/handlers";

import { AccountStateInterface } from "../../shared/interfaces";
import { RoleEnum } from "../../shared/enums";

export default function RestrictRoles(props : { source : RoleEnum }){

  const { account, setAccount } = useAccountContext();
  
  const { nameid, role } = useParser<AccountStateInterface>(account);

  const analyticService = new AnalyticService();

  useEffect(() => {
    if(role === undefined)
      return;   
    
    if(props.source === role){
      let term = (props.source === RoleEnum.Guest ? 'Guest' : 'Member');
      
      analyticService.TrackEvent(term + ' Restricted', { UID: nameid, RID: role });

      setAccount({ ...account, isRestricted: true });
    }
  }, [role]);

  return (<></>);
}