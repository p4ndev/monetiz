describe('Reset Password', () => {
	beforeEach(function(){
		cy.fixture(Cypress.env('language')).then((i18n) => { this.i18n = i18n; });
	});
	
	it('Reset headline', function (){
		cy.viewport(Cypress.env('device'), Cypress.env('orientation'));
		cy.visit('/?id='+Cypress.env('userId')+'&stamp='+Cypress.env('passwordStamp').toString()+'&op=recovery');
	
		cy.wait(Cypress.env('millis') / 6);
		cy.get('#gaConsent').find('#r3-danger').click({ force: true });
		
		cy.get('#hdReset').should('have.text', this.i18n.headline.reset);	
		cy.get('#frReset').should('be.visible');
	});
	
	it.skip('Successful reset form', function (){
		cy.viewport(Cypress.env('device'), Cypress.env('orientation'));
		cy.visit('/?id='+Cypress.env('userId')+'&stamp='+Cypress.env('passwordStamp').toString()+'&op=recovery');
		cy.wait(Cypress.env('millis'));
	
		cy.get('#gaConsent').find('#r3-danger').click({ force: true });
		cy.wait(Cypress.env('millis') / 10);
	
		const email = Cypress.env('userEmail').toString();
		const pwd = Cypress.env('userPassword').toString();
	
		cy.get('#frReset').should('be.visible');
		cy.get('#frReset').find('#txtEmail').type(email);
		cy.get('#frReset').find('#txtPassword').type(pwd);
		cy.get('#frReset').find('#r5-secondary').click({ force: true });
		
		cy.get('#pnModal').should('be.visible');
		cy.get('#pnModal').find('#txtTitle').should('have.text', this.i18n.general.done);
		cy.get('#pnModal').find('#txtContent').should('have.text', this.i18n.operation.updatePass);
	});
});