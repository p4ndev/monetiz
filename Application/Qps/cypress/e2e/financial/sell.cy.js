describe('Sell', () => {
	const coins 			= 2;
	const withdrawId 		= 1;
	const amount 			= '0.20';

	const activityId 		= Cypress.env('withdrawActivityId');
	const transactionId 	= Cypress.env('withdrawComposeId');
	const createdAt 		= Cypress.env('withdrawCreatedAt');

	beforeEach(function(){
		cy.fixture(Cypress.env('language')).then((i18n) => { this.i18n = i18n; });
		cy.viewport(Cypress.env('device'), Cypress.env('orientation'));		
		cy.visit('/');
		
		cy.get('#gaConsent').find('#r3-danger').click();
		cy.wait(Cypress.env('millis') / 5);
		
		cy.get('#splash').find('#r0-primary').click();
		cy.wait(Cypress.env('millis') / 5);
		
		cy.memberSignIn();
		cy.wait(Cypress.env('millis') / 2);
	});

	it.skip('Available since member balance and pix', function(){
		cy.url().should('include', this.i18n.url.tenant);
		
		cy.get('div[role=tablist]').find('a').eq(1).click();
		cy.url().should('include', this.i18n.url.shoppingCart);
		cy.wait(Cypress.env('millis') / 5);
		
		cy.get('#pnPixForm').should('not.exist');
		cy.get('#pnWithdraw').should('be.visible');
		cy.get('#btnWithdraw-' + withdrawId).should('be.visible');
		cy.get('#lblWithdrawAmount-' + withdrawId).should('be.visible');
		
		cy.get('#hdWithdraw')
			.should('have.text', this.i18n.headline.withdraw);
		
		cy.get('#lblWithdrawAmount-' + withdrawId)
			.should('have.text', coins + this.i18n.general.coins);
		
		cy.get('#btnWithdraw-' + withdrawId)
			.should('have.text', this.i18n.general.currencySymbol + ' ' + amount);
	});

	it.skip('Complete withdraw registration', function(){
		cy.url().should('include', this.i18n.url.tenant);
		cy.wait(Cypress.env('millis') / 5);
		
		cy.get('div[role=tablist]').find('a').eq(1).click();
		cy.url().should('include', this.i18n.url.shoppingCart);
		cy.wait(Cypress.env('millis') / 5);
		
		cy.get('#btnWithdraw-' + withdrawId).click();
		
		cy.get('#pnModal').find('#txtTitle')
			.should('have.text', this.i18n.headline.startedWithdraw);

		cy.get('#pnModal').find('#txtContent')
			.should('have.text', this.i18n.withdraw.successContent);
	});

	it.skip('Data review after complete execution', function(){
		cy.url().should('include', this.i18n.url.tenant);
		
		cy.get('div[role=tablist]').find('a').eq(2).click();
		cy.wait(Cypress.env('millis') * 3);

		cy.get('#pnActivityEntry-' + activityId)
			.should('be.visible');
		
		cy.get('#pnActivityEntry-' + activityId)
			.find('#txtTitle-' + activityId)
				.should('have.text', this.i18n.headline.activityWithdraw);
				
		cy.get('#pnActivityEntry-' + activityId)
			.find('#txtContent-' + activityId)
				.should('have.text', this.i18n.withdraw.activitySuccess);
				
		cy.get('#pnActivityEntry-' + activityId)
			.find('#txtLeftContent-' + activityId)
				.should('have.text', 'Id: ' + transactionId);
				
		cy.get('#pnActivityEntry-' + activityId)
			.find('#txtRightContent-' + activityId)
				.should('have.text', createdAt);

		cy.get('#coinWallet')
			.should('have.text', '0');

		cy.get('#pnActivityEntry-' + activityId)
			.find('#lblIcon-' + activityId)
				.should('have.text', '- ' + coins);
	});
});