import { StorageHandler } from "../../handlers";
import { BaseService } from "../base.service";

import { HttpStatusCode201Created, HttpStatusCode206PartialContent, HttpStatusCode208AlreadyReported } from "../../../shared/constants";
import { MaterialIconDynamicNameType } from "../../../shared/types";
import { ActionStateInterface } from "../../../shared/interfaces";

export class ActionService extends BaseService
{
  private readonly storageHandler : StorageHandler;
  private readonly apiAddress : string;
  public hasAnswered : boolean;

  constructor(){
    super();
    
    this.storageHandler = new StorageHandler();
    this.apiAddress = `${process.env.EXPO_PUBLIC_API_ADDRESS}/room`;
  }

  async LoadAsync(actionIds : Array<number>, skipActionIds : Array<number> | undefined = undefined, from : string, token : string) : Promise<ActionStateInterface | null>{
    return new Promise(async (resolve, reject) => {

      if(skipActionIds.length === actionIds.length)
        return reject();

      this.hasAnswered = false;
      let idx = skipActionIds.length;
      let endpoint = `${this.apiAddress}/${actionIds[idx]}/action?from=${from}`;

      const response = await fetch(endpoint, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `bearer ${token}`
        }
      });

      if(this.CatchExceptions(response.status))
        return reject();

      if(response.status === HttpStatusCode208AlreadyReported)
        this.hasAnswered = true;

      const data = await response.json();

      return resolve(data as ActionStateInterface);
    });
  }

  async AnswerAsync(isNegative : boolean, actionId : number, token : string) : Promise<void>{
    return new Promise(async (resolve, reject) => {

      const playerAnswer = (isNegative ? 'no' : 'yes');

      const endpoint = `${this.apiAddress}/${playerAnswer}/answer/boolean?aid=${actionId}`;

      const response = await fetch(endpoint, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `bearer ${token}`
        }
      });

      if(
        this.CatchExceptions(response.status) || 
        (
          response.status !== HttpStatusCode201Created &&
          response.status !== HttpStatusCode206PartialContent
        )
      ) return reject();

      this.name = 'room.action.successName';
      this.content = 'room.action.successMessage';

      return resolve();
    });
  }

  async ToggleVoiceOfflineAsync(content : boolean) {
    await this.storageHandler.AddAsync('speak', content);
  }

  async CanSpeakAsync() : Promise<boolean> {
    let result = await this.storageHandler.FindAsync<boolean>('speak');

    if(result === undefined || result === null){
      await this.ToggleVoiceOfflineAsync(true);
      return true;
    }      

    return result;
  }

  VoiceIcon = (speak : boolean) => (speak ? 'record-voice-over' : 'voice-over-off') as MaterialIconDynamicNameType;

  VoiceColor = (speak : boolean, color : string) => (speak ? color : '#FFFFFF80') as MaterialIconDynamicNameType;

  HasBalance = (coin : number) => (coin > 0);
}