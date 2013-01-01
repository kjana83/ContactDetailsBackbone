/* File Created: December 14, 2012 */
/// <reference path="../require-jquery.js" />
/// <reference path="../jasmine-1.2.0/jasmine.js" />

define(['jquery', 'backbone', 'underscore'],
function ($, Backbone, _) {

	describe("jQuery Library",
		function () {
			it("Should be loaded",
			function () {
				expect(typeof $).toBe("function");
			});
		});

	describe("Backbone Library",
		function () {
			it("Should be loaded",
			function () {
				expect(typeof Backbone).toBe("object");
			});
		});
	describe("Underscore Library",
		function () {
			it("Should be loaded",
			function () {
				expect(typeof _).toBe("function");
			});
		});
});