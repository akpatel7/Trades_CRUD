using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AllocationsCRUD.Models
{
    public interface ITradesEntities
    {
        IQueryable<T> Query<T>() where T : class;
    }

    public partial class BCATrade_devEntities : ITradesEntities
    {
        public IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }
    }
}