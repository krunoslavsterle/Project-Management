using PM.Model.Common;
using PM.Repository.Common;
using PM.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private IUnitOfWork unitOfWork;

        #endregion Fields

        #region Constructors

        public IdentityService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion Constructors

        #region Methods

        #region User methods


        /// <summary>
        /// Adds the user asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public Task AddUserAsync(IUserPoco model)
        {
            unitOfWork.UserRepository.AddAsync(model);
            return unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the user asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public Task DeleteUserAsync(IUserPoco model)
        {
            unitOfWork.UserRepository.DeleteAsync(model);
            return unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IUserPoco"/>.</returns>
        public Task<IUserPoco> GetUserById(Guid id)
        {
            return unitOfWork.UserRepository.GetByUserIdAsync(id);
        }

        /// <summary>
        /// Finds the user by user name asynchronous.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public Task<IUserPoco> GetUserByUserNameAsync(string userName)
        {
            return unitOfWork.UserRepository.FindByUserNameAsync(userName);
        }

        /// <summary>
        /// Updates the user asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>True if updated.</returns>
        public async Task<bool> UpdateUserAsync(IUserPoco model)
        {
            await unitOfWork.UserRepository.UpdateAsync(model);
            return await unitOfWork.SaveChangesAsync() > 0;
        }

        #endregion User methods

        #region Claim methods

        /// <summary>
        /// Creates the claim asynchronous.
        /// </summary>
        /// <returns><see cref="IClaimPoco"/>.</returns>
        public Task<IClaimPoco> CreateClaimAsync()
        {
            return unitOfWork.UserRepository.CreateClaimAsync();
        }

        #endregion Claim methods

        #region External login methods

        /// <summary>
        /// Creates the external login.
        /// </summary>
        /// <returns><see cref="IExternalLogin"/></returns>
        public Task<IExternalLoginPoco> CreateExternalLoginAsync()
        {
            return unitOfWork.ExternalLoginRepository.CreateAsync();
        }

        /// <summary>
        /// Gets the <see cref="IExternalLogin"/> by provider and key asynchronous.
        /// </summary>
        /// <param name="loginProvider">The login provider.</param>
        /// <param name="providerKey">The provider key.</param>
        /// <returns><see cref="IExternalLogin"/>.</returns>
        public Task<IExternalLoginPoco> GetExternalLoginAsync(string loginProvider, string providerKey)
        {
            return unitOfWork.ExternalLoginRepository.GetByProviderAndKeyAsync(loginProvider, providerKey);            
        }

        #endregion External login methods

        #region Role methods
        
        /// <summary>
        /// Adds the role asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>True if added.</returns>
        public async Task<bool> AddRoleAsync(IRolePoco model)
        {
            await unitOfWork.RoleRepository.AddAsync(model);
            return await unitOfWork.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Deletes the role asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> DeleteRoleAsync(IRolePoco model)
        {
            await unitOfWork.RoleRepository.UpdateAsync(model);
            return await unitOfWork.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Gets the role by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Task<IRolePoco> GetRoleAsync(string name)
        {
            return unitOfWork.RoleRepository.FindByNameAsync(name);
        }

        /// <summary>
        /// Gets the role asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<IRolePoco> GetRoleAsync(Guid id)
        {
            return unitOfWork.RoleRepository.FindByIdAsync(id);
        }

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns></returns>
        public IList<IRolePoco> GetAllRoles()
        {
            return unitOfWork.RoleRepository.GetAll();
        }

        /// <summary>
        /// Updates the role asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>True if updated.</returns>
        public async Task<bool> UpdateRoleAsync(IRolePoco model)
        {
            await unitOfWork.RoleRepository.UpdateAsync(model);
            return await unitOfWork.SaveChangesAsync() > 0;
        }
        
        #endregion Role methods
        
        #endregion Methods
    }
}
