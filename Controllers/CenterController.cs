using OCCSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

/********************************************************************************************************************
 *  DATE        Developer   Desc
 *  11/12/2014  Chi         Added  [OutputCache(Duration = <in seconds>)]
 *  11/22/2014  Chi         added Shared Resources 
 *  12/01/2014  CHi         Added CCList
 *  01/07/2015  Chi         Changed OCCMessageBoard to OCCAnnoucement
 *  01/07/2015  AM          Changed RP, SR to ResearchProgram and SharedResource
 *  01/20/2016  Chi         For Researc Program --> Replaced vwRP to vwDT1bProgram for FY14
 *  04/06/2016  Chi         Created the UnderConstruction actionResult for temporaly display Under Construction page when user clicks on Research Program error page 
 *  04/11/2016  Chi         Temporaly replaced vwDt1bProgram back to vwRP
 *  03/23/2017  Chi         Removed using Telerik.Web;
 *                                  using Telerik.Pdf;
 *  05/16/2017  Chi         Commented out Kendo.mvc.* references, it doesn't seem to be in use in the application
 *  04/23/2021  Chi         added CEO compoment - not displaying data on Stage (works fine locally)
 *  05/11/2021  Chi         Added Education & Training component
 ********************************************************************************************************************/

namespace OCCSolution.Controllers
{
    public class CenterController : Controller
    {
        private OCCEntities db = new OCCEntities();

        // GET: Centers from vwCOE every 30 minutes
        [OutputCache(Duration = 3600)]
        public ActionResult ET()
        {
            var etItems = new List<vwET>();
            try
            {
                etItems = db.vwETs.ToList();
            }
            catch (Exception ex)
            {
                // TODO:  Log this error
                Console.WriteLine(ex.Message);
            }
            return View(etItems);
        }

        // GET: Centers from vwCOE every 30 minutes
        [OutputCache(Duration = 3600)]
        public ActionResult COE()
        {
            var coeItems = new List<vwCOE>();
            try
            {
                coeItems = db.vwCOEs.ToList();
            }
            catch (Exception ex)
            {
                // TODO:  Log this error
                Console.WriteLine(ex.Message);
            }
            return View(coeItems);
        }

        // GET: Centers from vwCCList every 30 minutes
        [OutputCache(Duration = 3600)]
        public ActionResult CCList()
        {
            var dataItems = new List<vwCCList>();
            try
            {
                dataItems = db.vwCCLists.ToList();
            }
            catch (Exception ex)
            {
                // TODO:  Log this error
                Console.WriteLine(ex.Message);
            }
            return View(dataItems);
        }


        public ActionResult CancerCenters()
        {
            return View();
        }

        // GET: Research Programs from vwRP every hour
        [OutputCache(Duration = 3600)]
        public ActionResult RP()
        {
            var rpData = new List<vwRP>();
            try
            {
                rpData = db.vwRPs.ToList();
            }
            catch (Exception ex)
            {
                // TODO:  Log this error
                Console.WriteLine(ex.Message);
            }
            return View(rpData);
        }

        public ActionResult UnderConstruction()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        // GET: vwDT1dSR every hour
        [OutputCache(Duration = 3600)]
        public ActionResult SharedResource()
        {

            var dataItems = new List<vwDT1dSR>();
            try
            {
                dataItems = db.vwDT1dSR.ToList();
            }
            catch (Exception ex)
            {
                // TODO:  Log this error
                Console.WriteLine(ex.Message);
            }
            return View(dataItems);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
