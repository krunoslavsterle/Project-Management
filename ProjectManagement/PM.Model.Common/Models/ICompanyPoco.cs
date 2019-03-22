using System;
using System.Collections.Generic;

namespace PM.Model.Common
{
    /// <summary>
    /// Company poco contract.
    /// </summary>
    public interface ICompanyPoco : IBasePoco
    {
        #region Properties
        
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
        
        #endregion Properties

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        ICollection<IUserPoco> Users { get; set; }

        #endregion Navigation Properties
    }
}
