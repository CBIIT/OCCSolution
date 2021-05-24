using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCCSolution.Models;

namespace OCCSolution.Controllers
{
    public class DTControllerVM : Controller
    {
        private OCCEntities db = new OCCEntities();

        /// <summary> GET: DT
        /// Application data caching is a mechanism for storing the Data objects on cache.
        /// We can use this to store the data that need to cached. 
        /// It's per Application and informatin kept in cache best to use when you have data that can be reused for multiple users/sessions and (usually) if its readonly.
        /// For instance, a UserID will be stored in a Session. A User's language or name may also be stored in the Session.
        ///  But information useful to a group of Users or to all Users, such as lookup values, has to be stored in the Cache.
        /// The following code stores the OCCMessageBoards list in the Application Cache.
        /// </summary>
        /// <returns></returns>
        public ActionResult DT()
        {
            var msgBoardItems = new List<vwOCCMessageBoard>();

            try
            {
                if (System.Web.HttpContext.Current.Cache["occMessageBoards"] == null)
                {
                    System.Web.HttpContext.Current.Cache["occMessageBoards"] = db.vwOCCMessageBoards.ToList();

                }
                ViewBag.OCCMessageBoards = System.Web.HttpContext.Current.Cache["occMessageBoards"];
            }
            catch (Exception ex)
            {
                // TODO:  Log this error
                Console.WriteLine(ex.Message);
                ViewBag.OCCMessageBoards = msgBoardItems;
            }
            return View();
            //return View(db.OCCMessageBoards.ToList());
        }

        // GET: vwDT1Benchmark every hour
        [OutputCache(Duration = 2600)]
        public ActionResult DT1()
        {
            ViewBag.Message = "DT1";
            var dtItems = new List<vwDT1Benchmark>();
            try
            {
                dtItems = db.vwDT1Benchmark.ToList();
            }
            catch (Exception ex)
            {
                // TODO:  Log this error
                Console.WriteLine(ex.Message);
            }
            return View(dtItems);
        }

        // GET: vwDT2Benchmark every hour
        [OutputCache(Duration = 2600)]
        public ActionResult DT2()
        {
            ViewBag.Message = "DT2";
            var dtItems = new List<vwDT2bBenchmark>();
            try
            {
                dtItems = db.vwDT2bBenchmark.ToList();
            }
            catch (Exception ex)
            {
                // TODO:  Log this error
                Console.WriteLine(ex.Message);
            }
            return View(dtItems);
        }

  

        // GET: vwDT2Benchmark every hour
        [OutputCache(Duration = 2600)]
        public ActionResult DT3()
        {
            ViewBag.Message = "DT3";
            ViewModelDT3Benchmark vm = new ViewModelDT3Benchmark();

            try
            {
               
                //vm.vwNewlyPatient = (from a in db.vwDT3NewlyPatientBenchmark select a).ToList();
                //vm.vwTop20Enroll = (from b in db.vwDT3Top20EnrolledBenchmark select b).ToList();
                //vm.vwTop20Reg = (from c in db.vwDT3Top20RegisteredBenchmark select c).ToList();

                ViewData["vwDT3NewlyPatientBenchmark"] = db.vwDT3NewlyPatientBenchmark.ToList();
                ViewData["vwDT3Top20EnrolledBenchmark"] = db.vwDT3Top20EnrolledBenchmark.ToList();
                ViewData["vwDT3Top20RegisteredBenchmark"] = db.vwDT3Top20RegisteredBenchmark.ToList();

            }
            catch (Exception ex)
            {
                // TODO:  Log this error
                Console.WriteLine(ex.Message);
            }
            return View(ViewData);
        }

        // GET: vwDT2Benchmark every hour
        [OutputCache(Duration = 2600)]
        public ActionResult DT4()
        {
            ViewBag.Message = "DT4";
            var dtItems = new List<vwDT1Benchmark>();
            try
            {
                dtItems = db.vwDT1Benchmark.ToList();
            }
            catch (Exception ex)
            {
                // TODO:  Log this error
                Console.WriteLine(ex.Message);
            }
            return View(dtItems);
        }
    }
}