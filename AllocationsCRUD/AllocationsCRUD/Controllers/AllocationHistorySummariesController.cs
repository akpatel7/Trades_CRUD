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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using AllocationsCRUD.Models;

namespace AllocationsCRUD.Controllers
{
    /*
    To add a route for this controller, merge these statements into the Register method of the WebApiConfig class. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using AllocationsCRUD.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<AllocationHistorySummary>("AllocationHistorySummaries");
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class AllocationHistorySummariesController : ODataController
    {
        private PortofolioEntities db = new PortofolioEntities();

        // GET odata/AllocationHistorySummaries
        [Queryable]
        public IQueryable<AllocationHistorySummary> GetAllocationHistorySummaries()
        {
            return db.AllocationHistorySummaries;
        }

        // GET odata/AllocationHistorySummaries(5)
        [Queryable]
        public SingleResult<AllocationHistorySummary> GetAllocationHistorySummary([FromODataUri] long key)
        {
            return SingleResult.Create(db.AllocationHistorySummaries.Where(allocationhistorysummary => allocationhistorysummary.Id == key));
        }

        // PUT odata/AllocationHistorySummaries(5)
        public async Task<IHttpActionResult> Put([FromODataUri] long key, AllocationHistorySummary allocationhistorysummary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != allocationhistorysummary.Id)
            {
                return BadRequest();
            }

            db.Entry(allocationhistorysummary).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllocationHistorySummaryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(allocationhistorysummary);
        }

        // POST odata/AllocationHistorySummaries
        public async Task<IHttpActionResult> Post(AllocationHistorySummary allocationhistorysummary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AllocationHistorySummaries.Add(allocationhistorysummary);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AllocationHistorySummaryExists(allocationhistorysummary.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(allocationhistorysummary);
        }

        // PATCH odata/AllocationHistorySummaries(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] long key, Delta<AllocationHistorySummary> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AllocationHistorySummary allocationhistorysummary = await db.AllocationHistorySummaries.FindAsync(key);
            if (allocationhistorysummary == null)
            {
                return NotFound();
            }

            patch.Patch(allocationhistorysummary);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllocationHistorySummaryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(allocationhistorysummary);
        }

        // DELETE odata/AllocationHistorySummaries(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] long key)
        {
            AllocationHistorySummary allocationhistorysummary = await db.AllocationHistorySummaries.FindAsync(key);
            if (allocationhistorysummary == null)
            {
                return NotFound();
            }

            db.AllocationHistorySummaries.Remove(allocationhistorysummary);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AllocationHistorySummaryExists(long key)
        {
            return db.AllocationHistorySummaries.Count(e => e.Id == key) > 0;
        }
    }
}
