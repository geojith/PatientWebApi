using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Patient_Registration.Models;

namespace Patient_Registration.Controllers
{
    public class Pat_registrationController : ApiController
    {
        private PDBEntities1 db = new PDBEntities1();

        // GET: api/Pat_registration
        public IQueryable<Pat_registration> GetPat_registration()
        {
            return db.Pat_registration;
        }

        // GET: api/Pat_registration/5
        [ResponseType(typeof(Pat_registration))]
        public IHttpActionResult GetPat_registration(int id)
        {
            Pat_registration pat_registration = db.Pat_registration.Find(id);
            if (pat_registration == null)
            {
                return NotFound();
            }

            return Ok(pat_registration);
        }

        // PUT: api/Pat_registration/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPat_registration(int id, Pat_registration pat_registration)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != pat_registration.p_id)
            {
                return BadRequest();
            }

            db.Entry(pat_registration).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Pat_registrationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Pat_registration
        [ResponseType(typeof(Pat_registration))]
        public IHttpActionResult PostPat_registration(Pat_registration pat_registration)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.Pat_registration.Add(pat_registration);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pat_registration.p_id }, pat_registration);
        }

        // DELETE: api/Pat_registration/5
        [ResponseType(typeof(Pat_registration))]
        public IHttpActionResult DeletePat_registration(int id)
        {
            Pat_registration pat_registration = db.Pat_registration.Find(id);
            if (pat_registration == null)
            {
                return NotFound();
            }

            db.Pat_registration.Remove(pat_registration);
            db.SaveChanges();

            return Ok(pat_registration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Pat_registrationExists(int id)
        {
            return db.Pat_registration.Count(e => e.p_id == id) > 0;
        }
    }
}