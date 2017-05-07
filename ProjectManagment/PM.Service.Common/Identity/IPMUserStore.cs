using Microsoft.AspNet.Identity;
using PM.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.Service.Common
{
    /// <summary>
    /// PM User Store contract.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.IUserStore{PM.Model.Common.IUserPoco, System.Guid}" />
    public interface IPMUserStore : IUserStore<IUserPoco, Guid>, IUserRoleStore<IUserPoco, Guid>, IUserPasswordStore<IUserPoco, Guid>, IUserSecurityStampStore<IUserPoco, Guid>
    {
        /// <summary>
        /// Creates the user asynchronous.
        /// </summary>
        /// <returns><see cref="IUserPoco"/>.</returns>
        IUserPoco CreateUser();

        /// <summary>
        /// Gets the users by company identifier asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IUserPoco"/>.</returns>
        Task<IEnumerable<IUserPoco>> GetUsersByCompanyIdAsync(Guid companyId, params string[] includeProperties);
    }
}
