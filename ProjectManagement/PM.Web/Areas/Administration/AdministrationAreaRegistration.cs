using System.Web.Mvc;

namespace PM.Web.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administration_dashboard",
                "Administration/Dashboard",
                new { controller = "Dashboard", action = "Index"}
            );

            context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}",
                new { action = "Projects", id = UrlParameter.Optional }
            );
        }
    }
}