using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AllocationsCRUD.Models
{
    public class AllocationsDataService: DbContext, IAllocationsEntitiesDataService
    {
        public AllocationsDataService()
            : base("name=BCATrade_devEntities")
        {}

        public DbSet<AllocationSummary> AllocationSummaries { get; set; }

        public IQueryable<T> Query<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Remove<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public new void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}