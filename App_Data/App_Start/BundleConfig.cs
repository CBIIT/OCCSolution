using System.Web.Optimization;

///<!--COMMENTS-------------------------------------------------------------------------------------------------------
///    Date        Developer     Desc
///    11/21/2014  Chi           Rebundled
///    03/12/2015  Chi           Replaced   "~/Scripts/jquery-{version}.js" with "~/Scripts/jquery-1.11.1.min.js" is needed for the jquery-accessibleMegaMenu.js                    
///    
///    
///------------------------------------------------------------------------------------------------------------------->

namespace OCCSolution
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // 05/06/2021
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //           "~/Scripts/jquery-1.11.1.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jquerymin").Include(
            //            "~/Scripts/jquery-1.11.1.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryDT").Include(
            //  "~/Scripts/DataTables-1.10.4/js/dataTables.min.js", //added 11/22/2014 for columnSR/ICD9/ICD10 header & footer and DT1 filter
            //  "~/Scripts/jquery.dataTables-1.9.4.js",
            //  "~/Scripts/dataTables.tableTools.js"
            //  ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerymin").Include(
                        "~/Scripts/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryDT").Include(
              "~/Scripts/DataTables-1.10.4/js/dataTables.min.js", //added 11/22/2014 for columnSR/ICD9/ICD10 header & footer and DT1 filter
              "~/Scripts/jquery.dataTables-1.9.4.js",
              "~/Scripts/dataTables.tableTools.js"
              ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                      //"~/Scripts/jquerySPService-2014.01.min.js",
                      "~/Scripts/jquerySPService-{version}.min.js",
                      "~/Scripts/jquery.dataTables.rowGrouping.js"));


            // can't have {version} and wild card * in the same bundle
            bundles.Add(new ScriptBundle("~/Scripts/subjs").IncludeDirectory(
                      "~/Scripts", "*.js", true));


            bundles.Add(new ScriptBundle("~/bundles/flash").Include(
                        "~/Content/swf/*.swf"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //NOTE when include this //"~/Scripts/bootstrap.min.js", the drop-down menu won't work!!!
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-dropdown.js",
                      "~/Scripts/respond.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/dataTables.tableTools.css",
                      "~/Content/dataTables.jqueryui.css",
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-social.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/themes/base/jquery").Include(
                   "~/Content/themes/base/jquery.dataTables.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                       "~/Content/themes/base/jquery.ui.core.css",
                       "~/Content/themes/base/jquery.ui.resizable.css",
                       "~/Content/themes/base/jquery.ui.selectable.css",
                       "~/Content/themes/base/jquery.ui.accordion.css",
                       "~/Content/themes/base/jquery.ui.autocomplete.css",
                       "~/Content/themes/base/jquery.ui.button.css",
                       "~/Content/themes/base/jquery.ui.dialog.css",
                       "~/Content/themes/base/jquery.ui.slider.css",
                       "~/Content/themes/base/jquery.ui.tabs.css",
                       "~/Content/themes/base/jquery.ui.datepicker.css",
                       "~/Content/themes/base/jquery.ui.progressbar.css"
                       ));

            bundles.Add(new StyleBundle("~/Content/styles/kendo").Include(
                 "~/Content/styles/kendo.common.min.css",
                 "~/Content/styles/kendo.default.min.css",
                  "~/Content/styles/kendo.dataviz.min.css",
                  "~/Content/styles/kendo.dataviz.default.min.css",
                  "~/Content/styles/kendo.blueopal.min.css"
                  ));

            bundles.Add(new ScriptBundle("~/Scripts/js/kendo").Include(
               "~/Scripts/js/angular.min.js",
               "~/Scripts/js/kendo.all.min.js",
               "~/Scripts/js/kendo.aspnetmvc.min.js"));


            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
