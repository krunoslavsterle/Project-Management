using PM.Common;
using PM.Common.Enums;
using PM.Common.Extensions;
using PM.Model.Common;
using PM.Service.Common;
using PM.Web.Areas.Administration.Models;
using PM.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;

namespace PM.Web.Areas.Administration.Controllers
{
    /// <summary>
    /// Dashboard controller.
    /// </summary>
    /// <seealso cref="PM.Web.Controllers.BaseController" />
    [Authorize]
    public class DashboardController : BaseController
    {
        #region Fields

        private readonly IProjectService projectService;
        private readonly ILookupService lookupService;

        #endregion Fields

        #region Constructors

        public DashboardController(IMapper mapper, IProjectService projectService, IPMUserStoreService userStore, ILookupService lookupService)
            : base(mapper, userStore)
        {
            this.projectService = projectService;
            this.lookupService = lookupService;
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
            var user = await this.UserStore.GetUserAsync(p => p.Id == UserId,
                this.ToNavPropertyString(nameof(IUserPoco.ProjectUsers), nameof(IProjectUserPoco.Project), nameof(IProjectPoco.Tasks)));

            var projects = user.ProjectUsers.Select(p => p.Project).ToList();
            var tasks = projects.SelectMany(p => p.Tasks);

            var vm = new DashboardViewModel()
            {
                UserName = user.UserName,
                UserTitle = "Project Manager",
                NumOfProjects = projects.Count(),
                NumOfTasks = tasks.Count(),
                Tasks = Mapper.Map<IEnumerable<DashboardTaskDTO>>(tasks),
                Activities = GetMockDashboard(),
                Statuses = lookupService.GetAllTaskStatus().ToDictionary(key => key.Id, value => value.Name)
            };
            

            return View("Dashboard", vm);
        }

        #endregion Actions

        private IList<DashboardActivityDTO> GetMockDashboard()
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
            
            return activities;
        }
    }
}