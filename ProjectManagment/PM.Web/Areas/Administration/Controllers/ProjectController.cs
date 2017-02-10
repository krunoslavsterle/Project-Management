using PM.Common;
using PM.Common.Filters;
using PM.Model.Common;
using PM.Service.Common;
using PM.Web.Areas.Administration.Models;
using PM.Web.Controllers;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PM.Web.Areas.Administration.Controllers
{
    /// <summary>
    /// Project controller.
    /// </summary>
    /// <seealso cref="PM.Web.Controllers.BaseController" />
    [Authorize]
    public class ProjectController : BaseController
    {
        #region Fields

        private readonly IProjectService projectService;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="projectService">The project service.</param>
        public ProjectController(IMapper mapper, IProjectService projectService)
            : base(mapper)
        {
            this.projectService = projectService;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Projects async GET action.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Projects")]
        public async Task<ViewResult> ProjectsAsync()
        {
            var domainList = await projectService.GetProjectsAsync();
            var vm = Mapper.Map<IList<ProjectViewModel>>(domainList);

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
        [ValidateAntiForgeryToken]
        [ActionName("NewProject")]
        public async Task<ActionResult> NewProjectAsync(CreateProjectViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.OwnerId = this.UserId;

                try
                {
                    await this.projectService.InsertProjectAsync(Mapper.Map<IProjectPoco>(vm));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                return RedirectToAction("Projects");
            }

            return View("NewProject", vm);
        }

        /// <summary>
        /// Project async GET action.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Project")]
        public async Task<ViewResult> ProjectAsync(string pId)
        {
            if (String.IsNullOrEmpty(pId))
                throw new Exception("The parameter [pId] is null or empty.");

            Guid projectId = ShortGuid.Decode(pId);                  
            var project = await projectService.GetProjectAsync(projectId);

            ViewBag.Title = project.Name;
            ViewBag.ProjectId = projectId;

            return View("Project");
        }

        /// <summary>
        /// Timeline async GET action.
        /// </summary>
        /// <param name="pId">The project identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Timeline")]
        public async Task<ActionResult> TimelineAsync(string pId)
        {
            
            return View("Timeline");
        }

        #endregion Methods
    }
}