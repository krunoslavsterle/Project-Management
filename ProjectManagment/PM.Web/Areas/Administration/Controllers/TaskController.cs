using PM.Common;
using PM.Model.Common;
using PM.Service.Common;
using PM.Web.Administration.Models;
using PM.Web.Areas.Administration.Models;
using PM.Web.Controllers;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using PM.Common.Extensions;
using PM.Web.Administration.Task;
using System.Collections;
using System.Collections.Generic;

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

        #region Methods

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

            Guid projectId = ShortGuid.Decode(pId);
            var project = await projectService.GetProjectAsync(projectId, 
                this.ToNavPropertyString(nameof(IProjectPoco.ProjectUsers), this.ToNavPropertyString(nameof(IProjectUserPoco.User))), 
                this.ToNavPropertyString(nameof(IProjectPoco.Tasks)));

            var priorities = lookupService.GetAllTaskPriority();
            var statuses = lookupService.GetAllTaskStatus();
            var projectUsers = project.ProjectUsers.Select(p => p.User);

            var vm = new ListViewModel()
            {
                ProjectName = project.Name,
                ProjectId = projectId,
                Tasks = Mapper.Map<IEnumerable<TaskDTO>>(project.Tasks),
                TaskPriorityList = priorities.ToDictionary(p => p.Id, d => d.Name),
                TaskStatusList = statuses.ToDictionary(p => p.Id, d => d.Name),
                ProjectUsersList = projectUsers.ToDictionary(p => p.Id, d => d.UserName)
            };
            
            return View("List", vm);
        }

        /// <summary>
        /// NewAsync GET action.
        /// </summary>
        /// <param name="pId">The product short guid.</param>
        /// <exception cref="System.Exception">The parameter [pId] is null or empty.</exception>
        [HttpGet]
        [ActionName("New")]
        public async Task<ActionResult> NewAsync(string pId)
        {
            if (String.IsNullOrEmpty(pId))
                throw new Exception("The parameter [pId] is null or empty.");

            Guid projectId = ShortGuid.Decode(pId);
            var priorities = lookupService.GetAllTaskPriority();
            var statuses = lookupService.GetAllTaskStatus();

            var vm = new CreateTaskViewModel();
            vm.CreatedByUserId = UserId;
            vm.PriorityList = new SelectList(priorities, "Id", "Name", vm.PriorityId);
            vm.StatusList = new SelectList(statuses, "Id", "Name", vm.StatusId);
            vm.ProjectId = projectId;

            //ViewBag.ProjectName = project.Name;
            //ViewBag.ProjectId = project.Id;

            return View("New", vm);
        }

        /// <summary>
        /// NewAsync POST action.
        /// </summary>
        /// <param name="vm">The view model.</param>
        [HttpPost]
        [ActionName("New")]
        public async Task<ActionResult> NewAsync(CreateTaskViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.AssignedToUserId = UserId; // temp solution.
                var domain = Mapper.Map<ITaskPoco>(vm);
                try
                {
                    await taskService.InsertTaskAsync(domain);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return RedirectToAction("List", new { pId = ShortGuid.Encode(vm.ProjectId) });
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


        #endregion Methods
    }
}