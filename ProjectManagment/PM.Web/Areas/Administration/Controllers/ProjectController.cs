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
using PM.Web.Administration.User;
using PagedList;

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
            : base(mapper, userStore)
        {
            this.projectService = projectService;
            this.lookupService = lookupService;
        }

        #endregion Constructors

        #region Actions

        /// <summary>
        /// Projects async GET action.
        /// </summary>
        /// <returns>View.</returns>
        [HttpGet]
        [ActionName("Projects")]
        public async Task<ViewResult> ProjectsAsync()
        {
            var vm = await GetProjectsViewModelAsync(new PagingParameters(1, 5));

            ViewBag.Page = 1;
            return View("Projects", vm);
        }

        /// <summary>
        /// ProjectsList async GET action.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <returns>Partial View.</returns>
        [HttpGet]
        [ActionName("ProjectsList")]
        public async Task<ViewResult> ProjectsListAsync(int page = 1)
        {
            var pagingParameters = new PagingParameters(page, 5);
            var vm = await GetProjectsViewModelAsync(pagingParameters);

            ViewBag.Page = page;
            return View("_ProjectsList", vm.Projects);
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
                var domainProject = projectService.CreateProject();
                var projectUser = projectService.CreateProjectUser();

                Mapper.Map<CreateProjectViewModel, IProjectPoco>(vm, domainProject);
                domainProject.ProjectLeaderId = this.UserId;
                domainProject.CompanyId = this.CompanyId;

                projectUser.ProjectId = domainProject.Id;
                projectUser.UserId = this.UserId;
                projectUser.ProjectRoleId = lookupService.GetAllProjectRoles().First(p => p.Abrv == "PM").Id;
                domainProject.ProjectUsers.Add(projectUser);

                try
                {
                    await this.projectService.InsertProjectAsync(domainProject);
                    var projectsVm = await GetProjectsViewModelAsync(new PagingParameters(1, 5));

                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(new { success = true, responseText = "Project is added successfuly.", html = this.RenderView("_ProjectsList", projectsVm.Projects) }, JsonRequestBehavior.AllowGet);
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
            var resolvedStatus = lookupService.GetAllTaskStatus().First(p => p.Abrv == "CLOSED");

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
        public ActionResult TimelineAsync(string pId)
        {
            if (String.IsNullOrEmpty(pId))
                throw new Exception("The parameter [pId] is null or empty.");

            return View("Timeline");
        }

        /// <summary>
        /// Team GET action.
        /// </summary>
        /// <param name="pId">The product short guid.</param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Team")]
        public async Task<ActionResult> TeamAsync(string pId)
        {
            if (String.IsNullOrEmpty(pId))
                throw new Exception("The parameter [pId] is null or empty.");

            var project = await projectService.GetProjectAsync(ShortGuid.Decode(pId),
                this.ToNavPropertyString(nameof(IProjectPoco.ProjectUsers), this.ToNavPropertyString(nameof(IProjectUserPoco.User))));

            var vm = new TeamViewModel();
            vm.ProjectId = project.Id;
            vm.ProjectName = project.Name;
            vm.ProjectUsers = Mapper.Map<IEnumerable<UserPreviewViewModel>>(project.ProjectUsers.Select(p => p.User));

            await SetTeamListViewBagAsync(vm.ProjectUsers, project.CompanyId);
            return View("Team", vm);
        }

        /// <summary>
        /// AddToTeam POST action.
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddToTeam")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddToTeamAsync(TeamViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var domain = projectService.CreateProjectUser();
                domain.ProjectId = vm.ProjectId;
                domain.UserId = vm.SelectedUserId;
                domain.ProjectRoleId = vm.SelectedProjectRoleId;

                try
                {
                    await this.projectService.InsertProjectUserAsync(domain);
                    var project = await projectService.GetProjectAsync(vm.ProjectId,
                        this.ToNavPropertyString(nameof(IProjectPoco.ProjectUsers), this.ToNavPropertyString(nameof(IProjectUserPoco.User))));

                    vm.ProjectUsers = Mapper.Map<IEnumerable<UserPreviewViewModel>>(project.ProjectUsers.Select(p => p.User));
                    await SetTeamListViewBagAsync(vm.ProjectUsers, project.CompanyId);                    

                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(new { success = true, responseText = "User is added successfuly.", html = this.RenderView("_UsersList", vm.ProjectUsers) }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    SetErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong");
                }
            }
            else
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return PartialView("_AddToTeamModal", vm);
        }

        #endregion Actions

        #region Methods

        private async Task SetTeamListViewBagAsync(IEnumerable<UserPreviewViewModel> projectUsers, Guid companyId)
        {
            var optionalUsers = await UserStore.GetUsersAsync(p => p.CompanyId == companyId);
            optionalUsers = optionalUsers.Where(p => !(projectUsers.Select(d => d.UserId).Contains(p.Id))).ToList();

            var projectRoles = lookupService.GetAllProjectRoles();

            ViewBag.OptionalUsers = new SelectList(optionalUsers, nameof(IUserPoco.Id), nameof(IUserPoco.UserName));
            ViewBag.ProjectRoles = new SelectList(projectRoles, nameof(IProjectRolePoco.Id), nameof(IProjectRolePoco.Name));
        }

        private async Task<ProjectsViewModel> GetProjectsViewModelAsync(IPagingParameters pagingParameters)
        {
            var sortingParameter = new SortingParameters();
            sortingParameter.Add(new SortingPair(nameof(IProjectPoco.DateCreated), false));
            
            var statuses = lookupService.GetAllTaskStatus();
            var domainList = await projectService.GetProjectsPagedAsync(pagingParameters, p => p.CompanyId == this.CompanyId, sortingParameter,
                        this.ToNavPropertyString(nameof(IProjectPoco.Tasks)), this.ToNavPropertyString(nameof(IProjectPoco.ProjectUsers), nameof(IProjectUserPoco.User)));

            var vmProjects = new StaticPagedList<ProjectPreviewViewModel>(Mapper.Map<IEnumerable<ProjectPreviewViewModel>>(domainList.ToList()), pagingParameters.PageNumber, pagingParameters.PageSize, domainList.TotalItemCount);
            foreach (var project in vmProjects)
            {
                var tasks = domainList.First(p => p.Id == project.Id).Tasks;
                var team = Mapper.Map<IEnumerable<UserPreviewViewModel>>(domainList.First(p => p.Id == project.Id).ProjectUsers.Select(d => d.User));

                project.TaskCount = tasks.Count();
                project.CompletedTaskCount = tasks.Where(d => d.StatusId == statuses.First(s => s.Abrv == "CLOSED").Id).Count();
                project.LateTaskCount = tasks.Where(p => p.DueDate <= DateTime.UtcNow).Count();
                project.TeamMembers = team;
            }

            var vm = new ProjectsViewModel()
            {
                Projects = vmProjects
            };
            return vm;
        }

        #endregion Methods
    }
}