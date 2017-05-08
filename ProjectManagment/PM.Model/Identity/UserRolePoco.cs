using PM.Model.Common;
using System;

namespace PM.Model
{
    /// <summary>
    /// UserRolePoco class.
    /// </summary>
    /// <seealso cref="PM.Model.Common.IUserRolePoco" />
    public class UserRolePoco : IUserRolePoco
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the user navigation property.
        /// </summary>
        /// <value>
        /// The user navigation property.
        /// </value>
        public IUserPoco User { get; set; }

        /// <summary>
        /// Gets or sets the role navigation property.
        /// </summary>
        /// <value>
        /// The role navigation property.
        /// </value>
        public IRolePoco Role { get; set; }
    }
}
