using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactsWebApi.Models;
using ContactsWebApi.Data;
using System.Text.RegularExpressions;
using ContactsWebApi.Attribute;
using System.ComponentModel.DataAnnotations;

namespace ContactsWebApi.Controllers
{ 
    [RoutePrefix("api/[controller]")]
    public class ContactsController : ApiController
    {
        private ContactsDBContext _contactsDBContext = new ContactsDBContext();
        // GET: api/Contacts
        [EnableETag]
        public IHttpActionResult Get()
        {
            //return StatusCode(HttpStatusCode.OK);
            var cts = _contactsDBContext.Contacts;
            return Ok(_contactsDBContext.Contacts);
        }

        // GET: api/Contacts/5
        [EnableETag]
        public HttpResponseMessage Get(int id)
        {
            var contact = _contactsDBContext.Contacts.Find(id);
            if (contact == null)
            {
                //return StatusCode(HttpStatusCode.NoContent);
                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Contact With id = " + id.ToString() + " not found");
                throw new HttpResponseException(errorResponse);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK, contact);
            response.Content.Headers.Expires = new DateTimeOffset(DateTime.Now.AddSeconds(300));
            return response;
        }

        // POST: api/Contacts
        [InvalidModelStateFilter]
        public HttpResponseMessage Post([FromBody]Contact model)
        {

            if (ModelState.IsValid)
            {
                _contactsDBContext.Contacts.Add(model);
                _contactsDBContext.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // PUT: api/Contacts/5
        public HttpResponseMessage Put(int id, [FromBody]Contact contact)
        {
            if (ModelState.IsValid)
            {
                var _entity = _contactsDBContext.Contacts.Find(id);

                if (_entity is null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                else
                {
                    _entity.FirstName = contact.FirstName;
                    _entity.LastName = contact.LastName;
                    _entity.Image = contact.Image;
                    _entity.Email = contact.Email;
                    _entity.PersonalPhone = contact.PersonalPhone;
                    _entity.WorkPhone = contact.WorkPhone;
                    _entity.StreetAddress = contact.StreetAddress;
                    _entity.State = contact.State;
                    _entity.City = contact.City;
                    _entity.ZipCode = contact.ZipCode;
                    _contactsDBContext.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }

            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE: api/Contacts/5
        public IHttpActionResult Delete(int id)
        {
            var contact = _contactsDBContext.Contacts.Find(id);
            if (contact is null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                _contactsDBContext.Contacts.Remove(contact);
                _contactsDBContext.SaveChanges();
                return Ok("Contact Deleted Successfully.");
            }
        }

        [HttpGet]
        [ActionName("searchby")]
        [EnableETag]
        public IHttpActionResult Search(string type, string term)
        {
            if (type == "phone")
            {
                var contacts = _contactsDBContext.Contacts.Where(x => x.PersonalPhone.StartsWith(term) || x.WorkPhone.StartsWith(term)).ToList();
                return contacts == null ? Ok("No Match Found!") : (IHttpActionResult)Ok(contacts);
            }
            else if (type == "email" && !string.IsNullOrEmpty(term))
            {
                var contacts = _contactsDBContext.Contacts.Where(x =>
                                                              x.Email.ToLower().Contains(term.ToLower())).ToList();
                return contacts == null ? Ok("No Match Found!") : (IHttpActionResult)Ok(contacts);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
