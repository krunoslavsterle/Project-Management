using PagedList;
using PM.Common;
using PM.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PM.Service.Common
{
    /// <summary>
    /// Project service contract.
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// Creates the project.
        /// </summary>
        /// <returns></returns>
        IProjectPoco CreateProject();

        /// <summary>
        /// Creates the project user in memory.
        /// </summary>
        /// <returns><see cref="IProjectUserPoco"/> model.</returns>
        IProjectUserPoco CreateProjectUser();

        /// <summary>
        /// Gets the <see cref="IProject"/> asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns><see cref="IProjectPoco"/> model.</returns>
        Task<IProjectPoco> GetProjectAsync(Guid id, params string[] includeProperties);

        /// <summary>
        /// Gets the list of projects asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectPoco"/>.</returns>
        Task<IEnumerable<IProjectPoco>> GetProjectsAsync(Expression<Func<IProjectPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="IProjectPoco"/> paged asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectPoco"/> paged.</returns>
        Task<IPagedList<IProjectPoco>> GetProjectsPagedAsync(IPagingParameters pagingParameters, Expression<Func<IProjectPoco, bool>> filter, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Inserts the <see cref="IProjectPoco"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        Task InsertProjectAsync(IProjectPoco model);

        /// <summary>
        /// Inserts the list of <see cref="IProjectPoco"/> asynchronous.
        /// </summary>
        /// <param name="models">The list of projects.</param>
        /// <returns>Task.</returns>
        Task InsertProjectsAsync(IEnumerable<IProjectPoco> models);

        /// <summary>
        /// Deletes the <see cref="IProjectPoco"/> asynchronous.
        /// </summary>
        /// <param name="id">The project identifier.</param>
        /// <returns>Task.</returns>
        Task DeleteProjectAsync(Guid id);

        /// <summary>
        /// Updates the <see cref="IProjectPoco"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        Task UpdateProjectAsync(IProjectPoco model);

        /// <summary>
        /// Updates the list of <see cref="IProjectPoco"/> asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        /// <returns>Task.</returns>
        Task UpdateProjectsAsync(IEnumerable<IProjectPoco> models);

        /// <summary>
        /// Gets the one <see cref="IProjectUserPoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="IProjectUserPoco"/> asynchronously.</returns>
        Task<IProjectUserPoco> GetProjectUserAsync(Expression<Func<IProjectUserPoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="IProjectUserPoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectUserPoco"/> models asynchronous.</returns>
        Task<IEnumerable<IProjectUserPoco>> GetProjectUsersAsync(Expression<Func<IProjectUserPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="IProjectUserPoco"/> asynchrously. 
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The sorting parameters.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>The paged list of <see cref="IProjectUserPoco"/> asynchrously. </returns>
        Task<IPagedList<IProjectUserPoco>> GetProjectUsersPagedAsync(IPagingParameters pagingParameters, Expression<Func<IProjectUserPoco, bool>> filter, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Inserts the project user asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task InsertProjectUserAsync(IProjectUserPoco model);
    }
}
