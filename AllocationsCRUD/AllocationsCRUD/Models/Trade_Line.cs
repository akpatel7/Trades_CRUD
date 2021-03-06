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
    
    public partial class Trade_Line
    {
        public int trade_line_id { get; set; }
        public string trade_line_uri { get; set; }
        public Nullable<int> trade_id { get; set; }
        public Nullable<int> trade_line_group_id { get; set; }
        public Nullable<int> tradable_thing_id { get; set; }
        public Nullable<int> position_id { get; set; }
        public string trade_line_label { get; set; }
        public string trade_line_editorial_label { get; set; }
        public Nullable<System.DateTime> created_on { get; set; }
        public Nullable<int> created_by { get; set; }
        public Nullable<System.DateTime> last_updated { get; set; }
    
        public virtual Position Position { get; set; }
        public virtual Tradable_Thing Tradable_Thing { get; set; }
        public virtual Trade Trade { get; set; }
        public virtual Trade_Line_Group Trade_Line_Group { get; set; }
    }
}
