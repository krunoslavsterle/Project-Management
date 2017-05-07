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
    /// UserRole repository contract.
    /// </summary>
    public interface IUserRoleRepository
    {
        /// <summary>
        /// Creates the user role.
        /// </summary>
        /// <returns><see cref="IUserRolePoco"/>.</returns>
        IUserRolePoco CreateUserRole();

        /// <summary>
        /// Gets a list of all <see cref="IUserRolePoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IUserRolePoco"/> models.</returns>
        IEnumerable<IUserRolePoco> GetAll(ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a list of all <see cref="IUserRolePoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IUserRolePoco"/> models asynchronously.</returns>
        Task<IEnumerable<IUserRolePoco>> GetAllAsync(ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="IUserRolePoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IUserRolePoco"/> models.</returns>
        IPagedList<IUserRolePoco> GetAllPaged(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="IUserRolePoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IUserRolePoco"/> models asynchronously.</returns>
        Task<IPagedList<IUserRolePoco>> GetAllPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="IUserRolePoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="IUserRolePoco"/> asynchronously.</returns>
        Task<IUserRolePoco> GetOneAsync(Expression<Func<IUserRolePoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="IUserRolePoco"/> model.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        IUserRolePoco GetOne(Expression<Func<IUserRolePoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="IUserRolePoco"/> models.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IUserRolePoco"/> models.</returns>
        IEnumerable<IUserRolePoco> Get(Expression<Func<IUserRolePoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="IUserRolePoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IUserRolePoco"/> models asynchronous.</returns>
        Task<IEnumerable<IUserRolePoco>> GetAsync(Expression<Func<IUserRolePoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="IUserRolePoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IUserRolePoco"/> models.</returns>
        IPagedList<IUserRolePoco> GetPaged(IPagingParameters pagingParameters, Expression<Func<IUserRolePoco, bool>> filter = null, ISortingParameters orderBy = null,
            params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="IUserRolePoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IUserRolePoco"/> models asynchronous.</returns>
        Task<IPagedList<IUserRolePoco>> GetPagedAsync(IPagingParameters pagingParameters, Expression<Func<IUserRolePoco, bool>> filter = null,
            ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the <see cref="IUserRolePoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IUserRolePoco"/>.</returns>
        IUserRolePoco GetById(Guid id);

        /// <summary>
        /// Gets the <see cref="IUserRolePoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IUserRolePoco"/>.</returns>
        Task<IUserRolePoco> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets the <see cref="IUserRolePoco"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IUserRolePoco"/> count.</returns>
        int GetCount(Expression<Func<IUserRolePoco, bool>> filter = null);

        /// <summary>
        /// Gets the <see cref="IUserRolePoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IUserRolePoco"/> count asynchronous.</returns>
        Task<int> GetCountAsync(Expression<Func<IUserRolePoco, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        bool GetIsExists(Expression<Func<IUserRolePoco, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        Task<bool> GetIsExistsAsync(Expression<Func<IUserRolePoco, bool>> filter = null);

        /// <summary>
        /// Inserts the specified <see cref="IUserRolePoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        void Insert(IUserRolePoco model);

        /// <summary>
        /// Inserts the list of <see cref="IUserRolePoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Insert(IList<IUserRolePoco> models);

        /// <summary>
        /// Inserts the specified <see cref="IUserRolePoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task InsertAsync(IUserRolePoco model);

        /// <summary>
        /// Inserts the list of <see cref="IUserRolePoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task InsertAsync(IList<IUserRolePoco> models);

        /// <summary>
        /// Updates the specified <see cref="IUserRolePoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Update(IUserRolePoco model);

        /// <summary>
        /// Updates the list of <see cref="IUserRolePoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        void Update(IList<IUserRolePoco> models);

        /// <summary>
        /// Updates the specified <see cref="IUserRolePoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task UpdateAsync(IUserRolePoco model);

        /// <summary>
        /// Updates the list of <see cref="IUserRolePoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        System.Threading.Tasks.Task UpdateAsync(IList<IUserRolePoco> models);

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
        /// Deletes the specified <see cref="IUserRolePoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Delete(IUserRolePoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Delete(IList<IUserRolePoco> models);

        /// <summary>
        /// Deletes the specified <see cref="IUserRolePoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task DeleteAsync(IUserRolePoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task DeleteAsync(IList<IUserRolePoco> models);

        /// <summary>
        /// Adds <see cref="IUserRolePoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForInset(IUserRolePoco model);

        /// <summary>
        /// Adds <see cref="IUserRolePoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForUpdate(IUserRolePoco model);

        /// <summary>
        /// Adds <see cref="IUserRolePoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForDelete(IUserRolePoco model);

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