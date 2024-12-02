import { HttpStatusCode200OK, HttpStatusCode304NotModified } from "../../../shared/constants";
import { RecoveryRequestInterface } from "../../../shared/interfaces";
import { BaseService } from "../base.service";

export class RecoveryService extends BaseService
{
  private readonly apiAddress : string;

  constructor(){
    super();

    this.apiAddress = `${process.env.EXPO_PUBLIC_API_ADDRESS}/account/recovery`;
  }

  async SendRecoveryEmailAsync(email : string) : Promise<void> {
    return new Promise(async (resolve, reject) => {

      const response = await fetch(`${this.apiAddress}/?email=${email}`, {
        headers : { 'Content-Type': 'application/json' },
        method  : 'GET'
      });

      if(this.CatchExceptions(response.status))
        return reject();

      if(response.status === HttpStatusCode200OK)
      {
        this.name = 'account.recovery.successName';
        this.content = 'account.recovery.successMessage';
        return resolve();
      }

      return reject();
    });
  }

  async ResetPasswordAsync(model : RecoveryRequestInterface) : Promise<void> {
    return new Promise(async (resolve, reject) => {

      const response = await fetch(`${this.apiAddress}`, {
        headers : { 'Content-Type': 'application/json' },
        body    : JSON.stringify(model),
        method  : "PATCH"
      });

      if(this.CatchExceptions(response.status))
        return reject();

      if(response.status === HttpStatusCode304NotModified){
          this.name = 'global.serverErrorName';
          this.content = 'account.reset.resourceNotPersisted';
          return reject();
      }
      
      this.name = 'account.reset.newPasswordName';
      this.content = 'account.reset.newPasswordMessage';
      return resolve();

    });
  }
}