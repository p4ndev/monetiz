describe('Availability', () => {
    beforeEach(function () {
        cy.viewport(Cypress.env('device'), Cypress.env('orientation'));
        cy.visit('/');
    });
        
    it('Cookie policy consent', function() {
        cy.get('#gaConsent').find('#r3-danger').should('be.visible');
        cy.get('#gaConsent').find('#r4-success').should('be.visible');
    });

    it('Main navigation links', function (){
        cy.get('#splash').find('#r0-primary').should('be.visible');
        cy.get('#splash').find('#r1-primary').should('be.visible');
        cy.get('#splash').find('#r2-secondary').should('be.visible');
    });
});