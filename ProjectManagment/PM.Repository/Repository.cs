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
using PM.Common;

namespace PM.Repository
{
    /// <summary>
    /// Generic repository class.
    /// </summary>
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Constructors

        /// <summary>
        /// Initialize a new instance of <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="Context">PM app Context.</param>
        public Repository(PMAppContext Context, IMapper mapper)
        {
            this.Context = Context;
            this.Mapper = mapper;
            DbSet = this.Context.Set<T>();
        }
        
        #endregion Constructors

        /// <summary>
        /// Gets the database set.
        /// </summary>
        /// <value>
        /// The database set.
        /// </value>
        protected DbSet<T> DbSet { get; private set; }

        /// <summary>
        /// Gets the Context.
        /// </summary>
        /// <value>
        /// The Context.
        /// </value>
        protected PMAppContext Context { get; private set; }

        /// <summary>
        /// Gets the mapper.
        /// </summary>
        /// <value>
        /// The mapper.
        /// </value>
        protected IMapper Mapper { get; private set; }

        #region Methods

        /// <summary>
        /// Asynchronously gets record count.
        /// </summary>
        /// <returns>Records count.</returns>
        public Task<long> CountAsync()
        {
            return Task.FromResult<long>(DbSet.Count());
        }
        
        /// <summary>
        /// Asynchronously gets one record using predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>One record.</returns>
        public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Asynchronously gets all records using predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Enumerable list of records.</returns>
        public Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return Task.FromResult<IList<T>>(DbSet.ToList());
            }
            return Task.FromResult<IList<T>>(DbSet.Where(predicate).ToList());
        }

        
        
        #endregion Methods
    }
}
