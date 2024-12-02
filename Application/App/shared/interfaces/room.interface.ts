import { PlayerInterface } from "./lobby.interface"

interface GameStateInterface{
    id : number | undefined,
    name : string | undefined,
    firstGroupId : number | undefined,
    firstGroupName : string | undefined,
    secondGroupId : number | undefined,
    secondGroupName : string | undefined,
    actionIds : Array<number> | undefined
}

interface GameInterface{
    id : number,
    name : string,
    firstGroupId : number,
    firstGroup : PlayerInterface | undefined | null,    
    secondGroupId : number,
    secondGroup : PlayerInterface | undefined | null,
    actionIds : Array<number>
}

interface ActionStateInterface{
    name : string | undefined,
    colors : Array<string>,
    id : number | undefined,
    gameId : number | undefined,    
    image : string | undefined,
    hasAnswered : boolean | undefined,
    startsAt : Date | undefined,
    endsAt : Date | undefined,
    eligible : boolean | undefined
}

interface RoomStateInterface{
    speak : boolean | undefined,
    game : GameStateInterface,
    eligible : boolean | undefined,    
    action : ActionStateInterface
}

interface GameEntryInterface{
    source : GameInterface
}

export {
    RoomStateInterface, GameStateInterface, ActionStateInterface,
    GameInterface, GameEntryInterface
}