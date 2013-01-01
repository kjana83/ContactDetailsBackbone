/* File Created: December 14, 2012 */
/// <reference path="../jasmine-1.2.0/jasmine.js" />
define(['jquery', 'backbone', 'underscore', 'Customer'],
function ($, Backbone, _, Customer) {
	describe("Customer Model",
		function () {
			it("Model should be created",
			function () {
				var customer = new Customer();
				expect(typeof (customer)).toBe("object");
				expect(typeof (customer)).not.toBe(null);
			});

			it("Able to assign and retrieve values from model",
			function () {
				var customer = new Customer({ Title: 'Mr', FirstName: 'Jana' });
				var title = customer.get('Title');
				var firstName = customer.get('FirstName');
				expect(title).toEqual("Mr");
				expect(firstName).toEqual("Jana");
			});
		});
});