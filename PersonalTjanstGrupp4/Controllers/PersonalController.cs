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
using PersonalTjanstGrupp4;

namespace PersonalTjanstGrupp4.Controllers
{
    public class PersonalController : ApiController
    {
        private PersonalModell db = new PersonalModell();

        // GET: api/Personal
        public IQueryable<Personal> GetPersonal()
        {
            return db.Personal;
        }

        // GET: api/Personal/5
        [HttpGet]
        public IHttpActionResult GetPersonal(int id)
        {
            Personal personal = db.Personal.Find(id);
            if (personal == null)
            {
                return NotFound();
            }

            return Ok(personal);
        }

        // PUT: api/Personal/5
        [Route("UppdateraPersonal")]
        [HttpPut]
        public IHttpActionResult PutPersonal(Personal personal)
        {
            var id = personal.Id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personal.Id)
            {
                return BadRequest();
            }

            db.Entry(personal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalExists(id))
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

        // POST: api/Personal
        
        [Route("SkapaPersonal")]
        [HttpPost]
        public IHttpActionResult PostPersonal(Personal personal)
        {
            personal.RefID = personal.Id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personal.Add(personal);
            db.SaveChanges();

            return Ok("Konto Skapats");
        }



        // DELETE: api/Personal/5
        //[ResponseType(typeof(Personal))]
        //[Route("DeletePersonal")]
        [HttpDelete]
        public IHttpActionResult DeletePersonal(int Id)
        {
            Personal personal = db.Personal.Find(Id);
            if (personal == null)
            {
                return NotFound();
            }

            db.Personal.Remove(personal);
            db.SaveChanges();
 

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonalExists(int id)
        {
            return db.Personal.Count(e => e.Id == id) > 0;
        }
    }
}