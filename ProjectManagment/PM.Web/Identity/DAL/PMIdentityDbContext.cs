using Microsoft.AspNet.Identity.EntityFramework;
using PM.Web.Identity.Models;
using System.Data.Entity;

namespace PM.Web.Identity.DAL
{
    /// <summary>
    /// Identity database context.
    /// </summary>
    public class PMIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public PMIdentityDbContext()
            : base("PMLocalDBConnection")
        {

        }

        /// <summary>
        /// Returns a new instance of a <see cref="PMIdentityDbContext"/> class.
        /// </summary>
        /// <returns>New instance of a <see cref="PMIdentityDbContext"/> class.</returns>
        public static PMIdentityDbContext Create()
        {
            return new PMIdentityDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("AppIdentity");
        }
    }
}