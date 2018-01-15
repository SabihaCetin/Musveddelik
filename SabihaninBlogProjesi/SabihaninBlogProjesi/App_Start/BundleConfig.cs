using System.Web;
using System.Web.Optimization;

namespace SabihaninBlogProjesi
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(

                "~/vendor/bootstrap/js/bootstrap.min.js",
                "~/vendor/metisMenu/metisMenu.min.js",
                "~/vendor/raphael/raphael.min.js",
                "~/vendor/morrisjs/morris.min.js",
                "~/data/morris-data.js",
                "~/dist/js/sb-admin-2.js",
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(

                "~/Scripts/jquery-ui.min.js",
                "~/Scripts/modernizr.js",
                "~/Scripts/responsee.js",
                "~/Scripts/jquery-1.8.3.min.js",
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
               
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(


                 "~/vendor/bootstrap/css/bootstrap.min.css",
                "~/vendor/metisMenu/metisMenu.min.css",
                "~/dist/css/sb-admin-2.css",
                "~/vendor/morrisjs/morris.css",
                "~/vendor/font-awesome/css/font-awesome.min.css",
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
