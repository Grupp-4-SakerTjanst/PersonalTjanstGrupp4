﻿using System;
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
    public class PersonalsController : ApiController
    {
        private PersonalModel db = new PersonalModel();

        // GET: api/Personals
        public IQueryable<Personal> GetPersonal()
        {
           
            return db.Personal;
        }

        // GET: api/Personals/5

        [Route("Personals/{id:int}")]
        [ResponseType(typeof(Personal))]
        public IHttpActionResult GetPersonal(int id)
        {
            Personal personal = db.Personal.Find(id);
            if (personal == null)
            {
                return NotFound();
            }

            return Ok(personal);
        }

        // PUT: api/Personals/5
        [Route("Personals/{id:int}")]
        [ResponseType(typeof(Personal))]
        public IHttpActionResult PutPersonal(int id, Personal personal)
        {
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

        // POST: api/Personals
       
        [ResponseType(typeof(Personal))]
        public IHttpActionResult PostPersonal(Personal personal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personal.Add(personal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personal.Id }, personal);
        }

        // DELETE: api/Personals/5
        [ResponseType(typeof(Personal))]
        public IHttpActionResult DeletePersonal(int id)
        {
            Personal personal = db.Personal.Find(id);
            if (personal == null)
            {
                return NotFound();
            }

            db.Personal.Remove(personal);
            db.SaveChanges();

            return Ok(personal);
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