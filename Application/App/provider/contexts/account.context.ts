import { createContext, useContext } from "react";

const AccountContext = createContext<any>({});
const useAccountContext = () => useContext(AccountContext);

export { AccountContext, useAccountContext };