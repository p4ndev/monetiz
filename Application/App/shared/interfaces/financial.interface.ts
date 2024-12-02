import { BalancePhaseEnum, PixTypeEnum } from "../enums";

interface FinancialStateInterface{
    coin : number | undefined,
    phase : BalancePhaseEnum | undefined,
    checkout : CheckoutResponseInterface | null
}

interface BuyCoinEntryPropsInterface{
    id : string,
    stageStyle : any,
    iconStyle : any,
    iconWrapperStyle : any,
    iconSource : string,    
    amount : number,
    total : number,
    onClicked : () => void
}

interface SellCoinEntryPropsInterface{
    id : number,
    amount : number,
    total : number,
    
    onClicked : () => void
}

interface CheckoutResponseInterface{
    innerPaymentId : number,
    outerPaymentId : number,
    
    coins : number,
    total : number,

    code : string,
    status : string,
    ticketUrl : string,

    createdAt : Date,
    expiresAt : Date
}

interface PaymentRequestInterface{
    id : string,
    coins : number,
    total : number,
    product : string
}

interface CoinMenuStateItemInterface{
    lci : number,
    ldi : number
}

interface BalanceEntryResponse{
    bid : number,
    eid : number,
    ogt : number,
    amount : number,
    createdAt : Date
}

interface BalanceResponse {
    credits : Array<BalanceEntryResponse>,
    debits : Array<BalanceEntryResponse>
}

interface RemoveCheckoutRequestInterface{
    externalPaymentId : number,
    internalPaymentId : number
}

interface PaymentProviderInterface{
    IsInProgress(status : string) : boolean;
    IsComplete(status : string) : boolean;
}

interface PixRequestInterface{
    content : string,
    type : PixTypeEnum
}

export {
    FinancialStateInterface, CheckoutResponseInterface, BuyCoinEntryPropsInterface,
    SellCoinEntryPropsInterface, PaymentRequestInterface, RemoveCheckoutRequestInterface,
    CoinMenuStateItemInterface, BalanceEntryResponse, BalanceResponse, PaymentProviderInterface, PixRequestInterface
}