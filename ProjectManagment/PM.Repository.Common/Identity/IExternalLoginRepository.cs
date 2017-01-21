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
    /// External login repository contract.
    /// </summary>
    public interface IExternalLoginRepository
    {
        /// <summary>
        /// Creates <see cref="IExternalLoginPoco"/> the asynchronous.
        /// </summary>
        /// <returns><see cref="IExternalLoginPoco"/>.</returns>
        System.Threading.Tasks.Task<IExternalLoginPoco> CreateAsync();

        /// <summary>
        /// Gets a list of all <see cref="IExternalLoginPoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IExternalLoginPoco"/> models.</returns>
        IEnumerable<IExternalLoginPoco> GetAll(ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a list of all <see cref="IExternalLoginPoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IExternalLoginPoco"/> models asynchronously.</returns>
        Task<IEnumerable<IExternalLoginPoco>> GetAllAsync(ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="IExternalLoginPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IExternalLoginPoco"/> models.</returns>
        IPagedList<IExternalLoginPoco> GetAllPaged(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="IExternalLoginPoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IExternalLoginPoco"/> models asynchronously.</returns>
        Task<IPagedList<IExternalLoginPoco>> GetAllPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="IExternalLoginPoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="IExternalLoginPoco"/> asynchronously.</returns>
        Task<IExternalLoginPoco> GetOneAsync(Expression<Func<IExternalLoginPoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="IExternalLoginPoco"/> model.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        IExternalLoginPoco GetOne(Expression<Func<IExternalLoginPoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="IExternalLoginPoco"/> models.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IExternalLoginPoco"/> models.</returns>
        IEnumerable<IExternalLoginPoco> Get(Expression<Func<IExternalLoginPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="IExternalLoginPoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IExternalLoginPoco"/> models asynchronous.</returns>
        Task<IEnumerable<IExternalLoginPoco>> GetAsync(Expression<Func<IExternalLoginPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="IExternalLoginPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IExternalLoginPoco"/> models.</returns>
        IPagedList<IExternalLoginPoco> GetPaged(IPagingParameters pagingParameters, Expression<Func<IExternalLoginPoco, bool>> filter = null, ISortingParameters orderBy = null,
            params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="IExternalLoginPoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IExternalLoginPoco"/> models asynchronous.</returns>
        Task<IPagedList<IExternalLoginPoco>> GetPagedAsync(IPagingParameters pagingParameters, Expression<Func<IExternalLoginPoco, bool>> filter = null,
            ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the <see cref="IExternalLoginPoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IExternalLoginPoco"/>.</returns>
        IExternalLoginPoco GetById(Guid id);

        /// <summary>
        /// Gets the <see cref="IExternalLoginPoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IExternalLoginPoco"/>.</returns>
        Task<IExternalLoginPoco> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets the <see cref="IExternalLoginPoco"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IExternalLoginPoco"/> count.</returns>
        int GetCount(Expression<Func<IExternalLoginPoco, bool>> filter = null);

        /// <summary>
        /// Gets the <see cref="IExternalLoginPoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IExternalLoginPoco"/> count asynchronous.</returns>
        Task<int> GetCountAsync(Expression<Func<IExternalLoginPoco, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        bool GetIsExists(Expression<Func<IExternalLoginPoco, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        Task<bool> GetIsExistsAsync(Expression<Func<IExternalLoginPoco, bool>> filter = null);

        /// <summary>
        /// Inserts the specified <see cref="IExternalLoginPoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        void Insert(IExternalLoginPoco model);

        /// <summary>
        /// Inserts the list of <see cref="IExternalLoginPoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Insert(IList<IExternalLoginPoco> models);

        /// <summary>
        /// Inserts the specified <see cref="IExternalLoginPoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task InsertAsync(IExternalLoginPoco model);

        /// <summary>
        /// Inserts the list of <see cref="IExternalLoginPoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task InsertAsync(IList<IExternalLoginPoco> models);

        /// <summary>
        /// Updates the specified <see cref="IExternalLoginPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Update(IExternalLoginPoco model);

        /// <summary>
        /// Updates the list of <see cref="IExternalLoginPoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        void Update(IList<IExternalLoginPoco> models);

        /// <summary>
        /// Updates the specified <see cref="IExternalLoginPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task UpdateAsync(IExternalLoginPoco model);

        /// <summary>
        /// Updates the list of <see cref="IExternalLoginPoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        System.Threading.Tasks.Task UpdateAsync(IList<IExternalLoginPoco> models);

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
        /// Deletes the specified <see cref="IExternalLoginPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Delete(IExternalLoginPoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Delete(IList<IExternalLoginPoco> models);

        /// <summary>
        /// Deletes the specified <see cref="IExternalLoginPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task DeleteAsync(IExternalLoginPoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task DeleteAsync(IList<IExternalLoginPoco> models);

        /// <summary>
        /// Adds <see cref="IExternalLoginPoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForInset(IExternalLoginPoco model);

        /// <summary>
        /// Adds <see cref="IExternalLoginPoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForUpdate(IExternalLoginPoco model);

        /// <summary>
        /// Adds <see cref="IExternalLoginPoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForDelete(IExternalLoginPoco model);

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