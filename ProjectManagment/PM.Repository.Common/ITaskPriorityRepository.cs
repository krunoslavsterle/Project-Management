using PagedList;
using PM.Common;
using PM.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PM.Repository.Common
{
    /// <summary>
    /// TaskPriority repository contract.
    /// </summary>
    public interface ITaskPriorityRepository
    {
        /// <summary>
        /// Gets a list of all <see cref="ITaskPriorityPoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskPriorityPoco"/> models.</returns>
        IEnumerable<ITaskPriorityPoco> GetAll(ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a list of all <see cref="ITaskPriorityPoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskPriorityPoco"/> models asynchronously.</returns>
        Task<IEnumerable<ITaskPriorityPoco>> GetAllAsync(ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="ITaskPriorityPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="ITaskPriorityPoco"/> models.</returns>
        IPagedList<ITaskPriorityPoco> GetAllPaged(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="ITaskPriorityPoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="ITaskPriorityPoco"/> models asynchronously.</returns>
        Task<IPagedList<ITaskPriorityPoco>> GetAllPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="ITaskPriorityPoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="ITaskPriorityPoco"/> asynchronously.</returns>
        Task<ITaskPriorityPoco> GetOneAsync(Expression<Func<ITaskPriorityPoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="ITaskPriorityPoco"/> model.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        ITaskPriorityPoco GetOne(Expression<Func<ITaskPriorityPoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="ITaskPriorityPoco"/> models.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskPriorityPoco"/> models.</returns>
        IEnumerable<ITaskPriorityPoco> Get(Expression<Func<ITaskPriorityPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="ITaskPriorityPoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskPriorityPoco"/> models asynchronous.</returns>
        Task<IEnumerable<ITaskPriorityPoco>> GetAsync(Expression<Func<ITaskPriorityPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="ITaskPriorityPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="ITaskPriorityPoco"/> models.</returns>
        IPagedList<ITaskPriorityPoco> GetPaged(IPagingParameters pagingParameters, Expression<Func<ITaskPriorityPoco, bool>> filter = null, ISortingParameters orderBy = null,
            params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="ITaskPriorityPoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="ITaskPriorityPoco"/> models asynchronous.</returns>
        Task<IPagedList<ITaskPriorityPoco>> GetPagedAsync(IPagingParameters pagingParameters, Expression<Func<ITaskPriorityPoco, bool>> filter = null,
            ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the <see cref="ITaskPriorityPoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="ITaskPriorityPoco"/>.</returns>
        ITaskPriorityPoco GetById(Guid id);

        /// <summary>
        /// Gets the <see cref="ITaskPriorityPoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="ITaskPriorityPoco"/>.</returns>
        Task<ITaskPriorityPoco> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets the <see cref="ITaskPriorityPoco"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="ITaskPriorityPoco"/> count.</returns>
        int GetCount(Expression<Func<ITaskPriorityPoco, bool>> filter = null);

        /// <summary>
        /// Gets the <see cref="ITaskPriorityPoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="ITaskPriorityPoco"/> count asynchronous.</returns>
        Task<int> GetCountAsync(Expression<Func<ITaskPriorityPoco, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        bool GetIsExists(Expression<Func<ITaskPriorityPoco, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        Task<bool> GetIsExistsAsync(Expression<Func<ITaskPriorityPoco, bool>> filter = null);

        /// <summary>
        /// Inserts the specified <see cref="ITaskPriorityPoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        void Insert(ITaskPriorityPoco model);

        /// <summary>
        /// Inserts the list of <see cref="ITaskPriorityPoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Insert(IList<ITaskPriorityPoco> models);

        /// <summary>
        /// Inserts the specified <see cref="ITaskPriorityPoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task InsertAsync(ITaskPriorityPoco model);

        /// <summary>
        /// Inserts the list of <see cref="ITaskPriorityPoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task InsertAsync(IList<ITaskPriorityPoco> models);

        /// <summary>
        /// Updates the specified <see cref="ITaskPriorityPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Update(ITaskPriorityPoco model);

        /// <summary>
        /// Updates the list of <see cref="ITaskPriorityPoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        void Update(IList<ITaskPriorityPoco> models);

        /// <summary>
        /// Updates the specified <see cref="ITaskPriorityPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task UpdateAsync(ITaskPriorityPoco model);

        /// <summary>
        /// Updates the list of <see cref="ITaskPriorityPoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        System.Threading.Tasks.Task UpdateAsync(IList<ITaskPriorityPoco> models);

        /// <summary>
        /// Deletes model by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(Guid id);

        /// <summary>
        /// Deletes models by the list of ids.
        /// </summary>
        /// <param name="ids">The list of identifiers.</param>
        void Delete(IList<Guid> ids);

        /// <summary>
        /// Deletes model by id asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        System.Threading.Tasks.Task DeleteAsync(Guid id);

        /// <summary>
        /// Deletes models by the list of ids asynchronous.
        /// </summary>
        /// <param name="ids">The list of identifiers.</param>
        System.Threading.Tasks.Task DeleteAsync(IList<Guid> ids);

        /// <summary>
        /// Deletes the specified <see cref="ITaskPriorityPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Delete(ITaskPriorityPoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Delete(IList<ITaskPriorityPoco> models);

        /// <summary>
        /// Deletes the specified <see cref="ITaskPriorityPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task DeleteAsync(ITaskPriorityPoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task DeleteAsync(IList<ITaskPriorityPoco> models);

        /// <summary>
        /// Adds <see cref="ITaskPriorityPoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForInset(ITaskPriorityPoco model);

        /// <summary>
        /// Adds <see cref="ITaskPriorityPoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForUpdate(ITaskPriorityPoco model);

        /// <summary>
        /// Adds <see cref="ITaskPriorityPoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForDelete(ITaskPriorityPoco model);

        /// <summary>
        /// Saves the context changes.
        /// </summary>
        void Save();

        /// <summary>
        /// Saves the context changes asynchronous.
        /// </summary>
        System.Threading.Tasks.Task SaveAsync();
    }
}