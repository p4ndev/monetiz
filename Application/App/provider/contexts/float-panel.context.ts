import { createContext, useContext } from "react";

const FloatPanelContext = createContext<any>({});
const useFloatPanelContext = () => useContext(FloatPanelContext);

export { FloatPanelContext, useFloatPanelContext };