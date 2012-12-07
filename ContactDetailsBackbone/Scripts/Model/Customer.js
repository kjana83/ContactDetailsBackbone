/// <reference path="../backbone.js" />
/// <reference path="../underscore-min.js" />
/// <reference path="../jquery-1.7.1-vsdoc.js" />

var Customer = Backbone.Model.extend({
	idAttribute:"Id",
	url: 'api/Contacts/'
});