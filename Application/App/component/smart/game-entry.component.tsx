import { View, Image, Text, Pressable } from "react-native";

import { useAccountContext, useRoomContext } from "../../provider/contexts";
import { GameEntryStyle, HelperStyle } from "../../provider/styles";
import { AnalyticService } from "../../provider/services";
import { useParser } from "../../provider/handlers";

import { AccountStateInterface, GameEntryInterface, GameInterface } from "../../shared/interfaces";
import { AppMap, useAsset } from "../../shared/constants";

export default function GameEntry(props : GameEntryInterface){
        
    const { room, setRoom } = useRoomContext();
    const { account } = useAccountContext();

    const { nameid, role } = useParser<AccountStateInterface>(account);
    
    const { id, firstGroup, secondGroup, name, actionIds } = props.source as GameInterface;

    const analyticService = new AnalyticService();

    const onGameEntryClicked = () => {
        setRoom({ 
            ...room,
            game : {
                id              : id,
                name            : name,
                firstGroupId    : firstGroup.id,
                firstGroupName  : firstGroup.name,
                secondGroupId   : secondGroup.id,
                secondGroupName : secondGroup.name,
                actionIds       : actionIds
            }
        });

        analyticService.TrackEvent('Game Viewed By', { UID: nameid, RID: role, GID: id, FGI: firstGroup.id, SGI: secondGroup.id });

        AppMap.Room.BooleanAction();
    }

    return (
        <Pressable onPress={onGameEntryClicked} style={GameEntryStyle.stage} id={'btnGame' + id}>
            <View style={GameEntryStyle.left}>
                <Image style={GameEntryStyle.icon} source={{ uri: useAsset(firstGroup.logotype) }} resizeMode={'contain'} />
                <Text style={[HelperStyle.light, GameEntryStyle.playerName]} id={'home' + id + '-' + firstGroup.id}>
                    {firstGroup.name}
                </Text>
            </View>
            <View style={GameEntryStyle.center}>
                <Text style={[HelperStyle.light, GameEntryStyle.label]} id={'match' + id}>{ name }</Text>
                <Text style={[HelperStyle.bold, GameEntryStyle.cross]}>X</Text>
            </View>
            <View style={GameEntryStyle.right}>
                <Image style={GameEntryStyle.icon} source={{ uri: useAsset(secondGroup.logotype) }} resizeMode={'contain'} />
                <Text style={[HelperStyle.light, GameEntryStyle.playerName]} id={'guest' + id + '-' + secondGroup.id}>
                    {secondGroup.name}
                </Text>
            </View>
        </Pressable>
    );
}