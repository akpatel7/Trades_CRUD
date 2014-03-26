using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using AllocationsCRUD.Models;

namespace AllocationsCRUD.Controllers
{
    public class AllocationSummaryController : ODataController
    {
        private readonly AllocationsDataService _allocationsEntitiesDataService;

        public AllocationSummaryController()
        {
            _allocationsEntitiesDataService = new AllocationsDataService();
        }

        // GET odata/Items
        [Queryable]
        public IQueryable<AllocationSummary> Get()
        {
            return _allocationsEntitiesDataService.AllocationSummaries;
        }

        // GET odata/Item
        [Queryable]
        public SingleResult<AllocationSummary> GetAllocationSummary([FromODataUri] int key)
        {
            return SingleResult.Create(_allocationsEntitiesDataService.AllocationSummaries.Where(item => item.Id == key));
        }

        // PUT odata/TodoItems(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, AllocationSummary item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != item.Id)
            {
                return BadRequest();
            }

            _allocationsEntitiesDataService.Entry(item).State = EntityState.Modified;

            try
            {
                await _allocationsEntitiesDataService.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(item);
        }

        // POST odata/TodoItems
        public async Task<IHttpActionResult> Post(AllocationSummary item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _allocationsEntitiesDataService.AllocationSummaries.Add(item);
            await _allocationsEntitiesDataService.SaveChangesAsync();

            return Created(item);
        }

        // PATCH odata/TodoItems(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<AllocationSummary> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AllocationSummary item = await _allocationsEntitiesDataService.AllocationSummaries.FindAsync(key);
            if (item == null)
            {
                return NotFound();
            }

            patch.Patch(item);

            try
            {
                await _allocationsEntitiesDataService.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(item);
        }

        // DELETE odata/TodoItems(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            AllocationSummary item = await _allocationsEntitiesDataService.AllocationSummaries.FindAsync(key);
            if (item == null)
            {
                return NotFound();
            }

            _allocationsEntitiesDataService.AllocationSummaries.Remove(item);
            await _allocationsEntitiesDataService.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/TodoItems(5)/TodoList
        //[Queryable]
        //public SingleResult<TodoList> GetTodoList([FromODataUri] int key)
        //{
        //    return SingleResult.Create(_allocationsEntitiesDataService.AllocationSummaries.Where(m => m.Id == key).Select(m => m.TodoList));
        //}

        private bool ItemExists(int key)
        {
            return _allocationsEntitiesDataService.AllocationSummaries.Count(e => e.Id == key) > 0;
        }
    }
}