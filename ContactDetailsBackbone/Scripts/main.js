/* File Created: December 14, 2012 */
requirejs.config({
	'paths': {
		"backbone": "backbone",
		"underscore": "underscore-min",
		"App":"App/App",
		"CustomerCollection":"Collection/CustomerCollection",
		"Customer":"Model/Customer",
		"CustomerView":"View/CustomerView",
		"AddCustomerView":"View/AddCustomerView",
		"CustTemplate":"Templates/CustTemplate",
		"InputTemplate":"Templates/InputTemplate",
		"bootstrap":"bootstrap"
	},
	'shim': {
		backbone: {
			'deps': ['jquery', 'underscore'],
			'exports': 'Backbone'
		},
		underscore: {
			'exports':'_'
		}
	}
});

require(['jquery','backbone','underscore', 'App','bootstrap'],
	function ($,Backbone,_,App, bootstrap) {
		App.init();
	});