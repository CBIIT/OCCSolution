using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OCCSolution.Models;
using System;
using System.Configuration; 
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

/*
 * Date         Develper        Desc
 * 12/29/2014   Chi             Added SiteMap and ExternalWebsitePolicy methods
 * 01/07/2015   Chi             Changed OCCMessageBoard to OCCAnnoucement
 * 01/13/2015   Chi             Corrected the spelling of the word announcement
 * 03/25/2022   Chi             Called external REST search API from NCI-Frederick, 
 *                              TO PROTECT AGAINST SCRIPT or URL EXPLOITS in webApp, apply encoding (HttpUtility.UrlPathEncode) to strings:
 *                              Used the UrlPathEncode method when you encode the path portion of a URL in order to guarantee a consistent decoded URL.  The UrlPathEncode method converts each space character into the string "%20", which represents a space in hexadecimal notation. 
 *                              you can also use WebUtility.UrlDecode for the searchParams. 
 *             NOTE - to see console.wrteline, Tools|options|Debug|General| check redirect output text to the immediate window. 
 */
namespace OCCSolution.Controllers
{
    public class HomeController : Controller
    {
        private OCCEntities db = new OCCEntities();

        /// <summary>  GET:SearchResult
        /// NOTE: HtmlEncode makes it safe to display user-entered text on a web page
        /// searchParams = WebUtility.HtmlEncode("Data Tables");
        /// HttpUtility.UrlEncode or WebUtility.UrlEncode works fine if there's no blank between words. it fails on  "data tables" search  
        /// searchParams = HttpUtility.UrlEncode("science");
        /// var externalAPIUrl = WebUtility.UrlEncode("https://ncifrederick.cancer.gov/Api/Services/search/excuteSearch/CancerCenters/") + searchParams; ===> CAUSED the handshake failed error due to an unexpected packet format
        /// </summary>
        /// <returns>View</returns>

        [HttpPost]
        public async Task<ActionResult> SearchResult(string searchParam)
        {

            //get the current base URL whether it's in Development, Staging, or Production env:
            Uri currentURLpage = System.Web.HttpContext.Current.Request.Url;                          //"https://localhost:63707/Home/SearchResult"
            string baseURL = currentURLpage.OriginalString.Replace(currentURLpage.PathAndQuery, ""); //"https://localhost:63707"
            baseURL = String.Concat(baseURL, "/");                                                   //"https://localhost:63707/"

            //DEBUG purposes:
            //searchParam = "Data Tables";
            //Console.WriteLine("***Debug On Console ***THE CURRENT baseURL IS" + baseURL);                
            System.Diagnostics.Debug.WriteLine("**System.Diagnostics.Debug**::The current baseURL is: " + baseURL);   //can see this on the Output window
            System.Diagnostics.Debug.WriteLine("**Debugging**: The search param is: " + searchParam);

            List<SearchModelClass> SearchInfo = new List<SearchModelClass>();

            //encode the url and search param to mitigate script or URL injection attacks 
            var externalAPIUrl = HttpUtility.UrlPathEncode("https://ncifrederick.cancer.gov/Api/Services/search/excuteSearch/CancerCenters/" + searchParam);

            using (var client = new HttpClient())
            {
                //passing servcie base url
                client.BaseAddress = new Uri(baseURL);

                client.DefaultRequestHeaders.Clear();
                
                //define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                //Sending request to find web api REST service resource CancerCenters using HttpClient
                //Initalization
                HttpResponseMessage response = new HttpResponseMessage();

              
                //HTTP GET
                response = await client.GetAsync(externalAPIUrl).ConfigureAwait(false);

                //Verification - Checking the response is successful or not which is sent using HttpClient
                if (response.IsSuccessStatusCode)
                {
                    //reading/storing the response/SearchResult recieved from web api
                    var searchResult = response.Content.ReadAsStringAsync().Result;

                    //Deserializing the searchResult recieved from web api and storing into the search list
                    SearchInfo = JsonConvert.DeserializeObject<List<SearchModelClass>>(searchResult);
                }
                //returning the search list to view
                return View(SearchInfo);
            }
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