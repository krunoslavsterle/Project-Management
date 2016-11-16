using System;
using System.Collections.Generic;

namespace PM.DAL.Entities
{
    // TODO: THIS SHOULD BE ENTITY CLASS. - CREATE DOMAIN MODEL FOR THIS AND IMPLEMENT AUTOMAPPER.
    /// <summary>
    /// User entity.
    /// </summary>
    public class UserEntity
    {
        public UserEntity()
        {
            this.Claims =  new List<ClaimEntity>();
            this.Logins = new List<ExternalLoginEntity>();
            this.Roles = new List<RoleEntity>();
        }
        #region Fields

        private ICollection<ClaimEntity> _claims;
        private ICollection<ExternalLoginEntity> _externalLogins;
        private ICollection<RoleEntity> _roles;

        #endregion Fields

        #region Scalar Properties
        
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        /// <value>
        /// The password hash.
        /// </value>
        public virtual string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the security stamp.
        /// </summary>
        /// <value>
        /// The security stamp.
        /// </value>
        public virtual string SecurityStamp { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public virtual string Email { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the claims.
        /// </summary>
        /// <value>
        /// The claims.
        /// </value>
        public virtual ICollection<ClaimEntity> Claims
        {
            get { return _claims ?? (_claims = new List<ClaimEntity>()); }
            set { _claims = value; }
        }

        /// <summary>
        /// Gets or sets the logins.
        /// </summary>
        /// <value>
        /// The logins.
        /// </value>
        public virtual ICollection<ExternalLoginEntity> Logins
        {
            get
            {
                return _externalLogins ??
                    (_externalLogins = new List<ExternalLoginEntity>());
            }
            set { _externalLogins = value; }
        }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        public virtual ICollection<RoleEntity> Roles
        {
            get { return _roles ?? (_roles = new List<RoleEntity>()); }
            set { _roles = value; }
        }

        #endregion
    }
}
