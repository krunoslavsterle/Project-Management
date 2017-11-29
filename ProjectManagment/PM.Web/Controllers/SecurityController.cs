using PM.Web.Models;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using PM.Service.Common;
using PM.Model.Common;
using PM.Common;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using System.Security.Claims;

namespace PM.Web.Controllers
{
    /// <summary>
    /// Security controller.
    /// </summary>
    public class SecurityController : Controller
    {
        #region Fields

        private readonly IMapper mapper;
        private readonly IPMUserStoreService userStore;
        private readonly UserManager<IUserPoco, Guid> userManager;
        private readonly ICompanyService companyService;

        #endregion Fields

        #region Constructors
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityController"/> class.
        /// </summary>
        /// <param name="userStore">The user store.</param>
        /// <param name="companyService">The company service.</param>
        public SecurityController(IPMUserStoreService userStore, ICompanyService companyService, IMapper mapper)
        {
            this.companyService = companyService;
            this.userStore = userStore;
            this.mapper = mapper;
            this.userManager = new UserManager<IUserPoco, Guid>(userStore);

            var provider = Startup.DataProtectionProvider;
            this.userManager.UserTokenProvider = new DataProtectorTokenProvider<IUserPoco, Guid>(provider.Create("EmailConfirmation"));
        }

        #endregion Constructors

        #region Properties
        
        /// <summary>
        /// Gets the AuthenticationManager.
        /// </summary>
        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        #endregion Properties

        #region Actions

        /// <summary>
        /// Login async GET action.
        /// </summary>
        /// <returns>View.</returns>
        [HttpGet]
        [ActionName("Login")]
        public Task<ViewResult> LoginAsync()
        {
            return Task.FromResult(View());
        }

        /// <summary>
        /// Login async POST action.
        /// </summary>
        /// <param name="model">Login view model.</param>
        /// <returns>View.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [ActionName("Login")]
        public async Task<ActionResult> LoginAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindAsync(model.UserName, model.Password);
                if (user != null)
                {
                    await SignInAsync(user, true);
                    return RedirectToAction("Index", "Dashboard", new { area = "Administration" });
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return View(model);
        }

        /// <summary>
        /// Sign out async GET action.
        /// </summary>
        /// <returns>View.</returns>
        [HttpPost]
        [ActionName("SignOut")]
        [ValidateAntiForgeryToken]
        public Task<RedirectToRouteResult> SignOutAsync()
        {
            AuthenticationManager.SignOut();
            return Task.FromResult(RedirectToAction("Index", "Home"));
        }

        /// <summary>
        /// Register GET action.
        /// </summary>
        /// <returns>View.</returns>
        [HttpGet]
        public ViewResult Register()
        {
            return View("Register");
        }

        /// <summary>
        /// Register async POST action.
        /// </summary>
        /// <param name="model">Register view model.</param>
        /// <returns>View.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [ActionName("Register")]
        public async Task<ActionResult> RegisterAsync(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var company = companyService.Create();
                company.Name = model.CompanyName;
                company.DateCreated = DateTime.UtcNow;
                company.DateUpdated = DateTime.UtcNow;

                var user = userStore.CreateUser();
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.CompanyId = company.Id;

                bool companyCreated = false;
                try
                {
                    await companyService.InsertAsync(company);
                    companyCreated = true;

                    var result = await userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user.Id, "Administrator");

                        // Need to invalidate Company model - circular reference for AutoMapper.
                        user.Company = null;

                        await SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Dashboard", new { area = "Administration" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Faild to register user");
                    }
                }
                catch (Exception ex)
                {
                    if (companyCreated)
                        await companyService.DeleteAsync(company.Id);

                    ModelState.AddModelError("", "Faild to register user");
                }                
            }

            return View(model);
        }

        /// <summary>
        /// ActivateAccount GET action.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="code">The code.</param>
        [HttpGet]
        [AllowAnonymous]
        [ActionName("ActivateAccount")]
        public async Task<ActionResult> ActivateAccountAsync(Guid userId, string code)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");

            if (String.IsNullOrEmpty(code))
                throw new ArgumentNullException("code");

            var result = await userManager.ConfirmEmailAsync(userId, code);
            if (result.Succeeded)
            {
                var userDomain = await userManager.FindByIdAsync(userId);
                var vm = mapper.Map<RegisterViewModel>(userDomain);
                vm.CompanyName = "Test Company";
                return View("Activate", vm);
            }

            throw new Exception("The provided code is not valid for your user");
        }

        /// <summary>
        /// ActivateAccount POST action.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [ActionName("ActivateAccount")]
        public async Task<ActionResult> ActivateAccountAsync(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDomain = await userManager.FindByNameAsync(model.UserName);

                var provider = Startup.DataProtectionProvider;
                this.userManager.UserTokenProvider = new DataProtectorTokenProvider<IUserPoco, Guid>(provider.Create("PasswordReset"));

                await userManager.ResetPasswordAsync(userDomain.Id, this.userManager.GeneratePasswordResetToken(userDomain.Id), model.Password);

                await SignInAsync(userDomain, isPersistent: false);
                return RedirectToAction("Index", "Dashboard", new { area = "Administration" });
            }

            return View("Activate");
        }

        #endregion Actions

        #region Methods

        private async Task SignInAsync(IUserPoco user, bool isPersistent)
        { 
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            Session["UserEmail"] = user.Email;
            Session["CompanyId"] = user.CompanyId;

            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        #endregion Methods
    }
}