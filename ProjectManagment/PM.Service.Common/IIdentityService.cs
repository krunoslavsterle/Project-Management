using PM.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Service.Common
{
    public interface IIdentityService
    {
        /// <summary>
        /// Adds the user asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task AddUserAsync(IUserPoco model);

        /// <summary>
        /// Deletes the user asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task DeleteUserAsync(IUserPoco model);

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IUserPoco"/>.</returns>
        Task<IUserPoco> GetUserById(Guid id);

        /// <summary>
        /// Finds the user by user name asynchronous.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        Task<IUserPoco> GetUserByUserNameAsync(string userName);

        /// <summary>
        /// Updates the user asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>True if updated.</returns>
        Task<bool> UpdateUserAsync(IUserPoco model);

        /// <summary>
        /// Creates the claim asynchronous.
        /// </summary>
        /// <returns><see cref="IClaimPoco"/>.</returns>
        Task<IClaimPoco> CreateClaimAsync();

        /// <summary>
        /// Creates the external login.
        /// </summary>
        /// <returns><see cref="IExternalLoginPoco"/></returns>
        Task<IExternalLoginPoco> CreateExternalLoginAsync();

        /// <summary>
        /// Gets the <see cref="IExternalLoginPoco"/> by provider and key asynchronous.
        /// </summary>
        /// <param name="loginProvider">The login provider.</param>
        /// <param name="providerKey">The provider key.</param>
        /// <returns><see cref="IExternalLoginPoco"/>.</returns>
        Task<IExternalLoginPoco> GetExternalLoginAsync(string loginProvider, string providerKey);

        /// <summary>
        /// Adds the role asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>True if added.</returns>
        Task<bool> AddRoleAsync(IRolePoco model);

        /// <summary>
        /// Deletes the role asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<bool> DeleteRoleAsync(IRolePoco model);

        /// <summary>
        /// Gets the role by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        Task<IRolePoco> GetRoleAsync(string name);

        /// <summary>
        /// Gets the role asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<IRolePoco> GetRoleAsync(Guid id);

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns></returns>
        IList<IRolePoco> GetAllRoles();

        /// <summary>
        /// Updates the role asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>True if updated.</returns>
        Task<bool> UpdateRoleAsync(IRolePoco model);
    }
}
