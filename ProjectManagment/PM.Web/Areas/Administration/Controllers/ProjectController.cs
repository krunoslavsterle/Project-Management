using PM.Common;
using PM.Common.Extensions;
using PM.Model.Common;
using PM.Service.Common;
using PM.Web.Controllers;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using PM.Web.Administration.Project;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using PM.Web.Infrastructure;

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
        private readonly IPMUserStore userStore;
        private readonly ILookupService lookupService;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="projectService">The project service.</param>
        /// <param name="identityService">The identity service.</param>
        public ProjectController(IMapper mapper, IProjectService projectService, IPMUserStore userStore, ILookupService lookupService)
            : base(mapper)
        {
            this.projectService = projectService;
            this.userStore = userStore;
            this.lookupService = lookupService;
        }

        #endregion Constructors

        #region Actions

        /// <summary>
        /// Projects async GET action.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Projects")]
        public async Task<ViewResult> ProjectsAsync()
        {
            var domainList = await projectService.GetProjectsAsync();
            var vmProjects = Mapper.Map<IEnumerable<ProjectPreviewViewModel>>(domainList);
            var vm = new ProjectsViewModel();
            vm.Projects = vmProjects;

            return View("Projects", vm);
        }
        
        /// <summary>
        /// New project async POST action.
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync(CreateProjectViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = await userStore.FindByIdAsync(UserId);
                var domainProject = projectService.CreateProject();
                Mapper.Map<CreateProjectViewModel, IProjectPoco>(vm, domainProject);
                domainProject.ProjectLeaderId = user.Id;
                domainProject.CompanyId = user.CompanyId;

                try
                {
                    await this.projectService.InsertProjectAsync(domainProject);
                    var domainList = await projectService.GetProjectsAsync();
                    var vmProjects = Mapper.Map<IEnumerable<ProjectPreviewViewModel>>(domainList);

                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(new { success = true, responseText = "Project is added successfuly.", html = this.RenderView("_ProjectsList", vmProjects) }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    SetErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong");
                }
            }
            else
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return PartialView("_NewProjectModal", vm);
        }

        /// <summary>
        /// Project async GET action.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Overview")]
        public async Task<ViewResult> OverviewAsync(string pId)
        {
            if (String.IsNullOrEmpty(pId))
                throw new Exception("The parameter [pId] is null or empty.");

            Guid projectId = ShortGuid.Decode(pId);                  
            var project = await projectService.GetProjectAsync(projectId,
                this.ToNavPropertyString(nameof(IProjectPoco.Tasks)));

            var vmProject = Mapper.Map<ProjectPreviewViewModel>(project);
            var resolvedStatus = lookupService.GetAllTaskStatus().First(p => p.Abrv == "RESOLVED");

            var vm = new OverviewViewModel();
            vm.Project = vmProject;
            vm.Project.TaskCount = project.Tasks.Count;
            vm.Project.LateTaskCount = project.Tasks.Where(p => p.DueDate <= DateTime.UtcNow).Count();
            vm.Project.CompletedTaskCount = project.Tasks.Where(p => p.StatusId == resolvedStatus.Id).Count();

            ViewBag.Title = project.Name;
            ViewBag.ProjectId = projectId;

            return View("Overview", vm);
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

        #endregion Actions
    }
}