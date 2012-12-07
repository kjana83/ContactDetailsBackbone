/// <reference path="../backbone.js" />
/// <reference path="../underscore-min.js" />
/// <reference path="../jquery-1.7.1-vsdoc.js" />
var custCollection = new CustomerCollection();
custCollection.fetch();
custCollection.bind("reset", function () {
	$("#custList").empty();
	custCollection.forEach(function (cs) {
		var custView = new CustomerView({
			model: cs
		});
		$("#custList").append(custView.render().el);
	});
});
$("#custView").append(new AddCustomerView().render().el)