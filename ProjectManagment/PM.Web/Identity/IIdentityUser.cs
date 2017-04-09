using Microsoft.AspNet.Identity;
using PM.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Web.Identity
{
    public interface IIdentityUser : IUser<Guid>
    {
        /// <summary>
        /// Unique key for the user
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        Guid CompanyId { get; set; }

        /// <summary>
        /// Unique username
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        /// <value>
        /// The password hash.
        /// </value>
        string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the security stamp.
        /// </summary>
        /// <value>
        /// The security stamp.
        /// </value>
        string SecurityStamp { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        ICompanyPoco Company { get; set; }
    }
}
