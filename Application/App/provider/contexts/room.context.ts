import { createContext, useContext } from "react";

const RoomContext = createContext<any>({});
const useRoomContext = () => useContext(RoomContext);

export { RoomContext, useRoomContext };