using PM.Web.Administration.Models;
using System.Web.Mvc;

namespace PM.Web.Areas.Administration.Controllers
{
    public class UserController : Controller
    {
        // GET: Administration/User
        [HttpGet]
        [ActionName("Index")]
        public ActionResult IndexAsync()
        {
            // List of users
            var vm = new IndexUserViewModel();
            return View("Index", vm);
        }
    }
}