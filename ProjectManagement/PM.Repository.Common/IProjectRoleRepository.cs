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
    /// ProjectRole repository contract.
    /// </summary>
    public interface IProjectRoleRepository
    {
        /// <summary>
        /// Gets a list of all <see cref="IProjectRolePoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectRolePoco"/> models.</returns>
        IEnumerable<IProjectRolePoco> GetAll(ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a list of all <see cref="IProjectRolePoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectRolePoco"/> models asynchronously.</returns>
        Task<IEnumerable<IProjectRolePoco>> GetAllAsync(ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="IProjectRolePoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IProjectRolePoco"/> models.</returns>
        IPagedList<IProjectRolePoco> GetAllPaged(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="IProjectRolePoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IProjectRolePoco"/> models asynchronously.</returns>
        Task<IPagedList<IProjectRolePoco>> GetAllPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="IProjectRolePoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="IProjectRolePoco"/> asynchronously.</returns>
        Task<IProjectRolePoco> GetOneAsync(Expression<Func<IProjectRolePoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="IProjectRolePoco"/> model.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        IProjectRolePoco GetOne(Expression<Func<IProjectRolePoco, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="IProjectRolePoco"/> models.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectRolePoco"/> models.</returns>
        IEnumerable<IProjectRolePoco> Get(Expression<Func<IProjectRolePoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="IProjectRolePoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectRolePoco"/> models asynchronous.</returns>
        Task<IEnumerable<IProjectRolePoco>> GetAsync(Expression<Func<IProjectRolePoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="IProjectRolePoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IProjectRolePoco"/> models.</returns>
        IPagedList<IProjectRolePoco> GetPaged(IPagingParameters pagingParameters, Expression<Func<IProjectRolePoco, bool>> filter = null, ISortingParameters orderBy = null,
            params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="IProjectRolePoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IProjectRolePoco"/> models asynchronous.</returns>
        Task<IPagedList<IProjectRolePoco>> GetPagedAsync(IPagingParameters pagingParameters, Expression<Func<IProjectRolePoco, bool>> filter = null,
            ISortingParameters orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the <see cref="IProjectRolePoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IProjectRolePoco"/>.</returns>
        IProjectRolePoco GetById(Guid id);

        /// <summary>
        /// Gets the <see cref="IProjectRolePoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IProjectRolePoco"/>.</returns>
        Task<IProjectRolePoco> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets the <see cref="IProjectRolePoco"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IProjectRolePoco"/> count.</returns>
        int GetCount(Expression<Func<IProjectRolePoco, bool>> filter = null);

        /// <summary>
        /// Gets the <see cref="IProjectRolePoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IProjectRolePoco"/> count asynchronous.</returns>
        Task<int> GetCountAsync(Expression<Func<IProjectRolePoco, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        bool GetIsExists(Expression<Func<IProjectRolePoco, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        Task<bool> GetIsExistsAsync(Expression<Func<IProjectRolePoco, bool>> filter = null);

        /// <summary>
        /// Inserts the specified <see cref="IProjectRolePoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        void Insert(IProjectRolePoco model);

        /// <summary>
        /// Inserts the list of <see cref="IProjectRolePoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Insert(IList<IProjectRolePoco> models);

        /// <summary>
        /// Inserts the specified <see cref="IProjectRolePoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task InsertAsync(IProjectRolePoco model);

        /// <summary>
        /// Inserts the list of <see cref="IProjectRolePoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task InsertAsync(IList<IProjectRolePoco> models);

        /// <summary>
        /// Updates the specified <see cref="IProjectRolePoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Update(IProjectRolePoco model);

        /// <summary>
        /// Updates the list of <see cref="IProjectRolePoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        void Update(IList<IProjectRolePoco> models);

        /// <summary>
        /// Updates the specified <see cref="IProjectRolePoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task UpdateAsync(IProjectRolePoco model);

        /// <summary>
        /// Updates the list of <see cref="IProjectRolePoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        System.Threading.Tasks.Task UpdateAsync(IList<IProjectRolePoco> models);

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
        /// Deletes the specified <see cref="IProjectRolePoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Delete(IProjectRolePoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Delete(IList<IProjectRolePoco> models);

        /// <summary>
        /// Deletes the specified <see cref="IProjectRolePoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task DeleteAsync(IProjectRolePoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task DeleteAsync(IList<IProjectRolePoco> models);

        /// <summary>
        /// Adds <see cref="IProjectRolePoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForInset(IProjectRolePoco model);

        /// <summary>
        /// Adds <see cref="IProjectRolePoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForUpdate(IProjectRolePoco model);

        /// <summary>
        /// Adds <see cref="IProjectRolePoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForDelete(IProjectRolePoco model);

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