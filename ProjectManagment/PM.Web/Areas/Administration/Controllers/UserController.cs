using PM.Common;
using PM.Model.Common;
using PM.Service.Common;
using PM.Web.Administration.Models;
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

namespace PM.Web.Areas.Administration.Controllers
{
    public class UserController : BaseController
    {
        private readonly IIdentityService identityService;
        private readonly ILookupService lookupService;
        private readonly UserManager<IdentityUser, Guid> userManager;
        private readonly UserStore userStore;

        public UserController(IMapper mapper, IIdentityService identityService, ILookupService lookupService, UserManager<IdentityUser, Guid> userManager, UserStore userStore) 
            : base(mapper)
        {
            this.identityService = identityService;
            this.lookupService = lookupService;
            this.userManager = userManager;
            this.userStore = userStore;
        }
        
        // GET: Administration/User
        [HttpGet]
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            // TODO: PUT THIS IN THE BASE CONTROLLER.
            var user = await identityService.GetUserById(UserId);
            var users = await identityService.GetUsersByCompanyId(user.CompanyId, "Roles");

            // List of users
            var vm = new IndexUserViewModel();
            vm.Users = users;
            return View("Index", vm);
        }

        [HttpGet]
        [ActionName("New")]
        public async Task<ActionResult> NewAsync()
        {
            var vm = new CreateUserViewModel();
            return View("New", vm);
        }

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

                var iRole = new IdentityRole(role.Name, role.RoleId);
                domain.Roles.Add(iRole);

                var password = GenerateTempPassword(7);

                try
                {
                    var newUser = await userManager.CreateAsync(domain, password);
                    if (newUser.Succeeded)
                    {
                        var nUser = await userStore.FindByIdAsync(domain.Id);
                        //await userStore.AddToRoleAsync(nUser, "User");
                    }

                    //await userManager.AddToRoleAsync(domain.Id, "User");
                    //await userStore.AddToRoleAsync(domain, "User");


                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(new { success = true, responseText = "User is created successfuly.", html = this.RenderView("_NewUserModal", vm) }, JsonRequestBehavior.AllowGet);
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

        private string GenerateTempPassword(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}