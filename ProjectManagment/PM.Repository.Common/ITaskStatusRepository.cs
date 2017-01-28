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
    /// TaskStatus repository contract.
    /// </summary>
    public interface ITaskStatusRepository
    {
        /// <summary>
        /// Gets a list of all <see cref="ITaskStatusPoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskStatusPoco"/> models.</returns>
        IEnumerable<ITaskStatusPoco> GetAll(ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a list of all <see cref="ITaskStatusPoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskStatusPoco"/> models asynchronously.</returns>
        Task<IEnumerable<ITaskStatusPoco>> GetAllAsync(ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="ITaskStatusPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="ITaskStatusPoco"/> models.</returns>
        IPagedList<ITaskStatusPoco> GetAllPaged(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="ITaskStatusPoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="ITaskStatusPoco"/> models asynchronously.</returns>
        Task<IPagedList<ITaskStatusPoco>> GetAllPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="ITaskStatusPoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="ITaskStatusPoco"/> asynchronously.</returns>
        Task<ITaskStatusPoco> GetOneAsync(Expression<Func<ITaskStatusPoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="ITaskStatusPoco"/> model.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        ITaskStatusPoco GetOne(Expression<Func<ITaskStatusPoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="ITaskStatusPoco"/> models.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskStatusPoco"/> models.</returns>
        IEnumerable<ITaskStatusPoco> Get(Expression<Func<ITaskStatusPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="ITaskStatusPoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskStatusPoco"/> models asynchronous.</returns>
        Task<IEnumerable<ITaskStatusPoco>> GetAsync(Expression<Func<ITaskStatusPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="ITaskStatusPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="ITaskStatusPoco"/> models.</returns>
        IPagedList<ITaskStatusPoco> GetPaged(IPagingParameters pagingParameters, Expression<Func<ITaskStatusPoco, bool>> filter = null, ISortingParameters orderBy = null,
            params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="ITaskStatusPoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="ITaskStatusPoco"/> models asynchronous.</returns>
        Task<IPagedList<ITaskStatusPoco>> GetPagedAsync(IPagingParameters pagingParameters, Expression<Func<ITaskStatusPoco, bool>> filter = null,
            ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the <see cref="ITaskStatusPoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="ITaskStatusPoco"/>.</returns>
        ITaskStatusPoco GetById(Guid id);

        /// <summary>
        /// Gets the <see cref="ITaskStatusPoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="ITaskStatusPoco"/>.</returns>
        Task<ITaskStatusPoco> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets the <see cref="ITaskStatusPoco"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="ITaskStatusPoco"/> count.</returns>
        int GetCount(Expression<Func<ITaskStatusPoco, bool>> filter = null);

        /// <summary>
        /// Gets the <see cref="ITaskStatusPoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="ITaskStatusPoco"/> count asynchronous.</returns>
        Task<int> GetCountAsync(Expression<Func<ITaskStatusPoco, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        bool GetIsExists(Expression<Func<ITaskStatusPoco, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        Task<bool> GetIsExistsAsync(Expression<Func<ITaskStatusPoco, bool>> filter = null);

        /// <summary>
        /// Inserts the specified <see cref="ITaskStatusPoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        void Insert(ITaskStatusPoco model);

        /// <summary>
        /// Inserts the list of <see cref="ITaskStatusPoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Insert(IList<ITaskStatusPoco> models);

        /// <summary>
        /// Inserts the specified <see cref="ITaskStatusPoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task InsertAsync(ITaskStatusPoco model);

        /// <summary>
        /// Inserts the list of <see cref="ITaskStatusPoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task InsertAsync(IList<ITaskStatusPoco> models);

        /// <summary>
        /// Updates the specified <see cref="ITaskStatusPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Update(ITaskStatusPoco model);

        /// <summary>
        /// Updates the list of <see cref="ITaskStatusPoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        void Update(IList<ITaskStatusPoco> models);

        /// <summary>
        /// Updates the specified <see cref="ITaskStatusPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task UpdateAsync(ITaskStatusPoco model);

        /// <summary>
        /// Updates the list of <see cref="ITaskStatusPoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        System.Threading.Tasks.Task UpdateAsync(IList<ITaskStatusPoco> models);

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
        /// Deletes the specified <see cref="ITaskStatusPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Delete(ITaskStatusPoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Delete(IList<ITaskStatusPoco> models);

        /// <summary>
        /// Deletes the specified <see cref="ITaskStatusPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task DeleteAsync(ITaskStatusPoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task DeleteAsync(IList<ITaskStatusPoco> models);

        /// <summary>
        /// Adds <see cref="ITaskStatusPoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForInset(ITaskStatusPoco model);

        /// <summary>
        /// Adds <see cref="ITaskStatusPoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForUpdate(ITaskStatusPoco model);

        /// <summary>
        /// Adds <see cref="ITaskStatusPoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForDelete(ITaskStatusPoco model);

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