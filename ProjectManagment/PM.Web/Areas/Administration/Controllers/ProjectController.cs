using PM.Common;
using PM.Model.Common;
using PM.Service.Common;
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
    /// Project controller.
    /// </summary>
    [Authorize]
    public class ProjectController : BaseController
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectController"/> class.
        /// </summary>
        /// <param name="projectService">The project service.</param>
        public ProjectController(IMapper mapper, IProjectService projectService)
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

        [HttpGet]
        [ActionName("Projects")]
        public async Task<ViewResult> ProjectsAsync()
        {
            var domainList = await ProjectService.FindAsync(null);
            var vm = Mapper.Map <IList<ProjectViewModel>>(domainList);

            return View("Projects", vm);
        }


        /// <summary>
        /// New project async GET action.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("NewProject")]
        public Task<ViewResult> NewProjectAsync()
        {
            return Task.FromResult(View());
        }

        /// <summary>
        /// New project async POST action.
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("NewProject")]
        public async Task<ActionResult> NewProjectAsync(CreateProjectViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.OwnerId = this.UserId;
                bool isAdded = await this.ProjectService.AddAsync(Mapper.Map<IProject>(vm));

                if (isAdded)
                    return RedirectToAction("Projects");
            }

            return View("NewProject", vm);
        }

        [HttpGet]
        [ActionName("Project")]
        public async Task<ViewResult> ProjectAsync(Guid projectId)
        {
            var project = await ProjectService.GetProjectAsync(projectId);

            ViewBag.ProjectName = project.Name;
            ViewBag.ProjectId = project.Id;

            return View("Project");
        }

        #endregion Methods
    }
}