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
using PM.Common.Clients;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using PagedList;

namespace PM.Web.Areas.Administration.Controllers
{
    /// <summary>
    /// User controller.
    /// </summary>
    [Authorize]
    public class UserController : BaseController
    {
        #region Fields

        private readonly ILookupService lookupService;
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
        public UserController(IMapper mapper, IPMUserStoreService userStore, ILookupService lookupService)
            : base(mapper, userStore)
        {
            this.lookupService = lookupService;
            this.userManager = new UserManager<IUserPoco, Guid>(userStore);

            var provider = Startup.DataProtectionProvider;
            this.userManager.UserTokenProvider = new DataProtectorTokenProvider<IUserPoco, Guid>(provider.Create("EmailConfirmation"));
        }

        #endregion Constructors

        #region Actions

        /// <summary>
        /// Index GET action.
        /// </summary>
        /// <returns>View.</returns>
        [HttpGet]
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var user = await userManager.FindByIdAsync(UserId);
            var vm = new IndexUserViewModel()
            {
                Users = await GetUsersListViewModelsPaged(new PagingParameters(1, 9), user.CompanyId)
            };
            return View("Index", vm);
        }

        /// <summary>
        /// User list GET action.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <returns>Partial view.</returns>
        [HttpGet]
        [ActionName("UsersList")]
        public async Task<ViewResult> UsersListAsync(int page = 1)
        {
            var user = await userManager.FindByIdAsync(UserId);
            var vm = await GetUsersListViewModelsPaged(new PagingParameters(page, 9), user.CompanyId);
            return View("_UsersList", vm);
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
                var newUser = UserStore.CreateUser();
                newUser.CompanyId = CompanyId;
                newUser.UserName = vm.UserName;
                newUser.Email = vm.Email;

                try
                {
                    var created = await userManager.CreateAsync(newUser, GenerateTempPassword(7));
                    if (created.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newUser.Id, "User");

                        // Send confirmation email.
                        var code = await userManager.GenerateEmailConfirmationTokenAsync(newUser.Id);
                        var url = Url.Action("ActivateAccount", "Security", new { area = "", userId = newUser.Id, code = code }, protocol: Request.Url.Scheme);
                        using (var emailClient = new EmailClient())
                        {
                            await emailClient.SendEmail("Confirm PM Account", "<p>Please confirm your account by clicking this link: <a href=\"" + url + "\">link</a></p>", newUser.Email);
                        }

                        // TODO: PUT THIS IN THE BASE CONTROLLER.
                        var users = await UserStore.GetUsersByCompanyIdAsync(CompanyId, this.ToNavPropertyString(nameof(IUserPoco.UserRoles), nameof(IUserRolePoco.Role)));
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

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return PartialView("_NewUserModal", vm);
        }

        #endregion Actions

        #region Methods

        private async Task<IPagedList<UserPreviewViewModel>> GetUsersListViewModelsPaged(IPagingParameters pagingParameters, Guid companyId)
        {
            var sortingParameters = new SortingParameters();
            sortingParameters.Add("DateCreated", false);

            var users = await UserStore.GetUsersByCompanyIdPagedAsync(pagingParameters, sortingParameters, companyId,
                this.ToNavPropertyString(nameof(IUserPoco.UserRoles), nameof(IUserRolePoco.Role)));

            return new StaticPagedList<UserPreviewViewModel>(Mapper.Map<IEnumerable<UserPreviewViewModel>>(users.ToList()), pagingParameters.PageNumber, pagingParameters.PageSize, users.TotalItemCount);
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