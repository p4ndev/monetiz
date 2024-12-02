import { AccountStateInterface, DecodeTokenResponseInterface, SignInResponseInterface } from "../../shared/interfaces";
import { useClaimEnum, useRoleEnum } from "./util.handler";
import { ClaimEnum } from "../../shared/enums";

export class TokenHandler
{
  private DecodeBase64(base64Url: string): string {
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const paddedBase64 = base64.padEnd(base64.length + (4 - (base64.length % 4)) % 4, '=');
    const decodedData = atob(paddedBase64);
    return decodedData;
  }
  
  private Decode(token: string) : DecodeTokenResponseInterface {
    const parts = token.split('.');

    if (parts.length !== 3)
      throw new Error('Invalid JWT');

    const header = JSON.parse(this.DecodeBase64(parts[0]));
    const payload = JSON.parse(this.DecodeBase64(parts[1]));
    const signature = parts[2];

    return { header, payload, signature };
  }

  Parse(model : SignInResponseInterface) : AccountStateInterface{
    let parsedClaims : Array<ClaimEnum> = [];
    const { payload } = this.Decode(model.token);
    const parsedRole = useRoleEnum(payload.role);

    if(payload.claims){
      if(typeof payload.claims === 'string')
        parsedClaims.push(useClaimEnum(payload.claims.toString()));
      else
        payload.claims.map(c => parsedClaims.push(useClaimEnum(c.toString())));
    }

    let output : AccountStateInterface = {
      isRestricted : false,
      refresh      : false,

      token        : model.token,
      expiresIn    : model.expiresIn,

      nameid       : payload.nameid,
      unique_name  : payload.unique_name,
      email        : payload.email,

      role         : parsedRole,
      claims       : parsedClaims
    };

    return output;
  }
}