import { useEffect } from "react";
import { interval } from "rxjs";

import { useAccountContext, useFinancialContext } from "../../provider/contexts";
import { AnalyticService, CheckoutService } from "../../provider/services";
import { useParser } from "../../provider/handlers";

import { AccountStateInterface, FinancialStateInterface } from "../../shared/interfaces";
import { AppMap, Millis } from "../../shared/constants";
import { BalancePhaseEnum } from "../../shared/enums";

export default function CheckoutSettle() {

    const { account } = useAccountContext();
    const { financial, setFinancial } = useFinancialContext();

    const { nameid, role, token } = useParser<AccountStateInterface>(account);
    const { checkout } = useParser<FinancialStateInterface>(financial);

    const analyticService = new AnalyticService();
    const checkoutService = new CheckoutService('buy');

    const initializeAsync = async () => {
        try {
            if (token === null || token === undefined || token === '' || 
                    checkout === null || checkout === undefined)
                        return;

            const { innerPaymentId, outerPaymentId, status } = checkout;

            if (!checkoutService.IsInProgress(status))
                return;

            await checkoutService.SettleAsync(innerPaymentId, outerPaymentId, token);
            analyticService.TrackEvent('Finished Checkout', { UID: nameid, RID: role, IPI: innerPaymentId, EPI: outerPaymentId });
            setFinancial({ ...financial, checkout: undefined, phase: BalancePhaseEnum.Sync });
            AppMap.Financial.SuccessfulCheckout();
        }
        catch (e){ }
    };

    useEffect(() => {
        const sup = interval(Millis.PixSettleRevision).subscribe(initializeAsync);

        return () => {
            sup.unsubscribe();
        };
    }, [token, checkout]);

    return (<></>);
}