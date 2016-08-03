using System;

namespace PM.DAL.Entities
{
    /// <summary>
    /// External login entity.
    /// </summary>
    public class ExternalLoginEntity
    {
        #region Fields

        private UserEntity _user;

        #endregion Fields

        #region Scalar Properties

        /// <summary>
        /// Gets or sets the login provider.
        /// </summary>
        /// <value>
        /// The login provider.
        /// </value>
        public virtual string LoginProvider { get; set; }

        /// <summary>
        /// Gets or sets the provider key.
        /// </summary>
        /// <value>
        /// The provider key.
        /// </value>
        public virtual string ProviderKey { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public virtual Guid UserId { get; set; }

        #endregion Scalar Properties

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public virtual UserEntity User
        {
            get { return _user; }
            set
            {
                _user = value;
                UserId = value.UserId;
            }
        }

        #endregion Navigation Properties
    }
}
