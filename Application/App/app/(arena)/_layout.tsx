import { Stack } from "expo-router";

import BaseLayout from "../../component/base/base-layout.component";

export default class ArenaLayout extends BaseLayout{
    render(){
        return (
            <Stack screenOptions={this.tabScreenOptions}>
                <Stack.Screen name="room/boolean-action" />
            </Stack>
        );
    }
}