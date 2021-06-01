using System.Web;
using System.Web.Optimization;

namespace Jobify
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/scripts/bootbox.js",
                        "~/Scripts/respond.js",
                        "~/scripts/datatables/jquery.datatables.js",
                        "~/scripts/datatables/datatables.bootstrap.js",
                        "~/scripts/typeahead.bundle.js",
                        "~/scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/content/datatables/css/datatables.bootstrap.css",
                      "~/content/typeahead.css",
                      "~/content/toastr.css",
                      "~/assets/css/style.css"
                      ));

            bundles.Add(new StyleBundle("~/template/css").Include(
                    "~/assets/css/style.css",
                    "~/assets/vendor/bootstrap/css/bootstrap.min.css",
                    "~/assets/vendor/icofont/icofont.min.css",
                    "~/assets/vendor/boxicons/css/boxicons.min.css",
                    "~/assets/vendor/remixicon/remixicon.css",
                    "~/assets/vendor/owl.carousel/assets/owl.carousel.min.css",
                    "~/assets/vendor/animate.css/animate.min.css",
                    "~/assets/vendor/aos/aos.css"));

            bundles.Add(new ScriptBundle("~/template/js").Include(
                "~/assets/js/main.js",
                "~/assets/vendor/jquery/jquery.min.js",
                "~/assets/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/assets/vendor/jquery.easing/jquery.easing.min.js",
                "~/assets/vendor/php-email-form/validate.js",
                "~/assets/vendor/waypoints/jquery.waypoints.min.js",
                "~/assets/vendor/counterup/counterup.min.js",
                "~/assets/vendor/owl.carousel/owl.carousel.min.js",
                "~/assets/vendor/aos/aos.js"));
        }
    }
}
