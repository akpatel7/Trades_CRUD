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
    
    public partial class PortfolioSummary
    {
        public string Service { get; set; }
        public string ServiceCode { get; set; }
        public string Type { get; set; }
        public string Benchmark { get; set; }
        public string Status { get; set; }
        public Nullable<int> StatusId { get; set; }
        public string Duration { get; set; }
        public int Id { get; set; }
        public string Uri { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public Nullable<System.DateTime> FirstPublishedDate { get; set; }
        public string PerformanceModel { get; set; }
    }
}
