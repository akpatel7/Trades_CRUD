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
    builder.EntitySet<Portfolio>("Portfolios");
    builder.EntitySet<Allocation>("Allocation"); 
    builder.EntitySet<Benchmark>("Benchmarks"); 
    builder.EntitySet<Comment>("Comment"); 
    builder.EntitySet<DurationType>("DurationTypes"); 
    builder.EntitySet<PortfolioType>("PortfolioTypes"); 
    builder.EntitySet<Service>("Services"); 
    builder.EntitySet<Status>("Status"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PortfoliosController : ODataController
    {
        private PortofolioEntities db = new PortofolioEntities();

        // GET odata/Portfolios
        [Queryable]
        public IQueryable<Portfolio> GetPortfolios()
        {
            return db.Portfolios;
        }

        // GET odata/Portfolios(5)
        [Queryable]
        public SingleResult<Portfolio> GetPortfolio([FromODataUri] int key)
        {
            return SingleResult.Create(db.Portfolios.Where(portfolio => portfolio.Id == key));
        }

        // PUT odata/Portfolios(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Portfolio portfolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != portfolio.Id)
            {
                return BadRequest();
            }

            db.Entry(portfolio).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortfolioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(portfolio);
        }

        // POST odata/Portfolios
        public async Task<IHttpActionResult> Post(Portfolio portfolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Portfolios.Add(portfolio);
            await db.SaveChangesAsync();

            return Created(portfolio);
        }

        // PATCH odata/Portfolios(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Portfolio> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Portfolio portfolio = await db.Portfolios.FindAsync(key);
            if (portfolio == null)
            {
                return NotFound();
            }

            patch.Patch(portfolio);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortfolioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(portfolio);
        }

        // DELETE odata/Portfolios(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Portfolio portfolio = await db.Portfolios.FindAsync(key);
            if (portfolio == null)
            {
                return NotFound();
            }

            db.Portfolios.Remove(portfolio);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Portfolios(5)/Allocations
        [Queryable]
        public IQueryable<Allocation> GetAllocations([FromODataUri] int key)
        {
            return db.Portfolios.Where(m => m.Id == key).SelectMany(m => m.Allocations);
        }

        // GET odata/Portfolios(5)/Benchmark
        [Queryable]
        public SingleResult<Benchmark> GetBenchmark([FromODataUri] int key)
        {
            return SingleResult.Create(db.Portfolios.Where(m => m.Id == key).Select(m => m.Benchmark));
        }

        // GET odata/Portfolios(5)/Comments
        [Queryable]
        public IQueryable<Comment> GetComments([FromODataUri] int key)
        {
            return db.Portfolios.Where(m => m.Id == key).SelectMany(m => m.Comments);
        }

        // GET odata/Portfolios(5)/DurationType
        [Queryable]
        public SingleResult<DurationType> GetDurationType([FromODataUri] int key)
        {
            return SingleResult.Create(db.Portfolios.Where(m => m.Id == key).Select(m => m.DurationType));
        }

        // GET odata/Portfolios(5)/PortfolioType
        [Queryable]
        public SingleResult<PortfolioType> GetPortfolioType([FromODataUri] int key)
        {
            return SingleResult.Create(db.Portfolios.Where(m => m.Id == key).Select(m => m.PortfolioType));
        }

        // GET odata/Portfolios(5)/Service
        [Queryable]
        public SingleResult<Service> GetService([FromODataUri] int key)
        {
            return SingleResult.Create(db.Portfolios.Where(m => m.Id == key).Select(m => m.Service));
        }

        // GET odata/Portfolios(5)/Status
        [Queryable]
        public SingleResult<Status> GetStatus([FromODataUri] int key)
        {
            return SingleResult.Create(db.Portfolios.Where(m => m.Id == key).Select(m => m.Status));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PortfolioExists(int key)
        {
            return db.Portfolios.Count(e => e.Id == key) > 0;
        }
    }
}
