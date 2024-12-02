describe('Action', () => {
	const positieActivityId = Cypress.env('positieActivityId');
	const negativeActivityId = Cypress.env('negativeActivityId');

	beforeEach(function (){
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
		
	it('Content review', function (){
		cy.get(this.i18n.html.esports).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get(this.i18n.html.cbLol).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get('#btnGame5').click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.url().should('include', this.i18n.url.booleanAction);
		cy.get('#lblGame').should('have.text', this.i18n.game.cbLol);
		cy.get('#hdBooleanAction').should('have.text', this.i18n.player.pain + ' x ' + this.i18n.player.furia);
	});

	it('Voice feature review', function (){
		cy.get(this.i18n.html.esports).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get(this.i18n.html.cbLol).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get('#btnGame5').click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get('#btnVoice').should('be.visible');

		cy.log('On');
		cy.get('#btnVoice').find('div').eq(0).should('have.css', 'color', 'rgb(70, 191, 255)');
		
		cy.log('Off');
		cy.get('#btnVoice').click();
		cy.get('#btnVoice').find('div').eq(0).should('have.css', 'color', 'rgba(255, 255, 255, 0.5)');
	});

	it('Button labels availability no balance', function (){
		cy.get(this.i18n.html.esports).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get(this.i18n.html.cbLol).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get('#btnGame5').click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get('#btnMenu').should('be.visible');
		cy.get('#btnOther').should('be.visible');
		
		cy.get('#btnMenu')
			.find('#lblButtonMenu')
				.should('be.visible')
				.should('have.text', this.i18n.general.menu);
				
		cy.get('#btnOther')
			.find('#lblButtonOther')
				.should('be.visible')
				.should('have.text', this.i18n.general.other);
					
		cy.wait(Cypress.env('millis') * 11);
		
		cy.get('#btnMenu')
			.find('#lblButtonMenu')
				.should('not.exist');
				
		cy.get('#btnOther')
			.find('#lblButtonOther')
				.should('not.exist');
	});

	it('Other navigation', function (){
		cy.get(this.i18n.html.esports).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get(this.i18n.html.cbLol).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get('#btnGame5').click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.wait(Cypress.env('millis'));
		
		cy.get('#btnOther').click();			
		cy.url().should('include', this.i18n.url.booleanAction);
	});

	it('Menu navigation', function (){
		cy.get(this.i18n.html.esports).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get(this.i18n.html.cbLol).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get('#btnGame5').click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.wait(Cypress.env('millis'));
		
		cy.get('#btnMenu').click();
		cy.url().should('include', this.i18n.url.tenant);
	});

	it('Boolean options with balance', function (){
		cy.get(this.i18n.html.esports).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get(this.i18n.html.cbLol).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get('#btnGame5').click({force: true});
		cy.wait(Cypress.env('millis'));
		
		cy.wait(Cypress.env('millis') / 5);
		cy.url().should('include', this.i18n.url.booleanAction);
	});

	it.skip('Button labels availability with balance', function (){
		cy.get(this.i18n.html.esports).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get(this.i18n.html.cbLol).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get('#btnGame5').click({force: true});
		cy.wait(Cypress.env('millis'));
			
		cy.get('#btnNo').should('be.visible');
		cy.get('#btnYes').should('be.visible');
		
		cy.get('#lblButtonNo')
			.should('have.text', this.i18n.general.no);
		
		cy.get('#lblButtonYes')
			.should('have.text', this.i18n.general.yes);
		
		cy.wait(Cypress.env('millis') * 11);
		
		cy.get('#lblButtonNo')
			.should('not.exist');
		
		cy.get('#lblButtonYes')
			.should('not.exist');
	});

	it.skip('Answer navigations', function (){
		cy.get(this.i18n.html.esports).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get(this.i18n.html.cbLol).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get('#btnGame5').click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get('#btnNo').click();
		cy.url().should('include', this.i18n.url.booleanAction);
		
		cy.wait(Cypress.env('millis'));
		cy.get('#btnYes').click();
		cy.url().should('include', this.i18n.url.booleanAction);
	});

	// FIXME: Need to implement
	it.skip('Data review', function() {
		cy.get('div[role=tablist]').find('a').eq(2).click();

		// Negative Answer Activity
		cy.get('#lblIcon-' + negativeActivityId).should('have.text', '- 1');
		cy.get('#txtRightContent-' + negativeActivityId).should('have.text', this.i18n.activity.createdAt);
		cy.get('#txtLeftContent-' + negativeActivityId).should('have.text', this.i18n.activity.activiteNegative);
		cy.get('#txtTitle-' + negativeActivityId).should('have.text', this.i18n.activity.activityBattle);

		// Positive Answer Activity
		cy.get('#lblIcon-' + positieActivityId).should('have.text', '- 1');
		cy.get('#txtRightContent-' + positieActivityId).should('have.text', this.i18n.activity.createdAt);
		cy.get('#txtLeftContent-' + positieActivityId).should('have.text', this.i18n.activity.activitePositive);
		cy.get('#txtTitle-' + positieActivityId).should('have.text', this.i18n.activity.activityBattle);
	});

});