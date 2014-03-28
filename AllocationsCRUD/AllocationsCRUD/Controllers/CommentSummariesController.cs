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
    builder.EntitySet<CommentSummary>("CommentSummaries");
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CommentSummariesController : ODataController
    {
        private PortofolioEntities db = new PortofolioEntities();

        // GET odata/CommentSummaries
        [Queryable]
        public IQueryable<CommentSummary> GetCommentSummaries()
        {
            return db.CommentSummaries;
        }

        // GET odata/CommentSummaries(5)
        [Queryable]
        public SingleResult<CommentSummary> GetCommentSummary([FromODataUri] int key)
        {
            return SingleResult.Create(db.CommentSummaries.Where(commentsummary => commentsummary.Id == key));
        }

        // PUT odata/CommentSummaries(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, CommentSummary commentsummary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != commentsummary.Id)
            {
                return BadRequest();
            }

            db.Entry(commentsummary).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentSummaryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(commentsummary);
        }

        // POST odata/CommentSummaries
        public async Task<IHttpActionResult> Post(CommentSummary commentsummary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CommentSummaries.Add(commentsummary);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CommentSummaryExists(commentsummary.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(commentsummary);
        }

        // PATCH odata/CommentSummaries(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<CommentSummary> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CommentSummary commentsummary = await db.CommentSummaries.FindAsync(key);
            if (commentsummary == null)
            {
                return NotFound();
            }

            patch.Patch(commentsummary);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentSummaryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(commentsummary);
        }

        // DELETE odata/CommentSummaries(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            CommentSummary commentsummary = await db.CommentSummaries.FindAsync(key);
            if (commentsummary == null)
            {
                return NotFound();
            }

            db.CommentSummaries.Remove(commentsummary);
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

        private bool CommentSummaryExists(int key)
        {
            return db.CommentSummaries.Count(e => e.Id == key) > 0;
        }
    }
}
