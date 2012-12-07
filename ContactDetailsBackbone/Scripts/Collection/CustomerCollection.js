/// <reference path="../backbone.js" />
/// <reference path="../underscore-min.js" />
/// <reference path="../jquery-1.7.1-vsdoc.js" />

var CustomerCollection = Backbone.Collection.extend({
	url:'api/Contacts',
	model:Customer
});