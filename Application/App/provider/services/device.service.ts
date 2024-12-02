import { DeviceType, deviceType } from "expo-device";
import { Dimensions } from "react-native";

export class DeviceService
{
  IsLandscape() : boolean{
    if(this.IsDeviceOnly() && this.IsDimensionPortrait() && !this.IsDimensionLandscape())
      return false;
    return true;
  }

  private IsDeviceOnly() : boolean{
    return (deviceType === DeviceType.PHONE || deviceType === DeviceType.DESKTOP);
  }

  private IsDimensionPortrait() : boolean{
    const dim = Dimensions.get('window');
    return dim.height >= dim.width;
  }

  private IsDimensionLandscape() : boolean{
    const dim = Dimensions.get('window');
    return dim.width >= dim.height;
  }
}