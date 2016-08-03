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
        Task AddUserAsync(IUser model);

        /// <summary>
        /// Deletes the user asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task DeleteUserAsync(IUser model);

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IUser"/>.</returns>
        Task<IUser> GetUserById(Guid id);

        /// <summary>
        /// Finds the user by user name asynchronous.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        Task<IUser> GetUserByUserNameAsync(string userName);

        /// <summary>
        /// Updates the user asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>True if updated.</returns>
        Task<bool> UpdateUserAsync(IUser model);

        /// <summary>
        /// Creates the claim asynchronous.
        /// </summary>
        /// <returns><see cref="IClaim"/>.</returns>
        Task<IClaim> CreateClaimAsync();

        /// <summary>
        /// Creates the external login.
        /// </summary>
        /// <returns><see cref="IExternalLogin"/></returns>
        Task<IExternalLogin> CreateExternalLoginAsync();

        /// <summary>
        /// Gets the <see cref="IExternalLogin"/> by provider and key asynchronous.
        /// </summary>
        /// <param name="loginProvider">The login provider.</param>
        /// <param name="providerKey">The provider key.</param>
        /// <returns><see cref="IExternalLogin"/>.</returns>
        Task<IExternalLogin> GetExternalLoginAsync(string loginProvider, string providerKey);

        /// <summary>
        /// Adds the role asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>True if added.</returns>
        Task<bool> AddRoleAsync(IRole model);

        /// <summary>
        /// Deletes the role asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<bool> DeleteRoleAsync(IRole model);

        /// <summary>
        /// Gets the role by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        Task<IRole> GetRoleAsync(string name);

        /// <summary>
        /// Gets the role asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<IRole> GetRoleAsync(Guid id);

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns></returns>
        IList<IRole> GetAllRoles();

        /// <summary>
        /// Updates the role asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>True if updated.</returns>
        Task<bool> UpdateRoleAsync(IRole model);
    }
}
