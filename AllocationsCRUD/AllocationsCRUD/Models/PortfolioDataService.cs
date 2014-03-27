using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AllocationsCRUD.Models
{
    public class PortfolioDataService : DbContext, IPortfolioEntitiesDataService
    {
        public PortfolioDataService()
            : base("name=BCATrade_devEntities")
        {}

        public DbSet<PortfolioSummary> PortfolioSummaries { get; set; }
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