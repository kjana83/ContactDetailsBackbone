using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using ContactDetailsBackbone.Controllers;
using ContactDetailsBackbone.Models;
using NUnit.Framework;
using Simple.Data;

namespace ContactDetailsBackbone.UnitTests
{
	/// <summary>
	/// Contains unit test case for the Contact controller.
	/// </summary>
	[TestFixture]
	public class ContactsControllerUnitTest
	{
		#region Private instance variables

		private IEnumerable<Contact> CustomerList;

		private Contact contact;

		#endregion Private instance variables

		#region Unit Test Cases

		/// <summary>
		/// Initiate the database.
		/// </summary>
		[SetUp]
		public void DBInit()
		{
			var adapter = new InMemoryAdapter();
			adapter.SetKeyColumn("Contact", "Id");
			Database.UseMockAdapter(adapter);

			var db = Database.Open();
			db.Contact.Insert(Id: 1, FirstName: "Jana", LastName: "K", Title: "Mr", Status: "Active");
			db.Contact.Insert(Id: 2, FirstName: "Test", LastName: "User", Title: "Miss", Status: "Active");
		}

		/// <summary>
		/// Test case for Collecting all customers
		/// </summary>
		[TestCase]
		public void GetShouldProvideAllTheActiveUsers()
		{
			RequestAllTheCustomers();
			AllCustomerShouldBeReceivedFromDB();
		}

		/// <summary>
		/// Gets the users by ID.
		/// </summary>
		[TestCase]
		public void GetTheUsersByID()
		{
			RequestSingleUser();
			SingleUserShouldBeReturned();
		}

		/// <summary>
		/// Posts the new contact.
		/// </summary>
		[TestCase]
		public void PostNewContact()
		{
			AddNewContact();
			ContactShouldBeAdded();
		}

		[TestCase]
		public void UpdateContact()
		{
			UpdateTheExistingContact();
			ContactShouldBeUpdated();
		}

		#endregion Unit Test Cases

		#region Private Methods

		/// <summary>
		/// Contacts the should be added.
		/// </summary>
		private void ContactShouldBeAdded()
		{
			this.contact = null;
			this.contact = this.ContactController().Get(3);
			Assert.AreEqual("Kanagaraj", this.contact.LastName);
		}

		/// <summary>
		/// Adds the new contact.
		/// </summary>
		private void AddNewContact()
		{
			this.contact = new Contact { Id = 3, FirstName = "Jana", LastName = "Kanagaraj", Status = "Active" };
			this.ApiContactController(HttpMethod.Post).Post(this.contact);
		}

		/// <summary>
		/// Contacts the controller.
		/// </summary>
		/// <returns></returns>
		private ContactsController ContactController()
		{
			return new ContactsController();
		}

		/// <summary>
		/// Web Api controller  for the Contacts.
		/// </summary>
		/// <returns>
		/// Contact Controller instance
		/// </returns>
		private ContactsController ApiContactController(HttpMethod method)
		{
			var request = new HttpRequestMessage(method, "http://localhost/api/Contact");
			var config = new HttpConfiguration();
			config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/Contact", defaults: new { controller = "Contact" });
			var routeData = new HttpRouteData(config.Routes[0], new HttpRouteValueDictionary { { "Controller", "Contact" } });
			ContactsController contactController = new ContactsController();
			ApiController controller = contactController;
			controller.ControllerContext = new HttpControllerContext(config, routeData, request);
			controller.Request = request;
			controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
			controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
			return contactController;
		}

		/// <summary>
		/// Check if the customer received from database.
		/// </summary>
		private void AllCustomerShouldBeReceivedFromDB()
		{
			Assert.GreaterOrEqual(2, this.CustomerList.Count());
		}

		/// <summary>
		/// Requests all the customers.
		/// </summary>
		private void RequestAllTheCustomers()
		{
			this.CustomerList = this.ContactController().Get();
		}

		/// <summary>
		/// Singles the user should be returned.
		/// </summary>
		private void SingleUserShouldBeReturned()
		{
			Assert.AreEqual(1, this.contact.Id);
			Assert.AreEqual("Jana", this.contact.FirstName);
		}

		/// <summary>
		/// Requests the single user.
		/// </summary>
		private void RequestSingleUser()
		{
			this.contact = this.ContactController().Get(1);
		}

		/// <summary>
		/// Contacts the should be updated.
		/// </summary>
		private void ContactShouldBeUpdated()
		{
			Assert.AreEqual("UpdatedLastName", this.contact.LastName);
		}

		/// <summary>
		/// Updates the existing contact.
		/// </summary>
		private void UpdateTheExistingContact()
		{
			this.contact = this.ContactController().Get(1);
			this.contact.LastName = "UpdatedLastName";
			this.contact = this.ApiContactController(HttpMethod.Put).Put(this.contact);
		}

		#endregion Private Methods
	}
}