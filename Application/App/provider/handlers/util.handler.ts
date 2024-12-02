import { currencySymbol, decimalSeparator } from "../../provider/locales";
import { ClaimEnum, RoleEnum } from "../../shared/enums";

function useParser<T>(data:any) : T{
  return (data as T);
}

function useStyleOrNull(condition, style){
  return (condition === true ? style : null);
}

function useEnum<T extends Record<string, string | number>>(enumEntity : T, name: string) : T[keyof T] | undefined {
  const enumValueList = Object.keys(enumEntity).filter((key) => isNaN(Number(key)));

  for (let enumValue of enumValueList) {
    if (enumValue === name) {
      return enumEntity[enumValue as keyof T];
    }
  }

  return undefined;
}

const useClaimEnum = (name : string) : ClaimEnum | undefined => useEnum(ClaimEnum, name);
const useRoleEnum = (name : string) : RoleEnum | undefined => useEnum(RoleEnum, name);

const usePluralize = (term : string, counter : number) : string => (term + (counter > 1 ? 's' : ''));
const usePrice = (amount : number, cents : number = 2)  : string => (currencySymbol + ' ' + amount.toFixed(cents).toString().replaceAll('.', decimalSeparator));

export { useParser, useStyleOrNull, useEnum, useClaimEnum, useRoleEnum, usePluralize, usePrice }