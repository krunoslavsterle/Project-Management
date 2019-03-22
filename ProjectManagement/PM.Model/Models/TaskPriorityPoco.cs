using PM.Model.Common;
using System;
using System.Collections.Generic;

namespace PM.Model
{
    /// <summary>
    /// Task priority poco class.
    /// </summary>
    public class TaskPriorityPoco : BasePoco, ITaskPriorityPoco
    {
        #region Properties
        
        /// <summary>
        /// Gets or sets the abrv.
        /// </summary>
        /// <value>
        /// The abrv.
        /// </value>
        public string Abrv { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder { get; set; }
        
        #endregion Properties

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the tasks navigation property.
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        public virtual ICollection<ITaskPoco> Tasks { get; set; }

        #endregion Navigation Properties
    }
}
