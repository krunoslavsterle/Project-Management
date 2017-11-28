using PM.Repository.Common;
using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PM.DAL;
using System.Data.Entity;
using PM.Common;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using DynamicExpression.Core;
using System.Data.Entity.Migrations;

namespace PM.Repository
{
    /// <summary>
    /// Generic repository class. Implemented based on Generic Repository from Chris Pratt: <see cref="http://cpratt.co/truly-generic-repository/"/>
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class GenericRepository<TEntity, TModel> : IGenericRepository<TEntity, TModel> 
        where TEntity : class
        where TModel : class
    {
        #region Fields

        protected readonly PMDatabaseEntities context;
        protected readonly DbSet<TEntity> dbSet;
        protected readonly IMapper mapper;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        public GenericRepository(PMDatabaseEntities context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            dbSet = this.context.Set<TEntity>();
        }

        #endregion Constructors

        #region Methods
        
        /// <summary>
        /// Gets the <see cref="TEntity"/> queryable.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>       
        /// <returns>A query.</returns>
        protected virtual IQueryable<TEntity> GetQueryable(
            IPagingParameters pagingParameters,
            Expression<Func<TModel, bool>> filter = null,
            ISortingParameters orderBy = null,
            params string[] includeProperties)
        {
            // AsNoTracking - disable loading of all navigation properties automatically. 
            IQueryable<TEntity> query = context.Set<TEntity>().AsNoTracking(); 

            // Filtering using Dynamic Linq.
            if (filter != null)
                query = query.Where(DynamicExpressionHandler.GetDynamicQueryString(filter.Body));

            // Include properties.
            if (includeProperties != null && includeProperties.Length > 0)
            {
                foreach(var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            
            // Order by.
            if (orderBy != null && orderBy.Sorters.Count > 0)
            {
                foreach(var item in orderBy.Sorters)
                {
                    if (item.IsAscending)
                        query = query.OrderBy(item.OrderBy);
                    else
                        query = query.OrderBy(item.OrderBy + " descending");
                }
            }

            // Paging.
            if (pagingParameters != null)
            {
                query = query.Skip(pagingParameters.Skip);
                query = query.Take(pagingParameters.PageSize);
            }
            
            return query;
        }
        
        /// <summary>
        /// Get the list of all <see cref="TEntity"/>.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of all <see cref="TEntity"/>.</returns>
        public virtual IEnumerable<TEntity> GetAll(
            IPagingParameters pagingParameters,
            ISortingParameters orderBy = null,
            params string[] includeProperties)
        {
            return GetQueryable(pagingParameters, null, orderBy, includeProperties).ToList();
        }
        
        /// <summary>
        /// Gets the list of all <see cref="TEntity"/> asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of all <see cref="TEntity"/> asynchronous.</returns>
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(
            IPagingParameters pagingParameters,
            ISortingParameters orderBy = null,
            params string[] includeProperties)
        {
            return await GetQueryable(pagingParameters, null, orderBy, includeProperties).ToListAsync();
        }

        /// <summary>
        /// Gets the one <see cref="TEntity"/> asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="TEntity"/> asynchronously.</returns>
        public virtual async Task<TEntity> GetOneAsync(Expression<Func<TModel, bool>> filter = null, params string[] includeProperties)
        {
            return await GetQueryable(null, filter, null, includeProperties).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Gets the one <see cref="TEntity"/>.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="TEntity" />.</returns>
        public virtual TEntity GetOne(Expression<Func<TModel, bool>> filter = null, params string[] includeProperties)
        {
            return GetQueryable(null, filter, null, includeProperties).SingleOrDefault();
        }
        
        /// <summary>
        /// Gets the list of <see cref="TEntity"/>.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="TEntity"/>.</returns>
        public virtual IEnumerable<TEntity> Get(
            IPagingParameters pagingParameters,
            Expression<Func<TModel, bool>> filter = null,
            ISortingParameters orderBy = null,
            params string[] includeProperties)
        {
            return GetQueryable(pagingParameters, filter, orderBy, includeProperties).ToList();
        }

        /// <summary>
        /// Gets the list of <see cref="TEntity"/> asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="TEntity"/> asynchronous.</returns>
        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            IPagingParameters pagingParameters,
            Expression<Func<TModel, bool>> filter = null,
            ISortingParameters orderBy = null,
            params string[] includeProperties)
        {
            return await GetQueryable(pagingParameters, filter, orderBy, includeProperties).ToListAsync();
        }

        /// <summary>
        /// Gets the <see cref="TEntity"/> by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="TEntity"/> by identifier.</returns>
        public virtual TEntity GetById(object id)
        {
            return context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Gets the <see cref="TEntity"/> by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="TEntity"/> by identifier asynchronous.</returns>
        public virtual Task<TEntity> GetByIdAsync(object id)
        {
            return context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Gets the <see cref="TEntity"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>The <see cref="TEntity"/> count.</returns>
        public virtual int GetCount(Expression<Func<TModel, bool>> filter = null)
        {
            return GetQueryable(null, filter).Count();
        }

        /// <summary>
        /// Gets the <see cref="TEntity"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>The <see cref="TEntity"/> count asynchronous.</returns>
        public virtual Task<int> GetCountAsync(Expression<Func<TModel, bool>> filter = null)
        {
            return GetQueryable(null, filter).CountAsync();
        }

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual bool GetIsExists(Expression<Func<TModel, bool>> filter = null)
        {
            return GetQueryable(null, filter).Any();
        }

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual Task<bool> GetIsExistsAsync(Expression<Func<TModel, bool>> filter = null)
        {
            return GetQueryable(null, filter).AnyAsync();
        }

        /// <summary>
        /// Inserts the specified <see cref="TEntity"/> entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Updates the specified <see cref="TEntity"/> entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="modifiedBy">The modified by.</param>
        public virtual void Update(TEntity entity)
        {
            //context.Users.Local.Clear();
            //context.Set<TEntity>().Attach(entity);
            context.Set<TEntity>().AddOrUpdate<TEntity>(entity);
            
            //context.User.Local.First().Roles.Add(new Role() { Name = "User", RoleId = new Guid("1D71081D-B7A1-4457-8552-B4EF15AAB01D") });
            //context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes entity by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public virtual void Delete(object id)
        {
            TEntity entity = context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        /// <summary>
        /// Deletes the specified <see cref="TEntity"/> entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        /// <summary>
        /// Saves this context changes.
        /// </summary>
        public virtual void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                ThrowEnhancedValidationException(e);
            }
        }

        /// <summary>
        /// Saves the context changes asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        public virtual System.Threading.Tasks.Task SaveAsync()
        {
            try
            {
                return context.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                ThrowEnhancedValidationException(e);
            }

            return System.Threading.Tasks.Task.FromResult(0);
        }

        private void ThrowEnhancedValidationException(DbEntityValidationException e)
        {
            var errorMessages = e.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

            var fullErrorMessage = string.Join("; ", errorMessages);
            var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);
            throw new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
        }



        #endregion Methods
    }
}
