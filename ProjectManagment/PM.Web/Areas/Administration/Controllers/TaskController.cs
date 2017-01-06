using PM.Common;
using PM.Service.Common;
using PM.Web.Areas.Administration.Models;
using PM.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PM.Web.Areas.Administration.Controllers
{
    /// <summary>
    /// Task controller.
    /// </summary>
    /// <seealso cref="PM.Web.Controllers.BaseController" />
    public class TaskController : BaseController
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="projectService">The project service.</param>
        public TaskController(IMapper mapper, IProjectService projectService) 
            : base(mapper)
        {
            this.ProjectService = projectService;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the project service.
        /// </summary>
        /// <value>
        /// The project service.
        /// </value>
        protected IProjectService ProjectService { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Task list GET action.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("List")]
        public async Task<ActionResult> ListAsync()
        {
            //var project = await ProjectService.GetProjectAsync(projectId);
            //ViewBag.ProjectName = project.Name;
            //ViewBag.ProjectId = project.Id;

            return View("List");
        }

        [HttpGet]
        [ActionName("New")]
        public async Task<ActionResult> NewAsync(Guid projectId)
        {
            var project = await ProjectService.GetProjectAsync(projectId);
            var vm = new CreateTaskViewModel();
            vm.ProjectId = projectId;
            vm.OwnerId = UserId;

            ViewBag.ProjectName = project.Name;
            ViewBag.ProjectId = project.Id;

            return View("NewTask", vm);
        }

        #endregion Methods
    }
}