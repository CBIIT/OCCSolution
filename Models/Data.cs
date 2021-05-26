//------------------------------------------------------------------------------
// NAME     DATE            DESC
// Chi      10/21/2014      Created
//------------------------------------------------------------------------------
namespace OCCSolution.Models
{
    using System.Collections.Generic;

    public class Data
    {

        public List<vwDT3NewlyPatientBenchmark> GetDT3NewlyPatients()
        {
            List<vwDT3NewlyPatientBenchmark> newlyPatients = new List<vwDT3NewlyPatientBenchmark>();
            return newlyPatients;
        }

        public List<vwDT3Top20EnrolledBenchmark> GetDT3Top20EnrolledPatients()
        {
            List<vwDT3Top20EnrolledBenchmark> enroll = new List<vwDT3Top20EnrolledBenchmark>();
            return enroll;
        }

        public List<vwDT3Top20RegisteredBenchmark> GetDT3Top20RegisteredPatients()
        {
            List<vwDT3Top20RegisteredBenchmark> reg = new List<vwDT3Top20RegisteredBenchmark>();
            return reg;
        }
    }
}
