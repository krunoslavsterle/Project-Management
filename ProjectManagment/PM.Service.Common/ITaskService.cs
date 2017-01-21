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
    /// Task service contract.
    /// </summary>
    public interface ITaskService
    {
        /// <summary>
        /// Gets the <see cref="ITaskPoco"/> asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="ITaskPoco"/> model.</returns>
        Task<ITaskPoco> GetTaskAsync(Guid id);

        /// <summary>
        /// Gets the list of Tasks asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskPoco"/>.</returns>
        Task<IEnumerable<ITaskPoco>> GetTasksAsync(Expression<Func<ITaskPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="ITaskPoco"/> paged asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskPoco"/> paged.</returns>
        Task<IPagedList<ITaskPoco>> GetTasksPagedAsync(IPagingParameters pagingParameters, Expression<Func<ITaskPoco, bool>> filter, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Inserts the <see cref="ITaskPoco"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        Task InsertTaskAsync(ITaskPoco model);

        /// <summary>
        /// Inserts the list of <see cref="ITaskPoco"/> asynchronous.
        /// </summary>
        /// <param name="models">The list of Tasks.</param>
        /// <returns>Task.</returns>
        Task InsertTasksAsync(IEnumerable<ITaskPoco> models);

        /// <summary>
        /// Deletes the <see cref="ITaskPoco"/> asynchronous.
        /// </summary>
        /// <param name="id">The Task identifier.</param>
        /// <returns>Task.</returns>
        Task DeleteTaskAsync(Guid id);

        /// <summary>
        /// Updates the <see cref="ITaskPoco"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        Task UpdateTaskAsync(ITaskPoco model);

        /// <summary>
        /// Updates the list of <see cref="ITaskPoco"/> asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        /// <returns>Task.</returns>
        Task UpdateTasksAsync(IEnumerable<ITaskPoco> models);
    }
}
