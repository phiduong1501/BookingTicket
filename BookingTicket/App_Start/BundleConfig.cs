using System.Web;
using System.Web.Optimization;

namespace BookingTicket
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                   "~/Scripts/angular/angular.js",
                   "~/Scripts/angular/angular-route.js",
                   "~/Scripts/angular/angular-animate.js",
                   "~/Scripts/angular/angular-sanitize.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                      "~/Scripts/kendo/js/kendo.all.min.js",
                      "~/Scripts/kendo/js/kendo.angular.min.js",
                      "~/Scripts/kendo/js/cultures/kendo.culture.vi-VN.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                      "~/Scripts/toastr/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/excellentexport.js",
                      "~/Scripts/app/Filters.js",
                      "~/Scripts/app/mainapp.js",
                      "~/Scripts/app/config.js",
                      "~/Scripts/app/factory/*.js",
                      "~/Scripts/app/controller/*.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/sb-admin.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/site.css",
                      "~/Content/loading.css",
                      "~/Scripts/kendo/css/kendo.common.min.css",
                      "~/Scripts/kendo/css/kendo.material.min.css",
                      "~/Scripts/kendo/css/kendo.material.mobile.min.css"));

            bundles.Add(new StyleBundle("~/Content/css/toastr").Include(
                      "~/Scripts/toastr/toastr.css"));
        }
    }
}
