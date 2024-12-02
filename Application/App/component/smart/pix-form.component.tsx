import { View, TextInput, Text, Keyboard } from 'react-native';
import { useEffect, useState } from 'react';
import { interval } from 'rxjs';

import { AnalyticService, FloatPanelService, PixService } from '../../provider/services';
import { useAccountContext, useFloatPanelContext } from '../../provider/contexts';
import { HelperStyle, PixCodeFormStyle } from '../../provider/styles';
import { useParser } from '../../provider/handlers';
import i18n from '../../provider/locales';

import { AccountStateInterface, PixRequestInterface } from '../../shared/interfaces';
import { PixFormModel} from '../../shared/states';
import { PixTypeEnum } from '../../shared/enums';
import { Millis } from '../../shared/constants';

import Headline from '../dumb/headline.component';
import Button from '../dumb/button.component';

export default function PixForm(){

    const { account, setAccount } = useAccountContext();
    const { floatPanel, setFloatPanel } = useFloatPanelContext();

    const [instructionIdx, setInstructionIdx] = useState<number>(-1);
    const [instructionMsg, setInstructionMsg] = useState<string>('');
    const [model, setModel] = useState<PixRequestInterface>(PixFormModel);

    const { nameid, role, token } = useParser<AccountStateInterface>(account);
    
    const pixService = new PixService();
    const analyticService = new AnalyticService();
    const floatPanelService = new FloatPanelService(floatPanel, setFloatPanel);
    
    const isEmail = (data : string) : boolean => (data.indexOf('@') !== -1 && data.indexOf('.') !== -1);
    const isPhone = (data : string) : boolean => (data.indexOf('(') !== -1 && data.indexOf(')') !== -1);
    const isCnpj = (data : string) : boolean => (/^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$/).test(data);
    const isCpf = (data : string) : boolean => (/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/).test(data);
    const isRandom = (data : string) : boolean => (/^[a-zA-Z0-9]{10,}$/).test(data);
    const hasFormat = (data : PixTypeEnum) : boolean => (data !== PixTypeEnum.None);

    const onFormSubmitAsync = async (e) => {
        if(e !== undefined || e !== null)
          e.preventDefault();
    
        await onSubmitAsync();
      };

    const onSubmitAsync = async () => {
        try
        {
            Keyboard.dismiss();
            
            if(model.type === PixTypeEnum.None){
                floatPanelService
                    .ShowConfirmationModal(
                        'financial.pix.invalidKeyName',
                        'financial.pix.invalidKeyContent'
                    );

                analyticService
                    .TrackEvent(
                        'Pix Type > Validation Error', {
                            FIELDS: ['pix'],
                            INPUTS: model.content
                        }
                    );

                return;
            }

            floatPanelService.ShowLoaderModal();

            await pixService.InitializeAsync(model, token);

            analyticService.TrackDetailed('Pix Registered', { UID: nameid, RID: role, PTI: model.type });

            setAccount({ ...account, refresh: true });
        }
        catch(e)
        {
            floatPanelService
                .ShowConfirmationModal(
                    pixService.name,
                    pixService.content
                );
        }
    }

    useEffect(() => {
        if(isEmail(model.content))            setModel({ ...model, type: PixTypeEnum.Email });
        else if(isCpf(model.content))         setModel({ ...model, type: PixTypeEnum.Cpf });
        else if(isCnpj(model.content))        setModel({ ...model, type: PixTypeEnum.Cnpj });
        else if(isPhone(model.content))       setModel({ ...model, type: PixTypeEnum.Phone });
        else if(isRandom(model.content))      setModel({ ...model, type: PixTypeEnum.Random });
        else                                  setModel({ ...model, type: PixTypeEnum.None });
    }, [model.content]);

    useEffect(() => {
        const sup = interval(Millis.PixKeyInstructions)
            .subscribe(() => setInstructionIdx(p => {
                if(p < pixService.TotalInstructions())
                    return (p + 1);
                return 0;
            }));

        setInstructionIdx(p => p + 1);

        return () => {
            sup.unsubscribe();
        }
    }, []);

    useEffect(() => {
        if(instructionIdx >= 0)
            setInstructionMsg(pixService.ExtractInstructions(instructionIdx));

    }, [instructionIdx]);

    return (
        <>
            <Headline.Light i18n='financial.pix.pixFormHeadline' />
            <form onSubmit={onFormSubmitAsync} id='pnPixForm'>
                <View style={PixCodeFormStyle.stage}>
                    <View style={PixCodeFormStyle.leftCell}>
                        <View style={HelperStyle.inputWrap}>
                            <TextInput
                                maxLength={36}
                                id='txtPixKey'
                                style={[HelperStyle.input, HelperStyle.regular]}
                                onChange={async (e) => setModel({ ...model, content: e.nativeEvent.text })}
                                placeholder={i18n.t('financial.pix.pixInstructionField')} />
                        </View>
                        { hasFormat(model.type) &&
                            <Text style={[HelperStyle.light, HelperStyle.headlineLight, PixCodeFormStyle.keyFormat]}>
                                {i18n.t('financial.pix.keyType')}: <Text style={PixCodeFormStyle.FormatBox} id='lblPixType'>{ pixService.FriendlyName(model.type) }</Text>
                            </Text>
                        }
                        { !hasFormat(model.type) &&
                            <Text style={[ HelperStyle.light, HelperStyle.opaque, PixCodeFormStyle.helper]}>
                                { instructionMsg }
                            </Text>
                        }
                    </View>
                    <View style={PixCodeFormStyle.rightCell}>
                        <Button.Secondary onClick={onSubmitAsync} icon='save' id='btnRegisterPixKey' />
                        <input type="submit" hidden />
                    </View>
                </View>
            </form>
        </>
    );
}