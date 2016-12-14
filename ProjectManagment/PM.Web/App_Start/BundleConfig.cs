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

            //bundles.Add(new ScriptBundle("~/bundles/core/js").Include(
            //    "~/Scripts/app.js", 
            //    "~/Scripts/core.js", 
            //    "~/Scripts/metisMenu.js", 
            //    "~/Scripts/screenfull.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
                "~/Scripts/jquery/jquery.js"
                
                ));


            bundles.Add(new StyleBundle("~/Content/landing-page/css").Include(
                "~/Content/landing.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap/css").Include(
                "~/Content/bootstrap.css", 
                "~/Content/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/site-style/css").Include(
                "~/Content/site.css" ));

        }
            
    }
}