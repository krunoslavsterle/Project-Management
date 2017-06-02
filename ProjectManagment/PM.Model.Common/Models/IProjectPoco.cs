using System;
using System.Collections.Generic;

namespace PM.Model.Common
{
    /// <summary>
    /// Project contract.
    /// </summary>
    public interface IProjectPoco : IBasePoco
    {
        #region Properties
        
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        Guid CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the project leader.
        /// </summary>
        /// <value>
        /// The project leader.
        /// </value>
        Guid ProjectLeaderId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; set; }
                
        #endregion Properties

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        ICollection<ITaskPoco> Tasks { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        ICompanyPoco Company { get; set; }

        /// <summary>
        /// Gets or sets the project leader.
        /// </summary>
        /// <value>
        /// The project leader.
        /// </value>
        IUserPoco ProjectLeader { get; set; }

        /// <summary>
        /// Gets or sets the project users.
        /// </summary>
        /// <value>
        /// The project users.
        /// </value>
        ICollection<IProjectUserPoco> ProjectUsers { get; set; }

        #endregion Navigation Properties
    }
}
