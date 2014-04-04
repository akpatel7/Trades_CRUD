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
    builder.EntitySet<Service>("Services");
    builder.EntitySet<Portfolio>("Portfolio"); 
    builder.EntitySet<Trade>("Trade"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ServicesController : ODataController
    {
        private PortofolioEntities db = new PortofolioEntities();

        // GET odata/Services
        [Queryable]
        public IQueryable<Service> GetServices()
        {
            return db.Services;
        }

        // GET odata/Services(5)
        [Queryable]
        public SingleResult<Service> GetService([FromODataUri] int key)
        {
            return SingleResult.Create(db.Services.Where(service => service.service_id == key));
        }

        // PUT odata/Services(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != service.service_id)
            {
                return BadRequest();
            }

            db.Entry(service).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(service);
        }

        // POST odata/Services
        public async Task<IHttpActionResult> Post(Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Services.Add(service);
            await db.SaveChangesAsync();

            return Created(service);
        }

        // PATCH odata/Services(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Service> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Service service = await db.Services.FindAsync(key);
            if (service == null)
            {
                return NotFound();
            }

            patch.Patch(service);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(service);
        }

        // DELETE odata/Services(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Service service = await db.Services.FindAsync(key);
            if (service == null)
            {
                return NotFound();
            }

            db.Services.Remove(service);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Services(5)/Portfolios
        [Queryable]
        public IQueryable<Portfolio> GetPortfolios([FromODataUri] int key)
        {
            return db.Services.Where(m => m.service_id == key).SelectMany(m => m.Portfolios);
        }

        // GET odata/Services(5)/Trades
        [Queryable]
        public IQueryable<Trade> GetTrades([FromODataUri] int key)
        {
            return db.Services.Where(m => m.service_id == key).SelectMany(m => m.Trades);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceExists(int key)
        {
            return db.Services.Count(e => e.service_id == key) > 0;
        }
    }
}
