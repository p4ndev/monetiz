import { PaymentProviderInterface } from "../../../shared/interfaces";
import { initMercadoPago } from '@mercadopago/sdk-react'

export class MercadoPagoService implements PaymentProviderInterface
{
    constructor() {
        initMercadoPago(`${process.env.EXPO_PUBLIC_COIN_MPA_PUBLIC_KEY}`);   
    }
    
    IsInProgress(status : string): boolean {
        return (status.toString().toLocaleLowerCase() === 'pending');
    }

    IsComplete(status : string): boolean {
        return (status.toString().toLocaleLowerCase() === 'approved');
    }
}