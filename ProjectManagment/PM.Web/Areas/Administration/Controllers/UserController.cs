using PM.Common;
using PM.Service.Common;
using PM.Web.Controllers;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;
using Microsoft.AspNet.Identity;
using PM.Web.Identity;
using PM.Web.Administration.User;
using System.Net;
using PM.Web.Infrastructure;
using System.Collections;
using System.Collections.Generic;

namespace PM.Web.Areas.Administration.Controllers
{
    /// <summary>
    /// User controller.
    /// </summary>
    public class UserController : BaseController
    {
        #region Fields

        private readonly IIdentityService identityService;
        private readonly ILookupService lookupService;
        private readonly IProjectService projectService;
        private readonly UserManager<IdentityUser, Guid> userManager;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="identityService">The identity service.</param>
        /// <param name="lookupService">The lookup service.</param>
        /// <param name="userManager">The user manager.</param>
        public UserController(IMapper mapper, IIdentityService identityService, ILookupService lookupService, UserManager<IdentityUser, Guid> userManager)
            : base(mapper)
        {
            this.identityService = identityService;
            this.lookupService = lookupService;
            this.userManager = userManager;
        }

        #endregion Constructors

        #region Actions

        /// <summary>
        /// Index GET action.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            // TODO: PUT THIS IN THE BASE CONTROLLER.
            var user = await identityService.GetUserById(UserId);
            var users = await identityService.GetUsersByCompanyId(user.CompanyId, "Roles");

            // List of users
            var vm = new IndexUserViewModel();
            vm.Users = Mapper.Map<IEnumerable<UserPreviewViewModel>>(users);
            return View("Index", vm);
        }
        
        /// <summary>
        /// Create POST action.
        /// </summary>
        /// <param name="vm">The view model.</param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync(CreateUserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var role = lookupService.GetAllRoles().First(p => p.Name == "User");
                var user = await identityService.GetUserById(UserId);

                var domain = new IdentityUser()
                {
                    Id = Guid.NewGuid(),
                    CompanyId = user.CompanyId,
                    UserName = vm.UserName,
                    Email = vm.Email
                };

                try
                {
                    var newUser = await userManager.CreateAsync(domain, GenerateTempPassword(7));
                    if (newUser.Succeeded)
                    {
                        await InsertUserToRole(domain.Id, role.RoleId);

                        // TODO: PUT THIS IN THE BASE CONTROLLER.
                        var users = await identityService.GetUsersByCompanyId(user.CompanyId, "Roles");
                        var usersVm = Mapper.Map<IEnumerable<UserPreviewViewModel>>(users);

                        Response.StatusCode = (int)HttpStatusCode.OK;
                        return Json(new { success = true, responseText = "User is created successfuly.", html = this.RenderView("_UsersList", usersVm) }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    SetErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong");
                }
            }
            else
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return PartialView("_NewUserModal", vm);
        }

        #endregion Actions

        #region Methods

        private Task InsertUserToRole(Guid userId, Guid roleId)
        {
            var userRole = identityService.CreateUserRole();
            userRole.RoleId = roleId;
            userRole.UserId = userId;

            return identityService.InsertUserRole(userRole);
        }

        private string GenerateTempPassword(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        #endregion 
    }
}