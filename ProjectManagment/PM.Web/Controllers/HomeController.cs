using System.Threading.Tasks;
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
        [ActionName("Index")]
        [HttpGet]
        public Task<ViewResult> IndexAsync()
        {
            return Task.FromResult(View("Index"));
        }        
    }
}