import { useEffect, useState } from "react";
import { View, Text } from "react-native";

import { GAStyle, HelperStyle } from "../../provider/styles";
import { AnalyticService } from "../../provider/services";
import i18n from "../../provider/locales";

import Button from "../dumb/button.component";

export default function GoogleAnalyticsConsent(){

    const analyticServices = new AnalyticService();

    const [hasConsent, setHasConsent] = useState<boolean | null>(null);

    const onAcceptAsync = async () => {
        await analyticServices.PositiveConsentAsync();
        setHasConsent(true);
    };

    const onDeclineAsync = async () => {
        await analyticServices.NegativeConsentAsync();
        setHasConsent(true);
    };

    useEffect(() => {
        new Promise(async () => {
            const data = await analyticServices.LoadOfflineConsentAsync();

            setHasConsent(data);
        });
    }, []);

    if(hasConsent === null)
        return (
            <View style={GAStyle.stage} id='gaConsent'>
                <Text style={[ HelperStyle.light, GAStyle.instructions]}>
                    { i18n.t('global.cookieConsent') }
                </Text>
                <View style={GAStyle.grid}>
                    <View style={GAStyle.cell}>
                        <Button.Danger i18n="global.no" onClick={async () => await onDeclineAsync()} />
                    </View>
                    <View style={GAStyle.cell}>
                        <Button.Success i18n="global.yes" onClick={async () => await onAcceptAsync()} />
                    </View>
                </View>
            </View>
        );
}