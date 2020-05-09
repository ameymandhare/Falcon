using System.Web;
using System.Web.Optimization;

namespace FalconSchool
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/Scripts/jquery-1.12.4.min.js",
                        "~/Content/Scripts/jquery-ui-1.12.1.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/jQueryThemes/base/jquery-ui.css",
                      "~/Content/jQueryThemes/base/all.css"));

            bundles.Add(new ScriptBundle("~/bundles/custom-scripts").Include(
                    "~/Content/Scripts/ProspectStudent/CreateProspect.js"));
        }
    }
}