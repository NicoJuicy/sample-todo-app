using System.Web;
using System.Web.Optimization;

namespace TodoApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-yeti.min.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular-scripts")
            .Include(
            "~/Scripts/angular/angular.js",
            "~/Scripts/angular/angular-cookies.js",
            "~/Scripts/angular/angular-resource.js",
            "~/Scripts/angular/angular-sanitize.js",
            // "~/assets/ui-bootstrap-tpls-2.5.0.min.js",
            "~/Scripts/angular/angular-animate.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/angular-app")
            .Include(
              "~/Scripts/app/load.js",
              //"~/assets/angular/directives.js",
              // "~/assets/angular/filters.js",
              "~/Scripts/app/services/todoService.js",
              "~/Scripts/app/controllers/TodosController.js"));

        }
    }
}
