//------------------------------------------------------------------------------
// NAME     DATE            DESC
// Chi      10/21/2014      Created
//------------------------------------------------------------------------------
namespace OCCSolution.Models
{
    using System.Collections.Generic;

    public class Data
    {

        public List<vwDT3NewlyRegBenchmark> GetDT3NewlyReg()
        {
            List<vwDT3NewlyRegBenchmark> newlyRegPatients = new List<vwDT3NewlyRegBenchmark>();
            return newlyRegPatients;
        }

        public List<vwDT3Top20RegisteredBenchmark> GetDT3Top20RegisteredPatients()
        {
            List<vwDT3Top20RegisteredBenchmark> reg = new List<vwDT3Top20RegisteredBenchmark>();
            return reg;
        }
    }
}
