using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactDetailsBackbone.Models;
using Simple.Data;

namespace ContactDetailsBackbone.Controllers
{

	/// <summary>
	/// Contains all the action items for the Contact. 
	/// </summary>
    public class ContactsController : ApiController
    {
		private const string ACTIVE = "Active";
		private const string INACTIVE = "Inactive";

		/// <summary>
		/// GET/Contacts/All
		/// </summary>
		/// <returns></returns>
        public IEnumerable<Contact> Get()
        {
			var db = Database.Open();
			return db.Contact.FindAll(db.Contact.Status == ACTIVE);
        }
        
		/// <summary>		
		/// GET/Contacts/Id
		/// </summary>
		/// <param name="id">The id.</param>
		/// <returns></returns>
        public Contact Get(int id)
        {
            return Database.Open().Contact.Get(id);
        }

		/// <summary>
		/// POST/Contact
		/// </summary>
		/// <param name="contact">The contact.</param>
		/// <returns></returns>
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
					Status = ACTIVE
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

		/// <summary>
		/// PUT/Contacts/
		/// </summary>
		/// <param name="contact">The contact.</param>
		/// <returns></returns>
        public Contact Put(Contact contact)
        {
			Database.Open().Contact.Update(contact);
			return contact;
        }
		
		/// <summary>
		/// Delete/Contacts/id
		/// </summary>
		/// <param name="Id">The id.</param>
		/// <returns></returns>
		public Contact Delete(int Id)
		{
			var status = Database.Open().Contact.UpdateById(Id:Id, Status: INACTIVE);

			if (status != null)
			{
				return null;
			}

			throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
		}

		/// <summary>
		/// Gets the contact location.
		/// </summary>
		/// <param name="contactID">The contact ID.</param>
		/// <returns></returns>
        Uri GetContactLocation(int contactID)
        {
            var controller = this.Request.GetRouteData().Values["controller"];
            return new Uri(this.Url.Link("DefaultApi", new { controller = controller, id = contactID }));
        }
        

    }
}
