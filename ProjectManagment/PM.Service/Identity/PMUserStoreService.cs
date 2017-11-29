using PM.Common;
using PM.Model.Common;
using PM.Repository.Common;
using PM.Service.Common;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PM.Repository;
using System.Linq.Expressions;
using PagedList;

namespace PM.Service
{
    /// <summary>
    /// PM User store class.
    /// </summary>
    /// <seealso cref="PM.Service.Common.IPMUserStoreService" />
    public class PMUserStoreService : IPMUserStoreService
    {
        #region Fields

        private readonly IUserRepository userRepository;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IMapper mapper;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PMUserStoreService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="userRoleRepository">The user role repository.</param>
        /// <param name="roleRepository">The role repository.</param>
        /// <param name="mapper">The mapper.</param>
        public PMUserStoreService(IUserRepository userRepository, IUserRoleRepository userRoleRepository, IRoleRepository roleRepository, IMapper mapper)
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
        /// Finds the user by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The user.</returns>
        public IUserPoco FindById(Guid userId)
        {
            return userRepository.GetOne(p => p.Id == userId);
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
        /// Gets the users by company identifier paged asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The sorting parameter.</param>
        /// <param name="companyId">The company id.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>The users by company identifier paged asynchronous</returns>
        public Task<IPagedList<IUserPoco>> GetUsersByCompanyIdPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy, Guid companyId, params string[] includeProperties)
        {
            return userRepository.GetPagedAsync(pagingParameters, p => p.CompanyId == companyId, orderBy, includeProperties);
        }

        /// <summary>
        /// Gets the one <see cref="IUserPoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="IUserPoco"/> asynchronously.</returns>
        public Task<IUserPoco> GetUserAsync(Expression<Func<IUserPoco, bool>> filter = null,params string[] includeProperties)
        {
            return userRepository.GetOneAsync(filter, includeProperties);
        }

        /// <summary>
        /// Gets the users asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IUserPoco"/>.</returns>
        public Task<IEnumerable<IUserPoco>> GetUsersAsync(Expression<Func<IUserPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            return userRepository.GetAsync(filter, orderBy, includeProperties);
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

            user.DateUpdated = DateTime.UtcNow;
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
        
        #region IUserEmailStore

        /// <summary>
        /// Set the user email.
        /// </summary>
        /// <param name="user">User.</param>
        /// <param name="email">Email</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">user or email</exception>
        public Task SetEmailAsync(IUserPoco user, string email)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (String.IsNullOrEmpty(email))
                throw new ArgumentNullException("email");

            user.Email = email;
            return UpdateAsync(user);
        }

        /// <summary>
        /// Get the user email.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">user.</exception>
        public Task<string> GetEmailAsync(IUserPoco user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.Email);
        }

        /// <summary>
        /// Returns true if the user email is confirmed.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>True if the user email is confirmed.</returns>
        /// <exception cref="System.ArgumentNullException">user.</exception>
        public Task<bool> GetEmailConfirmedAsync(IUserPoco user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.EmailConfirmed);
        }

        /// <summary>
        /// Sets whether the user email is confirmed.
        /// </summary>
        /// <param name="user">User.</param>
        /// <param name="confirmed">Confirmed flag.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.ArgumentNullException">user.</exception>
        public Task SetEmailConfirmedAsync(IUserPoco user, bool confirmed)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.EmailConfirmed = confirmed;
            return UpdateAsync(user);
        }

        /// <summary>
        /// Returns the user associated with this email.
        /// </summary>
        /// <param name="email">User email address.</param>
        /// <returns>The user associated with this email..</returns>
        /// <exception cref="System.ArgumentNullException">email.</exception>
        public Task<IUserPoco> FindByEmailAsync(string email)
        {
            return userRepository.GetOneAsync(p => p.Email == email);
        }

        #endregion IUserEmailStore

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
