/// <reference path="../backbone.js" />
/// <reference path="../underscore-min.js" />
/// <reference path="../jquery-1.7.1-vsdoc.js" />
/// <reference path="../require-jquery.js" />
define(['jquery', 'backbone', 'underscore', 'Customer', 'InputTemplate', 'CustomerCollection', 'App'],
function ($, Backbone, _, Customer, InputTemplate, CustomerCollection, App) {	
	var AddCustomerView = Backbone.View.extend({
		model: Customer,
		events: {
			'keypress #Title,#FirstName,#LastName': 'addCustomer'
		},
		addCustomer: function (e) {
			if (e.which === 13) {
				var Title = $("#Title");
				var FirstName = $("#FirstName");
				var LastName = $("#LastName");

				if (!Title.val().trim()) {
					alert('Please enter Title ');
					return;
				}

				if (!FirstName.val().trim()) {
					alert('Please enter FirstName ');
					return;
				}
				if (!LastName.val().trim()) {
					alert('Please enter LastName ');
					return;
				}

				var cust = new Customer({
					Title: Title.val().trim(),
					FirstName: FirstName.val().trim(),
					LastName: LastName.val().trim()
				});

				cust.save('', '', { success: function () {
					CustomerCollection().fetch()
				}
				});

				Title.val('');
				FirstName.val('');
				LastName.val('');

				Title.focus();
			}
		},

		render: function () {
			this.$el.html(_.template(inputTemplate));
			return this;
		}
	});

	return AddCustomerView;
});