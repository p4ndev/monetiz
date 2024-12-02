import ReactGA from "react-ga4";
import { StorageHandler } from "../handlers";

export class AnalyticService
{
    private consent : boolean | null = null;
    private readonly storageHandler : StorageHandler;
    
    constructor() {
        this.storageHandler = new StorageHandler();

        new Promise(async () => {
            await this.InitializeAsync();
        });
    }

    public Track(name : string){
        if(this.consent !== true)
            return;

        ReactGA
            .event({
                category : 'User Interaction',
                action: 'User Interaction'
            });

        // ReactGA.event({
        //     category        : "User Interaction",
        //     action          : name,
        //     nonInteraction  : true,
        //     transport       : "xhr"
        // });
    }

    public TrackDetailed(name : string, data : any | undefined = undefined){
        if(this.consent !== true)
            return;

        ReactGA
            .event({
                category : 'User Interaction Detailed',
                action: 'User Interaction Detailed'
            });

        // ReactGA.event({
        //     category        : "User Interaction Detailed",
        //     action          : name,
        //     value           : data,
        //     nonInteraction  : true,
        //     transport       : "xhr"
        // });
    }

    public TrackEvent(name : string, data : any | undefined = undefined){
        if(this.consent !== true)
            return;

        ReactGA
            .event({
                category : 'Event Detailed',
                action: 'Event Detailed'
            });

        // ReactGA.event({
        //     category        : "Event Detailed",
        //     action          : name,
        //     value           : data,
        //     nonInteraction  : true,
        //     transport       : "xhr"
        // });
    }

    public Open(route : string, pageTitle : string){
        if(this.consent !== true)
            return;

        ReactGA
            .send({
                hitType : 'mna-screen-view'
            });

        // ReactGA.send({
        //     hitType : "mna-screen-view",
        //     page    : route,
        //     title   : pageTitle
        // });
    }

    private DeleteCookie(cookieName) {
        document.cookie = cookieName + '=;expires=Mon Jan 01 1900 00:00:00 ; path=/ ; domain=monetiz.fun';
        document.cookie = cookieName + '=;expires=Mon Jan 01 1900 00:00:00 ; path=/ ; domain=localhost';
    }

    public async PositiveConsentAsync() : Promise<void>{
        this.consent = true;
        await this.storageHandler.AddAsync('ga-consent', this.consent);

        new Promise(async () => {
            await this.InitializeAsync();
        });
    }

    public async NegativeConsentAsync() : Promise<void>{
        this.consent = false;
        const keyName = `${process.env.EXPO_PUBLIC_GA_KEY}`;
        await this.storageHandler.AddAsync('ga-consent', this.consent);

        this.DeleteCookie('_ga');
        this.DeleteCookie('_ga_' + keyName.split('-')[1]);
    }

    public async InitializeAsync() : Promise<void> {
        await this.LoadOfflineConsentAsync();

        if(this.consent === true)
            ReactGA.initialize(`${process.env.EXPO_PUBLIC_GA_KEY}`);
    }

    async LoadOfflineConsentAsync() : Promise<boolean | null> {
        this.consent = await this.storageHandler.FindAsync<boolean>('ga-consent');
        return this.consent;
    }
}