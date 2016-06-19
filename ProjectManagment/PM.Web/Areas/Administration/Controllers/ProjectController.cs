using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PM.Web.Areas.Administration.Controllers
{
    /// <summary>
    /// Project controller.
    /// </summary>
    [Authorize]
    public class ProjectController : Controller
    {
        [HttpGet]
        [ActionName("Projects")]
        public async Task<ActionResult> ProjectsAsync()
        {
            return View();
        }
    }
}