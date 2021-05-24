//------------------------------------------------------------------------------
// NAME     DATE            DESC
// Chi      10/21/2014      Created
//------------------------------------------------------------------------------

namespace OCCSolution.Models
{
    using System;
    using System.Collections.Generic;

    public partial class DT1BFY13
    {
        public Nullable<double> GrantNumber { get; set; }
        public Nullable<System.DateTime> ReportingDate { get; set; }
        public Nullable<double> ProgCode { get; set; }
        public string ProgName { get; set; }
        public string MeritLevel { get; set; }
        public string IsNewProg { get; set; }
        public string IsDevProg { get; set; }
        public string IsMultiLeader { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Degree1 { get; set; }
        public string Degree2 { get; set; }
        public string Degree3 { get; set; }
        public string IsNew { get; set; }
        public Nullable<double> NoOfMember { get; set; }
        public string Comment { get; set; }
        public int dt1bFY131 { get; set; }
        public Nullable<int> CenterID { get; set; }

        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }

        public virtual Center Center { get; set; }
    }
}
