using PM.Model.Common;
using System;

namespace PM.Model
{
    /// <summary>
    /// Claim domain model.
    /// </summary>
    public class ClaimPoco : IClaimPoco
    {
        #region Properties

        /// <summary>
        /// Gets or sets the claim identifier.
        /// </summary>
        /// <value>
        /// The claim identifier.
        /// </value>
        public int ClaimId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the type of the claim.
        /// </summary>
        /// <value>
        /// The type of the claim.
        /// </value>
        public string ClaimType { get; set; }

        /// <summary>
        /// Gets or sets the claim value.
        /// </summary>
        /// <value>
        /// The claim value.
        /// </value>
        public string ClaimValue { get; set; }
        
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public IUserPoco User { get; set; }

        #endregion Properties
    }
}
