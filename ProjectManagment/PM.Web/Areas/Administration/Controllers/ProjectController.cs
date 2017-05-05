using PM.Common;
using PM.Model.Common;
using PM.Service.Common;
using PM.Web.Controllers;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using PM.Web.Administration.Project;
using System.Net;

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
        private readonly IIdentityService identityService;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="projectService">The project service.</param>
        /// <param name="identityService">The identity service.</param>
        public ProjectController(IMapper mapper, IProjectService projectService, IIdentityService identityService)
            : base(mapper)
        {
            this.projectService = projectService;
            this.identityService = identityService;
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
            //var domainList = await projectService.GetProjectsAsync();
            //var vm = Mapper.Map<IList<ProjectViewModel>>(domainList);

            return View("Projects");
        }
        
        /// <summary>
        /// New project async POST action.
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("CreateProject")]
        public async Task<ActionResult> CreateProjectAsync(CreateProjectViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = await identityService.GetUserById(UserId);
                var domainProject = projectService.CreateProject();
                Mapper.Map<CreateProjectViewModel, IProjectPoco>(vm, domainProject);
                domainProject.ProjectLeaderId = user.UserId;
                domainProject.CompanyId = user.CompanyId;

                try
                {
                    await this.projectService.InsertProjectAsync(domainProject);
                }
                catch (Exception ex)
                {
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return Json(new { success = false, responseText = "There was an error" }, JsonRequestBehavior.AllowGet);
                }

                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new { success = true, responseText = "Project is added successfuly." }, JsonRequestBehavior.AllowGet);
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            vm.Description = "test";
            return PartialView("_NewProjectModal", vm);
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

        #endregion Actions
    }
}