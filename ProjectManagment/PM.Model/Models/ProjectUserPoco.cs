using PM.Model.Common;
using System;

namespace PM.Model
{
    /// <summary>
    /// ProjectUser poco model.
    /// </summary>
    public class ProjectUserPoco : IProjectUserPoco
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

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
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date updated.
        /// </summary>
        /// <value>
        /// The date updated.
        /// </value>
        public DateTime DateUpdated { get; set; }

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

        #endregion Navigation Properties
    }
}
