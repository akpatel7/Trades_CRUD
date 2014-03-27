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
    builder.EntitySet<PortfolioSummary>("PortfolioSummaries");
    builder.EntitySet<AllocationSummary>("AllocationSummary"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PortfolioSummariesController : ODataController
    {
        private PortfolioDataService db = new PortfolioDataService();

        // GET odata/PortfolioSummaries
        [Queryable]
        public IQueryable<PortfolioSummary> GetPortfolioSummaries()
        {
            return db.PortfolioSummaries;
        }

        // GET odata/PortfolioSummaries(5)
        [Queryable]
        public SingleResult<PortfolioSummary> GetPortfolioSummary([FromODataUri] int key)
        {
            return SingleResult.Create(db.PortfolioSummaries.Where(portfoliosummary => portfoliosummary.Id == key));
        }

        // PUT odata/PortfolioSummaries(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, PortfolioSummary portfoliosummary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != portfoliosummary.Id)
            {
                return BadRequest();
            }

            db.Entry(portfoliosummary).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortfolioSummaryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(portfoliosummary);
        }

        // POST odata/PortfolioSummaries
        public async Task<IHttpActionResult> Post(PortfolioSummary portfoliosummary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PortfolioSummaries.Add(portfoliosummary);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PortfolioSummaryExists(portfoliosummary.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(portfoliosummary);
        }

        // PATCH odata/PortfolioSummaries(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<PortfolioSummary> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PortfolioSummary portfoliosummary = await db.PortfolioSummaries.FindAsync(key);
            if (portfoliosummary == null)
            {
                return NotFound();
            }

            patch.Patch(portfoliosummary);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortfolioSummaryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(portfoliosummary);
        }

        // DELETE odata/PortfolioSummaries(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            PortfolioSummary portfoliosummary = await db.PortfolioSummaries.FindAsync(key);
            if (portfoliosummary == null)
            {
                return NotFound();
            }

            db.PortfolioSummaries.Remove(portfoliosummary);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/PortfolioSummaries(5)/AllocationSummaries
        [Queryable]
        public IQueryable<AllocationSummary> GetAllocationSummaries([FromODataUri] int key)
        {
            PortfolioSummary portofolio = db.PortfolioSummaries.FirstOrDefault(p => p.Id == key);
            if (portofolio == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return db.AllocationSummaries.Where(m => m.Portfolio_Id == portofolio.Id);
        }

        // GET odata/PortfolioSummaries(5)/AllocationSummaries
        [Queryable]
        public IQueryable<AllocationSummary> GetExpandedAllocationTree([FromODataUri] int key)
        {
            PortfolioSummary portofolio = db.PortfolioSummaries.FirstOrDefault(p => p.Id == key);
            if (portofolio == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return db.AllocationSummaries.Where(m => m.Portfolio_Id == portofolio.Id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PortfolioSummaryExists(int key)
        {
            return db.PortfolioSummaries.Count(e => e.Id == key) > 0;
        }
    }
}
