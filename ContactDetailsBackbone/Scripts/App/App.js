/// <reference path="../backbone.js" />
/// <reference path="../underscore-min.js" />
/// <reference path="../jquery-1.7.1-vsdoc.js" />
define(['jquery', 'backbone', 'underscore', 'AddCustomerView', 'Customer', 'CustomerCollection', 'CustomerView'],
function ($, Backbone, _, AddCustomerView, Customer, CustomerCollection, CustomerView	) {

	var init = $(function () {
		CustomerCollection.fetch();
		CustomerCollection.bind("reset", function () {
			$("#custList").empty();
			CustomerCollection.forEach(function (cs) {
				var custView = new CustomerView({
					model: cs
				});
				$("#custList").append(custView.render().el);
			});
		});
		$("#custView").append(new AddCustomerView().render().el);
	});
	return init;
});