using PM.Common.Cache;
using PM.Model.Common;
using PM.Repository;
using PM.Repository.Common;
using PM.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.Service
{
    /// <summary>
    /// Identity service.
    /// </summary>
    /// <seealso cref="PM.Service.Common.IIdentityService" />
    public class IdentityService : IIdentityService
    {
        #region Fields

        private const string IDENTITY_USER_CACHE_KEY = "IDENTITY_USER_";

        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IExternalLoginRepository externalLoginRepository;
        private readonly ICacheProvider cacheProvider;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="roleRepository">The role repository.</param>
        /// <param name="externalLoginRepository">The external login repository.</param>
        /// <param name="cacheProvider">The cache provider.</param>
        public IdentityService(IUserRepository userRepository, IRoleRepository roleRepository, IExternalLoginRepository externalLoginRepository, ICacheProvider cacheProvider)
        {
            this.userRepository = userRepository;
            this.externalLoginRepository = externalLoginRepository;
            this.roleRepository = roleRepository;
            this.cacheProvider = cacheProvider;
        }

        #endregion Constructors

        #region Methods

        #region User methods

        /// <summary>
        /// Creates the instance of the <see cref="IUserPoco"/> class.
        /// </summary>
        /// <returns>The instance of the <see cref="IUserPoco"/> class.</returns>
        public virtual IUserPoco CreateUser()
        {
            return userRepository.CreateUser();
        }

        /// <summary>
        /// Gets the users by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IUserPoco"/>.</returns>
        public virtual Task<IEnumerable<IUserPoco>> GetUsersByCompanyId(Guid companyId, params string[] includeProperties)
        {
            return userRepository.GetAsync(p => p.CompanyId == companyId, null, includeProperties);
        }

        /// <summary>
        /// Inserts the <see cref="IUserPoco"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        public Task AddUserAsync(IUserPoco model)
        {
            return userRepository.InsertAsync(model);
        }

        /// <summary>
        /// Deletes the <see cref="IUserPoco"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        public Task DeleteUserAsync(IUserPoco model)
        {
            return userRepository.DeleteAsync(model);
        }

        /// <summary>
        /// Gets the <see cref="IUserPoco"/> by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IUserPoco"/>.</returns>
        public Task<IUserPoco> GetUserById(Guid id)
        {
            String userKey = IDENTITY_USER_CACHE_KEY + id.ToString();
            return this.cacheProvider.GetOrAddAsync<IUserPoco>(userKey, (string key) =>
            {
                return userRepository.GetById(id);
            },
            DateTimeOffset.MaxValue);
        }

        /// <summary>
        /// Finds the <see cref="IUserPoco"/> by user name asynchronous.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public Task<IUserPoco> GetUserByUserNameAsync(string userName)
        {
            return userRepository.GetOneAsync(p => p.UserName == (string)userName);
        }

        /// <summary>
        /// Updates the user asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>True if updated.</returns>
        public Task<bool> UpdateUserAsync(IUserPoco model)
        {
            return TryExecuteTaskAsync(userRepository.UpdateAsync(model));
        }

        #endregion User methods

        #region Claim methods

        /// <summary>
        /// Creates the claim asynchronous.
        /// </summary>
        /// <returns><see cref="IClaim"/>.</returns>
        public System.Threading.Tasks.Task<IClaimPoco> CreateClaimAsync()
        {
            return userRepository.CreateClaimAsync();
        }

        #endregion Claim methods

        #region External login methods

        /// <summary>
        /// Creates <see cref="IExternalLoginPoco"/> the asynchronous.
        /// </summary>
        /// <returns><see cref="IExternalLoginPoco"/>.</returns>
        public System.Threading.Tasks.Task<IExternalLoginPoco> CreateExternalLoginAsync()
        {
            return externalLoginRepository.CreateAsync();
        }

        /// <summary>
        /// Gets the <see cref="IExternalLogin"/> by provider and key asynchronous.
        /// </summary>
        /// <param name="loginProvider">The login provider.</param>
        /// <param name="providerKey">The provider key.</param>
        /// <returns><see cref="IExternalLogin"/>.</returns>
        public Task<IExternalLoginPoco> GetExternalLoginAsync(string loginProvider, string providerKey)
        {
            return externalLoginRepository.GetOneAsync(p => p.LoginProvider == loginProvider && p.ProviderKey == providerKey);
        }

        #endregion External login methods

        #region Role methods

        /// <summary>
        /// Creates a instance of the <see cref="IRolePoco"/> class.
        /// </summary>
        /// <returns>Instance of the <see cref="IRolePoco"/> class.</returns>
        public virtual IRolePoco CreateRole()
        {
            return roleRepository.CreateRole();
        }

        /// <summary>
        /// Adds the <see cref="IRolePoco"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>True if added.</returns>
        public Task<bool> AddRoleAsync(IRolePoco model)
        {
            return TryExecuteTaskAsync(roleRepository.InsertAsync(model));
        }

        /// <summary>
        /// Deletes the <see cref="IRolePoco"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public Task<bool> DeleteRoleAsync(IRolePoco model)
        {
            return TryExecuteTaskAsync(roleRepository.DeleteAsync(model));
        }

        /// <summary>
        /// Gets the <see cref="IRolePoco"/> by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Task<IRolePoco> GetRoleAsync(string name)
        {
            return roleRepository.GetOneAsync(p => p.Name == name);
        }

        /// <summary>
        /// Gets the <see cref="IRolePoco"/> asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<IRolePoco> GetRoleAsync(Guid id)
        {
            return roleRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns></returns>
        public IList<IRolePoco> GetAllRoles()
        {
            return roleRepository.GetAll().ToList();
        }

        /// <summary>
        /// Updates the role asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>True if updated.</returns>
        public Task<bool> UpdateRoleAsync(IRolePoco model)
        {
            return TryExecuteTaskAsync(roleRepository.UpdateAsync(model));
        }
                
        #endregion Role methods

        private async Task<bool> TryExecuteTaskAsync(System.Threading.Tasks.Task task)
        {
            bool isSuccess = true;
            try
            {
                await task;
            }
            catch (Exception)
            {
                isSuccess = false;
            }

            return isSuccess;
        }
        
        #endregion Methods
    }
}
