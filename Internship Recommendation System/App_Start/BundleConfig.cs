using System.Web.Optimization;

namespace Internship_Recommendation_System
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

            bundles.Add(new Bundle("~/Content/js").Include(
                      "~/Content/bootstrap/js/bootstrap.bundle.min.js",
                      "~/Content/quill/quill.min.js",
                      "~/Content/simple-datatables/simple-datatables.js",
                      "~/Content/tinymce/tinymce.min.js",
                      "~/Content/php-email-form/validate.js",
                      "~/Scripts/site.js"));

            bundles.Add(new Bundle("~/Content/css").Include(
                      "~/Content/bootstrap/css/bootstrap.min.css",
                      "~/Content/bootstrap-icons/bootstrap-icons.css",
                      "~/Content/boxicons/css/boxicons.min.css",
                      "~/Content/quill/quill.snow.css",
                      "~/Content/quill/quill.bubble.css",
                      "~/Content/remixicon/remixicon.css",
                      "~/Content/simple-datatables/style.css",
                      "~/Content/site.css"));
        }
    }
}