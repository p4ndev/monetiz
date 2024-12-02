import { useEffect } from "react";

import { useAccountContext } from "../../provider/contexts";
import { AnalyticService } from "../../provider/services";
import { useParser } from "../../provider/handlers";

import { AccountStateInterface } from "../../shared/interfaces";
import { ClaimEnum } from "../../shared/enums";

export default function RestrictClaims(props : { source : ClaimEnum }){

  const { account, setAccount } = useAccountContext();
  
  const { nameid, claims } = useParser<AccountStateInterface>(account);

  const analyticService = new AnalyticService();

  useEffect(() => {
    if(claims === undefined)
      return;

    if(claims.indexOf(props.source) === -1) {
      let term = 'Claim';

      if(props.source === ClaimEnum.HasEmailConfirmed) term = 'Email Confirmation';
      
      analyticService.TrackEvent(term + ' Restricted', { UID: nameid, CID: props.source });

      setAccount({ ...account, isRestricted: true }); 
    }      
  }, [claims]);

  return (<></>);
}