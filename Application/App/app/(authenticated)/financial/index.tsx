import { useEffect } from "react";

import { useAccountContext, useFloatPanelContext } from "../../../provider/contexts";
import { FloatPanelService } from "../../../provider/services";
import { useParser } from "../../../provider/handlers";

import { AccountStateInterface } from "../../../shared/interfaces";
import { AppMap } from "../../../shared/constants";
import { RoleEnum } from "../../../shared/enums";

import RestrictRoles from "../../../component/smart/restrict-roles.component";
import CheckoutLoad from "../../../component/smart/checkout-load.component";

export default function FinancialHome() {

    const { account }                     = useAccountContext();
    const { floatPanel, setFloatPanel }   = useFloatPanelContext();

    const { isRestricted }                = useParser<AccountStateInterface>(account);

    const floatPanelService               = new FloatPanelService(floatPanel, setFloatPanel);

    useEffect(() => {    
        floatPanelService.ShowLoaderModal();

        if(isRestricted === true)
            AppMap.InvalidAccess();
        
        return () => {
            floatPanelService.HideLoaderModal();
        };
    }, [isRestricted]);

    return (
        <>
            <CheckoutLoad />
            <RestrictRoles source={RoleEnum.Guest} />
        </>
    );
}