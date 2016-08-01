using System;

namespace PM.DAL.Entities
{
    /// <summary>
    /// Claim entity.
    /// </summary>
    public class Claim
    {
        #region Fields

        private User _user;

        #endregion Fields

        #region Scalar Properties

        /// <summary>
        /// Gets or sets the claim identifier.
        /// </summary>
        /// <value>
        /// The claim identifier.
        /// </value>
        public virtual int ClaimId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public virtual Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the type of the claim.
        /// </summary>
        /// <value>
        /// The type of the claim.
        /// </value>
        public virtual string ClaimType { get; set; }

        /// <summary>
        /// Gets or sets the claim value.
        /// </summary>
        /// <value>
        /// The claim value.
        /// </value>
        public virtual string ClaimValue { get; set; }

        #endregion Scalar Properties

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        /// <exception cref="System.ArgumentNullException">value</exception>
        public virtual User User
        {
            get { return _user; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _user = value;
                UserId = value.UserId;
            }
        }

        #endregion Navigation Properties
    }
}
