import { I18n } from "i18n-js";

import { GlobalPtBr } from "./pt-br/global";
import { LoaderPtBr } from "./pt-br/loader";

import { HowToPlayPtBr } from "./pt-br/how-to-play";
import { IndexPtBr } from "./pt-br";

import { ActivationPtBr } from "./pt-br/account/activation";
import { RecoveryPtBr } from "./pt-br/account/recovery";
import { ProfilePtBr } from "./pt-br/account/profile";
import { SignUpPtBr } from "./pt-br/account/sign-up";
import { SignInPtBr } from "./pt-br/account/sign-in";
import { ResetPtBr } from "./pt-br/account/reset";

import { CategoryPtBr } from "./pt-br/lobby/category";
import { TenantPtBr } from "./pt-br/lobby/tenant";
import { EventPtBr } from "./pt-br/lobby/event";

import { ActionPtBr } from "./pt-br/room/action";
import { GamePtBr } from "./pt-br/room/game";

import { BuyPtBr } from "./pt-br/financial/buy";
import { SellPtBr } from "./pt-br/financial/sell";
import { PixPtBr } from "./pt-br/financial/pix";

const i18n  = new I18n({
    pt: {
        currencyCode : 'BRL',
        currencySymbol : 'R$',
        languageTag : "pt-BR",
        languageCode : "pt",
        regionCode : 'BR',
        temperatureUnit : 'celsius',

        global : GlobalPtBr,
        loader : LoaderPtBr,
        
        index : IndexPtBr,
        howToPlay : HowToPlayPtBr,        

        account : {
            signUp : SignUpPtBr,
            signIn : SignInPtBr,
            recovery : RecoveryPtBr,
            reset : ResetPtBr,
            profile : ProfilePtBr,
            activation : ActivationPtBr
        },

        lobby: {
            tenant : TenantPtBr,
            category : CategoryPtBr,
            event : EventPtBr,
        },

        room : {
            game : GamePtBr,
            action : ActionPtBr
        },

        financial: {
            buy : BuyPtBr,
            sell : SellPtBr,
            pix : PixPtBr,
        }
    }
});

i18n.locale = 'pt';
i18n.enableFallback = true;

export default i18n;