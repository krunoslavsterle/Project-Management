using System.Collections.Generic;

namespace PM.Model.Common
{
    /// <summary>
    /// Task status poco contract.
    /// </summary>
    public interface ITaskStatusPoco : IBasePoco
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
        /// Gets or sets the tasks navigation property.
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        ICollection<ITaskPoco> Tasks { get; set; }

        #endregion Navigation Properties
    }
}
