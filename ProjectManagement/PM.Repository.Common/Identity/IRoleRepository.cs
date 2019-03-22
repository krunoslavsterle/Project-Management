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
    /// Role repository contract.
    /// </summary>
    public interface IRoleRepository
    {
        /// <summary>
        /// Creates a instance of the <see cref="IRolePoco"/> class.
        /// </summary>
        /// <returns>Instance of the <see cref="IRolePoco"/> class.</returns>
        IRolePoco CreateRole();
        
        /// <summary>
        /// Gets a list of all <see cref="IRolePoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IRolePoco"/> models.</returns>
        IEnumerable<IRolePoco> GetAll(ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a list of all <see cref="IRolePoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IRolePoco"/> models asynchronously.</returns>
        Task<IEnumerable<IRolePoco>> GetAllAsync(ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="IRolePoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IRolePoco"/> models.</returns>
        IPagedList<IRolePoco> GetAllPaged(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="IRolePoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IRolePoco"/> models asynchronously.</returns>
        Task<IPagedList<IRolePoco>> GetAllPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="IRolePoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="IRolePoco"/> asynchronously.</returns>
        Task<IRolePoco> GetOneAsync(Expression<Func<IRolePoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="IRolePoco"/> model.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        IRolePoco GetOne(Expression<Func<IRolePoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="IRolePoco"/> models.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IRolePoco"/> models.</returns>
        IEnumerable<IRolePoco> Get(Expression<Func<IRolePoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="IRolePoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IRolePoco"/> models asynchronous.</returns>
        Task<IEnumerable<IRolePoco>> GetAsync(Expression<Func<IRolePoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="IRolePoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IRolePoco"/> models.</returns>
        IPagedList<IRolePoco> GetPaged(IPagingParameters pagingParameters, Expression<Func<IRolePoco, bool>> filter = null, ISortingParameters orderBy = null,
            params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="IRolePoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IRolePoco"/> models asynchronous.</returns>
        Task<IPagedList<IRolePoco>> GetPagedAsync(IPagingParameters pagingParameters, Expression<Func<IRolePoco, bool>> filter = null,
            ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the <see cref="IRolePoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IRolePoco"/>.</returns>
        IRolePoco GetById(Guid id);

        /// <summary>
        /// Gets the <see cref="IRolePoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IRolePoco"/>.</returns>
        Task<IRolePoco> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets the <see cref="IRolePoco"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IRolePoco"/> count.</returns>
        int GetCount(Expression<Func<IRolePoco, bool>> filter = null);

        /// <summary>
        /// Gets the <see cref="IRolePoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IRolePoco"/> count asynchronous.</returns>
        Task<int> GetCountAsync(Expression<Func<IRolePoco, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        bool GetIsExists(Expression<Func<IRolePoco, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        Task<bool> GetIsExistsAsync(Expression<Func<IRolePoco, bool>> filter = null);

        /// <summary>
        /// Inserts the specified <see cref="IRolePoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        void Insert(IRolePoco model);

        /// <summary>
        /// Inserts the list of <see cref="IRolePoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Insert(IList<IRolePoco> models);

        /// <summary>
        /// Inserts the specified <see cref="IRolePoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task InsertAsync(IRolePoco model);

        /// <summary>
        /// Inserts the list of <see cref="IRolePoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task InsertAsync(IList<IRolePoco> models);

        /// <summary>
        /// Updates the specified <see cref="IRolePoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Update(IRolePoco model);

        /// <summary>
        /// Updates the list of <see cref="IRolePoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        void Update(IList<IRolePoco> models);

        /// <summary>
        /// Updates the specified <see cref="IRolePoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task UpdateAsync(IRolePoco model);

        /// <summary>
        /// Updates the list of <see cref="IRolePoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        System.Threading.Tasks.Task UpdateAsync(IList<IRolePoco> models);

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
        /// Deletes the specified <see cref="IRolePoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Delete(IRolePoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Delete(IList<IRolePoco> models);

        /// <summary>
        /// Deletes the specified <see cref="IRolePoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task DeleteAsync(IRolePoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task DeleteAsync(IList<IRolePoco> models);

        /// <summary>
        /// Adds <see cref="IRolePoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForInset(IRolePoco model);

        /// <summary>
        /// Adds <see cref="IRolePoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForUpdate(IRolePoco model);

        /// <summary>
        /// Adds <see cref="IRolePoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForDelete(IRolePoco model);

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