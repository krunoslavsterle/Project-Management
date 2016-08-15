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
        /// Asynchronously gets one record using predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>One record.</returns>
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
                
        /// <summary>
        /// Asynchronously gets record count.
        /// </summary>
        /// <returns>Records count.</returns>
        Task<long> CountAsync();
    }
}
