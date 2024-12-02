describe('Availability', () => {
	beforeEach(function () {
		cy.viewport(Cypress.env('device'), Cypress.env('orientation'));
		cy.visit('/');

		cy.get('#gaConsent').find('#r3-danger').click();
		
		cy.wait(Cypress.env('millis') / 6);

		cy.get('#splash').find('#r2-secondary').click();
	});

	it('Headline', function () {
		cy.get('#howToPlay').find('#headline').should('be.visible');		
	});

	it('Home link', function () {
		cy.get('#howToPlay').find('#btnHome').should('be.visible');
	});

	it('Questions', function () {
		cy.get('#howToPlay').find('#flQAs').should('be.visible');
	});
});