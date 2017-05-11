using PM.Common;
using System.Security.Claims;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Net;

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
        public BaseController(IMapper mapper)
        {
            this.Mapper = mapper;
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

        #endregion Properties

        #region Methods

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

        #endregion Methods
    }
}
