using System.Web.Mvc;

namespace PM.Web.Controllers
{
    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index GET action.
        /// </summary>
        /// <returns>View.</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }        
    }
}