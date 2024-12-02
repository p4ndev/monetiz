import { CoinMenuStateItemInterface, FinancialStateInterface, PixRequestInterface } from "../../shared/interfaces";
import { PixTypeEnum } from "../enums";

const FinancialState : FinancialStateInterface = {
    phase : undefined,
    coin : undefined,
    checkout : null
}

const CoinMenuItemState : CoinMenuStateItemInterface  = {
    lci : 0,
    ldi : 0
}

const PixFormModel : PixRequestInterface = {
    type : PixTypeEnum.None,
    content : ''
}

export { FinancialState, CoinMenuItemState, PixFormModel }