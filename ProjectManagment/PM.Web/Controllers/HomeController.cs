using System.Web.Mvc;

namespace PM.Web.Controllers
{
    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index async GET action.
        /// </summary>
        /// <returns>View.</returns>
        public ActionResult Index()
        {
            return View("Index");
        }        
    }
}