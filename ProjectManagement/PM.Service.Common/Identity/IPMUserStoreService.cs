using Microsoft.AspNet.Identity;
using PM.Common;
using PM.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PagedList;

namespace PM.Service.Common
{
    /// <summary>
    /// PM User Store contract.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.IUserStore{PM.Model.Common.IUserPoco, System.Guid}" />
    public interface IPMUserStoreService : IUserStore<IUserPoco, Guid>, 
                                           IUserRoleStore<IUserPoco, Guid>, 
                                           IUserPasswordStore<IUserPoco, Guid>, 
                                           IUserSecurityStampStore<IUserPoco, Guid>, 
                                           IUserEmailStore<IUserPoco, Guid>
    {
        /// <summary>
        /// Creates the user asynchronous.
        /// </summary>
        /// <returns><see cref="IUserPoco"/>.</returns>
        IUserPoco CreateUser();

        /// <summary>
        /// Finds the user by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The user.</returns>
        IUserPoco FindById(Guid userId);

        /// <summary>
        /// Gets the users by company identifier asynchronous.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IUserPoco"/>.</returns>
        Task<IEnumerable<IUserPoco>> GetUsersByCompanyIdAsync(Guid companyId, params string[] includeProperties);

        /// <summary>
        /// Gets the users by company identifier paged asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The sorting parameter.</param>
        /// <param name="companyId">The company id.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>The users by company identifier paged asynchronous</returns>
        Task<IPagedList<IUserPoco>> GetUsersByCompanyIdPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy, Guid companyId, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="IUserPoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="IUserPoco"/> asynchronously.</returns>
        Task<IUserPoco> GetUserAsync(Expression<Func<IUserPoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the users asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IUserPoco"/>.</returns>
        Task<IEnumerable<IUserPoco>> GetUsersAsync(Expression<Func<IUserPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);
    }
}
