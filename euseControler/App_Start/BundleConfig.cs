using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace euseControler
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Home style
            bundles.Add(new StyleBundle("~/bundles/main/css").Include(
                      "~/Content/css/style.css", new CssRewriteUrlTransform()));

             // Animate.css
             bundles.Add(new StyleBundle("~/bundles/animate/css").Include(
                       "~/Content/themes/StyleSheet1.css"));
           
            // Pe-icon-7-stroke
            bundles.Add(new StyleBundle("~/bundles/peicon7stroke/css").Include(
                      "~/Content/css/pe-icon-7-stroke.css", new CssRewriteUrlTransform()));

            /*bundles.Add(new StyleBundle("~/bundles/peicon7stroke/css/helper").Include(
                     "~/Content/pe-icons/helper.css", new CssRewriteUrlTransform()));*/

            bundles.Add(new StyleBundle("~/bundles/peicon7stroke/css/style").Include(
                     "~/Content/css/style.css", new CssRewriteUrlTransform()));

            // Bootstrap style
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                      "~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));

            /* // Font Awesome icons style
             bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include(
                       "~/Content/css/materialdesignicons.min.css", new CssRewriteUrlTransform()));*/
            /* //Toaster
             bundles.Add(new StyleBundle("~/bundles/toaster/css").Include(
                       "~/Vendors/toastr/toastr.min.css", new CssRewriteUrlTransform()));
             //DataTables
             bundles.Add(new StyleBundle("~/bundles/datatables/css").Include(
                 "~/Vendors/datatables/datatables.min.css", new CssRewriteUrlTransform()));*/

            // Bootstrap
            bundles.Add(new Bundle("~/bundles/bootstrap/js").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new Bundle("~/bundles/bootstrap2/js").Include(
                       "~/Scripts/bootstrap.min.js"));

            // jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
                      "~/Scripts/jquery-3.6.3.min.js"));

            // Unobtrusive           
            bundles.Add(new ScriptBundle("~/bundles/unobtrusive/js").Include(
                      "~/Content/js/jquery.easing.min.js"));

            // Pace
            /* bundles.Add(new ScriptBundle("~/bundles/pace/js").Include(
                       "~/Content/js/pace.min.js"));*/

            /*// Luna
            bundles.Add(new ScriptBundle("~/bundles/app/js").Include(
                      "~/Content/js/app.js"));*/

            //*****
            // jQuery Validation
            bundles.Add(new ScriptBundle("~/bundles/validation/js").Include(
                      "~/Scripts/jquery.validate.min.js"));
            /*
            //Toaster
            bundles.Add(new ScriptBundle("~/bundles/toaster/js").Include(
                     "~/Vendors/toastr/toastr.min.js"));

            //DataTables
            bundles.Add(new ScriptBundle("~/bundles/datatables/js").Include(
                "~/Vendors/datatables/datatables.min.js"));*/
        }
    }
}