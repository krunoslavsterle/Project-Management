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
    /// Task repository contract.
    /// </summary>
    /// <seealso cref="PM.Repository.Common.IRepository{PM.DAL.Task}" />
    public interface ITaskRepository
    {
        #region Methods

        /// <summary>
        /// Creates new in-memory istance of <see cref="ITaskPoco"/> class.
        /// </summary>
        /// <returns>New in-memory istance of <see cref="ITaskPoco"/> class.</returns>
        ITaskPoco Create();

        /// <summary>
        /// Gets a list of all <see cref="ITaskPoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskPoco"/> models.</returns>
        IEnumerable<ITaskPoco> GetAll(ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a list of all <see cref="ITaskPoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskPoco"/> models asynchronously.</returns>
        Task<IEnumerable<ITaskPoco>> GetAllAsync(ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="ITaskPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="ITaskPoco"/> models.</returns>
        IPagedList<ITaskPoco> GetAllPaged(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="ITaskPoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="ITaskPoco"/> models asynchronously.</returns>
        Task<IPagedList<ITaskPoco>> GetAllPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="ITaskPoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="ITaskPoco"/> asynchronously.</returns>
        Task<ITaskPoco> GetOneAsync(Expression<Func<ITaskPoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="ITaskPoco"/> model.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        ITaskPoco GetOne(Expression<Func<ITaskPoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="ITaskPoco"/> models.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskPoco"/> models.</returns>
        IEnumerable<ITaskPoco> Get(Expression<Func<ITaskPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="ITaskPoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskPoco"/> models asynchronous.</returns>
        Task<IEnumerable<ITaskPoco>> GetAsync(Expression<Func<ITaskPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="ITaskPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="ITaskPoco"/> models.</returns>
        IPagedList<ITaskPoco> GetPaged(IPagingParameters pagingParameters, Expression<Func<ITaskPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="ITaskPoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="ITaskPoco"/> models asynchronous.</returns>
        Task<IPagedList<ITaskPoco>> GetPagedAsync(IPagingParameters pagingParameters, Expression<Func<ITaskPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the <see cref="ITaskPoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="ITaskPoco"/>.</returns>
        ITaskPoco GetById(Guid id);

        /// <summary>
        /// Gets the <see cref="ITaskPoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="ITaskPoco"/>.</returns>
        Task<ITaskPoco> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets the <see cref="ITaskPoco"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="ITaskPoco"/> count.</returns>
        int GetCount(Expression<Func<ITaskPoco, bool>> filter = null);

        /// <summary>
        /// Gets the <see cref="ITaskPoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="ITaskPoco"/> count asynchronous.</returns>
        Task<int> GetCountAsync(Expression<Func<ITaskPoco, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        bool GetIsExists(Expression<Func<ITaskPoco, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        Task<bool> GetIsExistsAsync(Expression<Func<ITaskPoco, bool>> filter = null);

        /// <summary>
        /// Inserts the specified <see cref="ITaskPoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        void Insert(ITaskPoco model);

        /// <summary>
        /// Inserts the list of <see cref="ITaskPoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Insert(IList<ITaskPoco> models);

        /// <summary>
        /// Inserts the specified <see cref="ITaskPoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task InsertAsync(ITaskPoco model);

        /// <summary>
        /// Inserts the list of <see cref="ITaskPoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task InsertAsync(IList<ITaskPoco> models);

        /// <summary>
        /// Updates the specified <see cref="ITaskPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Update(ITaskPoco model);

        /// <summary>
        /// Updates the list of <see cref="ITaskPoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        void Update(IList<ITaskPoco> models);

        /// <summary>
        /// Updates the specified <see cref="ITaskPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task UpdateAsync(ITaskPoco model);

        /// <summary>
        /// Updates the list of <see cref="ITaskPoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        System.Threading.Tasks.Task UpdateAsync(IList<ITaskPoco> models);

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
        /// Deletes the specified <see cref="ITaskPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Delete(ITaskPoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Delete(IList<ITaskPoco> models);

        /// <summary>
        /// Deletes the specified <see cref="ITaskPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task DeleteAsync(ITaskPoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task DeleteAsync(IList<ITaskPoco> models);

        /// <summary>
        /// Adds <see cref="ITaskPoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForInset(ITaskPoco model);

        /// <summary>
        /// Adds <see cref="ITaskPoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForUpdate(ITaskPoco model);

        /// <summary>
        /// Adds <see cref="ITaskPoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForDelete(ITaskPoco model);

        /// <summary>
        /// Saves the context changes.
        /// </summary>
        void Save();

        /// <summary>
        /// Saves the context changes asynchronous.
        /// </summary>
        System.Threading.Tasks.Task SaveAsync();

        #endregion Methods
    }
}
