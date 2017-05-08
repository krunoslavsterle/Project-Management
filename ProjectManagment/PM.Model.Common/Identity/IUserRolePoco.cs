using System;

namespace PM.Model.Common
{
    /// <summary>
    /// UserRolePoco contract.
    /// </summary>
    public interface IUserRolePoco
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        Guid RoleId { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the user navigation property.
        /// </summary>
        /// <value>
        /// The user navigation property.
        /// </value>
        IUserPoco User { get; set; }

        /// <summary>
        /// Gets or sets the role navigation property.
        /// </summary>
        /// <value>
        /// The role navigation property.
        /// </value>
        IRolePoco Role { get; set; }
    }
}
