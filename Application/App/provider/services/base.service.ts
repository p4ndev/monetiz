import {
    HttpStatusCode401Unauthorized,
    HttpStatusCode403Forbidden,
    HttpStatusCode404NotFound,
    HttpStatusCode409Conflict,
    HttpStatusCode415UnsupportedMediaType,
    HttpStatusCode500InternalServerError
} from "../../shared/constants";

export abstract class BaseService
{
    public name : string;
    public content : string;

    constructor() {
        this.name = '';
        this.content = '';
    }

    protected CatchExceptions(status : number) : boolean
    {
        let output = false;

        switch(status){

            case HttpStatusCode401Unauthorized:
                output = true;
                this.name = 'global.serverErrorName';
                this.content = 'global.serverUnauthorizedRequest';
                break;

            case HttpStatusCode403Forbidden:
                output = true;
                this.name = 'global.serverErrorName';
                this.content = 'global.serverForbiddenAction';
                break;

            case HttpStatusCode404NotFound:
                output = true;
                this.name = 'global.serverErrorName';
                this.content = 'global.serverResourceNotFound';
                break;

            case HttpStatusCode409Conflict:
                output = true;
                this.name = 'global.serverErrorName';
                this.content = 'global.serverResourceConflicted';
                break;
    
            case HttpStatusCode415UnsupportedMediaType:
                output = true;
                this.name = 'global.serverErrorName';
                this.content = 'global.serverInvalidRequest';
                break;
    
            case HttpStatusCode500InternalServerError:
                output = true;
                this.name = 'global.serverErrorName';
                this.content = 'global.serverGeneralError';
                break;
        }

        return output;
    }
}