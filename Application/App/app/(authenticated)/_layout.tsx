import { MaterialIcons } from '@expo/vector-icons';
import { Tabs } from "expo-router";

import ReconnectPlayer from '../../component/smart/reconnect-player.component';
import ActivatePlayer from '../../component/smart/activate-player.component';
import CoinMenuItem from '../../component/smart/coin-menu-item.component';
import RefreshToken from '../../component/smart/refresh-token.component';
import BalanceLoad from '../../component/smart/balance-load.component';
import BaseLayout from "../../component/base/base-layout.component";

export default class AuthenticatedLayout extends BaseLayout{
    render(){
        return (
            <>
                <Tabs screenOptions={this.tabScreenOptions} sceneContainerStyle={this.tabContainerStyle}>
                    
                    <Tabs.Screen
                        name="lobby/tenant"
                        options={{
                            title: '',
                            href: 'lobby/tenant',
                            tabBarIconStyle: { marginLeft: -60 },
                            tabBarIcon: ({color}) => <MaterialIcons name="menu" size={this.iconSize} color={color} />
                        }} />

                    <Tabs.Screen
                        name="financial/index"
                        options={{
                            title: '',
                            href: 'financial',
                            unmountOnBlur: true,
                            tabBarIcon: () => <CoinMenuItem />
                        }} />

                    <Tabs.Screen
                        name="account/profile"
                        options={{
                            title: '',
                            href: 'account/profile',
                            unmountOnBlur: true,
                            tabBarIconStyle: { marginRight: -60 },
                            tabBarIcon: ({color}) => <MaterialIcons name="manage-accounts" size={this.iconSize} color={color} />
                        }} />

                    <Tabs.Screen name="empty-list" options={{ title: '', href: null }} />
                    <Tabs.Screen name="room/index" options={{ title: '', href: null }} />
                    <Tabs.Screen name="invalid-access" options={{ title: '', href: null }} />
                    <Tabs.Screen name="lobby/category" options={{ title: '', href: null }} />
                    <Tabs.Screen name="financial/checkout" options={{ title: '', href: null }} />
                    <Tabs.Screen name="financial/shopping-cart" options={{ title: '', href: null }} />
                    <Tabs.Screen name="financial/successful-checkout" options={{ title: '', href: null }} />
                    <Tabs.Screen name="financial/unsuccessful-checkout" options={{ title: '', href: null }} />

                </Tabs>
                
                <ActivatePlayer />
                <ReconnectPlayer />
                <RefreshToken />
                <BalanceLoad />
            </>
        );
    }
}