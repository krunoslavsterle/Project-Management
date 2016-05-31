using System.Web.Optimization;

namespace PM.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
                "~/Scripts/jquery/jquery.min.js",
                "~/Scripts/jquery/jquery.nicescroll.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(               
               "~/Scripts/bootstrap/bootstrap.js",
               "~/Scripts/bootstrap/bootstrap-progressbar.min.js"               
               ));

            bundles.Add(new ScriptBundle("~/bundles/customs/js").Include(
                "~/Scripts/icheck.min.js",
                "~/Scripts/custom.js",
                "~/Scripts/nprogress.js",
                "~/Scripts/shCore.js",
                "~/Scripts/shBrushXml.js"
                ));

            bundles.Add(new StyleBundle("~/Content/bootstrap/css").Include(
                "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/theme/css").Include(
                "~/Content/animate.css",
                "~/Content/custom.css",
                "~/Content/docs.css",
                "~/Content/shCoreDefault.css"));
        }
    }
}