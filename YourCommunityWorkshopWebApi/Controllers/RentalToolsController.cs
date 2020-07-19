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
using YourCommunityWorkshopWebApi.Models;

namespace YourCommunityWorkshopWebApi.Controllers
{
    public class RentalToolsController : ApiController
    {
        private ToolRentalEntities db = new ToolRentalEntities();

        // GET: api/RentalTools
        public IQueryable<RentalTool> GetRentalTools()
        {
            return db.RentalTools;
        }

        // GET: api/RentalItemsById/
        [HttpGet]
        [Route("api/RentalToolsById/{id}")]
        [ResponseType(typeof(RentalTool))]
        public IQueryable<RentalTool> GetRentalToolsById(int Id)
        {
            // to get Rental Items using RentalId
            return db.RentalTools.Where(r => r.RentalId == Id);
        }

        // GET: api/RentalTools/5
        [ResponseType(typeof(RentalTool))]
        public IHttpActionResult GetRentalTool(int id)
        {
            RentalTool rentalTool = db.RentalTools.Find(id);
            if (rentalTool == null)
            {
                return NotFound();
            }

            return Ok(rentalTool);
        }

        // PUT: api/RentalTools/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRentalTool(int id, RentalTool rentalTool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rentalTool.RentalToolId)
            {
                return BadRequest();
            }

            db.Entry(rentalTool).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalToolExists(id))
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

        // POST: api/RentalTools
        [ResponseType(typeof(RentalTool))]
        public IHttpActionResult PostRentalTool(RentalTool rentalTool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RentalTools.Add(rentalTool);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rentalTool.RentalToolId }, rentalTool);
        }

        // DELETE: api/RentalTools/5
        [ResponseType(typeof(RentalTool))]
        public IHttpActionResult DeleteRentalTool(int id)
        {
            RentalTool rentalTool = db.RentalTools.Find(id);
            if (rentalTool == null)
            {
                return NotFound();
            }

            db.RentalTools.Remove(rentalTool);
            db.SaveChanges();

            return Ok(rentalTool);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RentalToolExists(int id)
        {
            return db.RentalTools.Count(e => e.RentalToolId == id) > 0;
        }
    }
}