using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;
using PM.Common;
using PM.Common.Extensions;
using PM.Model.Common;
using PM.Service.Common;
using PM.Web.Administration.Task;
using PM.Web.Controllers;
using PM.Web.Infrastructure;

namespace PM.Web.Areas.Administration.Controllers
{
    /// <summary>
    /// Task controller.
    /// </summary>
    /// <seealso cref="PM.Web.Controllers.BaseController" />
    [Authorize]
    public class TaskController : BaseController
    {
        #region Fields

        private readonly ITaskService taskService;
        private readonly ILookupService lookupService;
        private readonly IProjectService projectService;

        #endregion Fields

        #region Constructors
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="userStore">The user store.</param>
        /// <param name="taskService">The task service.</param>
        /// <param name="projectService">The project service.</param>
        /// <param name="lookupService">The lookup service.</param>
        public TaskController(IMapper mapper, IPMUserStoreService userStore, ITaskService taskService, IProjectService projectService, ILookupService lookupService) 
            : base(mapper, userStore)
        {
            this.taskService = taskService;
            this.projectService = projectService;
            this.lookupService = lookupService;
        }

        #endregion Constructors
        
        #region Actions

        /// <summary>
        /// Task list GET action.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns>View.</returns>
        [HttpGet]
        [ActionName("List")]
        public async Task<ActionResult> ListAsync(string pId)
        {
            if (String.IsNullOrEmpty(pId))
                throw new Exception("The parameter [pId] is null or empty.");

            var vm = await GetListViewModelPaged(new PagingParameters(1, 9), ShortGuid.Decode(pId));
            return View("List", vm);
        }

        /// <summary>
        /// Tasks list GET action.
        /// </summary>
        /// <param name="pId">Project short guid.</param>
        /// <param name="page">Page number.</param>
        /// <returns>Partial view.</returns>
        [HttpGet]
        [ActionName("TasksList")]
        public async Task<ViewResult> TasksListAsync(string pId, int page = 1)
        {
            if (String.IsNullOrEmpty(pId))
                throw new Exception("The parameter [pId] is null or empty.");

            var vm = await GetListViewModelPaged(new PagingParameters(page, 9), ShortGuid.Decode(pId));
            return View("_TasksList", vm.Tasks);
        }
        
        /// <summary>
        /// New project async POST action.
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync(CreateTaskViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var domainTask = taskService.Create();
                Mapper.Map<CreateTaskViewModel, ITaskPoco>(vm, domainTask);
                domainTask.CreatedByUserId = UserId;
                domainTask.StatusId = lookupService.GetAllTaskStatus().First(p => p.Abrv == "NEW").Id;

                try
                {
                    await this.taskService.InsertTaskAsync(domainTask);
                    var projectVm = await GetListViewModelPaged(new PagingParameters(1, 9), vm.ProjectId);

                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(new { success = true, responseText = "Task is added successfuly.", html = this.RenderView("_TasksList", projectVm.Tasks, ViewData) }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    SetErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong");
                }
            }
            else
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return PartialView("_NewTaskModal", vm);
        }

        /// <summary>
        /// Edit GET action.
        /// </summary>
        /// <param name="tId">The task short guid.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">The parameter [tId] is null or empty.</exception>
        [HttpGet]
        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string tId)
        {
            if (String.IsNullOrEmpty(tId))
                throw new Exception("The parameter [tId] is null or empty.");

            var task = await taskService.GetTaskAsync(ShortGuid.Decode(tId), this.ToNavPropertyString(nameof(ITaskPoco.TaskComments)));
            if (task.TaskComments != null && task.TaskComments.Count() > 0)
                task.TaskComments = task.TaskComments.OrderBy(p => p.DateUpdated);

            var project = await projectService.GetProjectAsync(task.ProjectId,
                this.ToNavPropertyString(nameof(IProjectPoco.ProjectUsers), this.ToNavPropertyString(nameof(IProjectUserPoco.User))));
                
            var vm = Mapper.Map<EditTaskViewModel>(task);

            SetEditActionViewBags(project);
            return View("Edit", vm);
        }

