const { faker } = require('@faker-js/faker');

describe('Sign In', () => {
	beforeEach(function () {
		cy.fixture(Cypress.env('language')).then((i18n) => { this.i18n = i18n; });
		cy.viewport(Cypress.env('device'), Cypress.env('orientation'));
		
		cy.visit('/');
		
		cy.get('#gaConsent').find('#r3-danger').click();
		cy.wait(Cypress.env('millis') / 6);
		
		cy.get('#splash').find('#r0-primary').click();
	});
		
	it('Invalid email field', function () {
		cy.get('#frSignIn').should('be.visible');
		cy.get('#txtEmail').type('regular');
		cy.get('#r5-secondary').click();

		cy.get('#pnModal').find('#txtTitle').should('have.text', this.i18n.general.error);
		cy.get('#pnModal').find('#txtContent').should('have.text', this.i18n.error.email);
	});
	
	it('Invalid password field', function () {
		cy.get('#frSignIn').should('be.visible');
		cy.get('#txtEmail').type(faker.internet.email().toLowerCase());
		cy.get('#txtPassword').type('123');
		cy.get('#r5-secondary').click();

		cy.get('#pnModal').find('#txtTitle').should('have.text', this.i18n.general.error);
		cy.get('#pnModal').find('#txtContent').should('have.text', this.i18n.error.pass);
	});
	
	it('invalid user credentials', function () {
		cy.get('#frSignIn').should('be.visible');
		cy.get('#txtEmail').type(faker.internet.email().toLowerCase());
		cy.get('#txtPassword').type('321123');
		cy.get('#r5-secondary').click();

		cy.wait(Cypress.env('millis'));

		cy.get('#pnModal').should('be.visible');
		cy.get('#pnModal').find('#txtTitle').should('be.visible');
		cy.get('#pnModal').find('#txtContent').should('be.visible');

		cy.get('#pnModal').find('#txtTitle').should('have.text', this.i18n.general.error);
		cy.get('#pnModal').find('#txtContent').should('have.text', this.i18n.error.notFound);
	});
    
	it('Member log in', function () {
		cy.get('#hdSignIn').should('have.text', this.i18n.headline.signIn);
	
		cy.memberSignIn();
	
		cy.url().should('include', this.i18n.url.tenant);
	});
	
	it('Guest log in', function () {
		cy.get('#hdSignIn').should('have.text', this.i18n.headline.signIn);
	
		cy.guestSignIn();
	
		cy.url().should('include', this.i18n.url.tenant);
	});
});