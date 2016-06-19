using System.Web.Optimization;

namespace PM.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                "~/Scripts/bootstrap/bootstrap.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/common/js").Include(
                "~/Scripts/common-scripts.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
                "~/Scripts/jquery/jquery.js",
                "~/Scripts/jquery/jquery-ui-1.9.2.custom.min.js",
                "~/Scripts/jquery/jquery-ui.touch-punch.min.js",
                "~/Scripts/jquery/jquery.dcjqaccordion.2.7.js",
                "~/Scripts/jquery/jquery.scrollTo.min.js",
                "~/Scripts/jquery/jquery.nicescroll.js"
                ));


            bundles.Add(new StyleBundle("~/Content/landing-page/css").Include(
                "~/Content/landing.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/site-style/css").Include(
                "~/Content/style.css",
                "~/Content/style-responsive.css"));

        }
            
    }
}