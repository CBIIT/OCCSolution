//------------------------------------------------------------------------------
// <Chi-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </chi-generated>
//------------------------------------------------------------------------------

namespace OCCSolution.Models
{
    using System;
    using System.Collections.Generic;

    public partial class vwDT3NewlyRegBenchmark
    {
        public int ID { get; set; }
        public int FY { get; set; }
        public Nullable<int> ClinicalCount { get; set; }
        public string ClinicalRegHigh { get; set; }
        public string ClinicalRegLow { get; set; }
        public string ClinicalRegMedian { get; set; }
        public string ClinicalRegSubtotal { get; set; }
        public Nullable<int> CompCount { get; set; }
        public string CompRegHigh { get; set; }
        public string CompRegLow { get; set; }
        public string CompRegMedian { get; set; }
        public string CompRegSubtotal { get; set; }
        public string ClinicalEnrollHigh { get; set; }
        public string ClinicalEnrollLow { get; set; }
        public string ClinicalEnrollMedian { get; set; }
        public string ClinicalEnrollSubtotal { get; set; }
        public string CompEnrollHigh { get; set; }
        public string CompEnrollLow { get; set; }
        public string CompEnrollMedian { get; set; }
        public string CompEnrollSubtotal { get; set; }
        public string TotalReg { get; set; }
        public string TotalEnroll { get; set; }
    }
}
