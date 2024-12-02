import { CheckoutResponseInterface, PaymentProviderInterface, PaymentRequestInterface, RemoveCheckoutRequestInterface } from "../../../shared/interfaces";
import { HttpStatusCode200OK } from "../../../shared/constants";
import { MercadoPagoService } from "./mercado-pago.service";
import { BaseService } from "../base.service";

export class CheckoutService extends BaseService
{
  public readonly companyName : string;
  public readonly coinPackages : Array<number>;

  private readonly apiAddress : string;
  private readonly coinBuyPrice : number;
  private readonly coinSellPrice : number;

  private requestHeaders : HeadersInit;
  private paymentProvider : PaymentProviderInterface;
  
  constructor(format : string){
    super();
    this.coinPackages     = [15, 50, 200];
    this.paymentProvider  = this.CreatePaymentProvider(format);
    this.companyName      = process.env.EXPO_PUBLIC_COIN_MPA_COMPANY;
    this.coinBuyPrice     = Number(process.env.EXPO_PUBLIC_COIN_BUY_PRICE);
    this.coinSellPrice    = Number(process.env.EXPO_PUBLIC_COIN_SELL_PRICE);
    this.apiAddress       = `${process.env.EXPO_PUBLIC_API_ADDRESS}/financial/${format}`;
  }

  private CreatePaymentProvider(format : string) : PaymentProviderInterface{
    switch(format){
      case 'buy':
      case 'sell':
        return new MercadoPagoService();
    }
  }

  PriceToBuy(amount : number) : number{
    return (amount * this.coinBuyPrice);
  }

  PriceToSell(amount : number) : number{
    return (amount * this.coinSellPrice);
  }

  IsInProgress(status : string) : boolean {
    return this.paymentProvider.IsInProgress(status);
  }

  IsComplete(status : string) : boolean {
    return this.paymentProvider.IsComplete(status);
  }

  IsIncomplete(status : string) : boolean {
    return (!this.IsComplete(status) && !this.IsInProgress(status));
  }

  PurchaseTrackId(checkout : CheckoutResponseInterface) : string{
    return `${checkout.innerPaymentId}.${checkout.outerPaymentId}`;
  }

  async InitializeAsync(model : PaymentRequestInterface, token : string) : Promise<void> {
    return new Promise(async (resolve, reject) => {
      const response = await fetch(`${this.apiAddress}`, {
        body: JSON.stringify(model),
        method: 'POST',
        headers: {
          'Authorization'     : `bearer ${token}`,
          'Content-Type'      : 'application/json'
        }
      });

      if(this.CatchExceptions(response.status))
        return reject();

      return resolve();

    });
  }

  async LoadAsync(token : string) : Promise<CheckoutResponseInterface>{
    return new Promise(async (resolve, reject) => {

      const response = await fetch(`${this.apiAddress}`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `bearer ${token}`
        }
      });

      if(this.CatchExceptions(response.status))
        return reject();

      const data = await response.json();

      return resolve(data as CheckoutResponseInterface);
      
    });
  }

  async CancelAsync(model : RemoveCheckoutRequestInterface, token : string) : Promise<void>{
    return new Promise(async (resolve, reject) => {

      this.requestHeaders = new Headers();
      this.requestHeaders.set('Content-Type', 'application/json');
      this.requestHeaders.set('Authorization', `Bearer ${token}`);

      this.requestHeaders.set('epi', model.externalPaymentId.toString());
      this.requestHeaders.set('ipi', model.internalPaymentId.toString());

      const response = await fetch(`${this.apiAddress}`, {
        method  : 'DELETE',
        headers : this.requestHeaders
      });

      if(this.CatchExceptions(response.status))
        return reject();

      this.name = 'financial.pix.removeSuccessName';
      this.content = 'financial.pix.removeSuccessContent';

      return resolve();

    });
  }

  async ExpiredAsync(ipi: number, epi: number, token: string) : Promise<void> {
    return new Promise(async (resolve, reject) => {

      this.requestHeaders = new Headers();
      this.requestHeaders.set('Content-Type', 'application/json');
      this.requestHeaders.set('Authorization', `Bearer ${token}`);

      this.requestHeaders.set('ipi', ipi.toString());
      this.requestHeaders.set('epi', epi.toString());

      const response = await fetch(`${this.apiAddress}`, {
        method  : 'PUT',
        headers : this.requestHeaders
      });

      if(this.CatchExceptions(response.status))
        return reject();

      return resolve();

    });
  }

  async SettleAsync(ipi: number, epi: number, token: string) : Promise<void> {
    return new Promise(async (resolve, reject) => {

      this.requestHeaders = new Headers();
      this.requestHeaders.set('Content-Type', 'application/json');
      this.requestHeaders.set('Authorization', `Bearer ${token}`);

      this.requestHeaders.set('ipi', ipi.toString());
      this.requestHeaders.set('epi', epi.toString());

      const response = await fetch(`${this.apiAddress}`, {
        method  : 'PATCH',
        headers : this.requestHeaders
      });

      if(response.status === HttpStatusCode200OK)
        return resolve();

      return reject();

    });
  }
}