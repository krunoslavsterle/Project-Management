using System.Web.Optimization;

namespace PM.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/core/js").Include(
                "~/Scripts/bootstrap/bootstrap.js",
                "~/Scripts/jquery/jquery-{version}.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/iziToast.js",
                "~/Scripts/site.js"));
            
            bundles.Add(new StyleBundle("~/Content/landing-page/css").Include(
                "~/Content/landing.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap/css").Include(
                "~/Content/bootstrap.css", 
                "~/Content/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/site-style/css").Include(
                "~/Content/site.css",
                "~/Content/iziToast.css"));
        }
            
    }
}