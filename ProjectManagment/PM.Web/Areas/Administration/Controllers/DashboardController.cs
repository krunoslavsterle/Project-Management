using PM.Common;
using PM.Common.Enums;
using PM.Web.Areas.Administration.Models;
using PM.Web.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
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

        #region Actions

        [HttpGet]
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var vm = await GetMockDashboard();
            return View("Dashboard", vm);
        }

        #endregion Actions

        private Task<DashboardViewModel> GetMockDashboard()
        {
            IList<DashboardActivityDTO> activities = new List<DashboardActivityDTO>();
            activities.Add(new DashboardActivityDTO()
            {
                ActivityText = "jdoe has change Ksterle role to: Adminstrator",
                ActivityType = ActivityType.Profile,
                Magnitude = ActivityMagnitude.Medium,
                AuthorUsername = "jdoe",
                DateCreated = DateTime.UtcNow.AddDays(-1)
            });

            activities.Add(new DashboardActivityDTO()
            {
                ActivityText = "jdoe has changed changed task #3245 status to: In progress",
                ActivityType = ActivityType.Task,
                Magnitude = ActivityMagnitude.Low,
                AuthorUsername = "jdoe",
                DateCreated = DateTime.UtcNow.AddDays(-3)
            });

            var dashboard = new DashboardViewModel()
            {
                UserName = "Denise Watson",
                UserTitle = "Web Developer",
                NumOfProjects = 23,
                NumOfTasks = 121,
                Activities = activities
            };

            return Task.FromResult(dashboard);
        }
    }
}