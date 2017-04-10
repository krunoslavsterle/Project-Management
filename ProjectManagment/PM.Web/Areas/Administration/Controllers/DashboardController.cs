using PM.Common;
using PM.Web.Areas.Administration.Models;
using PM.Web.Controllers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PM.Web.Areas.Administration.Controllers
{
    /// <summary>
    /// Dashboard controller.
    /// </summary>
    /// <seealso cref="PM.Web.Controllers.BaseController" />
    public class DashboardController : BaseController
    {
        #region Constructors

        public DashboardController(IMapper mapper)
            : base(mapper)
        {

        }

        #endregion Constructors

        #region Methods

        [HttpGet]
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var vm = await GetMockDashboard();
            return View("Dashboard", vm);
        }

        #endregion Methods

        private Task<DashboardViewModel> GetMockDashboard()
        {
            var dashboard = new DashboardViewModel()
            {
                UserName = "Denise Watson",
                UserTitle = "Web Developer",
                NumOfProjects = 23,
                NumOfTasks = 121
            };

            return Task.FromResult(dashboard);
        }
    }
}