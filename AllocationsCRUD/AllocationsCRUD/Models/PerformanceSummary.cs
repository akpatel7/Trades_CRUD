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
    
    public partial class PerformanceSummary
    {
        public int Id { get; set; }
        public Nullable<int> ItemId { get; set; }
        public string Value { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> MeasureTypeId { get; set; }
        public string MeasureTypeLabel { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public Nullable<int> BenchmarkId { get; set; }
        public string BenchmarkLabel { get; set; }
        public string PerformanceType { get; set; }
        public string ServiceCode { get; set; }
    }
}