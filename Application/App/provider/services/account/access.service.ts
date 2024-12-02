import { AccountStateInterface, QuerystringResponseInterface, SignInRequestInterface, SignInResponseInterface, SignUpRequestInterface } from "../../../shared/interfaces";
import { HttpStatusCode200OK, HttpStatusCode201Created, HttpStatusCode206PartialContent, HttpStatusCode304NotModified } from "../../../shared/constants";
import { StorageHandler, TokenHandler, useClaimEnum } from "../../handlers";
import { ClaimEnum, RoleEnum } from "../../../shared/enums";
import { StorageClaimType } from "../../../shared/types";
import { BaseService } from "../base.service";

export class AccessService extends BaseService
{
  private readonly storageHandler : StorageHandler;
  private readonly tokenizeHandler : TokenHandler;
  private readonly apiAddress : string;

  constructor(){
    super();

    this.tokenizeHandler = new TokenHandler();
    this.storageHandler = new StorageHandler();

    this.apiAddress = `${process.env.EXPO_PUBLIC_API_ADDRESS}/account/access`;    
  }

  async SignInAsync(model : SignInRequestInterface) : Promise<SignInResponseInterface>{
    return new Promise<SignInResponseInterface>(async (resolve, reject) => {

      const response = await fetch(this.apiAddress, {
        method  : "GET",
        headers : {
          'Content-Type': 'application/json',
          ...model
        }
      });

      if(this.CatchExceptions(response.status) ||
          response.status !== HttpStatusCode200OK)
            return reject();

      this.name = 'account.signIn.successName';
      this.content = 'account.signIn.successMessage';

      const result = await response.json();

      return resolve(result as SignInResponseInterface);

    });
  }

  async OfflineSignInAsync(): Promise<AccountStateInterface> {
    const accountClaims : Array<ClaimEnum>  = [];
    const accountRole                       = await this.storageHandler.FindAsync<RoleEnum>('role');
    const storageClaims                     = await this.storageHandler.FindAsync<StorageClaimType>('claims');

    if(storageClaims !== undefined && storageClaims !== null){
        if(typeof storageClaims === 'string')
          accountClaims.push(useClaimEnum(storageClaims.toString()));
        else
          storageClaims.map(c => accountClaims.push(useClaimEnum(ClaimEnum[c])));
    }

    const storedAccount : AccountStateInterface = {
      token           : await this.storageHandler.FindAsync('token'),
      expiresIn       : await this.storageHandler.FindAsync<Date>('expiresIn'),

      unique_name     : await this.storageHandler.FindAsync('unique_name'),
      email           : await this.storageHandler.FindAsync<string>('email'),
      nameid          : Number(await this.storageHandler.FindAsync<number>('nameid')),
    
      refresh         : false,
      isRestricted    : false,
      
      role            : accountRole,
      claims          : accountClaims,
    };

    return storedAccount;
  }

  async SignUpAsync(model : SignUpRequestInterface) : Promise<void>{
    return new Promise(async (resolve, reject) => {

      const response = await fetch(this.apiAddress, {
        headers : { 'Content-Type': 'application/json' },
        body    : JSON.stringify(model),
        method  : "POST"
      });

      if(
        this.CatchExceptions(response.status) ||
        (
            response.status !== HttpStatusCode201Created &&
            response.status !== HttpStatusCode206PartialContent
        )
      ) return reject();

      this.name = 'account.signUp.successName';
      this.content = 'account.signUp.successScenario';
        
      return resolve();

    });
  }

  async SignOutAsync() : Promise<boolean>{
    await this.storageHandler.RemoveAllAsync();

    return true;
  }

  async ActivateAsync(id: number, stamp : string, token : string) : Promise<void> {
    return new Promise(async (resolve, reject) => {

      const response = await fetch(`${this.apiAddress}/?id=${id}&stamp=${stamp}`, {
        method : "PATCH",
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `bearer ${token}`
        }
      });

      if(this.CatchExceptions(response.status) || 
          response.status === HttpStatusCode304NotModified)
            return reject();

      if(response.status === HttpStatusCode200OK || 
          response.status === HttpStatusCode206PartialContent)
            return resolve();
    });
  }

  async RefreshTokenAsync(token : string) : Promise<SignInResponseInterface>{
    return new Promise<SignInResponseInterface>(async (resolve, reject) => {

      const response = await fetch(`${this.apiAddress}`, {
        method : "PUT",
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `bearer ${token}`
        }
      });

      if (this.CatchExceptions(response.status))
        return reject(false);

      const result = await response.json();

      return resolve(result as SignInResponseInterface);

    });
  }

  async StoreUserIdAsync(id: string) {
    await this.storageHandler.AddAsync('uid', id, false);
  }

  async StoreStampAsync(stamp: string) {
    await this.storageHandler.AddAsync('stamp', stamp, false);
  }

  async StoreOperationAsync(op: string) {
    await this.storageHandler.AddAsync('operation', op, false);
  }

  async FindQuerystringAsync() : Promise<QuerystringResponseInterface>{
    let output : QuerystringResponseInterface = {
      accountId : await this.storageHandler.FindAsync<number>('uid'),
      stamp     : await this.storageHandler.FindAsync<string>('stamp'),
      operation : await this.storageHandler.FindAsync<string>('operation'),
    };

    return output;
  }

  async ClearQuerystringAsync() : Promise<void>{
    await this.storageHandler.RemoveAsync('uid');
    await this.storageHandler.RemoveAsync('stamp');
    await this.storageHandler.RemoveAsync('operation');
  }

  async SaveAccountOfflineAsync(source : SignInResponseInterface) : Promise<AccountStateInterface> {
    const accountState = this.tokenizeHandler.Parse(source);
    
    accountState.unique_name = source.fullName;

    await this.storageHandler.RemoveAllAsync();

    await this.storageHandler.AddRangeAsync(accountState);

    return accountState;
  }
}