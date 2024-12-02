const activationActivityId = Cypress.env('activationActivityId');
const { faker } = require('@faker-js/faker');

describe('Sign Up', () => {
	beforeEach(function() {
		cy.fixture(Cypress.env('language')).then((i18n) => { this.i18n = i18n; });
		cy.viewport(Cypress.env('device'), Cypress.env('orientation'));
		
		cy.visit('/');
		
		cy.get('#gaConsent').find('#r3-danger').click();
		cy.wait(Cypress.env('millis') / 6);
		
		cy.get('#splash').find('#r1-primary').click();
	});
	
	it('Invalid email field', function() {
		cy.get('#frSignUp').should('be.visible');
		cy.get('#txtEmail').type('regular');
		cy.get('#r5-secondary').click();
	
		cy.get('#pnModal').find('#txtTitle').should('have.text', this.i18n.general.error);
		cy.get('#pnModal').find('#txtContent').should('have.text', this.i18n.error.email);
	});
	
	it('Invalid password field', function() {
		cy.get('#frSignUp').should('be.visible');
		cy.get('#txtFullName').type(faker.person.fullName());
		cy.get('#txtEmail').type(faker.internet.email().toLowerCase());
		cy.get('#txtPassword').type('123');
		cy.get('#r5-secondary').click();
	
		cy.get('#pnModal').find('#txtTitle').should('have.text', this.i18n.general.error);
		cy.get('#pnModal').find('#txtContent').should('have.text', this.i18n.error.pass);
	});
	
	it('Invalid passwords combination', function() {
		cy.get('#frSignUp').should('be.visible');
		cy.get('#txtFullName').type(faker.person.fullName());
		cy.get('#txtEmail').type(faker.internet.email().toLowerCase());
		cy.get('#txtPassword').type('123AbC');
		cy.get('#txtConfirmationPassword').type('AbC123');
		cy.get('#r5-secondary').click();
	
		cy.get('#pnModal').find('#txtTitle').should('have.text', this.i18n.general.error);
		cy.get('#pnModal').find('#txtContent').should('have.text', this.i18n.error.confirmationPass);
	});
	
	it('Conflicted account', function() {
		cy.get('#frSignUp').should('be.visible');
		cy.get('#txtFullName').type(Cypress.env('userFullName').toString());
		cy.get('#txtEmail').type(Cypress.env('userEmail').toString());
		cy.get('#txtPassword').type(Cypress.env('userPassword').toString());
		cy.get('#txtConfirmationPassword').type(Cypress.env('userPassword').toString());
		cy.get('#r5-secondary').click();
	
		cy.get('#pnModal').should('be.visible');
		cy.get('#pnModal').find('#txtTitle').should('be.visible');
		cy.get('#pnModal').find('#txtContent').should('be.visible');
	
		cy.get('#pnModal').find('#txtTitle').should('have.text', this.i18n.general.error);
		cy.get('#pnModal').find('#txtContent').should('have.text', this.i18n.error.conflicted);
	});
	
	it('New guest registered', function() {
		cy.get('#hdSignUp').should('have.text', this.i18n.headline.signUp);
		
		const email = faker.internet.email().toLowerCase();
		
		cy.get('#frSignUp').should('be.visible');
		cy.get('#txtFullName').type(faker.person.fullName());
		cy.get('#txtEmail').type(email);
		cy.get('#txtPassword').type(Cypress.env('userPassword').toString());
		cy.get('#txtConfirmationPassword').type(Cypress.env('userPassword').toString());
		cy.get('#r5-secondary').click();
	
		cy.log('Registered with ' + email);
	
		cy.wait(Cypress.env('millis') * 3);
		cy.url().should('include', this.i18n.url.signIn);
	});
	
	it.skip('Data review', function() {	
		cy.visit('/');
		cy.wait(Cypress.env('millis') / 3);
		
		cy.get('#splash').find('#r0-primary').click();
		cy.wait(Cypress.env('millis') / 3);
	
		cy.memberSignIn();
		cy.wait(Cypress.env('millis') / 3);
		
		cy.get('div[role=tablist]').find('a').eq(2).click();
		cy.wait(Cypress.env('millis') / 6);
	
		cy.get('#txtTitle-' + activationActivityId).should('have.text', this.i18n.activity.userActivationTitle);
		cy.get('#txtContent-' + activationActivityId).should('have.text', this.i18n.activity.userActivationContent);
	});	
});