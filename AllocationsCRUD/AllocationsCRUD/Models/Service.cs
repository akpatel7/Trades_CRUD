//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AllocationsCRUD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Service
    {
        public Service()
        {
            this.Portfolios = new HashSet<Portfolio>();
            this.Trades = new HashSet<Trade>();
        }
    
        public int service_id { get; set; }
        public string service_uri { get; set; }
        public string service_code { get; set; }
        public string service_label { get; set; }
    
        public virtual ICollection<Portfolio> Portfolios { get; set; }
        public virtual ICollection<Trade> Trades { get; set; }
    }
}
