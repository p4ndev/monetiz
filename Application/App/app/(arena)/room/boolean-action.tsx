import { GestureDetector, Gesture, Directions } from 'react-native-gesture-handler';
import { ImageBackground, Text, View, Pressable } from 'react-native';
import { MaterialIcons } from '@expo/vector-icons';
import { useEffect, useState } from 'react';
import * as Speech from 'expo-speech';
import { timer } from 'rxjs';

import { useAccountContext, useFinancialContext, useFloatPanelContext, useLobbyContext, useRoomContext } from '../../../provider/contexts';
import { ActionService, AnalyticService, FloatPanelService, FullscreenService } from '../../../provider/services';
import { HelperStyle, RoomStyle } from '../../../provider/styles';
import { useParser } from '../../../provider/handlers';
import i18n from '../../../provider/locales';

import { AccountStateInterface, FinancialStateInterface, LobbyStateInterface, RoomStateInterface } from '../../../shared/interfaces';
import { AppMap, Millis, useAsset } from '../../../shared/constants';
import { BalancePhaseEnum } from '../../../shared/enums';
import { RoomState } from '../../../shared/states';

export default function BooleanAction() {
    
    const { floatPanel, setFloatPanel }                     = useFloatPanelContext();
    const { financial, setFinancial }                       = useFinancialContext();
    const { account }                                       = useAccountContext();
    const { lobby }                                         = useLobbyContext();
    const { room, setRoom }                                 = useRoomContext();
    
    const { coin }                                          = useParser<FinancialStateInterface>(financial);
    const { nameid, role, token }                           = useParser<AccountStateInterface>(account);
    const { tenantId, categoryName, colors }                = useParser<LobbyStateInterface>(lobby);
    const { eligible, game, action, speak }                 = useParser<RoomStateInterface>(room);
    
    const [ vertical, setVertical ]                         = useState<number | undefined>(undefined);
    const [ skipIds, setSkipIds ]                           = useState<Array<number>>([]);
    const [ help, setHelp ]                                 = useState<boolean>(true);
    const [ headline, setHeadline ]                         = useState<string>('');

    const analyticService = new AnalyticService();
    const floatPanelService                                 = new FloatPanelService(floatPanel, setFloatPanel);
    const fullscreenService                                 = new FullscreenService();
    const actionService                                     = new ActionService();

    const fling = Gesture
        .Fling()
            .direction(Directions.UP)
                .onBegin((e) => setVertical(e.y))
                .onFinalize((e) => onSwipeAsync(e.y))
                    .runOnJS(true);

    const openAsync = async (from : string) => {
        try
        {
            floatPanelService.ShowLoaderModal();

            Speech.stop();

            if(
                (game.firstGroupName !== undefined && game.firstGroupName !== null) &&
                (game.secondGroupName !== undefined && game.secondGroupName !== null)
            )
                setHeadline(`${game.firstGroupName} x ${game.secondGroupName}`);
            else
                setHeadline(`${categoryName}`);

            const actionResult = await actionService.LoadAsync(game.actionIds, skipIds, from, token);

            if(actionResult === null)
                return;
            
            setRoom({
                ...room,
                eligible : true,
                action : {
                    ...actionResult,
                    hasAnswered : actionService.hasAnswered
                }
            });

            setSkipIds(p => [...p, actionResult.id]);

            analyticService.TrackEvent('Boolean Action Viewed By', { AID: actionResult.id, UID: nameid, RID: role, FROM: from });

            timer(Millis.CloseInitialModal)
                .subscribe(async () => {
                    floatPanelService.HideLoaderModal();

                    if(speak === true)
                        Speech.speak(
                            actionResult.name,
                            { rate: 0.8, pitch: 1, language: 'pt-BR' }
                        );
                });
        }
        catch
        {
            AppMap.Lobby.Tenant();
        }
    };

    const onMenuClicked = async () => {
        analyticService.Track('Menu from Action');
        fullscreenService.Exit();
        AppMap.Lobby.Tenant();
    }

    const onAnswerClickedAsync = async (isNegative : boolean) => {
        try
        {
            floatPanelService.ShowLoaderModal();

            await actionService.AnswerAsync(isNegative, action.id, token);

            setFinancial({ ...financial, phase: BalancePhaseEnum.Sync });

            analyticService.TrackDetailed((isNegative ? 'Negative' : 'Positive') + ' Answer', { AID: action.id });
            
            floatPanelService
                .ShowInformationModal(
                    actionService.name,
                    actionService.content
                );

            timer(Millis.CloseInitialModal).subscribe(() => { openAsync('answer'); });
        }
        catch (error)
        {
            floatPanelService.ShowConfirmationModal(actionService.name, actionService.content);

            timer(Millis.ArenaGeneralIssue).subscribe(AppMap.Lobby.Tenant);
        }
    }
    
    const onSwipeAsync = async (current : number) => {
        if(vertical > current){
            analyticService.Track('SwipeUp');
            await openAsync('swipe-up');
        }
    }

    const voiceToggle = async () => {
        let ableToSpeak = !speak;
        
        Speech.stop();
        
        setRoom({ ...room, speak: ableToSpeak });

        analyticService.Track(ableToSpeak ? 'VoiceOn' : 'VoiceOff');

        await actionService.ToggleVoiceOfflineAsync(ableToSpeak);
    }

    useEffect(() => {
        fullscreenService.Enter();

        analyticService.Open('/room/boolean-action', 'Arena > Boolean Action');

        floatPanelService.ShowLoaderModal();

        timer(Millis.RoomLabel).subscribe(() => setHelp(false));

        return () => {
            Speech.stop();
            setRoom(RoomState);
        };
    }, []);

    useEffect(() => {
        if(token === undefined || token === null || token === '' || !tenantId || !categoryName || game === undefined)
            return;

        openAsync('start');
    }, [token, game]);

    if(eligible === true)
        return (
            <GestureDetector gesture={fling}>
                <ImageBackground source={{ uri: useAsset(action.image) }} resizeMode="cover" style={HelperStyle.fully} id="ibRoom">
                    <View style={RoomStyle.stage}>
                        <View style={RoomStyle.wrapper} id='arenaWrapper'>
                            <View style={[RoomStyle.flag, { backgroundColor: colors[0] }]}>
                                <Text style={[RoomStyle.flagContent, HelperStyle.bold]} id='lblGame'>{ game.name }</Text>                                
                                <svg width="30" height="31" xmlns="http://www.w3.org/2000/svg" style={RoomStyle.flagEnd}>
                                    <g>
                                        <path d="m-0.62568,-0.73527l13.58656,12.29926l-13.40781,12.90526l27.59773,0l0,-25.69829l-27.77649,0.49378z" fill={colors[0]} />
                                    </g>
                                </svg>
                            </View>
                            <View style={RoomStyle.social}>
                                <Pressable onPress={voiceToggle} id='btnVoice'>
                                    <MaterialIcons name={actionService.VoiceIcon(speak)} size={25} color={actionService.VoiceColor(speak, colors[0])} />
                                </Pressable>
                            </View>
                            <Text style={[HelperStyle.bold, RoomStyle.headline, { color: colors[0] }]} id='hdBooleanAction'>
                                { headline }
                            </Text>
                            <Text style={[HelperStyle.light, RoomStyle.summary]}>
                                { action.name }
                            </Text>
                            <View style={RoomStyle.footer}>
                                <View style={RoomStyle.buttonWrapper}>
                                    { (!action.hasAnswered && actionService.HasBalance(coin)) &&
                                        <Pressable onPress={async () => await onAnswerClickedAsync(true)} id='btnNo'>
                                            <MaterialIcons name="close" size={40} color='#B90000' />
                                            { help && <Text style={[RoomStyle.label, RoomStyle.noLabel]} id='lblButtonNo'>{ i18n.t('global.no') }</Text> }
                                        </Pressable>
                                    }
                                </View>
                                <Pressable style={[HelperStyle.highOpaque, RoomStyle.buttonWrapper]} onPress={async () => await onMenuClicked()} id='btnMenu'>
                                    <MaterialIcons name="menu" size={40} color='white' />
                                    { help && <Text style={[RoomStyle.label, RoomStyle.regularLabel]} id='lblButtonMenu'>{ i18n.t('room.action.menu') }</Text> }
                                </Pressable>
                                <Pressable style={[HelperStyle.highOpaque, RoomStyle.buttonWrapper]} onPress={async () => await openAsync('button')} id='btnOther'>
                                    <MaterialIcons name="refresh" size={40} color='white' />
                                    { help && <Text style={[RoomStyle.label, RoomStyle.regularLabel]} id='lblButtonOther'>{ i18n.t('room.action.other') }</Text> }
                                </Pressable>
                                <View style={RoomStyle.buttonWrapper}>
                                    { (!action.hasAnswered && actionService.HasBalance(coin)) &&
                                        <Pressable onPress={async () => await onAnswerClickedAsync(false)} id='btnYes'>
                                            <MaterialIcons name="check" size={40} color='#00A62E' />
                                            { help && <Text style={[RoomStyle.label, RoomStyle.yesLabel]} id='lblButtonYes'>{ i18n.t('global.yes') }</Text> }
                                        </Pressable>
                                    }
                                </View>
                            </View>
                        </View>
                    </View>
                </ImageBackground>
            </GestureDetector>
        );
}