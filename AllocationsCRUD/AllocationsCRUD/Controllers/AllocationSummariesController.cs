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
using AllocationsCRUD.Models;

namespace AllocationsCRUD.Controllers
{
    public class AllocationSummariesController : ApiController
    {
        private PortfolioDataService db = new PortfolioDataService();

        // GET api/AllocationSummaries
        public IQueryable<AllocationSummary> GetAllocationSummaries()
        {
            return db.AllocationSummaries;
        }

        // GET api/AllocationSummaries/5
        [ResponseType(typeof(AllocationSummary))]
        public async Task<IHttpActionResult> GetAllocationSummary(int id)
        {
            AllocationSummary allocationsummary = await db.AllocationSummaries.FindAsync(id);
            if (allocationsummary == null)
            {
                return NotFound();
            }

            return Ok(allocationsummary);
        }

        // PUT api/AllocationSummaries/5
        public async Task<IHttpActionResult> PutAllocationSummary(int id, AllocationSummary allocationsummary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != allocationsummary.Id)
            {
                return BadRequest();
            }

            db.Entry(allocationsummary).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllocationSummaryExists(id))
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

        // POST api/AllocationSummaries
        [ResponseType(typeof(AllocationSummary))]
        public async Task<IHttpActionResult> PostAllocationSummary(AllocationSummary allocationsummary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AllocationSummaries.Add(allocationsummary);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AllocationSummaryExists(allocationsummary.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = allocationsummary.Id }, allocationsummary);
        }

        // DELETE api/AllocationSummaries/5
        [ResponseType(typeof(AllocationSummary))]
        public async Task<IHttpActionResult> DeleteAllocationSummary(int id)
        {
            AllocationSummary allocationsummary = await db.AllocationSummaries.FindAsync(id);
            if (allocationsummary == null)
            {
                return NotFound();
            }

            db.AllocationSummaries.Remove(allocationsummary);
            await db.SaveChangesAsync();

            return Ok(allocationsummary);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AllocationSummaryExists(int id)
        {
            return db.AllocationSummaries.Count(e => e.Id == id) > 0;
        }
    }
}