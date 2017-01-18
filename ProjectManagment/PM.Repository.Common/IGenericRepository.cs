using PM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PM.Repository.Common
{
    /// <summary>
    /// Generic repository contract.
    /// </summary>
    public interface IGenericRepository<TEntity, TModel> 
        where TEntity : class
        where TModel : class
    {
        /// <summary>
        /// Get the list of all <see cref="TEntity"/>.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of all <see cref="TEntity"/>.</returns>
        IEnumerable<TEntity> GetAll(
            IPagingParameters pagingParameters,
            ISortingParameters orderBy = null,
            params string[] includeProperties);

        /// <summary>
        /// Gets the list of all <see cref="TEntity"/> asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of all <see cref="TEntity"/> asynchronous.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync(
            IPagingParameters pagingParameters,
            ISortingParameters orderBy = null,
            params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="TEntity"/> asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="TEntity"/> asynchronously.</returns>
        Task<TEntity> GetOneAsync(Expression<Func<TModel, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the one <see cref="TEntity"/>.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="TEntity" />.</returns>
        TEntity GetOne(Expression<Func<TModel, bool>> filter = null, params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="TEntity"/>.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="TEntity"/>.</returns>
        IEnumerable<TEntity> Get(
            IPagingParameters pagingParameters,
            Expression<Func<TModel, bool>> filter = null,
            ISortingParameters orderBy = null,
            params string[] includeProperties);

        /// <summary>
        /// Gets the list of <see cref="TEntity"/> asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="TEntity"/> asynchronous.</returns>
        Task<IEnumerable<TEntity>> GetAsync(
            IPagingParameters pagingParameters,
            Expression<Func<TModel, bool>> filter = null,
            ISortingParameters orderBy = null,
            params string[] includeProperties);

        /// <summary>
        /// Gets the <see cref="TEntity"/> by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="TEntity"/> by identifier.</returns>
        TEntity GetById(object id);

        /// <summary>
        /// Gets the <see cref="TEntity"/> by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="TEntity"/> by identifier asynchronous.</returns>
        Task<TEntity> GetByIdAsync(object id);

        /// <summary>
        /// Gets the <see cref="TEntity"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>The <see cref="TEntity"/> count.</returns>
        int GetCount(Expression<Func<TModel, bool>> filter = null);

        /// <summary>
        /// Gets the <see cref="TEntity"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>The <see cref="TEntity"/> count asynchronous.</returns>
        Task<int> GetCountAsync(Expression<Func<TModel, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        bool GetIsExists(Expression<Func<TModel, bool>> filter = null);

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        Task<bool> GetIsExistsAsync(Expression<Func<TModel, bool>> filter = null);

        /// <summary>
        /// Inserts the specified <see cref="TEntity"/> entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Updates the specified <see cref="TEntity"/> entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="modifiedBy">The modified by.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes entity by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(object id);

        /// <summary>
        /// Deletes the specified <see cref="TEntity"/> entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Saves this context changes.
        /// </summary>
        void Save();

        /// <summary>
        /// Saves the context changes asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        System.Threading.Tasks.Task SaveAsync();
    }
}
