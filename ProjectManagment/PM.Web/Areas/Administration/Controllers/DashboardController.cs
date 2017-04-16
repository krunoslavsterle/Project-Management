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
    [Authorize]
    public class DashboardController : BaseController
    {
        #region Constructors

        public DashboardController(IMapper mapper)
            : base(mapper)
        {

        }

        #endregion Constructors

        #region Actions

        /// <summary>
        /// Index GET action.
        /// </summary>
        /// <returns></returns>
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

            IList<DashboardTaskDTO> tasks = new List<DashboardTaskDTO>();
            tasks.Add(new DashboardTaskDTO()
            {
                Id = Guid.NewGuid(),
                Name = "Implement Caching in Service",
                Project = "KSterle Home",
                Status = "New",
                DueDate = DateTime.Now
            });

            tasks.Add(new DashboardTaskDTO()
            {
                Id = Guid.NewGuid(),
                Name = "Implement factory pattern for DI",
                Project = "PM project",
                Status = "In Progress",
                DueDate = DateTime.Now
            });
            
            var dashboard = new DashboardViewModel()
            {
                UserName = "Denise Watson",
                UserTitle = "Web Developer",
                NumOfProjects = 23,
                NumOfTasks = 121,
                Activities = activities,
                Tasks = tasks
            };

            return Task.FromResult(dashboard);
        }
    }
}