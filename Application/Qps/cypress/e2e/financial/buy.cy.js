describe('Buy', () => {
	const coins 			= 15;
	const activityId 		= Cypress.env('puchaseActivityId');
	const transactionId 	= Cypress.env('purchaseComposeId');
	const createdAt 		= Cypress.env('purchaseCreatedAt');
	const expiresAt 		= Cypress.env('purchaseExpiration');

	beforeEach(function(){
		cy.fixture(Cypress.env('language')).then((i18n) => { this.i18n = i18n; });
		cy.viewport(Cypress.env('device'), Cypress.env('orientation'));		
		cy.visit('/');
		
		cy.get('#gaConsent').find('#r3-danger').click();
		cy.wait(Cypress.env('millis') / 5);
		
		cy.get('#splash').find('#r0-primary').click();
		cy.wait(Cypress.env('millis') / 5);
	});

	it('Block guest access', function(){		
		cy.guestSignIn();
		cy.wait(Cypress.env('millis') / 2);
		cy.url().should('include', i18n.url.tenant);
		
		cy.get('div[role=tablist]').find('a').eq(1).click();
		cy.url().should('include', this.i18n.url.blockAccess);
		cy.get('#hdInvalidAccess').should('have.text', this.i18n.error.blockAccess);
	});

	it('Packages data review', function(){		
		cy.memberSignIn();
		cy.wait(Cypress.env('millis') / 2);
		cy.url().should('include', this.i18n.url.tenant);
		
		cy.get('div[role=tablist]').find('a').eq(1).click();			
		cy.get('#pnCart').should('be.visible');
		cy.url().should('include', this.i18n.url.buy);
		cy.get('#hdCheckout').should('have.text', this.i18n.headline.buy);
		
		cy.get('#pnCart > div').eq(0).should('have.text', this.i18n.buy.firstPackage);			
		cy.get('#pnCart > div').eq(1).should('have.text', this.i18n.buy.secondPackage);
		cy.get('#pnCart > div').eq(2).should('have.text', this.i18n.buy.thirdPackage);
	});

	it.skip('Data review after complete execution', function(){		
		cy.memberSignIn();
		cy.wait(Cypress.env('millis') / 2);
		cy.url().should('include', this.i18n.url.tenant);
		
		cy.get('div[role=tablist]').find('a').eq(2).click();
		cy.wait(Cypress.env('millis') * 3);

		cy.get('#pnActivityEntry-' + activityId)
			.should('be.visible');
		
		cy.get('#pnActivityEntry-' + activityId)
			.find('#txtTitle-' + activityId)
				.should('have.text', this.i18n.headline.activityBuy);
				
		cy.get('#pnActivityEntry-' + activityId)
			.find('#txtContent-' + activityId)
				.should('have.text', this.i18n.buy.activityContent);
				
		cy.get('#pnActivityEntry-' + activityId)
			.find('#txtLeftContent-' + activityId)
				.should('have.text', 'Id: ' + transactionId);
				
		cy.get('#pnActivityEntry-' + activityId)
			.find('#txtRightContent-' + activityId)
				.should('have.text', createdAt);

		cy.get('#coinWallet')
			.should('have.text', coins);

		cy.get('#pnActivityEntry-' + activityId)
			.find('#lblIcon-' + activityId)
				.should('have.text', '+ ' + coins);
	});

	it.skip('Purchase 15 coins at 3.75 BRL', function(){
		cy.memberSignIn();
		cy.wait(Cypress.env('millis') / 2);
		cy.url().should('include', this.i18n.url.tenant);
		
		cy.get('div[role=tablist]').find('a').eq(1).click();
		cy.wait(Cypress.env('millis') / 2);
		cy.url().should('include', this.i18n.url.financial);
		
		cy.get('#btnFirstPackage').should('be.visible').click();
		cy.wait(Cypress.env('millis') / 2);
		cy.url().should('include', this.i18n.url.checkout);
	});

	it.skip('Transaction data review', function(){		
		cy.memberSignIn();
		cy.wait(Cypress.env('millis') / 2);
		cy.url().should('include', this.i18n.url.tenant);
		
		cy.get('div[role=tablist]').find('a').eq(1).click();
		cy.wait(Cypress.env('millis') / 2);
		cy.url().should('include', this.i18n.url.checkout);
		
		cy.get('#txtTitle').should('have.text', this.i18n.checkout.title);
		cy.get('#txtContent').should('have.text', this.i18n.checkout.content);
		cy.get('#hdCheckout').should('have.text', this.i18n.headline.checkout);
		cy.get('#r7-primary').click();
		cy.wait(Cypress.env('millis') / 2);
		
		cy.get('#pnCheckoutDetails').should('be.visible');			
		cy.get('#lblInfo').should('have.text', this.i18n.checkout.info);
		cy.get('#lblProduct').should('have.text', this.i18n.checkout.product);
		cy.get('#lblTax').should('have.text', this.i18n.checkout.tax);
		cy.get('#lblRefresh').should('have.text', this.i18n.checkout.refresh);
		
		cy.get('#lblTracking').should('have.text', this.i18n.checkout.track + transactionId + ';');
		cy.get('#lblExpiration').should('have.text', this.i18n.checkout.exp + expiresAt + ';');
	});

	it.skip('Cancel transaction successfully', function(){		
		cy.memberSignIn();
		cy.wait(Cypress.env('millis') / 2);
		cy.url().should('include', this.i18n.url.tenant);
		
		cy.get('div[role=tablist]').find('a').eq(1).click();
		cy.wait(Cypress.env('millis') / 2);
		cy.url().should('include', this.i18n.url.checkout);
		
		cy.get('#r7-primary').click();
		cy.wait(Cypress.env('millis') / 2);
		
		cy.get('#btnCancelTransaction').should('be.visible').click();
		cy.wait(Cypress.env('millis') / 2);
		
		cy.get('#txtTitle').should('have.text', this.i18n.headline.successPurchase);
		cy.get('#txtContent').should('have.text', this.i18n.buy.removalContent);
		
		cy.wait(Cypress.env('millis') / 2);
		cy.url().should('include', this.i18n.url.checkout);
	});

	it.skip('Pay transaction successfully', function(){		
		cy.memberSignIn();
		cy.wait(Cypress.env('millis') / 2);
		cy.url().should('include', this.i18n.url.tenant);
		
		cy.get('div[role=tablist]').find('a').eq(1).click();
		cy.wait(Cypress.env('millis') / 2);
		cy.url().should('include', this.i18n.url.checkout);
		
		cy.get('#r7-primary').click();
		cy.wait(Cypress.env('millis') * 25);
		
		cy.url().should('include', this.i18n.url.successCheckout);
		cy.get('#hdSuccessCheckout').should('have.text', this.i18n.checkout.success);
	});
});