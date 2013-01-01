/* File Created: December 14, 2012 */
/// <reference path="../jasmine-1.2.0/jasmine.js" />

define(['jquery', 'backbone', 'underscore', 'Customer', 'CustomerCollection'],
function ($, Backbone, _, Customer, CustomerCollection) {
	describe("Customer Collection",
		function () {
			it("Collection should be created", function () {
				var customer = new Customer({ Title: "Mr", FirstName: "Janarthanan", LastName: "Kanagaraj" });
				CustomerCollection.add(customer);
				expect(CustomerCollection.length).toEqual(1);
			});
		});
});