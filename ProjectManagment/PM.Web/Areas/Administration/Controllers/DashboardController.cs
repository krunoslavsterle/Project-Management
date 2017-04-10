using PM.Common;
using PM.Web.Controllers;
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

        public ActionResult Index()
        {
            return View("Dashboard");
        }

        #endregion Methods
    }
}