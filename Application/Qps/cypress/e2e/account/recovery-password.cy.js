describe('Recovery Password', () => {
	beforeEach(function(){
		cy.fixture(Cypress.env('language')).then((i18n) => { this.i18n = i18n; });
	});
	
	it('Recovery headline', function (){
		cy.viewport(Cypress.env('device'), Cypress.env('orientation'));
		cy.visit('/');
	
		cy.get('#gaConsent').find('#r3-danger').click({ force: true });
		cy.wait(Cypress.env('millis') / 6);
	
		cy.get('#splash').find('#r1-primary').click({ force: true });
		cy.wait(Cypress.env('millis') / 6);
	
		cy.get('div[role=tablist]').find('a').eq(2).click({ force: true });
	
		cy.get('#hdRecovery').should('have.text', this.i18n.headline.recovery);
		cy.get('#frRecovery').should('be.visible');
	});
	
	it('Successful recovery form', function (){
		cy.wait(Cypress.env('millis') / 5);
		cy.viewport(Cypress.env('device'), Cypress.env('orientation'));
		cy.visit('/');
	
		cy.get('#gaConsent').find('#r3-danger').click({ force: true });
		cy.wait(Cypress.env('millis') / 10);
	
		cy.get('#splash').find('#r1-primary').click({ force: true });
		cy.wait(Cypress.env('millis') / 10);
	
		cy.get('div[role=tablist]').find('a').eq(2).click({ force: true });
		cy.wait(Cypress.env('millis') / 3);
	
		const email = Cypress.env('userEmail').toString();
	
		cy.get('#frRecovery').should('be.visible');
		cy.get('#frRecovery').find('#txtEmail').should('be.visible').type(email);
		cy.get('#frRecovery').find('#r6-secondary').click({ force: true });
	
		cy.wait(Cypress.env('millis') * 2);
		cy.get('#pnModal').should('be.visible');
		cy.get('#pnModal').find('#txtTitle').should('have.text', this.i18n.account.recoveryTitle);
		cy.get('#pnModal').find('#txtContent').should('have.text', this.i18n.account.recoveryContent);
	});
	
	it.skip('Recovery successful XHR call', () => {
		const options = {
			failOnStatusCode  : false,
			method            : 'PATCH',
			url               : Cypress.env('api').toString() + '/account/recovery',
			body              : {
				id          : Number(Cypress.env('userId')),
				email       : Cypress.env('userEmail').toString(),
				password    : Cypress.env('userPassword').toString(),
				stamp       : Cypress.env('passwordStamp').toString()
			}
		};
	
		cy.request(options).its('status').should('eq', 200);
	});
	
	it.skip('Recovery failed XHR call', () => {
		const options = {
			failOnStatusCode  : false,
			method            : 'PATCH',
			url               : Cypress.env('api').toString() + '/account/recovery',
			body              : {
				id          : Number(Cypress.env('userId')),
				email       : Cypress.env('userEmail').toString(),
				password    : Cypress.env('userRevPassword').toString(),
				stamp       : Cypress.env('wrongPasswordStamp').toString()
			}
		};
	
		cy.request(options).its('status').should('eq', 304);
	});
});