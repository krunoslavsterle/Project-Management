using System.Web.Optimization;

namespace PM.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts

            bundles.Add(new ScriptBundle("~/bundles/core/js").Include(
                "~/Scripts/bootstrap/bootstrap.js",
                "~/Scripts/jquery/jquery-{version}.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/moment.min.js",
                "~/Scripts/iziToast.js",
                "~/Scripts/site.js"));

            bundles.Add(new ScriptBundle("~/bundles/chart/js").Include(
                "~/Scripts/Chart.js"));

            bundles.Add(new ScriptBundle("~/bundles/task-edit/js").Include(
                "~/Scripts/summernote.js",
                "~/Scripts/datepicker.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datepicker/js").Include(
                "~/Scripts/datepicker.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/ui-slider/js").Include(
                "~/Scripts/noUiSlider/nouislider.min.js"));

            #endregion Scripts

            #region CSS

            bundles.Add(new StyleBundle("~/Content/landing-page/css").Include(
                "~/Content/landing.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/site-style/css").Include(
                "~/Content/site.css",
                "~/Content/iziToast.css"));

            bundles.Add(new StyleBundle("~/Content/task-edit/css").Include(
                "~/Content/datepicker.min.css",
                "~/Content/summernote.css"));

            bundles.Add(new StyleBundle("~/Content/datepicker/css").Include(
                "~/Content/datepicker.min.css"));

            bundles.Add(new StyleBundle("~/Content/ui-slider/css").Include(
                "~/Content/nouislider.min.css"));

            #endregion CSS
        }
    }
}