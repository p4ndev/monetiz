import { useEffect, } from "react";

import { useAccountContext } from "../../provider/contexts";
import { AnalyticService, DeviceService } from "../../provider/services";

import { AppMap } from "../../shared/constants";

export default function RestrictDevices(){

  const { account, setAccount } = useAccountContext();
  
  const analyticService = new AnalyticService();
  const deviceService = new DeviceService();

  useEffect(() => {
    if(!deviceService.IsLandscape()){
      analyticService.Track('Device Restriction');      
      return;
    }

    setAccount({ ...account, isRestricted: true });

    AppMap.ViewportRestriction();
  }, []);

  return (<></>);
}