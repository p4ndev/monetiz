describe('Category', () => {
	beforeEach(function(){
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

	it('E-Sports > Headline and Navigation', function(){
		cy.get('#btnTenant1').click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.url().should('include', this.i18n.url.category);
		
		cy.get(this.i18n.html.cbLol).should('be.visible');	
		cy.get(this.i18n.html.valorant).should('be.visible');
		
		cy.get('#hdCategory').find('#headline').should('have.text', this.i18n.headline.category);
	});

	it('Soccer > Headline and Navigation', function(){
		cy.get('#btnTenant2').click({force: true});
		cy.wait(Cypress.env('millis'));
		
		cy.url().should('include', this.i18n.url.category);	
		cy.get(this.i18n.html.brasileirao).should('be.visible');		
		
		cy.get('#hdCategory').find('#headline').should('have.text', this.i18n.headline.category);
	});

	it('Reality Show > Headline and Navigation', function(){
		cy.get('#btnTenant3').click({force: true});
		cy.wait(Cypress.env('millis'));
		
		cy.url().should('include', this.i18n.url.category);	
		cy.get(this.i18n.html.aFazenda).should('be.visible');	
		cy.get(this.i18n.html.aGrandeConquista).should('be.visible');			
		
		cy.get('#hdCategory').find('#headline').should('have.text', this.i18n.headline.category);
	});

});