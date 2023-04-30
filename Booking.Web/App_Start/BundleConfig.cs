using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Booking.Web.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Bootstrap
            bundles.Add(new StyleBundle("~/Content/bootstrap.min.css").Include(
                      "~/Content/bootstrap.css", new CssRewriteUrlTransform()));
        }
    }
}