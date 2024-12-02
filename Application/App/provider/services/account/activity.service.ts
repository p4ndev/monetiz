import { ProfileEntryBackgroundStyle, ProfileEntryIconBackgroundStyle, ProfileEntryTextStyle } from "../../styles";
import { HttpStatusCode200OK, HttpStatusCode499ClientClosedRequest } from "../../../shared/constants";
import { ActivityEntryInterface, ProfileActivityEntryInterface } from "../../../shared/interfaces";
import { MaterialIconDynamicNameType } from "../../../shared/types";
import { ActivityTypeEnum } from "../../../shared/enums";
import i18n, { useShortDate } from "../../locales";
import { BaseService } from "../base.service";

export class ActivityService extends BaseService
{
  private readonly apiAddress : string;  
  public lastPage : boolean;

  constructor(){
    super();

    this.lastPage = false;
    this.apiAddress = `${process.env.EXPO_PUBLIC_API_ADDRESS}/account/activity`;
  }

  async LoadAsync(page : number = 0, token : string) : Promise<Array<ActivityEntryInterface>>{
    return new Promise(async (resolve, reject) => {

      const response = await fetch(`${this.apiAddress}/?page=${page}`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `bearer ${token}`
        }
      });

      if(this.CatchExceptions(response.status)){
        this.lastPage = true;
        return reject();
      }

      switch(response.status){

        case HttpStatusCode200OK:
          this.lastPage   = false;
          break;

        case HttpStatusCode499ClientClosedRequest:
          this.lastPage   = true;
          break;

      }

      const data = await response.json();

      return resolve(data as Array<ActivityEntryInterface>);

    });
  }

  private static Translate(value : string) : string{
    if(value == undefined || value == null)
        return "";

    if(value.indexOf('.') === -1)
        return value;

    const parsed = i18n.t(value);

    return (parsed.indexOf('missing') === -1 ? parsed : value);
  }

  private static ChopSummary(content : string) : string {
    return (content.length <= 30 ? content : content.substring(0, 30) + '...');
  }

  static ParseActivityEntry(source : ActivityEntryInterface) : ProfileActivityEntryInterface {
    const isPositiveIconLabel   = (source.icon[0] === '+');
    let translationKey : string;

    let output : ProfileActivityEntryInterface = {
      id : 0,
      name: '',
      summary: '',
      leftContent: '',
      centerContent: '',
      leftTranslatedContent: '',
      centerTranslatedContent: '',
      createdAt: '',
      eligible: false,
      textColor: false,
      stageBackgroundColor: false,
      iconBackgroundColor: false,
      iconName: 'light'
    };
    
    switch(source.activityTypeId)
    {
        case ActivityTypeEnum.Buy:
            output.eligible                 = true;
            translationKey                  = 'buy.';

            output.textColor                = ProfileEntryTextStyle.buy;
            output.stageBackgroundColor     = ProfileEntryBackgroundStyle.buy;
            output.iconBackgroundColor      = ProfileEntryIconBackgroundStyle.buy;
            break;

        case ActivityTypeEnum.Withdraw:
            output.eligible                 = true;
            translationKey                  = 'withdraw.';

            output.textColor                = ProfileEntryTextStyle.withdraw;
            output.stageBackgroundColor     = ProfileEntryBackgroundStyle.withdraw;
            output.iconBackgroundColor      = ProfileEntryIconBackgroundStyle.withdraw;
            break;

        case ActivityTypeEnum.Game:
            output.eligible                 = true;
            translationKey                  = 'game.';

            if(isPositiveIconLabel) {
                output.textColor            = ProfileEntryTextStyle.positive;
                output.stageBackgroundColor = ProfileEntryBackgroundStyle.positive;
                output.iconBackgroundColor  = ProfileEntryIconBackgroundStyle.positive;
            } else {
                output.textColor            = ProfileEntryTextStyle.negative;
                output.stageBackgroundColor = ProfileEntryBackgroundStyle.negative;
                output.iconBackgroundColor  = ProfileEntryIconBackgroundStyle.negative;
            }
            break;

        case ActivityTypeEnum.Account:
            output.eligible                 = true;
            translationKey                  = 'account.';

            output.textColor                = ProfileEntryTextStyle.account;
            output.stageBackgroundColor     = ProfileEntryBackgroundStyle.account;
            output.iconBackgroundColor      = ProfileEntryIconBackgroundStyle.account;
            break;

        default:
            output.eligible = false;
            translationKey = '';
            break;
    }

    if(output.eligible === true)
    {
        output.createdAt = useShortDate(source.createdAt);

        output.iconName = (source.icon as MaterialIconDynamicNameType);
        
        output.id = source.id;
        output.name = this.Translate(source.name);
        output.summary = this.ChopSummary(this.Translate(source.summary));
        
        output.leftContent = this.Translate(source.leftContent);
        output.centerContent = this.Translate(source.centerContent);

        output.leftTranslatedContent = i18n.t(`account.profile.${translationKey}leftLabel`);
        output.centerTranslatedContent = i18n.t(`account.profile.${translationKey}centerLabel`);
    }

    return output;
  }

  static RenderImage(value : string) : boolean{
    if(value[0] === '+' || value[0] === '-' || value[value.length - 1] === 'k')
      return false;

    return true;
  }
}