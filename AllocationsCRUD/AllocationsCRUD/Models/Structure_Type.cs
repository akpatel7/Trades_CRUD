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
    
    public partial class Structure_Type
    {
        public Structure_Type()
        {
            this.Trades = new HashSet<Trade>();
        }
    
        public int structure_type_id { get; set; }
        public string structure_type_label { get; set; }
    
        public virtual ICollection<Trade> Trades { get; set; }
    }
}
