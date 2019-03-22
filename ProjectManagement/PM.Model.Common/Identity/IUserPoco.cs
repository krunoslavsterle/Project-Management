using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;

namespace PM.Model.Common
{
    /// <summary>
    /// User domain model contract.
    /// </summary>
    public interface IUserPoco : IUser<Guid>
    {
        #region Properties
        
        new Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        Guid CompanyId { get; set; }
        
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
        /// Gets or sets the password reset token.
        /// </summary>
        /// <value>
        /// The password reset token.
        /// </value>
        string PasswordResetToken { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether email is confirmed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [email confirmed]; otherwise, <c>false</c>.
        /// </value>
        bool EmailConfirmed { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date updated.
        /// </summary>
        /// <value>
        /// The date updated.
        /// </value>
        DateTime DateUpdated { get; set; }

        /// <summary>
        /// Gets or sets the claims.
        /// </summary>
        /// <value>
        /// The claims.
        /// </value>
        ICollection<IClaimPoco> Claims { get; set; }

        /// <summary>
        /// Gets or sets the logins.
        /// </summary>
        /// <value>
        /// The logins.
        /// </value>
        ICollection<IExternalLoginPoco> ExternalLogins { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        ICollection<IUserRolePoco> UserRoles { get; set; }
        
        /// <summary>
        /// Gets or sets the project users.
        /// </summary>
        /// <value>
        /// The project users.
        /// </value>
        ICollection<IProjectUserPoco> ProjectUsers { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        ICompanyPoco Company { get; set; }

        #endregion Properties
    }
}
