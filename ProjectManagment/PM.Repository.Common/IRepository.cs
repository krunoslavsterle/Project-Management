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
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Asynchronously gets all records using predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Enumerable list of records.</returns>
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);

        /// <summary>
        /// Asynchronously gets one record using predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>One record.</returns>
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Asynchronously adds entity to database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Asynchronously updates entity in the database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Asynchronously deletes entity form the database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        Task DeleteAsync(T entity);

        /// <summary>
        /// Asynchronously gets record count.
        /// </summary>
        /// <returns>Records count.</returns>
        Task<long> CountAsync();
    }
}
