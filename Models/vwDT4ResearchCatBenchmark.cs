//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OCCSolution.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwDT4ResearchCatBenchmark
    {
        public int ID { get; set; }
        public int FY { get; set; }
        public string ClinicalResearchCat { get; set; }
        public Nullable<int> OpenTrialTotal { get; set; }
        public Nullable<int> OpenTrialMedian { get; set; }
        public Nullable<int> AccruedTotal { get; set; }
        public Nullable<int> AccruedMedian { get; set; }
        public int SortOrder { get; set; }
    }
}
