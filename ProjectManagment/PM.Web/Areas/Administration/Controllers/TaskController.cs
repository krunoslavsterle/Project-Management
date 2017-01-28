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
        #region Fields

        private readonly ITaskService taskService;
        private readonly ILookupService lookupService;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="taskService">The task service.</param>
        public TaskController(IMapper mapper, ITaskService taskService, ILookupService lookupService) 
            : base(mapper)
        {
            this.taskService = taskService;
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
            var tasks = await taskService.GetTasksAsync(p => p.ProjectId == projectId);
            var priorities = lookupService.GetAllTaskPriority();
            var vm = new TaskViewModel();
            vm.ProjectId = projectId;
            vm.Tasks = tasks;

            //var project = await ProjectService.GetProjectAsync(projectId);
            //ViewBag.ProjectName = project.Name;
            //ViewBag.ProjectId = project.Id;

            // TODO: IMPLEMENT USING VIEW MODELS.
            return View("List", vm);
        }

        //[HttpGet]
        //[ActionName("New")]
        //public async Task<ActionResult> NewAsync(Guid projectId)
        //{
        //    var project = await ProjectService.GetProjectAsync(projectId);
        //    var vm = new CreateTaskViewModel();
        //    vm.ProjectId = projectId;
        //    vm.OwnerId = UserId;

        //    ViewBag.ProjectName = project.Name;
        //    ViewBag.ProjectId = project.Id;

        //    return View("NewTask", vm);
        //}

        #endregion Methods
    }
}