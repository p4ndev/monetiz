Cypress.Commands.add('memberSignIn', () => {
    cy.get('#frSignIn').should('be.visible');
	cy.get('#txtEmail').type(Cypress.env('userEmail').toString());
	cy.get('#txtPassword').type('0TdQBTriTof5s');
	cy.get('#r5-secondary').click();	
	cy.wait(Cypress.env('millis'));
});

Cypress.Commands.add('guestSignIn', () => {
    cy.get('#frSignIn').should('be.visible');
	cy.get('#txtEmail').type(Cypress.env('userGuestEmail').toString());
	cy.get('#txtPassword').type('b5kAXSCbQYTLS');
	cy.get('#r5-secondary').click();	
	cy.wait(Cypress.env('millis'));
});