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
    
    public partial class Currency
    {
        public Currency()
        {
            this.Trades = new HashSet<Trade>();
            this.Performances = new HashSet<Performance>();
        }
    
        public int currency_id { get; set; }
        public string currency_uri { get; set; }
        public string currency_code { get; set; }
        public string currency_symbol { get; set; }
        public string currency_label { get; set; }
    
        public virtual ICollection<Trade> Trades { get; set; }
        public virtual ICollection<Performance> Performances { get; set; }
    }
}
