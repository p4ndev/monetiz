describe('Pix', () => {
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

	it('Available since balance', function(){
		cy.url().should('include', this.i18n.url.tenant);
		cy.wait(Cypress.env('millis'));

		cy.get('div[role=tablist]').find('a').eq(1).click({ force: true });
		cy.wait(Cypress.env('millis'));

		cy.url().should('include', this.i18n.url.shoppingCart);
		cy.get('#pnPixForm').should('be.visible');
	});

	it('Pix key', function(){
		cy.url().should('include', this.i18n.url.tenant);
		cy.get('div[role=tablist]').find('a').eq(1).click();
		
		cy.wait(Cypress.env('millis') / 5);
		cy.url().should('include', this.i18n.url.shoppingCart);
		
		cy.wait(Cypress.env('millis') / 5);
		cy.get('#txtPixKey').type(this.i18n.pix.fakeCpf);
		cy.get('#lblPixType').should("have.text", this.i18n.pix.titleCpf);
		
		cy.get('#txtPixKey').clear();
		cy.wait(Cypress.env('millis') / 5);
		cy.get('#txtPixKey').type(this.i18n.pix.fakeCnpj);
		cy.get('#lblPixType').should("have.text", this.i18n.pix.titleCnpj);
		
		cy.get('#txtPixKey').clear();
		cy.wait(Cypress.env('millis') / 5);
		cy.get('#txtPixKey').type(this.i18n.pix.fakeEmail);
		cy.get('#lblPixType').should("have.text", this.i18n.pix.titleEmail);
		
		cy.get('#txtPixKey').clear();
		cy.wait(Cypress.env('millis') / 5);
		cy.get('#txtPixKey').type(this.i18n.pix.fakeCelular);
		cy.get('#lblPixType').should("have.text", this.i18n.pix.titleCelular);

		cy.get('#txtPixKey').clear();
		cy.wait(Cypress.env('millis') / 5);
		cy.get('#txtPixKey').type(this.i18n.pix.fakeRandom);
		cy.get('#lblPixType').should("have.text", this.i18n.pix.titleRandom);
	});

	it.skip('Key registration (email)', function(){
		cy.url().should('include', this.i18n.url.tenant);
		cy.get('div[role=tablist]').find('a').eq(1).click();
		
		cy.wait(Cypress.env('millis') / 5);
		cy.url().should('include', this.i18n.url.shoppingCart);
		
		cy.wait(Cypress.env('millis') / 5);
		cy.get('#txtPixKey').type(this.i18n.pix.fakeCpf);
		cy.get('#lblPixType').should("have.text", this.i18n.pix.titleCpf);
		cy.get('#btnRegisterPixKey').click();
		
		cy.url().should('include', this.i18n.url.tenant);
		cy.wait(Cypress.env('millis') / 5);
		
		cy.get('div[role=tablist]').find('a').eq(1).click();
		cy.wait(Cypress.env('millis') / 5);
		cy.url().should('include', this.i18n.url.buy);
		
		cy.get('#pnPixForm').should('not.exist');
	});

	it.skip('Data review after complete execution', function(){
		cy.url().should('include', this.i18n.url.tenant);
		cy.get('div[role=tablist]').find('a').eq(2).click();		
		cy.url().should('include', this.i18n.url.activity);

		cy.get('#txtTitle-23').should('have.text', this.i18n.headline.activityPix);
		cy.get('#txtLeftContent-23').should('have.text', this.i18n.pix.activityLeft);
		cy.get('#txtContent-23').should('have.text', this.i18n.pix.activityContent);
	});
});