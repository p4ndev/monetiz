import { createContext, useContext } from "react";

const FinancialContext = createContext<any>({});
const useFinancialContext = () => useContext(FinancialContext);

export { FinancialContext, useFinancialContext };