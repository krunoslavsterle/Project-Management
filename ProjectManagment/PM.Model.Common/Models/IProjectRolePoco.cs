using System.Collections.Generic;

namespace PM.Model.Common
{
    /// <summary>
    /// ProjectRolePoco contract.
    /// </summary>
    public interface IProjectRolePoco : IBasePoco
    {
        #region Properties

        /// <summary>
        /// Gets or sets the abrv.
        /// </summary>
        /// <value>
        /// The abrv.
        /// </value>
        string Abrv { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        int SortOrder { get; set; }

        #endregion Properties

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the project users in this role - navigation property.
        /// </summary>
        /// <value>
        /// The project users in this role.
        /// </value>
        ICollection<IProjectUserPoco> ProjectUsersInRole { get; set; }

        #endregion Navigation Properties
    }
}
