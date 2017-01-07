using PagedList;
using PM.Common;
using PM.Common.Filters;
using PM.Model.Common;
using System;
using System.Collections.Generic;

namespace PM.Repository.Common
{
    /// <summary>
    /// Project repository contract.
    /// </summary>
    public interface IProjectRepository
    {
        /// <summary>
        /// Gets a list of all <see cref="IProjectPoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectPoco"/> models.</returns>
        IEnumerable<IProjectPoco> GetAll(string orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a list of all <see cref="IProjectPoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectPoco"/> models asynchronously.</returns>
        System.Threading.Tasks.Task<IEnumerable<IProjectPoco>> GetAllAsync(string orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="IProjectPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IProjectPoco"/> models.</returns>
        IPagedList<IProjectPoco> GetAllPaged(IPagingParameters pagingParameters, string orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets a paged list of all <see cref="IProjectPoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IProjectPoco"/> models asynchronously.</returns>
        System.Threading.Tasks.Task<IPagedList<IProjectPoco>> GetAllPagedAsync(IPagingParameters pagingParameters, string orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="IProjectPoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="IProjectPoco"/> asynchronously.</returns>
        System.Threading.Tasks.Task<IProjectPoco> GetOneAsync(ProjectFilter filter, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="IProjectPoco"/> model.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        IProjectPoco GetOne(ProjectFilter filter, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="IProjectPoco"/> models.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectPoco"/> models.</returns>
        IEnumerable<IProjectPoco> Get(ProjectFilter filter = null, string orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="IProjectPoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectPoco"/> models asynchronous.</returns>
        System.Threading.Tasks.Task<IEnumerable<IProjectPoco>> GetAsync(ProjectFilter filter = null, string orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="IProjectPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IProjectPoco"/> models.</returns>
        IPagedList<IProjectPoco> GetPaged(IPagingParameters pagingParameters, ProjectFilter filter = null, string orderBy = null, params string[] includeProperties);

        /// <summary>
        /// Gets the paged list of <see cref="IProjectPoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IProjectPoco"/> models asynchronous.</returns>
        System.Threading.Tasks.Task<IPagedList<IProjectPoco>> GetPagedAsync(
            IPagingParameters pagingParameters, 
            ProjectFilter filter = null, 
            string orderBy = null, 
            params string[] includeProperties);

        /// <summary>
        /// Gets the <see cref="IProjectPoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IProjectPoco"/>.</returns>
        IProjectPoco GetById(Guid id);

        /// <summary>
        /// Gets the <see cref="IProjectPoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IProjectPoco"/>.</returns>
        System.Threading.Tasks.Task<IProjectPoco> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets the <see cref="IProjectPoco"/> count.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns><see cref="IProjectPoco"/> count.</returns>
        int GetCount(ProjectFilter filter = null);

        /// <summary>
        /// Gets the <see cref="IProjectPoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns><see cref="IProjectPoco"/> count asynchronous.</returns>
        System.Threading.Tasks.Task<int> GetCountAsync(ProjectFilter filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        bool GetIsExists(ProjectFilter filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        System.Threading.Tasks.Task<bool> GetIsExistsAsync(ProjectFilter filter = null);

        /// <summary>
        /// Inserts the specified <see cref="IProjectPoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        void Insert(IProjectPoco model);

        /// <summary>
        /// Inserts the list of <see cref="IProjectPoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Insert(IList<IProjectPoco> models);

        /// <summary>
        /// Inserts the specified <see cref="IProjectPoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task InsertAsync(IProjectPoco model);

        /// <summary>
        /// Inserts the list of <see cref="IProjectPoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task InsertAsync(IList<IProjectPoco> models);

        /// <summary>
        /// Updates the specified <see cref="IProjectPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Update(IProjectPoco model);

        /// <summary>
        /// Updates the list of <see cref="IProjectPoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        void Update(IList<IProjectPoco> models);

        /// <summary>
        /// Updates the specified <see cref="IProjectPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task UpdateAsync(IProjectPoco model);

        /// <summary>
        /// Updates the list of <see cref="IProjectPoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        System.Threading.Tasks.Task UpdateAsync(IList<IProjectPoco> models);

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
        /// Deletes the specified <see cref="IProjectPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Delete(IProjectPoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        void Delete(IList<IProjectPoco> models);

        /// <summary>
        /// Deletes the specified <see cref="IProjectPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        System.Threading.Tasks.Task DeleteAsync(IProjectPoco model);

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        System.Threading.Tasks.Task DeleteAsync(IList<IProjectPoco> models);

        /// <summary>
        /// Adds <see cref="IProjectPoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForInset(IProjectPoco model);

        /// <summary>
        /// Adds <see cref="IProjectPoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForUpdate(IProjectPoco model);

        /// <summary>
        /// Adds <see cref="IProjectPoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        void AddForDelete(IProjectPoco model);

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
