using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCCSolution.Models;

/*<!--COMMENTS-------------------------------------------------------------------------------------------------------
    Date           Developer        Desc
 * 09/21/2015      Chi Dinh         Attempted to deploy ICD 10 updates
 *                                  Files: ICD.cs model, ICDView.cshtml view, GrantFundingController.cs controller,
 *                                  and ICD10Repository.cs Data file.
 * 03/31/2016      Chi              Modified variable _repository to _10repository 
 * 05/31/2017      Chi              Added method ActionResult ICD10                  
------------------------------------------------------------------------------------------------------------------->*/
namespace OCCSolution.Controllers
{
    public class GrantsFundingController : Controller
    {
        //ICD10Repository _10repository = new ICD10Repository();
        //ICD9Repository _9repository = new ICD9Repository();

        private OCCEntities db = new OCCEntities();

        public ActionResult FOAChangesOutline()
        {
            return View();
        }

        // GET: GrantsFunding
        public ActionResult GrantsFunding()
        {
            return View();
        }
        public ActionResult GuidelineChangesOutline()
        {
            return View();
        }
        
        
        public ActionResult DSMPRevCriteria()
        {
            return View();
        }

        //public ActionResult CURESupp()
        //{
        //    return View();
        //}

        public ActionResult RPPR()
        {
            return View();
        }

        public ActionResult DSMPPolicy()
        {
            return View();
        }



        public ActionResult PeerRevOrg()
        {
            return View();
        }

        public ActionResult PRMSandCPDMGuidance()
        {
            return View();
        }
        
        public ActionResult CCSGPeerRev()
        {
            return View();
        }

        public ActionResult eData()
        {
            return View();
        }

        public ActionResult DataGuide()
        {
            return View();
        }

        //public ActionResult ICDView()
        //{
        //    var model = _10repository.GetICDs();
        //    return View(model);
        //}

        //public ActionResult ICD9View()
        //{
        //    var model = _9repository.GetICDs();
        //    return View(model);
        //}

        //public ActionResult HIVSupp()
        //{
        //    return View();
        //}

        // GET: Centers from vwICD every 30 minutes
        [OutputCache(Duration = 1800)]
        public ActionResult ICD10()
        {
            var dataItems = new List<vwICD>();
            try
            {
                dataItems = db.vwICDs.ToList();
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