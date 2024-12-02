describe('Tenant', () => {
	beforeEach(function() {
		cy.fixture(Cypress.env('language')).then((i18n) => { this.i18n = i18n; });
		cy.viewport(Cypress.env('device'), Cypress.env('orientation'));		
		cy.visit('/');
		
		cy.get('#gaConsent').find('#r3-danger').click();
		cy.wait(Cypress.env('millis') / 5);
		
		cy.get('#splash').find('#r0-primary').click();
		cy.wait(Cypress.env('millis') / 5);

		cy.memberSignIn();
		cy.wait(Cypress.env('millis'));
	});

	it('Headline and Navigation', function() {
		cy.url().should('include', this.i18n.url.tenant);
		cy.get(this.i18n.html.esports).should('have.text', this.i18n.name.esports);
		cy.get(this.i18n.html.soccer).should('have.text', this.i18n.name.soccer);
		cy.get(this.i18n.html.realityShow).should('have.text', this.i18n.name.realityShow);			
		cy.get('#hdTenant').find('#headline').should('have.text', this.i18n.headline.tenant);
	});

});