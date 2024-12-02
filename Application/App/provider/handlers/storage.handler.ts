import AsyncStorage from '@react-native-async-storage/async-storage';

export class StorageHandler
{
    async FindAsync<T>(key : string) : Promise<T | null | undefined>{
        const localValue = await AsyncStorage.getItem(key);

        if(
            (localValue === undefined || localValue === null) && 
            (window && window.sessionStorage)
        ){
            const sessionValue = sessionStorage.getItem(key);

            if(sessionValue === undefined || sessionValue === null)
                return null;
            
            return JSON.parse(sessionValue) as T;
        }
        
        return JSON.parse(localValue) as T;
    }

    async AddAsync(key : string, value : any | string, isLocal : boolean = true) {
        if(value === undefined || value === null || value === '')
            return;

        if(isLocal)
            await AsyncStorage.setItem(key, JSON.stringify(value));
        else if(window && window.sessionStorage)
            sessionStorage.setItem(key, JSON.stringify(value));
    }

    async AddRangeAsync(source : any, isLocal : boolean = true){
        if (typeof source !== 'object' || source === null)
            return;

        for (const property in source) {
            if (!source.hasOwnProperty(property))
                continue;

            const value = source[property];

            await this.AddAsync(property, value, isLocal);
        }
    }

    async RemoveAsync(key : string){
        await AsyncStorage.removeItem(key);
        
        if(window && window.sessionStorage)
            sessionStorage.removeItem(key);
    }
    
    async RemoveRangeAsync(source : any){
        if (typeof source !== 'object' || source === null)
            return;

        for (const property in source) {
            if (!source.hasOwnProperty(property))
                continue;

            await this.RemoveAsync(property);
        }
    }

    async RemoveAllAsync(){
        await AsyncStorage.clear();

        if(window && window.sessionStorage)
            sessionStorage.clear();
    }
}