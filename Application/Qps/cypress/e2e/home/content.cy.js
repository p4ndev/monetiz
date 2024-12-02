describe('Content', () => {
	beforeEach(function() {
		cy.fixture(Cypress.env('language')).then((i18n) => { this.i18n = i18n; });
		cy.viewport(Cypress.env('device'), Cypress.env('orientation'));		
		cy.visit('/');
	});

	it('Cookie policy', function () {
		cy.get('#gaConsent').find('#r3-danger').should('contain', this.i18n.general.no);
		cy.get('#gaConsent').find('#r4-success').should('contain', this.i18n.general.yes);
	});
  
	it('Main navigation', function () {
		cy.get('#splash').find('#r0-primary').should('contain', this.i18n.operation.isPlayer);
		cy.get('#splash').find('#r1-primary').should('contain', this.i18n.operation.isAnonymous);
		cy.get('#splash').find('#r2-secondary').should('contain', this.i18n.operation.howToPlay);
	});
	
	it('Landscape restriction', function () {
		cy.viewport(Cypress.env('device'), 'landscape');		
		cy.visit('/');			
		cy.url().should('include', this.i18n.url.viewport);			
		cy.get('#hdViewportRestriction').should('have.text', this.i18n.error.viewportRestriction);
	});
});