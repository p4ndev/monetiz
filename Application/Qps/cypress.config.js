const { defineConfig } = require("cypress");

module.exports = defineConfig({
	env: {
		// ========================== Dynamic Fields ==================================		
		userGuestId				: 3,
		userGuestFullName		: 'Guest',
		userGuestEmail			: 'guest@monetiz.fun',
		
		userId					: 4,
		userFullName			: 'Member',
		userEmail				: 'member@monetiz.fun',
		
		activationStamp			: '68cfe111-ac55-4894-93a1-c9e9222f1fe0',
		passwordStamp			: '342eb609-cbce-47ec-ab9e-9d74cf7fc086',

		token					: '',
		
		purchaseComposeId 		: '0.00000000000',
		purchaseExpiration 		: '00/00 às 00:00',
		purchaseCreatedAt		: '00/00/0000',

		withdrawComposeId 		: '0.0',
		withdrawCreatedAt		: '00/00/0000',
		
		activationActivityId 	: 1,
		puchaseActivityId		: 0,
		withdrawActivityId		: 0,
		positieActivityId		: 0,
		negativeActivityId		: 0,

		// ========================== Static Fields ==================================
		app						: '',
		api						: '',
		
		millis					: 1500,		
		language				: 'pt-br',
		orientation				: 'portrait',
		device					: 'iphone-se2',		
		
		userPassword			: '0TdQBTriTof5s',
		userRevPassword			: '321321',
		
		wrongPasswordStamp		: '5d3dd787-23ed-9940-a9f2-23a3350647ab',
		wrongActivationStamp	: 'f7033979-485c-452e-d894-f42c7b8d5920',
	},
	e2e: {
		baseUrl					: 'http://localhost:8081',
		setupNodeEvents(on, config) {			
			if (config.env.environment === 'Production'){
				config.baseUrl = 'https://monetiz.fun';
				config.env.app = 'https://monetiz.fun';
				config.env.api = 'https://api.monetiz.fun';
			} else {
				config.baseUrl = 'http://localhost:8081';
				config.env.app = 'http://localhost:8081';
				config.env.api = 'http://localhost:5171';
			}
			
			return config;			
		}
	}
});



