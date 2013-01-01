/// <reference path="../backbone.js" />
/// <reference path="../underscore-min.js" />
/// <reference path="../jquery-1.7.1-vsdoc.js" />
/// <reference path="../require-jquery.js" />

define(['jquery', 'backbone', 'underscore', 'Customer'],
function ($, Backbone, _, Customer) {
	var CustomerCollection = Backbone.Collection.extend({
		url: 'api/Contacts',
		model: Customer
	});	
	return new CustomerCollection();
});