        /// <summary>
        /// Edit POST action.
        /// </summary>
        /// <param name="vm">The view model.</param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(EditTaskViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var domain = await taskService.GetTaskAsync(vm.Id);
                Mapper.Map<EditTaskViewModel, ITaskPoco>(vm, domain);
                domain.DateUpdated = DateTime.UtcNow;

                try
                {
                    await taskService.UpdateTaskAsync(domain);
                    var project = await projectService.GetProjectAsync(domain.ProjectId,
                        this.ToNavPropertyString(nameof(IProjectPoco.ProjectUsers), this.ToNavPropertyString(nameof(IProjectUserPoco.User))));

                    domain = await taskService.GetTaskAsync(domain.Id);
                    vm = Mapper.Map<EditTaskViewModel>(domain);
                    SetEditActionViewBags(project);

                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(new { success = true, responseText = "Task updated successfuly.", html = this.RenderView("_EditTask", vm, this.ViewData) }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    SetErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong");
                }
            }
            else
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return Json(new { success = false, responseText = "Task has not been updated successfuly." }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName("Comment")]
        [ValidateInput(false)]
        public async Task<ActionResult> CommentAsync(Guid taskId, string comment)
        {
            var domain = taskService.CreateTaskComment();
            domain.Text = comment;
            domain.TaskId = taskId;
            domain.UserId = this.UserId;

            try
            {
                await taskService.InsertTaskCommentAsync(domain);
                var comments = await taskService.GetTaskCommentAsync(p => p.TaskId == taskId);
                comments = comments.OrderBy(p => p.DateUpdated);

                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new { success = true, responseText = "Comment saved successfully.", html = this.RenderView("_CommentsList", Mapper.Map<IEnumerable<TaskCommentDTO>>(comments)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Actions

        #region Methods

        private async Task<ListViewModel> GetListViewModelPaged(IPagingParameters pagingParameters, Guid projectId)
        {
            var project = await projectService.GetProjectAsync(projectId,
                this.ToNavPropertyString(nameof(IProjectPoco.ProjectUsers), nameof(IProjectUserPoco.User)));

            var tasks = await GetTasksListPaged(pagingParameters, projectId);
            var vm = new ListViewModel()
            {
                ProjectName = project.Name,
                ProjectId = project.Id,
                Tasks = tasks
            };

            SetListActionViewBags(project);
            return vm;
        }

        private async Task<IPagedList<TaskDTO>> GetTasksListPaged(IPagingParameters pagingParameters, Guid projectId)
        {
            var sortingParameters = new SortingParameters();
            sortingParameters.Add("DateUpdated", false);
            var tasks = await taskService.GetTasksPagedAsync(pagingParameters, p => p.ProjectId == projectId, sortingParameters,
                this.ToNavPropertyString(nameof(ITaskPoco.AssignedToUser)),
                this.ToNavPropertyString(nameof(ITaskPoco.TaskComments)));

            var vm = new StaticPagedList<TaskDTO>(Mapper.Map<IEnumerable<TaskDTO>>(tasks.ToList()), pagingParameters.PageNumber, pagingParameters.PageSize, tasks.TotalItemCount);
            return vm;
        }

        private void SetListActionViewBags(IProjectPoco projectWithUsers)
        {
            var projectUsers = projectWithUsers.ProjectUsers.Select(p => p.User);
            ViewBag.PId = ShortGuid.Encode(projectWithUsers.Id);
            ViewBag.ProjectUsers = projectUsers.ToDictionary(p => p.Id, d => d.UserName);
            ViewBag.PriorityList = lookupService.GetAllTaskPriority().ToDictionary(p => p.Id, d => d.Name);
            ViewBag.StatusList = lookupService.GetAllTaskStatus().ToDictionary(p => p.Id, d => d.Name);
        }

        private void SetEditActionViewBags(IProjectPoco projectWithUsers)
        {
            ViewBag.ProjectName = projectWithUsers.Name;
            ViewBag.ProjectUsers = projectWithUsers.ProjectUsers.Select(p => p.User).ToDictionary(p => p.Id, d => d.UserName);
            ViewBag.PriorityList = lookupService.GetAllTaskPriority().ToDictionary(p => p.Id, d => d.Name);
            ViewBag.StatusList = lookupService.GetAllTaskStatus().OrderBy(d => d.SortOrder);
        }
        
        #endregion Methods
    }
}