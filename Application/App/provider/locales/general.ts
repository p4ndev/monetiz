import { getLocales } from "expo-localization";
import i18n from "./translation";

const userLocales = getLocales();
let indexLocale = userLocales.findIndex(ul => ul.languageTag === 'pt');

if(indexLocale === -1)
    indexLocale = 0;

let {
    currencyCode,
    currencySymbol,
    languageTag,
    languageCode,
    textDirection,
    digitGroupingSeparator,
    decimalSeparator,
    regionCode
} = getLocales()[indexLocale];

currencySymbol = i18n.t('currencySymbol');
currencyCode = i18n.t('currencyCode');
languageCode = i18n.t('languageCode');
languageTag = i18n.t('languageTag');
regionCode = i18n.t('regionCode');

export {
    languageCode, textDirection, digitGroupingSeparator,
    currencyCode, currencySymbol, languageTag, 
    decimalSeparator, regionCode
};