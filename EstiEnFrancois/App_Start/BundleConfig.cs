using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace EstiEnFrancois
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/vendor").Include(
                "~/Scripts/Vendor/*.js"));

            bundles.Add(new Bundle("~/bundles/site")
                .Include("~/Scripts/index.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Styles/Vendor/*.css",
                      "~/Content/Styles/style.css"));
        }
    }
}