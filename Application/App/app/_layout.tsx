import { useEffect, useState } from "react";
import { Platform } from "react-native";
import { Slot } from "expo-router";

import { AccountContext, FinancialContext, FloatPanelContext, LobbyContext, RoomContext } from "../provider/contexts";
import { AccountState, FinancialState, FloatPanelState, LobbyState, RoomState } from "../shared/states";

import GoogleAnalyticsConsent from "../component/smart/google-analytics-consent.component";
import ReconnectPlayer from "../component/smart/reconnect-player.component";
import RestrictDevices from "../component/smart/restrict-devices.component";
import RedirectPlayer from "../component/smart/redirect-player.component";
import FloatPanel from "../component/smart/float-panel.component";
import BaseFont from "../component/base/base-font.component";

import '../provider/styles/global.css';

export default function RootLayout(){
    
    const [ floatPanel, setFloatPanel   ] = useState(FloatPanelState);
    const [ account, setAccount         ] = useState(AccountState);
    const [ lobby, setLobby             ] = useState(LobbyState);
    const [ room, setRoom               ] = useState(RoomState);
    const [ financial, setFinancial     ] = useState(FinancialState);

    const [ loadFont, setLoadFont       ] = useState<boolean>(false);

    useEffect(() => {
        if(Platform.OS !== 'web')
            setLoadFont(true);
    }, []);

    return (
        <FloatPanelContext.Provider value={{ floatPanel, setFloatPanel }}>
        <AccountContext.Provider value={{ account, setAccount }}>
        <LobbyContext.Provider value={{ lobby, setLobby }}>        
        <RoomContext.Provider value={{ room, setRoom }}>
        <FinancialContext.Provider value={{ financial, setFinancial }}>
            
            <Slot />
            
            { loadFont === true && <BaseFont /> }
            <FloatPanel />
            <RedirectPlayer />
            <RestrictDevices />
            <ReconnectPlayer />
            <GoogleAnalyticsConsent />

        </FinancialContext.Provider>
        </RoomContext.Provider>
        </LobbyContext.Provider>
        </AccountContext.Provider>
        </FloatPanelContext.Provider>
    );
}