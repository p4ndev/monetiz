import { StyleProp, TextStyle, ViewStyle } from "react-native";
import { MaterialIconDynamicNameType } from "../types";
import { ClaimEnum, RoleEnum } from "../enums";

interface DecodeTokenResponseInterface{
    header : any,
    payload : any,
    signature : string
}

interface AccountStateInterface{
    token : string,
    expiresIn : Date,
    
    refresh : boolean,
    isRestricted : boolean,

    unique_name : string,
    nameid : number,
    email : string,

    role : RoleEnum | undefined,
    claims : Array<ClaimEnum> | undefined
}

interface SignInRequestInterface{
    email : string,
    password : string,
}

interface SignUpRequestInterface extends SignInRequestInterface{
    fullName : string,    
    confirmation : string
}

interface SignInResponseInterface{
    expiresIn : Date,
    token : string,
    fullName : string
}

interface RecoveryModelInterface{
    email : string,
    password : string
}

interface RecoveryRequestInterface extends RecoveryModelInterface{    
    id : number,
    stamp : string
}

interface ActivityEntryInterface{
    id : number,
    accountId : number,
    activityTypeId : number,
    icon : string,
    name : string,
    summary : string,    
    leftContent : string | undefined,
    centerContent : string | undefined,
    createdAt : Date
}

interface ProfileActivityEntryInterface{
    id : number,
    name : string,
    summary : string,
    
    leftContent : string,
    centerContent : string,

    leftTranslatedContent : string,
    centerTranslatedContent : string,

    createdAt : string,
    eligible : boolean,

    textColor : StyleProp<TextStyle>,
    stageBackgroundColor : StyleProp<ViewStyle>,
    iconBackgroundColor : StyleProp<ViewStyle>,

    iconName : MaterialIconDynamicNameType
}

interface QuerystringResponseInterface{
    accountId : number,
    stamp : string,
    operation : string
}

export {
    SignUpRequestInterface, AccountStateInterface, SignInRequestInterface,
    SignInResponseInterface, RecoveryRequestInterface, RecoveryModelInterface,
    DecodeTokenResponseInterface, ActivityEntryInterface, ProfileActivityEntryInterface,
    QuerystringResponseInterface
};