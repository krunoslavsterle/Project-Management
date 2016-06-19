using Microsoft.AspNet.Identity.Owin;
using PM.Web.App_Start;
using PM.Web.Models;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PM.Web.Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace PM.Web.Controllers
{
    /// <summary>
    /// Security controller.
    /// </summary>
    public class SecurityController : Controller
    {
        #region Fields

        private ApplicationUserManager _userManager;

        #endregion Fields

        #region Constructors

        public SecurityController()
        {

        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets user manager lazy.
        /// </summary>
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

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

        #region Methods

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
                var user = await UserManager.FindAsync(model.UserName, model.Password);
                if (user != null)
                {
                    await SignInAsync(user, true);
                    return RedirectToAction("Projects", "Project", new { area = "Administration" });
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
        [HttpGet]
        [ActionName("SignOut")]
        public Task<RedirectToRouteResult> SignOutAsync()
        {
            AuthenticationManager.SignOut();
            return Task.FromResult(RedirectToAction("Index", "Home"));
        }

        /// <summary>
        /// Register async GET action.
        /// </summary>
        /// <returns>View.</returns>
        [HttpGet]
        [ActionName("Register")]
        public Task<ViewResult> RegisterAsync()
        {
            return Task.FromResult(View());
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
                var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInAsync(user, isPersistent: false);

                    // TODO: Implement acc register confiramition.
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Faild to register user.");
                }
            }

            return View(model);
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            this.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            this.AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }

        #endregion Methods

    }
}