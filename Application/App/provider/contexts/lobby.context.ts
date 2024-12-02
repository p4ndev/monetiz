import { createContext, useContext } from "react";

const LobbyContext = createContext<any>({});
const useLobbyContext = () => useContext(LobbyContext);

export { LobbyContext, useLobbyContext };