using PM.Model.Common;
using System;
using System.Collections.Generic;

namespace PM.Model
{
    /// <summary>
    /// Role domain model.
    /// </summary>
    public class RolePoco : IRolePoco
    {
        #region Properties

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        
        #endregion Properies
    }
}
