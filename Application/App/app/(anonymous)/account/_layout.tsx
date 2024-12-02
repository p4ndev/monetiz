import { MaterialIcons } from '@expo/vector-icons';
import { Tabs } from 'expo-router';

import ReconnectPlayer from '../../../component/smart/reconnect-player.component';
import RedirectPlayer from '../../../component/smart/redirect-player.component';
import BaseLayout from '../../../component/base/base-layout.component';

export default class AnonymousAccountLayout extends BaseLayout{
    render(){
        return (
            <>
                <Tabs screenOptions={this.tabScreenOptions} sceneContainerStyle={this.tabContainerStyle}>
                    <Tabs.Screen
                        name="sign-in"
                        options={{
                            title: '',
                            tabBarIcon: ({color}) => <MaterialIcons name="login" size={this.iconSize} color={color} />
                        }} />

                    <Tabs.Screen
                        name="sign-up"
                        options={{
                            title: '',
                            tabBarIcon: ({color}) => <MaterialIcons name="group-add" size={this.iconSize} color={color} />
                        }} />
                    
                    <Tabs.Screen
                        name="recovery"
                        options={{
                            title: '',
                            tabBarIcon: ({color}) => <MaterialIcons name="lock-reset" size={this.iconSize} color={color} />
                        }} />

                    <Tabs.Screen
                        name="reset"
                        options={{ title: '', href: null }} />

                    <Tabs.Screen
                        name="sign-out"
                        options={{ title: '', href: null }} />
                </Tabs>
                
                <RedirectPlayer />
                <ReconnectPlayer />
            </>
        );        
    };
}