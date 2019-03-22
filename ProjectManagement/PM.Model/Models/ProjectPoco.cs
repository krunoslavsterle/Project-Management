using PM.Model.Common;
using System;
using System.Collections.Generic;

namespace PM.Model
{
    /// <summary>
    /// Project model.
    /// </summary>
    public class ProjectPoco : BasePoco, IProjectPoco
    {
        #region Properties
        
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the project leader.
        /// </summary>
        /// <value>
        /// The project leader.
        /// </value>
        public Guid ProjectLeaderId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        
        #endregion Properties

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        public virtual ICollection<ITaskPoco> Tasks { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public virtual ICompanyPoco Company { get; set; }

        /// <summary>
        /// Gets or sets the project leader.
        /// </summary>
        /// <value>
        /// The project leader.
        /// </value>
        public virtual IUserPoco ProjectLeader { get; set; }

        /// <summary>
        /// Gets or sets the project users.
        /// </summary>
        /// <value>
        /// The project users.
        /// </value>
        public virtual ICollection<IProjectUserPoco> ProjectUsers { get; set; }

        #endregion Navigation Properties
    }
}
