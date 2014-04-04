using System.Web;
using System.Web.Optimization;

namespace AllocationsCRUD
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.min.js",
                "~/Scripts/angular-resource.min.js",
                "~/cripts/underscore.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/toastr.css",
            //          "~/Content/breeze.directives.css",
            //          "~/Content/site.css",
            //          "~/Content/todo.css"
            //          ));

            bundles.Add(new StyleBundle("~/Content/css/bundle").Include(
                     "~/Content/css/bootstrap-dashboard.css",
                     "~/Content/css/smoothness/jquery-ui.css",
                     "~/Content/css/autoSuggest.css",
                     "~/Content/css/oo_style.css",
                     "~/Content/toastr.css",
                     "~/Content/site.css",
                     "~/Content/todo.css"
                 ));

        }
    }
}
