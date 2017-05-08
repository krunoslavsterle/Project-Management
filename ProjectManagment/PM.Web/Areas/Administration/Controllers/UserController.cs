using PM.Common;
using PM.Service.Common;
using PM.Web.Controllers;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;
using Microsoft.AspNet.Identity;
using PM.Web.Administration.User;
using System.Net;
using PM.Web.Infrastructure;
using System.Collections.Generic;
using PM.Model.Common;
using PM.Common.Extensions;

namespace PM.Web.Areas.Administration.Controllers
{
    /// <summary>
    /// User controller.
    /// </summary>
    public class UserController : BaseController
    {
        #region Fields

        private readonly ILookupService lookupService;
        private readonly IPMUserStore userStore;
        private readonly UserManager<IUserPoco, Guid> userManager;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="identityService">The identity service.</param>
        /// <param name="lookupService">The lookup service.</param>
        /// <param name="userManager">The user manager.</param>
        public UserController(IMapper mapper, IPMUserStore userStore, ILookupService lookupService)
            : base(mapper)
        {
            this.lookupService = lookupService;
            this.userStore = userStore;
            this.userManager = new UserManager<IUserPoco, Guid>(userStore);
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
            var user = await userManager.FindByIdAsync(UserId);
            var users = await userStore.GetUsersByCompanyIdAsync(user.CompanyId, user.ToNavPropertyString(nameof(IUserPoco.UserRoles), nameof(IUserRolePoco.Role)));

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
                var user = await userManager.FindByIdAsync(UserId);

                var newUser = userStore.CreateUser();
                newUser.CompanyId = user.CompanyId;
                newUser.UserName = vm.UserName;
                newUser.Email = vm.Email;
                
                try
                {
                    var created = await userManager.CreateAsync(newUser, GenerateTempPassword(7));
                    if (created.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newUser.Id, "User");

                        // TODO: PUT THIS IN THE BASE CONTROLLER.
                        var users = await userStore.GetUsersByCompanyIdAsync(user.CompanyId, user.ToNavPropertyString(nameof(IUserPoco.UserRoles), nameof(IUserRolePoco.Role)));
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