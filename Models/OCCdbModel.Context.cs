﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class OCCEntities : DbContext
    {
        public OCCEntities()
            : base("name=OCCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<vwDT2bBenchmark> vwDT2bBenchmark { get; set; }
        public virtual DbSet<vwDT3NewlyPatientBenchmark> vwDT3NewlyPatientBenchmark { get; set; }
        public virtual DbSet<vwDT3Top20EnrolledBenchmark> vwDT3Top20EnrolledBenchmark { get; set; }
        public virtual DbSet<vwDT3Top20RegisteredBenchmark> vwDT3Top20RegisteredBenchmark { get; set; }
        public virtual DbSet<vwDT4PhaseBenchmark> vwDT4PhaseBenchmark { get; set; }
        public virtual DbSet<vwDT4PrimaryPurposeBenchmark> vwDT4PrimaryPurposeBenchmark { get; set; }
        public virtual DbSet<vwDT4StudySourceBenchmark> vwDT4StudySourceBenchmark { get; set; }
        public virtual DbSet<vwDT1cMember> vwDT1cMember { get; set; }
        public virtual DbSet<vwDView> vwDViews { get; set; }
        public virtual DbSet<vwCCList> vwCCLists { get; set; }
        public virtual DbSet<vwOCCAnnouncement> vwOCCAnnouncements { get; set; }
        public virtual DbSet<vwDT1dSR> vwDT1dSR { get; set; }
        public virtual DbSet<vwRP> vwRPs { get; set; }
        public virtual DbSet<vwICD> vwICDs { get; set; }
        public virtual DbSet<vwDT4ResearchCatBenchmark> vwDT4ResearchCatBenchmark { get; set; }
        public virtual DbSet<vwCOE> vwCOEs { get; set; }
        public virtual DbSet<vwDT1Benchmark> vwDT1Benchmark { get; set; }
        public virtual DbSet<Center> Centers { get; set; }
        public virtual DbSet<vwET> vwETs { get; set; }
    
        public virtual ObjectResult<uspGetOCCStaffPOC_Result> uspGetOCCStaffPOC()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetOCCStaffPOC_Result>("uspGetOCCStaffPOC");
        }
    }
}
