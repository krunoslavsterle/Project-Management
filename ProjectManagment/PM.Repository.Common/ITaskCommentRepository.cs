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
    /// TaskComment repository contract.
    /// </summary>
    public interface ITaskCommentRepository
    {
        /// <summary>
        /// Creates <see cref="ITaskCommentPoco"/> in memmory.
        /// </summary>
        /// <returns><see cref="ITaskCommentPoco"/>.</returns>
        ITaskCommentPoco Create();

        /// <summary>
        /// Gets a list of all <see cref="ITaskCommentPoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskCommentPoco"/> models.</returns>
        IEnumerable<ITaskCommentPoco> GetAll(ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a list of all <see cref="ITaskCommentPoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskCommentPoco"/> models asynchronously.</returns>
        Task<IEnumerable<ITaskCommentPoco>> GetAllAsync(ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="ITaskCommentPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="ITaskCommentPoco"/> models.</returns>
        IPagedList<ITaskCommentPoco> GetAllPaged(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="ITaskCommentPoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="ITaskCommentPoco"/> models asynchronously.</returns>
        Task<IPagedList<ITaskCommentPoco>> GetAllPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="ITaskCommentPoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="ITaskCommentPoco"/> asynchronously.</returns>
        Task<ITaskCommentPoco> GetOneAsync(Expression<Func<ITaskCommentPoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="ITaskCommentPoco"/> model.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        ITaskCommentPoco GetOne(Expression<Func<ITaskCommentPoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="ITaskCommentPoco"/> models.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskCommentPoco"/> models.</returns>
        IEnumerable<ITaskCommentPoco> Get(Expression<Func<ITaskCommentPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="ITaskCommentPoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskCommentPoco"/> models asynchronous.</returns>
        Task<IEnumerable<ITaskCommentPoco>> GetAsync(Expression<Func<ITaskCommentPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="ITaskCommentPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="ITaskCommentPoco"/> models.</returns>
        IPagedList<ITaskCommentPoco> GetPaged(IPagingParameters pagingParameters, Expression<Func<ITaskCommentPoco, bool>> filter = null, ISortingParameters orderBy = null,
            params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="ITaskCommentPoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="ITaskCommentPoco"/> models asynchronous.</returns>
        Task<IPagedList<ITaskCommentPoco>> GetPagedAsync(IPagingParameters pagingParameters, Expression<Func<ITaskCommentPoco, bool>> filter = null,
            ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the <see cref="ITaskCommentPoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="ITaskCommentPoco"/>.</returns>
        ITaskCommentPoco GetById(Guid id);

        /// <summary>
        /// Gets the <see cref="ITaskCommentPoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="ITaskCommentPoco"/>.</returns>
        Task<ITaskCommentPoco> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets the <see cref="ITaskCommentPoco"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="ITaskCommentPoco"/> count.</returns>
        int GetCount(Expression<Func<ITaskCommentPoco, bool>> filter = null);

        /// <summary>
        /// Gets the <see cref="ITaskCommentPoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="ITaskCommentPoco"/> count asynchronous.</returns>
        Task<int> GetCountAsync(Expression<Func<ITaskCommentPoco, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        bool GetIsExists(Expression<Func<ITaskCommentPoco, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        Task<bool> GetIsExistsAsync(Expression<Func<ITaskCommentPoco, bool>> filter = null);

        /// <summary>
        /// Inserts the specified <see cref="ITaskCommentPoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        void Insert(ITaskCommentPoco model);

        /// <summary>
        /// Inserts the list of <see cref="ITaskCommentPoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Insert(IList<ITaskCommentPoco> models);

        /// <summary>
        /// Inserts the specified <see cref="ITaskCommentPoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task InsertAsync(ITaskCommentPoco model);

        /// <summary>
        /// Inserts the list of <see cref="ITaskCommentPoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task InsertAsync(IList<ITaskCommentPoco> models);

        /// <summary>
        /// Updates the specified <see cref="ITaskCommentPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Update(ITaskCommentPoco model);

        /// <summary>
        /// Updates the list of <see cref="ITaskCommentPoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        void Update(IList<ITaskCommentPoco> models);

        /// <summary>
        /// Updates the specified <see cref="ITaskCommentPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task UpdateAsync(ITaskCommentPoco model);

        /// <summary>
        /// Updates the list of <see cref="ITaskCommentPoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        System.Threading.Tasks.Task UpdateAsync(IList<ITaskCommentPoco> models);

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
        /// Deletes the specified <see cref="ITaskCommentPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Delete(ITaskCommentPoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Delete(IList<ITaskCommentPoco> models);

        /// <summary>
        /// Deletes the specified <see cref="ITaskCommentPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task DeleteAsync(ITaskCommentPoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task DeleteAsync(IList<ITaskCommentPoco> models);

        /// <summary>
        /// Adds <see cref="ITaskCommentPoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForInset(ITaskCommentPoco model);

        /// <summary>
        /// Adds <see cref="ITaskCommentPoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForUpdate(ITaskCommentPoco model);

        /// <summary>
        /// Adds <see cref="ITaskCommentPoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForDelete(ITaskCommentPoco model);

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