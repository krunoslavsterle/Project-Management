using System;

namespace PM.Model.Common
{
    /// <summary>
    /// Claim domain model contract.
    /// </summary>
    public interface IClaimPoco
    {
        #region Properties

        /// <summary>
        /// Gets or sets the claim identifier.
        /// </summary>
        /// <value>
        /// The claim identifier.
        /// </value>
        int ClaimId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the type of the claim.
        /// </summary>
        /// <value>
        /// The type of the claim.
        /// </value>
        string ClaimType { get; set; }

        /// <summary>
        /// Gets or sets the claim value.
        /// </summary>
        /// <value>
        /// The claim value.
        /// </value>
        string ClaimValue { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        IUserPoco User { get; set; }

        #endregion Properties
    }
}
