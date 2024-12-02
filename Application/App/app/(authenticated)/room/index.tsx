import { ScrollView, FlatList } from 'react-native';
import { useEffect, useState } from 'react';
import { timer } from 'rxjs';

import { useAccountContext, useFloatPanelContext, useLobbyContext, useRoomContext } from '../../../provider/contexts';
import { AnalyticService, FloatPanelService, GameService, PlayerService } from '../../../provider/services';
import { GameStyle, HelperStyle } from '../../../provider/styles';
import { useParser } from '../../../provider/handlers';

import { AccountStateInterface, GameInterface, LobbyStateInterface } from '../../../shared/interfaces';
import { AppMap, Millis } from '../../../shared/constants';

import GameEntry from '../../../component/smart/game-entry.component';
import Headline from '../../../component/dumb/headline.component';

export default function Game() {

    const { room, setRoom }                 = useRoomContext();
    const { lobby }                         = useLobbyContext();
    const { account }                       = useAccountContext();
    const { floatPanel, setFloatPanel }     = useFloatPanelContext();

    const [ data, setData ]                 = useState<Array<GameInterface>>([]);

    const { tenantId, categoryId }          = useParser<LobbyStateInterface>(lobby);
    const { token }                         = useParser<AccountStateInterface>(account);

    const gameService                       = new GameService();
    const playerService                     = new PlayerService();
    const analyticService                   = new AnalyticService();
    const floatPanelService                 = new FloatPanelService(floatPanel, setFloatPanel);

    const loadAsync = async () => {
        try
        {
            floatPanelService.ShowLoaderModal();

            const groupIds = [];

            let gameResults = await gameService.LoadAsync(tenantId, categoryId, token);
            
            gameResults
                .map(g => {
                    groupIds.push(g.firstGroupId);

                    if(g.secondGroupId !== undefined && g.secondGroupId !== null)
                        groupIds.push(g.secondGroupId);
                });

            if(groupIds.length === 1){
                if(gameResults.length >= 1){
                    const currentGame = gameResults[0];
                    
                    setRoom({ 
                        ...room,
                        game : {
                            id              : currentGame.id,
                            name            : currentGame.name,
                            firstGroupId    : currentGame.firstGroupId,
                            secondGroupId   : currentGame.secondGroupId,
                            actionIds       : currentGame.actionIds
                        }
                    });
                }

                AppMap.Room.BooleanAction();
                return;
            }

            await playerService.LoadAsync();

            const playerResults = playerService.FilterBy(groupIds);

            gameResults
                .map(g => {
                    g.firstGroup = playerResults.find(p => p.id === g.firstGroupId);
                    
                    if(g.secondGroupId !== undefined && g.secondGroupId !== null)
                        g.secondGroup = playerResults.find(p => p.id === g.secondGroupId);
                });

            setData(gameResults);

            timer(Millis.CloseInitialModal).subscribe(floatPanelService.HideLoaderModal);
        }
        catch(e)
        {
            floatPanelService.ShowConfirmationModal(gameService.name, gameService.content);
        }
    };

    useEffect(() => {    
        analyticService.Open('/room', 'Players');

        if(tenantId === undefined || tenantId === null || 
                categoryId === undefined || categoryId === null ||
                    token === undefined || token === null)
                        return;

        loadAsync();

        return () => {
            setData([]);
        };
    }, [tenantId, categoryId, token]);

    return (
        <ScrollView style={HelperStyle.topSpace}>
            <Headline.Colorful i18n='lobby.event.headline' id='hdGame' />

            <FlatList
                data={data}
                keyExtractor={e => e.id.toString()}
                contentContainerStyle={GameStyle.stage}
                renderItem={e => <GameEntry source={e.item} />} />
        </ScrollView>
    );
}