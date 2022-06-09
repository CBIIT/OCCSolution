using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCCSolution.Models;
/********************************************************************************************************************
 *  DATE        Developer   Desc
 *  01/07/2015  Chi         Changed OCCMessageBoard to OCCAnnouncement
 *  03/28/2015  Chi         Modify the view so that's Order by OCCAnnouncementID DESC -can't order by effectiveDate, in DB, convert it to string.
 ********************************************************************************************************************/
namespace OCCSolution.Controllers
{
    public class NewsEventsController : Controller
    {
        private OCCEntities db = new OCCEntities();

        // GET: NewsEvents
        public ActionResult NewsEvents()
        {
            return View();
        }

   
        // GET: vwOCCAnnouncement every hour
        [OutputCache(Duration = 3600)]
        public ActionResult OCCAnnouncement()
        {
            var dataItems = new List<vwOCCAnnouncement>();
            try
            {
                dataItems = db.vwOCCAnnouncements
                            .OrderByDescending(oa => oa.OCCAnnouncementID).ToList();
            }
            catch (Exception ex)
            {
                // TODO:  Log this error
                Console.WriteLine(ex.Message);
            }
            return View(dataItems);
        }
    }
}