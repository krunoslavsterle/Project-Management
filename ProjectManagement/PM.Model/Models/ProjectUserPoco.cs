using PM.Model.Common;
using System;

namespace PM.Model
{
    /// <summary>
    /// ProjectUser poco model.
    /// </summary>
    public class ProjectUserPoco : BasePoco, IProjectUserPoco
    {
        #region Properties
        
        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>
        /// The project identifier.
        /// </value>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Get or sets the Project Role.
        /// </summary>
        public Guid ProjectRoleId { get; set; }

        #endregion Properties

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>
        /// The project.
        /// </value>
        public IProjectPoco Project { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public IUserPoco User { get; set; }

        /// <summary>
        /// Get or sets the ProjectRole navigation property.
        /// </summary>
        public IProjectRolePoco ProjectRole { get; set; }

        #endregion Navigation Properties
    }
}
