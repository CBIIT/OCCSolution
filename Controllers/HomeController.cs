using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCCSolution.Models;

/*
 * Date         Develper        Desc
 * 12/29/2014   Chi             Added SiteMap and ExternalWebsitePolicy methods
 * 01/07/2015   Chi             Changed OCCMessageBoard to OCCAnnoucement
 * 01/13/2015   Chi             Corrected the spelling of the word announcement
 */
namespace OCCSolution.Controllers
{
    public class HomeController : Controller
    {
        private OCCEntities db = new OCCEntities();
        /// <summary>  GET: OCCMessageBoard
        /// Instead of return View(db.OCCMessageBoards.ToList());
        /// define the msgBoardItems in the following way allows the application to continue to function even in the event of the database server is down
        /// </summary>
        /// <returns></returns>

        public ActionResult SearchResultSamplePage()
        {
            return View();
        }

        public ActionResult SiteMap()
        {
            ViewBag.Message = "Site Map";
            return View();
        }

        public ActionResult ExternalWebsitePolicy()
        {
            ViewBag.Message = "External Website Policy";
            return View();
        }

        // GET: vwOCCAnnouncement every hour
        [OutputCache(Duration = 3600)]
        public ActionResult Index()
        {
            var msgBoardItems = new List<vwOCCAnnouncement>();
            try
            {
                msgBoardItems = db.vwOCCAnnouncements.ToList();
            }
            catch(Exception ex)
            {
                // TODO:  Log this error
                Console.WriteLine(ex.Message);
            }
            return View(msgBoardItems);
        }


        public ActionResult About()
        {
            ViewBag.Message = "About Us";
            return View();
        }

        public ActionResult OurTeam()
        {
            ViewBag.Message = "Meet Our Team";

            return View();
        }

        public ActionResult FAQs()
        {
            return View();
        }

        public ActionResult DTFAQs()
        {
            return View();
        }

        public ActionResult CCSGFAQs()
        {
            return View();
        }

        public ActionResult FOAFAQs()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact OCC Staff.";

            return View();
        }

        public ActionResult AboutOCCWebApp()
        {
            ViewBag.Message = "About OCC WebApp";
            return View();
        }

        public ActionResult Keyboard()
        {
            ViewBag.Message = "Keyboard Shortcuts Definition";
            return View();
        }
    }
}