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
    
    public partial class Track_Record
    {
        public int track_record_id { get; set; }
        public Nullable<int> trade_id { get; set; }
        public Nullable<int> track_record_type_id { get; set; }
        public Nullable<decimal> track_record_value { get; set; }
        public Nullable<System.DateTime> track_record_date { get; set; }
        public Nullable<int> created_by { get; set; }
        public Nullable<System.DateTime> last_updated { get; set; }
    
        public virtual Track_Record_Type Track_Record_Type { get; set; }
        public virtual Trade Trade { get; set; }
    }
}
