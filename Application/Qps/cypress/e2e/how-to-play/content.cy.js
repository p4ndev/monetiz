describe('Content', () => {
	beforeEach(function () {
		cy.fixture(Cypress.env('language')).then((i18n) => { this.i18n = i18n; });
		cy.viewport(Cypress.env('device'), Cypress.env('orientation'));
		cy.visit('/');

		cy.get('#gaConsent').find('#r3-danger').click();
		
		cy.wait(Cypress.env('millis') / 6);

		cy.get('#splash').find('#r2-secondary').click();
	});

	it('Headline', function () {
		cy.get('#howToPlay').find('#headline').should('contain', this.i18n.headline.howToPlay);
	});

	it('Counter', function () {
		cy.get('#howToPlay').find('#flQAs > div > div').should('have.length', Number(this.i18n.general.howToPlayCounter));
	});
});