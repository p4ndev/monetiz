import { RoomStateInterface } from "../../shared/interfaces";

export const RoomState : RoomStateInterface = {
    eligible : undefined,
    speak : undefined,

    game : {
        id : undefined,
        name : undefined,
        firstGroupId : undefined,
        firstGroupName : undefined,
        secondGroupId : undefined,
        secondGroupName : undefined,
        actionIds : undefined
    },

    action : {
        id : undefined,
        gameId : undefined,        
        eligible : undefined,
        hasAnswered : undefined,
        name : undefined,
        image : undefined,
        startsAt : undefined,
        endsAt : undefined,
        colors : []
    }    
}