﻿using PM.Web.Models;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using PM.Service.Common;
using PM.Model.Common;

namespace PM.Web.Controllers
{
    /// <summary>
    /// Security controller.
    /// </summary>
    public class SecurityController : Controller
    {
        #region Fields

        private readonly IPMUserStore userStore;
        private readonly UserManager<IUserPoco, Guid> userManager;
        private readonly ICompanyService companyService;

        #endregion Fields

        #region Constructors
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityController"/> class.
        /// </summary>
        /// <param name="userStore">The user store.</param>
        /// <param name="companyService">The company service.</param>
        public SecurityController(IPMUserStore userStore, ICompanyService companyService)
        {
            this.companyService = companyService;
            this.userStore = userStore;
            this.userManager = new UserManager<IUserPoco, Guid>(userStore);
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
                var test = await userStore.FindByIdAsync(new Guid("E8AB9AF0-DA85-4E91-B65E-5744B01F8235"));
                var user = await userManager.FindAsync(model.UserName, model.Password);
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
        [HttpPost]
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
            // TODO: Implement loger.
            if (ModelState.IsValid)
            {
                var company = companyService.Create();
                company.Name = model.CompanyName;
                company.DateCreated = DateTime.UtcNow;
                company.DateUpdated = DateTime.UtcNow;

                var user = userStore.CreateUser();
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.Company = company;
                user.CompanyId = company.Id;

                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Need to invalidate Company model - circular reference for AutoMapper.
                    user.Company = null;
                    await SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Faild to register user");
                }
            }

            return View(model);
        }

        private async Task SignInAsync(IUserPoco user, bool isPersistent)
        { 
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        #endregion Methods

    }
}