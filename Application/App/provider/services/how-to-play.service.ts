import { HowToPlayInterface } from "../../shared/interfaces";
import { BaseService } from "./base.service";
import { languageTag } from "../locales";

export class HowToPlayService extends BaseService
{
  private readonly jsonFile : string;

  constructor(){
    super();

    this.jsonFile = 'how-to-play';
    this.name = 'global.serverErrorName';
    this.content = 'global.serverGeneralError';
  }

  async LoadAsync() : Promise<Array<HowToPlayInterface>>{
    const dt = new Date();
    
    const version = `?v=${(dt.getMonth() + 1)}-${dt.getDate()}-${dt.getFullYear()}`;
    
    const response = await fetch(`${process.env.EXPO_PUBLIC_BASE_ADDRESS}/assets/offload/${languageTag.toLocaleLowerCase()}/${this.jsonFile}.json${version}`);

    if (!response.ok)
        throw new Error(`Http error: ${response.status}`);

    const data = await response.json();

    return (data as Array<HowToPlayInterface>);
  }
}