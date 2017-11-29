using PM.Common;
using System.Security.Claims;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Net;
using PM.Service.Common;
using System.Threading.Tasks;

namespace PM.Web.Controllers
{
    /// <summary>
    /// Base controller.
    /// </summary>
    public abstract class BaseController : Controller
    {
        private ClaimsIdentity claimsIdentity;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public BaseController(IMapper mapper, IPMUserStoreService userStore)
        {
            this.Mapper = mapper;
            this.UserStore = userStore;
        }
        
        #endregion Constructors

        #region Properties

        /// <summary> 
        /// Gets or sets the mapper.
        /// </summary>
        /// <value>
        /// The mapper.
        /// </value>
        public IMapper Mapper { get; set; }
        
        /// <summary>
        /// Gets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string UserName
        {
            get
            {
                if (claimsIdentity == null)
                {
                    claimsIdentity = User.Identity as ClaimsIdentity;
                }

                return claimsIdentity.GetUserName();
            }           
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId
        {
            get
            {
                if (claimsIdentity == null)
                {
                    claimsIdentity = User.Identity as ClaimsIdentity;
                }

                var userIdClaim = claimsIdentity.Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    return new Guid(userIdClaim.Value);
                }

                return Guid.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId
        {
            get
            {
                return GetCompanyId();
            }
        }

        /// <summary>
        /// Gets or sets the user store.
        /// </summary>
        /// <value>
        /// The user store.
        /// </value>
        public IPMUserStoreService UserStore { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Called before the action method is invoked.
        /// </summary>
        /// <param name="filterContext">Information about the current request and action.</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            ViewBag.UserEmail = GetUserEmail();
        }

        /// <summary>
        /// Sets the response status code and description for error handling.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="description">The description.</param>
        public void SetErrorResponse(HttpStatusCode statusCode, string description)
        {
            Response.StatusCode = (int)statusCode;
            Response.StatusDescription = description;
        }

        /// <summary>
        /// Gets the user email.
        /// </summary>
        /// <returns></returns>
        public string GetUserEmail()
        {
            var email = Session["UserEmail"];
            if (email != null)
                return (string)email;

            var user = UserStore.FindById(UserId);
            if (user == null)
                return null;

            Session["UserEmail"] = user.Email;
            return user.Email;
        }

        private Guid GetCompanyId()
        {
            var companyId = Session["CompanyId"];
            if (companyId != null)
                return (Guid)companyId;

            var user = UserStore.FindById(UserId);
            if (user == null)
                return Guid.Empty;

            Session["CompanyId"] = user.CompanyId;
            return user.CompanyId;
        }

        #endregion Methods
    }
}
