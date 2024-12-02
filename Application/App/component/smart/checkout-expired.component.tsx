import { useEffect } from "react";
import { timer } from "rxjs";

import { useAccountContext, useFinancialContext, useFloatPanelContext } from "../../provider/contexts";
import { AnalyticService, CheckoutService, FloatPanelService } from "../../provider/services";
import { useDateExpired } from "../../provider/locales";
import { useParser } from "../../provider/handlers";

import { AccountStateInterface, FinancialStateInterface } from "../../shared/interfaces";
import { AppMap, Millis } from "../../shared/constants";

export default function CheckoutExpired() {

    const { account } = useAccountContext();
    const { financial, setFinancial } = useFinancialContext();
    const { floatPanel, setFloatPanel } = useFloatPanelContext();

    const { nameid, role, token } = useParser<AccountStateInterface>(account);
    const { checkout } = useParser<FinancialStateInterface>(financial);

    const analyticService = new AnalyticService();
    const checkoutService = new CheckoutService('buy');
    const floatPanelService = new FloatPanelService(floatPanel, setFloatPanel);

    const initializeAsync = async () => {
        const { innerPaymentId, outerPaymentId, expiresAt } = checkout;

        if (useDateExpired(expiresAt) === true)
        {
            floatPanelService
                .ShowInformationModal(
                    'financial.pix.expirationName',
                    'financial.pix.expirationMessage'
                );

            await checkoutService.ExpiredAsync(innerPaymentId, outerPaymentId, token);

            analyticService.TrackEvent('Expired Checkout', { UID: nameid, RID: role, IPI: innerPaymentId, EPI: outerPaymentId });
            setFinancial({ ...financial, checkout: undefined });
            floatPanelService.HideInformationModal();
            AppMap.Financial.ShoppingCart();
        }
    };

    useEffect(() => {
        if(token === undefined || token === null ||
            checkout === undefined || checkout === null)
                return;

        timer(Millis.CheckoutExpirationDate).subscribe(initializeAsync);
    }, [token, checkout]);

    return (<></>);
}