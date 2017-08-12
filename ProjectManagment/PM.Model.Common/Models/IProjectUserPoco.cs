using System;

namespace PM.Model.Common
{
    /// <summary>
    /// ProjectUser poco contract.
    /// </summary>
    public interface IProjectUserPoco : IBasePoco
    {
        #region Properties
        
        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>
        /// The project identifier.
        /// </value>
        Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        Guid UserId { get; set; }

        /// <summary>
        /// Get or sets the Project Role.
        /// </summary>
        Guid ProjectRoleId { get; set; }

        #endregion Properties

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>
        /// The project.
        /// </value>
        IProjectPoco Project { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        IUserPoco User { get; set; }

        /// <summary>
        /// Get or sets the ProjectRole navigation property.
        /// </summary>
        IProjectRolePoco ProjectRole { get; set; }

        #endregion Navigation Properties
    }
}
