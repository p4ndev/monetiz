describe('Category', () => {
	let gid = 0;
	let homeId = 0;
	let guestId = 0;

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

	it('E-Sports > CbLoL > paiN x FURIA', function (){
		cy.get(this.i18n.html.esports).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get(this.i18n.html.cbLol).click({force: true});
		cy.wait(Cypress.env('millis'));
		
		cy.url().should('include', this.i18n.url.game);
		
		this.gid = 5;
		this.homeId = 7; // paiN
		this.guestId = 8; // FURIA
		
		cy.get('#btnGame'+this.gid).should('be.visible');
		cy.get('#home'+this.gid+'-'+this.homeId).should('be.visible');
		cy.get('#match'+this.gid).should('be.visible');
		cy.get('#guest'+this.gid+'-'+this.guestId).should('be.visible');
		
		cy.get('#home'+this.gid+'-'+this.homeId).should('have.text', this.i18n.player.pain);
		cy.get('#match'+this.gid).should('have.text', this.i18n.game.cbLol);
		cy.get('#guest'+this.gid+'-'+this.guestId).should('have.text', this.i18n.player.furia);
					
		cy.get('#hdGame').find('#headline').should('have.text', this.i18n.headline.game);
	});

	it('E-Sports > Valorant > LOUD x Sentinels', function (){		
		cy.get(this.i18n.html.esports).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get(this.i18n.html.valorant).click({force: true});
		cy.wait(Cypress.env('millis'));
		
		cy.url().should('include', this.i18n.url.game);
		
		this.gid = 6;
		this.homeId = 9; // LOUD
		this.guestId = 10; // Sentinels
					
		cy.get('#btnGame'+this.gid).should('be.visible');
		cy.get('#home'+this.gid+'-'+this.homeId).should('be.visible');
		cy.get('#match'+this.gid).should('be.visible');
		cy.get('#guest'+this.gid+'-'+this.guestId).should('be.visible');
		
		cy.get('#home'+this.gid+'-'+this.homeId).should('have.text', this.i18n.player.loud);
		cy.get('#match'+this.gid).should('have.text', this.i18n.game.valorant);
		cy.get('#guest'+this.gid+'-'+this.guestId).should('have.text', this.i18n.player.sentinels);
					
		cy.get('#hdGame').find('#headline').should('have.text', this.i18n.headline.game);	
	});

	it('Soccer > Brasileirão > Palmeiras x Cuiabá', function (){	
		cy.get(this.i18n.html.soccer).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get(this.i18n.html.brasileirao).click({force: true});
		cy.wait(Cypress.env('millis'));
		
		cy.url().should('include', this.i18n.url.game);
		
		this.gid = 1;
		this.homeId = 1; // Palmeiras
		this.guestId = 2; // Cuiaba
					
		cy.get('#btnGame'+this.gid).should('be.visible');
		cy.get('#home'+this.gid+'-'+this.homeId).should('be.visible');
		cy.get('#match'+this.gid).should('be.visible');
		cy.get('#guest'+this.gid+'-'+this.guestId).should('be.visible');
		
		cy.get('#home'+this.gid+'-'+this.homeId).should('have.text', this.i18n.player.sep);
		cy.get('#match'+this.gid).should('have.text', this.i18n.game.brasileirao);
		cy.get('#guest'+this.gid+'-'+this.guestId).should('have.text', this.i18n.player.cuiaba);
		
		cy.get('#hdGame').find('#headline').should('have.text', this.i18n.headline.game);
	});

	it('Soccer > Brasileirão > Atlético Mineiro x Corinthians', function (){	
		cy.get(this.i18n.html.soccer).click({force: true});
		cy.wait(Cypress.env('millis'));

		cy.get(this.i18n.html.brasileirao).click({force: true});
		cy.wait(Cypress.env('millis'));
		
		cy.url().should('include', this.i18n.url.game);
			
		this.gid = 2;
		this.homeId = 3; // Atletico Mineiro
		this.guestId = 4; // Timão
					
		cy.get('#btnGame'+this.gid).should('be.visible');
		cy.get('#home'+this.gid+'-'+this.homeId).should('be.visible');
		cy.get('#match'+this.gid).should('be.visible');
		cy.get('#guest'+this.gid+'-'+this.guestId).should('be.visible');
		
		cy.get('#home'+this.gid+'-'+this.homeId).should('have.text', this.i18n.player.atleticoMg);
		cy.get('#match'+this.gid).should('have.text', this.i18n.game.brasileirao);
		cy.get('#guest'+this.gid+'-'+this.guestId).should('have.text', this.i18n.player.timao);
				
		cy.get('#hdGame').find('#headline').should('have.text', this.i18n.headline.game);	
	});

});