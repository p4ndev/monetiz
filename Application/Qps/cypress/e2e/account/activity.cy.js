describe('Activities', () => {
	beforeEach(function() {
		cy.fixture(Cypress.env('language')).then((i18n) => { this.i18n = i18n; });	
		cy.viewport(Cypress.env('device'), Cypress.env('orientation'));
		cy.visit('/');	
		
		cy.get('#gaConsent').find('#r3-danger').click();
		cy.wait(Cypress.env('millis') / 6);	
		
		cy.get('#splash').find('#r0-primary').click();
		cy.wait(Cypress.env('millis') / 6);

		cy.memberSignIn();
		cy.wait(Cypress.env('millis') / 6);
	});

	it('Headline and Form', function() {
		cy.get('div[role=tablist]').find('a').eq(2).click();

		cy.get('#hdProfile').should('have.text', Cypress.env('userFullName') + ',');			
		
		cy.url().should('include', this.i18n.url.activity);
	});
});