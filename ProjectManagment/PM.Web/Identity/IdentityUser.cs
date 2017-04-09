using Microsoft.AspNet.Identity;
using PM.Model.Common;
using System;

namespace PM.Web.Identity
{

    /// <summary>
    /// Identity user extended class.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.IUser{System.Guid}" />
    public class IdentityUser : IIdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityUser"/> class.
        /// </summary>
        public IdentityUser()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityUser"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        public IdentityUser(string userName)
            : this()
        {
            this.UserName = userName;
        }

        /// <summary>
        /// Unique key for the user
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// Unique username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        /// <value>
        /// The password hash.
        /// </value>
        public virtual string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the security stamp.
        /// </summary>
        /// <value>
        /// The security stamp.
        /// </value>
        public virtual string SecurityStamp { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public virtual string Email { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public virtual ICompanyPoco Company { get; set; }
    }
}
