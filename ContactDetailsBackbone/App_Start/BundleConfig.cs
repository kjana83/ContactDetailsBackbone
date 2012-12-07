using System.Web;
using System.Web.Optimization;

namespace ContactDetailsBackbone
{
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/backbone").Include(
						"~/Scripts/underscore-min.js",
						"~/Scripts/backbone.js"));

			bundles.Add(new ScriptBundle("~/bundles/model").Include(
						"~/Scripts/Model/Customer.js"));

			bundles.Add(new ScriptBundle("~/bundles/collection").Include(
						"~/Scripts/Collection/CustomerCollection.js"));

			bundles.Add(new ScriptBundle("~/bundles/templates").Include(
						"~/Scripts/Templates/CustTemplate.js",
						"~/Scripts/Templates/InputTemplate.js"));

			bundles.Add(new ScriptBundle("~/bundles/view").Include(
						"~/Scripts/View/AddCustomerView.js",
						"~/Scripts/View/CustomerView.js"));

			bundles.Add(new ScriptBundle("~/bundles/app").Include(
						"~/Scripts/App/App.js"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
						"~/Scripts/bootstrap.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
						"~/Content/bootstrap.css",
						"~/Content/bootstrap-responsive.css",
						"~/Content/Site.css"));
		}
	}
}