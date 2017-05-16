using PM.Common;
using PM.Model.Common;
using PM.Service.Common;
using PM.Web.Administration.Models;
using PM.Web.Controllers;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using PM.Common.Extensions;
using PM.Web.Administration.Task;
using System.Collections.Generic;
using System.Net;
using PM.Web.Infrastructure;

namespace PM.Web.Areas.Administration.Controllers
{
    /// <summary>
    /// Task controller.
    /// </summary>
    /// <seealso cref="PM.Web.Controllers.BaseController" />
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
        /// <param name="taskService">The task service.</param>
        public TaskController(IMapper mapper, ITaskService taskService, IProjectService projectService, ILookupService lookupService) 
            : base(mapper)
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
        /// <returns></returns>
        [HttpGet]
        [ActionName("List")]
        public async Task<ActionResult> ListAsync(string pId)
        {
            if (String.IsNullOrEmpty(pId))
                throw new Exception("The parameter [pId] is null or empty.");

            var project = await PrepareListActionData(ShortGuid.Decode(pId));
            var vm = new ListViewModel()
            {
                ProjectName = project.Name,
                ProjectId = project.Id,
                Tasks = Mapper.Map<IEnumerable<TaskDTO>>(project.Tasks)
            };

            return View("List", vm);
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

                    var project = await PrepareListActionData(vm.ProjectId);
                    var tasksList = Mapper.Map<IEnumerable<TaskDTO>>(project.Tasks);

                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(new { success = true, responseText = "Task is added successfuly.", html = this.RenderView("_TasksList", tasksList, ViewData) }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    SetErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong");
                }
            }
            else
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return PartialView("_NewTaskModal", vm);
        }

        [HttpGet]
        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string tId)
        {
            if (String.IsNullOrEmpty(tId))
                throw new Exception("The parameter [tId] is null or empty.");

            var priorities = lookupService.GetAllTaskPriority();
            var statuses = lookupService.GetAllTaskStatus();

            var task = await taskService.GetTaskAsync(ShortGuid.Decode(tId));
            var vm = Mapper.Map<EditTaskViewModel>(task);
            vm.PriorityList = new SelectList(priorities, "Id", "Name", vm.PriorityId);
            vm.StatusList = new SelectList(statuses, "Id", "Name", vm.StatusId);

            return View("Edit", vm);
        }

        [HttpPost]
        [ActionName("Edit")]
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
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return RedirectToAction("Edit", "Task", new { area = "Administration", tId = ShortGuid.Encode(vm.Id) });
        }

        #endregion Actions

        #region Methods

        private async Task<IProjectPoco> PrepareListActionData(Guid projectId)
        {
            var project = await projectService.GetProjectAsync(projectId,
                this.ToNavPropertyString(nameof(IProjectPoco.ProjectUsers), this.ToNavPropertyString(nameof(IProjectUserPoco.User))),
                this.ToNavPropertyString(nameof(IProjectPoco.Tasks), this.ToNavPropertyString(nameof(ITaskPoco.AssignedToUser))));

            // Set dropdown collections.
            var projectUsers = project.ProjectUsers.Select(p => p.User);
            ViewBag.ProjectUsers = projectUsers.ToDictionary(p => p.Id, d => d.UserName);
            ViewBag.PriorityList = lookupService.GetAllTaskPriority().ToDictionary(p => p.Id, d => d.Name);
            ViewBag.StatusList = lookupService.GetAllTaskStatus().ToDictionary(p => p.Id, d => d.Name);

            return project;
        }

        #endregion Methods
    }
}