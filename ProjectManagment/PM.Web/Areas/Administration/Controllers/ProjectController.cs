using PM.Common;
using PM.Model.Common;
using PM.Service.Common;
using PM.Web.Areas.Administration.Models;
using PM.Web.Controllers;
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
        public Task<ViewResult> ProjectsAsync()
        {
            return Task.FromResult(View());
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

        #endregion Methods
    }
}