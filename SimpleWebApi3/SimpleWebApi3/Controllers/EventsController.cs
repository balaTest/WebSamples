using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SimpleWebApi3.Models;

namespace SimpleWebApi3.Controllers
{
    public class EventsController : ApiController
    {
        private EventsContext db = new EventsContext();
        
        // GET api/Events
        public IEnumerable<Event> GetEvents()
        {
            return db.Events.AsEnumerable();
        }

        // GET api/Events/5
        public IEnumerable<Event> GetEvent(int id)
        {
            db.Configuration.LazyLoadingEnabled=false;
            EventRecord eventrecord = db.EventRecords.Find(id);
            if (eventrecord == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            var events = db.Events.Where(e => e.EventRecordId == eventrecord.EventRecordId);
            return events.AsEnumerable();
        }

        // PUT api/Events/5
        public HttpResponseMessage PutEvent(int id, Event ev)
        {
            if (ModelState.IsValid && id == ev.Id)
            {
                db.Entry(ev).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Events
        public HttpResponseMessage PostEvent(Event ev)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(ev);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, ev);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = ev.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Events/5
        public HttpResponseMessage DeleteEvent(int id)
        {
            Event ev = db.Events.Find(id);
            if (ev == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Events.Remove(ev);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, ev);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}