using PM.Model.Common;
using System.Collections.Generic;

namespace PM.Model
{
    /// <summary>
    /// Company poco model.
    /// </summary>
    public class CompanyPoco : BasePoco, ICompanyPoco
    {
        #region Properties
        
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        
        #endregion Properties

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public ICollection<IUserPoco> Users { get; set; }

        #endregion Navigation Properties
    }
}
