using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    public class BiesController : ApiController
    {
        private RestAPIContext db = new RestAPIContext();

        // GET: api/Bies
        public IQueryable<By> GetBies()
        {
            return db.Bies;
        }

        // GET: api/Bies/5
        [ResponseType(typeof(By))]
        public async Task<IHttpActionResult> GetBy(int id)
        {
            By by = await db.Bies.FindAsync(id);
            if (by == null)
            {
                return NotFound();
            }

            return Ok(by);
        }

        // PUT: api/Bies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBy(int id, By by)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != by.ById)
            {
                return BadRequest();
            }

            db.Entry(by).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ByExists(id))
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

        // POST: api/Bies
        [ResponseType(typeof(By))]
        public async Task<IHttpActionResult> PostBy(By by)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bies.Add(by);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = by.ById }, by);
        }

        // DELETE: api/Bies/5
        [ResponseType(typeof(By))]
        public async Task<IHttpActionResult> DeleteBy(int id)
        {
            By by = await db.Bies.FindAsync(id);
            if (by == null)
            {
                return NotFound();
            }

            db.Bies.Remove(by);
            await db.SaveChangesAsync();

            return Ok(by);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ByExists(int id)
        {
            return db.Bies.Count(e => e.ById == id) > 0;
        }
    }
}