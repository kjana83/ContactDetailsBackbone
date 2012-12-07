using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Simple.Data;
using ContactDetailsBackbone.Models;

namespace ContactDetailsBackbone.Controllers
{
    public class ContactsController : ApiController
    {

        // GET/Contacts/All
        public IEnumerable<Contact> Get()
        {
			var db = Database.Open();
            return db.Contact.FindAll(db.Contacts.Status=="Active");
        }

        // GET/Contacts/Id
        public Contact Get(int id)
        {
            return Database.Open().Contact.Get(id);
        }

        // POST/Contact
        public HttpResponseMessage Post(Contact contact)
        {
            try
            {
                IEnumerable<Contact>  contacts = Database.Open().Contact.All();
                Database.Open().Contact.Insert
					(
					new Contact {Title=contact.Title,
					FirstName = contact.FirstName, 
					Id = contacts.Count() + 1, 
					LastName = contact.LastName,
					Status="Active"
					});

                HttpResponseMessage response = Request.CreateResponse<Contact>(HttpStatusCode.Created, contact);
                response.Headers.Location = GetContactLocation(contacts.Count());

                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex);
            }
        }

        // PUT/Contacts/
        public Contact Put(Contact contact)
        {
			Database.Open().Contact.Update(contact);
			return contact;
        }

		// Delete/Contacts/id
		public Contact Delete(int Id)
		{
			var status = Database.Open().Contact.UpdateById(Id:Id, Status: "Inactive");

			if (status != null)
			{
				return null;
			}

			throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
		}

        Uri GetContactLocation(int contactID)
        {
            var controller = this.Request.GetRouteData().Values["controller"];
            return new Uri(this.Url.Link("DefaultApi", new { controller = controller, id = contactID }));
        }
        

    }
}
