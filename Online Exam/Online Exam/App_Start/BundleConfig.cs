using System.Web;
using System.Web.Optimization;

namespace Online_Exam
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.min.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/toaster").Include(
                        "~/Scripts/toastr.js",
                        "~/Scripts/toastr.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.min.js",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*",
                        "~/Content/js/modernizr.custom.79639.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Content/toastr.css",
                      "~/Content/toastr.min.css"));

            bundles.Add(new ScriptBundle("~/datatable/scripts").Include(
                "~/Scripts/jquery.dataTables.min.js",
                "~/Scripts/dataTables.bootstrap4.min.js"));

            bundles.Add(new StyleBundle("~/datatable/styles").Include(
                "~/Content/Dashboard/vendor/datatables/dataTables.bootstrap4.css",
                "~/Content/Dashboard/vendor/datatables/dataTables.bootstrap4.min.css"));

            bundles.Add(new ScriptBundle("~/dashboard/styles").Include(
                "~/Content/Dashboard/vendor/fontawesome-free/css/all.min.css",
                "~/Content/Dashboard/css/font.css",
                "~/Content/Dashboard/css/sb-admin-2.min.css"));

            bundles.Add(new ScriptBundle("~/dashboard/scripts").Include(
                "~/Content/Dashboard/vendor/jquery/jquery.min.js",
                "~/Content/Dashboard/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/Dashboard/vendor/jquery-easing/jquery.easing.min.js",
                "~/Content/Dashboard/js/sb-admin-2.min.js"));

            bundles.Add(new StyleBundle("~/bundle/mainStyles").Include(
                "~/Content/css/bootstrap.min.css",
                "~/Content/style.css",
                "~/Content/css/versions.css",
                "~/Content/css/responsive.css",
                "~/Content/css/custom.css",
                "~/Content/toastr.css",
                "~/Content/toastr.min.css"));

            bundles.Add(new ScriptBundle("~/bundle/mainScripts").Include(
                "~/Content/js/all.js",
                "~/Content/js/tippy.all.min.js",
                "~/Content/js/custom.js",
                "~/Content/js/jquery.ba-cond.min.js",
                "~/Content/js/jquery.slitslider.js"));
        }
    }
}
