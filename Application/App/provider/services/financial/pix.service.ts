import { PixRequestInterface } from "../../../shared/interfaces";
import { PixTypeEnum } from "../../../shared/enums";
import { BaseService } from "../base.service";

export class PixService extends BaseService
{
    private readonly apiAddress : string;
    private readonly instructions : Array<string>;

    constructor(){
        super();

        this.instructions = ['(00) 00000-0000', '000.000.000-00', '00.000.000/0000-00', 'usuario@monetiz.fun', '00000000-wrta-0000-abcd-000000000000'];
        this.apiAddress = `${process.env.EXPO_PUBLIC_API_ADDRESS}/financial/pix`;
    }

    FriendlyName = (input : PixTypeEnum) : string => {
        let output = '';

        switch(input){
            case PixTypeEnum.Cpf:       output = 'Cpf';         break;
            case PixTypeEnum.Cnpj:      output = 'Cnpj';        break;
            case PixTypeEnum.Email:     output = 'Email';       break;
            case PixTypeEnum.Phone:     output = 'Celular';     break;
            case PixTypeEnum.Random:    output = 'Aleatória';   break;
        }

        return output;
    }

    async InitializeAsync(model : PixRequestInterface, token : string) : Promise<void>{
        return new Promise(async (resolve, reject) => {

            const response = await fetch(`${this.apiAddress}`, {
                body: JSON.stringify(model),
                method: 'POST',
                headers: {
                  'Content-Type': 'application/json',
                  'Authorization': `bearer ${token}`
                }
            });

            if(this.CatchExceptions(response.status))
                return reject();

            return resolve();
                        
        });
    }

    ExtractInstructions(idx : number) : string{
        return this.instructions[idx];
    }

    TotalInstructions() : number {
        return (this.instructions.length - 1);
    }
}