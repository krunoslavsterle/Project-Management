using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PM.Web.Identity.Models
{
    /// <summary>
    /// Application user model.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Creates a ClaimsIdentity representing the user.
        /// </summary>
        /// <param name="manager">User manager.</param>
        /// <returns>ClaimsIdentity.</returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}