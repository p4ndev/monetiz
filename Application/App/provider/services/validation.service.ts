export class ValidationService
{
    public name : string;
    public content : string;
    public hasError : boolean;
    public from : Array<string>;
    public data : Array<string>;
    private guidValidator : RegExp;

    constructor(){       
        this.name = '';
        this.from  = [];
        this.data  = [];
        this.content = '';
        this.hasError = false;
        this.guidValidator = /^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[1-5][0-9a-fA-F]{3}-[89abAB][0-9a-fA-F]{3}-[0-9a-fA-F]{12}$/;
    }

    IsValidEmail(email : string) : boolean{
        if(email.indexOf('@') !== -1 && email.indexOf('.') !== -1)
            return true;

        if(this.from.indexOf('email') === -1){
            this.from.push('email');
            this.data.push(email);
        }

        this.name = 'global.serverErrorName';
        this.content = 'global.invalidEmail';
        this.hasError = true;
        return false;
    }

    IsValidPassword(pass : string) : boolean{
        if(pass.length >= 6)
            return true;

        if(this.from.indexOf('password') === -1){
            this.from.push('password');
            this.data.push(pass);
        }

        this.name = 'global.serverErrorName';
        this.content = 'global.invalidPassword';
        this.hasError = true;
        return false;
    }

    IsValidConfirmation(pass : string, confPass : string) : boolean{
        if(pass === confPass)
            return true;

        if(this.from.indexOf('password-confirmation') === -1){
            this.from.push('password-confirmation');
            this.data.push('PASS: ' + pass + ' CONF: ' + confPass);
        }

        this.name = 'global.serverErrorName';
        this.content = 'account.signUp.invalidConfirmationPassword';
        this.hasError = true;
        return false;
    }

    IsValidId(data : number) : boolean{
        if(data > 0)
            return true;

        if(this.from.indexOf('id') === -1) {
            this.from.push('id');
            this.data.push(data.toString());
        }

        this.name = 'global.serverErrorName';
        this.content = 'global.invalidId';
        this.hasError = true;
        return false;
    }

    IsValidGuid(data? : string) : boolean{
        if(this.guidValidator.test(data))
            return true;

        if(this.from.indexOf('guid') === -1){
            this.from.push('guid');
            this.data.push(data);
        }

        this.name = 'global.serverErrorName';
        this.content = 'global.invalidGuid';
        this.hasError = true;
        return false;
    }

    Reset() : void{
        this.from = [];
        this.data = [];
    }
}