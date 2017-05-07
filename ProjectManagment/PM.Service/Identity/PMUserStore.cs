using PM.Common;
using PM.Model.Common;
using PM.Repository.Common;
using PM.Service.Common;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PM.Repository;

namespace PM.Service
{
    /// <summary>
    /// PM User store class.
    /// </summary>
    /// <seealso cref="PM.Service.Common.IPMUserStore" />
    public class PMUserStore : IPMUserStore
    {
        #region Fields

        private readonly IUserRepository userRepository;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IMapper mapper;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PMUserStore"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="userRoleRepository">The user role repository.</param>
        /// <param name="roleRepository">The role repository.</param>
        /// <param name="mapper">The mapper.</param>
        public PMUserStore(IUserRepository userRepository, IUserRoleRepository userRoleRepository, IRoleRepository roleRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.userRoleRepository = userRoleRepository;
            this.roleRepository = roleRepository;
            this.mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Creates the user in memory.
        /// </summary>
        /// <returns><see cref="IUserPoco"/>.</returns>
        public IUserPoco CreateUser()
        {
            return userRepository.CreateUser();
        }

        /// <summary>
        /// Insert a new user.
        /// </summary>
        /// <param name="user">User poco.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task CreateAsync(IUserPoco user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return userRepository.InsertAsync(user);
        }

        /// <summary>
        /// Delete a user form db.
        /// </summary>
        /// <param name="user">User poco.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task DeleteAsync(IUserPoco user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return userRepository.DeleteAsync(user.Id);
        }

        /// <summary>
        /// Finds a user by id.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <returns>Task.</returns>
        public Task<IUserPoco> FindByIdAsync(Guid userId)
        {
            return userRepository.GetOneAsync(p => p.Id == userId);
        }

        /// <summary>
        /// Find a user by name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Task<IUserPoco> FindByNameAsync(string userName)
        {
            return userRepository.GetOneAsync(p => p.UserName == userName);
        }

        /// <summary>
        /// Gets the users by company identifier asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IUserPoco"/>.</returns>
        public Task<IEnumerable<IUserPoco>> GetUsersByCompanyIdAsync(Guid companyId, params string[] includeProperties)
        {
            return userRepository.GetAsync(p => p.CompanyId == companyId, null, includeProperties);
        }

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="user">User poco.</param>
        /// <returns>Task</returns>
        public Task UpdateAsync(IUserPoco user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return userRepository.UpdateAsync(user);
        }

        /// <summary>
        /// Adds a user to role asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns>task</returns>
        /// <exception cref="System.ArgumentNullException">user or roleName.</exception>
        public async Task AddToRoleAsync(IUserPoco user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (String.IsNullOrEmpty(roleName))
                throw new ArgumentNullException("roleName");

            var role = await roleRepository.GetOneAsync(p => p.Name == roleName);
            var userRole = userRoleRepository.CreateUserRole();
            userRole.RoleId = role.RoleId;
            userRole.UserId = user.Id;

            await userRoleRepository.InsertAsync(userRole);
        }

        /// <summary>
        /// Removes the user from the role asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <exception cref="System.ArgumentNullException"> user or roleName.</exception>
        public async Task RemoveFromRoleAsync(IUserPoco user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (String.IsNullOrEmpty(roleName))
                throw new ArgumentNullException("roleName");

            var role = await roleRepository.GetOneAsync(p => p.Name == roleName);
            var userRole = await userRoleRepository.GetOneAsync(p => p.RoleId == role.RoleId && p.UserId == user.Id);

            await userRoleRepository.DeleteAsync(userRole);
        }

        /// <summary>
        /// Gets the user roles asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The user roles.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public async Task<IList<string>> GetRolesAsync(IUserPoco user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var userRoles = await userRoleRepository.GetAsync(p => p.UserId == user.Id, null, "Role");
            return userRoles.Select(p => p.Role).Select(d => d.Name).ToList();
        }

        /// <summary>
        /// Determines whether user is in role asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns>True if in role.</returns>
        /// <exception cref="System.ArgumentNullException">user or roleName.</exception>
        public async Task<bool> IsInRoleAsync(IUserPoco user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (String.IsNullOrEmpty(roleName))
                throw new ArgumentNullException("roleName");

            var role = await roleRepository.GetOneAsync(p => p.Name == roleName);

            var count = await userRoleRepository.GetCountAsync(p => p.RoleId == role.RoleId && p.UserId == user.Id);
            return count > 0;
        }

        /// <summary>
        /// Sets the password hash asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <returns>Task</returns>
        /// <exception cref="System.ArgumentNullException">user or passwordHash.</exception>
        public Task SetPasswordHashAsync(IUserPoco user, string passwordHash)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (String.IsNullOrEmpty(passwordHash))
                throw new ArgumentNullException("passwordHash");

            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        /// <summary>
        /// Gets the password hash asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The password hash.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task<string> GetPasswordHashAsync(IUserPoco user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult<string>(user.PasswordHash);
        }

        /// <summary>
        /// Determines whether the user has password asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>True if has password.</returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task<bool> HasPasswordAsync(IUserPoco user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult<bool>(!string.IsNullOrWhiteSpace(user.PasswordHash));
        }
        
        /// <summary>
        /// Sets the security stamp asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="stamp">The stamp.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">user or stamp.</exception>
        public Task SetSecurityStampAsync(IUserPoco user, string stamp)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (String.IsNullOrEmpty(stamp))
                throw new ArgumentNullException("stamp");

            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }

        /// <summary>
        /// Gets the security stamp asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public Task<string> GetSecurityStampAsync(IUserPoco user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult<string>(user.SecurityStamp);
        }
        
        #endregion Methods

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~PMUserStore() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        


        #endregion

    }
}
