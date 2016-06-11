using PM.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PM.DAL;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace PM.Repository
{
    /// <summary>
    /// Generic repository class.
    /// </summary>
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Fields

        private PMAppContext context = null;
        private DbSet<T> dbSet = null;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initialize a new instance of <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="context">PM app context.</param>
        public Repository(PMAppContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Asynchronously adds entity to database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public Task AddAsync(T entity)
        {
            return Task.FromResult(dbSet.Add(entity));
        }

        /// <summary>
        /// Asynchronously gets record count.
        /// </summary>
        /// <returns>Records count.</returns>
        public Task<long> CountAsync()
        {
            return Task.FromResult<long>(dbSet.Count());
        }

        /// <summary>
        /// Asynchronously deletes entity form the database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            return Task.FromResult(true);
        }

        /// <summary>
        /// Asynchronously gets one record using predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>One record.</returns>
        public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return dbSet.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Asynchronously gets all records using predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Enumerable list of records.</returns>
        public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return Task.FromResult<IEnumerable<T>>(dbSet.AsEnumerable());
            }
            return Task.FromResult<IEnumerable<T>>(dbSet.Where(predicate));
        }

        /// <summary>
        /// Asynchronously updates entity in the database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public Task UpdateAsync(T entity)
        {
            dbSet.Attach(entity);
            ((IObjectContextAdapter)context).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            return Task.FromResult(true);
        }

        #endregion Methods
    }
}
