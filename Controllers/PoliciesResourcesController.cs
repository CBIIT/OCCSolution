using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OCCSolution.Controllers
{
    public class PoliciesResourcesController : Controller
    {
        // GET: GrantsFunding
        public ActionResult PoliciesResources()
        {
            return View();
        }

        public ActionResult LogoUsagePolicy()
        {
            return View();
        }
    }
}