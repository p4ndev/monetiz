import { AccountStateInterface, RecoveryModelInterface, SignInRequestInterface, SignUpRequestInterface } from "../../shared/interfaces";

const AccountState : AccountStateInterface = {
  expiresIn : new Date(),
  role : undefined,
  claims : undefined,
  refresh : false,
  isRestricted : false,
  token : '',
  unique_name : '',
  email : '',
  nameid : 0
};

const AccountSignUpModel : SignUpRequestInterface = {
  email : '',
  fullName : '',
  password : '',
  confirmation  : ''
};

const AccountSignInModel : SignInRequestInterface = {
  email : '',
  password : ''
}

const AccountRecoveryModel : RecoveryModelInterface = AccountSignInModel;

export { AccountState, AccountSignUpModel, AccountSignInModel, AccountRecoveryModel }