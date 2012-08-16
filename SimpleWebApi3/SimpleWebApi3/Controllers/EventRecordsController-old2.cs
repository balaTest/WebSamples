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
    public class EventRecordsController : ApiController
    {
        private EventsContext db = new EventsContext();

        // GET api/EventRecords
        public IEnumerable<EventRecord> GetEventRecords()
        {
            return db.EventRecords.AsEnumerable();
        }

        // GET api/EventRecords/5
        public EventRecord GetEventRecord(int id)
        {
            EventRecord eventrecord = db.EventRecords.Find(id);
            if (eventrecord == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return eventrecord;
        }

        // PUT api/EventRecords/5
        public HttpResponseMessage PutEventRecord(int id, EventRecord eventrecord)
        {
            if (ModelState.IsValid && id == eventrecord.Id)
            {
                db.Entry(eventrecord).State = EntityState.Modified;

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

        // POST api/EventRecords
        public HttpResponseMessage PostEventRecord(EventRecord eventrecord)
        {
            if (ModelState.IsValid)
            {
                db.EventRecords.Add(eventrecord);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, eventrecord);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = eventrecord.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/EventRecords/5
        public HttpResponseMessage DeleteEventRecord(int id)
        {
            EventRecord eventrecord = db.EventRecords.Find(id);
            if (eventrecord == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.EventRecords.Remove(eventrecord);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, eventrecord);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}