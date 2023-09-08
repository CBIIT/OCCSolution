using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCCSolution.Models;
/**********************************************************************************************************************
 * Date         Developer       Desc
 * 01/04/2015   Chi             Added DT4 method
 * 
 **********************************************************************************************************************/
namespace OCCSolution.Controllers
{
    public class DTController : Controller
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
            //if (ModelState.IsValid)
            //{       
            //    var msgBoardItems = new List<vwOCCAnnoucement>();
            //    try
            //    {
            //        if (System.Web.HttpContext.Current.Cache["occAnnoucements"] == null)
            //        {
            //            System.Web.HttpContext.Current.Cache["occAnnoucements"] = db.vwOCCAnnoucements.ToList();
            //        }

            //        ViewBag.OCCAnnoucements = System.Web.HttpContext.Current.Cache["occAnnoucements"];
            //    }
            //    catch (Exception ex)
            //    {
            //        // TODO:  Log this error
            //        Console.WriteLine(ex.Message);
            //        ViewBag.OCCMessageBoards = msgBoardItems;
            //    }
           //}
            return View();

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

        // GET: vwDT3... every 30 minutes
        [OutputCache(Duration = 2600)]
        public ActionResult DT3()
        {
            ViewBag.Message = "DT3";
            try
            {
                if (ModelState.IsValid)
                {
                    ViewData["vwDT3NewlyRegBenchmark"] = db.vwDT3NewlyRegBenchmark.ToList();
                    ViewData["vwDT3Top20EnrolledBenchmark"] = db.vwDT3Top20EnrolledBenchmark.ToList();
                    ViewData["vwDT3Top20RegisteredBenchmark"] = db.vwDT3Top20RegisteredBenchmark.ToList();
                }
            }
            catch (Exception ex)
            {
                // TODO:  Log this error
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        // GET: vwDT2Benchmark every hour
        [OutputCache(Duration = 2600)]
        public ActionResult DT4()
        {
            ViewBag.Message = "DT4";
            try
            {
                if (ModelState.IsValid)
                {
                    ViewData["vwDT4StudySourceBenchmark"] = db.vwDT4StudySourceBenchmark.ToList();
                    ViewData["vwDT4ResearchCatBenchmark"] = db.vwDT4ResearchCatBenchmark.ToList();
                    ViewData["vwDT4PhaseBenchmark"] = db.vwDT4PhaseBenchmark.ToList();
                    ViewData["vwDT4PrimaryPurposeBenchmark"] = db.vwDT4PrimaryPurposeBenchmark.ToList();
                }
            }
            catch (Exception ex)
            {
                // TODO:  Log this error
                Console.WriteLine(ex.Message);
            }
            return View();
        }
    }
}