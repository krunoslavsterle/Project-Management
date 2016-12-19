using System;
using System.Collections.Generic;

namespace PM.Model.Common
{
    /// <summary>
    /// Role domain model contract.
    /// </summary>
    public interface IRolePoco
    {
        #region Properties

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        Guid RoleId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        ICollection<IUserPoco> Users { get; set; }

        #endregion Properies
    }
}
