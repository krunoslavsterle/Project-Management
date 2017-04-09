using PagedList;
using PM.Common;
using PM.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PM.Repository
{
    /// <summary>
    /// Company repository contract.
    /// </summary>
    public interface ICompanyRepository
    {
        /// <summary>
        /// Creates a new <see cref="ICompanyPoco"/> in memory instance.
        /// </summary>
        /// <returns>A new <see cref="ICompanyPoco"/> in memory instance.</returns>
        ICompanyPoco Create();

        /// <summary>
        /// Gets a list of all <see cref="ICompanyPoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ICompanyPoco"/> models.</returns>
        IEnumerable<ICompanyPoco> GetAll(ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a list of all <see cref="ICompanyPoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ICompanyPoco"/> models asynchronously.</returns>
        Task<IEnumerable<ICompanyPoco>> GetAllAsync(ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="ICompanyPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="ICompanyPoco"/> models.</returns>
        IPagedList<ICompanyPoco> GetAllPaged(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="ICompanyPoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="ICompanyPoco"/> models asynchronously.</returns>
        Task<IPagedList<ICompanyPoco>> GetAllPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="ICompanyPoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="ICompanyPoco"/> asynchronously.</returns>
        Task<ICompanyPoco> GetOneAsync(Expression<Func<ICompanyPoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="ICompanyPoco"/> model.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        ICompanyPoco GetOne(Expression<Func<ICompanyPoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="ICompanyPoco"/> models.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ICompanyPoco"/> models.</returns>
        IEnumerable<ICompanyPoco> Get(Expression<Func<ICompanyPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="ICompanyPoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ICompanyPoco"/> models asynchronous.</returns>
        Task<IEnumerable<ICompanyPoco>> GetAsync(Expression<Func<ICompanyPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="ICompanyPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="ICompanyPoco"/> models.</returns>
        IPagedList<ICompanyPoco> GetPaged(IPagingParameters pagingParameters, Expression<Func<ICompanyPoco, bool>> filter = null, ISortingParameters orderBy = null,
            params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="ICompanyPoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="ICompanyPoco"/> models asynchronous.</returns>
        Task<IPagedList<ICompanyPoco>> GetPagedAsync(IPagingParameters pagingParameters, Expression<Func<ICompanyPoco, bool>> filter = null,
            ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the <see cref="ICompanyPoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="ICompanyPoco"/>.</returns>
        ICompanyPoco GetById(Guid id);

        /// <summary>
        /// Gets the <see cref="ICompanyPoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="ICompanyPoco"/>.</returns>
        Task<ICompanyPoco> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets the <see cref="ICompanyPoco"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="ICompanyPoco"/> count.</returns>
        int GetCount(Expression<Func<ICompanyPoco, bool>> filter = null);

        /// <summary>
        /// Gets the <see cref="ICompanyPoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="ICompanyPoco"/> count asynchronous.</returns>
        Task<int> GetCountAsync(Expression<Func<ICompanyPoco, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        bool GetIsExists(Expression<Func<ICompanyPoco, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        Task<bool> GetIsExistsAsync(Expression<Func<ICompanyPoco, bool>> filter = null);

        /// <summary>
        /// Inserts the specified <see cref="ICompanyPoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        void Insert(ICompanyPoco model);

        /// <summary>
        /// Inserts the list of <see cref="ICompanyPoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Insert(IList<ICompanyPoco> models);

        /// <summary>
        /// Inserts the specified <see cref="ICompanyPoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task InsertAsync(ICompanyPoco model);

        /// <summary>
        /// Inserts the list of <see cref="ICompanyPoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task InsertAsync(IList<ICompanyPoco> models);

        /// <summary>
        /// Updates the specified <see cref="ICompanyPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Update(ICompanyPoco model);

        /// <summary>
        /// Updates the list of <see cref="ICompanyPoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        void Update(IList<ICompanyPoco> models);

        /// <summary>
        /// Updates the specified <see cref="ICompanyPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task UpdateAsync(ICompanyPoco model);

        /// <summary>
        /// Updates the list of <see cref="ICompanyPoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        System.Threading.Tasks.Task UpdateAsync(IList<ICompanyPoco> models);

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
        /// Deletes the specified <see cref="ICompanyPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Delete(ICompanyPoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Delete(IList<ICompanyPoco> models);

        /// <summary>
        /// Deletes the specified <see cref="ICompanyPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task DeleteAsync(ICompanyPoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task DeleteAsync(IList<ICompanyPoco> models);

        /// <summary>
        /// Adds <see cref="ICompanyPoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForInset(ICompanyPoco model);

        /// <summary>
        /// Adds <see cref="ICompanyPoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForUpdate(ICompanyPoco model);

        /// <summary>
        /// Adds <see cref="ICompanyPoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForDelete(ICompanyPoco model);

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