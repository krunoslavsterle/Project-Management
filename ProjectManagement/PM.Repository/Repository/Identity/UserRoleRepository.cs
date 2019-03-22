using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using PagedList;
using PM.Model.Common;
using PM.DAL;
using PM.Repository.Common;
using PM.Common;
using PM.Model;

namespace PM.Repository
{
    /// <summary>
    /// UserRole repository.
    /// </summary>
    public class UserRoleRepository : IUserRoleRepository
    {
        #region Fields

        private readonly IGenericRepository<UserRole, IUserRolePoco> genericRepository;
        private readonly IMapper mapper;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleRepository"/> class.
        /// </summary>
        /// <param name="genericRepository">The generic repository.</param>
        /// <param name="mapper">The mapper.</param>
        public UserRoleRepository(IGenericRepository<UserRole, IUserRolePoco> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Creates the user role.
        /// </summary>
        /// <returns><see cref="IUserRolePoco"/>.</returns>
        public virtual IUserRolePoco CreateUserRole()
        {
            var userRole = new UserRolePoco();
            userRole.Id = Guid.NewGuid();
            userRole.DateCreated = DateTime.UtcNow;

            return userRole;
        }

        /// <summary>
        /// Gets a list of all <see cref="IUserRolePoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IUserRolePoco"/> models.</returns>
        public virtual IEnumerable<IUserRolePoco> GetAll(ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = genericRepository.GetAll(null, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IUserRolePoco>>(entities);
        }

        /// <summary>
        /// Gets a list of all <see cref="IUserRolePoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IUserRolePoco"/> models asynchronously.</returns>
        public virtual async Task<IEnumerable<IUserRolePoco>> GetAllAsync(ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = await genericRepository.GetAllAsync(null, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IUserRolePoco>>(entities);
        }

        /// <summary>
        /// Gets a paged list of all <see cref="IUserRolePoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IUserRolePoco"/> models.</returns>
        public virtual IPagedList<IUserRolePoco> GetAllPaged(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            int count = genericRepository.GetCount();
            var entities = genericRepository.GetAll(pagingParameters, orderBy, includeProperties);

            return new StaticPagedList<IUserRolePoco>(mapper.Map<IEnumerable<IUserRolePoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets a paged list of all <see cref="IUserRolePoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IUserRolePoco"/> models asynchronously.</returns>
        public virtual async Task<IPagedList<IUserRolePoco>> GetAllPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            int count = await genericRepository.GetCountAsync();
            var entities = await genericRepository.GetAllAsync(pagingParameters, orderBy, includeProperties);

            return new StaticPagedList<IUserRolePoco>(mapper.Map<IEnumerable<IUserRolePoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the one <see cref="IUserRolePoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="IUserRolePoco"/> asynchronously.</returns>
        public virtual async Task<IUserRolePoco> GetOneAsync(Expression<Func<IUserRolePoco, bool>> filter = null, params string[] includeProperties)
        {
            var entity = await genericRepository.GetOneAsync(filter, includeProperties);
            return mapper.Map<IUserRolePoco>(entity);
        }

        /// <summary>
        /// Gets the one <see cref="IUserRolePoco"/> model.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        public virtual IUserRolePoco GetOne(Expression<Func<IUserRolePoco, bool>> filter = null, params string[] includeProperties)
        {
            var entity = genericRepository.GetOne(filter, includeProperties);
            return mapper.Map<IUserRolePoco>(entity);
        }

        /// <summary>
        /// Gets the list of <see cref="IUserRolePoco"/> models.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IUserRolePoco"/> models.</returns>
        public virtual IEnumerable<IUserRolePoco> Get(Expression<Func<IUserRolePoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = genericRepository.Get(null, filter, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IUserRolePoco>>(entities);
        }

        /// <summary>
        /// Gets the list of <see cref="IUserRolePoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IUserRolePoco"/> models asynchronous.</returns>
        public virtual async Task<IEnumerable<IUserRolePoco>> GetAsync(Expression<Func<IUserRolePoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = await genericRepository.GetAsync(null, filter, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IUserRolePoco>>(entities);
        }

        /// <summary>
        /// Gets the paged list of <see cref="IUserRolePoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IUserRolePoco"/> models.</returns>
        public virtual IPagedList<IUserRolePoco> GetPaged(IPagingParameters pagingParameters, Expression<Func<IUserRolePoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var count = genericRepository.GetCount();
            var entities = genericRepository.Get(pagingParameters, filter, orderBy, includeProperties);

            return new StaticPagedList<IUserRolePoco>(mapper.Map<IEnumerable<IUserRolePoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the paged list of <see cref="IUserRolePoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IUserRolePoco"/> models asynchronous.</returns>
        public virtual async Task<IPagedList<IUserRolePoco>> GetPagedAsync(IPagingParameters pagingParameters, Expression<Func<IUserRolePoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var count = await genericRepository.GetCountAsync(filter);
            var entities = await genericRepository.GetAsync(pagingParameters, filter, orderBy, includeProperties);

            return new StaticPagedList<IUserRolePoco>(mapper.Map<IEnumerable<IUserRolePoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the <see cref="IUserRolePoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IUserRolePoco"/>.</returns>
        public virtual IUserRolePoco GetById(Guid id)
        {
            var entity = genericRepository.GetById(id);
            return mapper.Map<IUserRolePoco>(entity);
        }

        /// <summary>
        /// Gets the <see cref="IUserRolePoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IUserRolePoco"/>.</returns>
        public virtual async Task<IUserRolePoco> GetByIdAsync(Guid id)
        {
            var entity = await genericRepository.GetByIdAsync(id);
            return mapper.Map<IUserRolePoco>(entity);
        }

        /// <summary>
        /// Gets the <see cref="IUserRolePoco"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IUserRolePoco"/> count.</returns>
        public virtual int GetCount(Expression<Func<IUserRolePoco, bool>> filter = null)
        {
            return genericRepository.GetCount(filter);
        }

        /// <summary>
        /// Gets the <see cref="IUserRolePoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IUserRolePoco"/> count asynchronous.</returns>
        public virtual Task<int> GetCountAsync(Expression<Func<IUserRolePoco, bool>> filter = null)
        {
            return genericRepository.GetCountAsync(filter);
        }

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual bool GetIsExists(Expression<Func<IUserRolePoco, bool>> filter = null)
        {
            return genericRepository.GetIsExists(filter);
        }

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual Task<bool> GetIsExistsAsync(Expression<Func<IUserRolePoco, bool>> filter = null)
        {
            return genericRepository.GetIsExistsAsync(filter);
        }

        /// <summary>
        /// Inserts the specified <see cref="IUserRolePoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Insert(IUserRolePoco model)
        {
            genericRepository.Insert(mapper.Map<UserRole>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Inserts the list of <see cref="IUserRolePoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual void Insert(IList<IUserRolePoco> models)
        {
            var entities = mapper.Map<List<UserRole>>(models);
            entities.ForEach(p => genericRepository.Insert(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Inserts the specified <see cref="IUserRolePoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task InsertAsync(IUserRolePoco model)
        {
            genericRepository.Insert(mapper.Map<UserRole>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Inserts the list of <see cref="IUserRolePoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual System.Threading.Tasks.Task InsertAsync(IList<IUserRolePoco> models)
        {
            var entities = mapper.Map<List<UserRole>>(models);
            entities.ForEach(p => genericRepository.Insert(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Updates the specified <see cref="IUserRolePoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Update(IUserRolePoco model)
        {
            genericRepository.Update(mapper.Map<UserRole>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Updates the list of <see cref="IUserRolePoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        public virtual void Update(IList<IUserRolePoco> models)
        {
            var entities = mapper.Map<List<UserRole>>(models);
            entities.ForEach(p => genericRepository.Update(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Updates the specified <see cref="IUserRolePoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task UpdateAsync(IUserRolePoco model)
        {
            genericRepository.Update(mapper.Map<UserRole>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Updates the list of <see cref="IUserRolePoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        public virtual System.Threading.Tasks.Task UpdateAsync(IList<IUserRolePoco> models)
        {
            var entities = mapper.Map<List<UserRole>>(models);
            entities.ForEach(p => genericRepository.Update(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Deletes model by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public virtual void Delete(Guid id)
        {
            genericRepository.Delete(id);
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes models by the list of ids.
        /// </summary>
        /// <param name="ids">The list of identifiers.</param>
        public virtual void Delete(IList<Guid> ids)
        {
            ids.ToList().ForEach(p => genericRepository.Delete(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes model by id asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(Guid id)
        {
            genericRepository.Delete(id);
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Deletes models by the list of ids asynchronous.
        /// </summary>
        /// <param name="ids">The list of identifiers.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(IList<Guid> ids)
        {
            ids.ToList().ForEach(p => genericRepository.Delete(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Deletes the specified <see cref="IUserRolePoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Delete(IUserRolePoco model)
        {
            genericRepository.Delete(mapper.Map<UserRole>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual void Delete(IList<IUserRolePoco> models)
        {
            var entities = mapper.Map<List<UserRole>>(models);
            entities.ForEach(p => genericRepository.Delete(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes the specified <see cref="IUserRolePoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(IUserRolePoco model)
        {
            genericRepository.Delete(mapper.Map<UserRole>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(IList<IUserRolePoco> models)
        {
            var entities = mapper.Map<List<UserRole>>(models);
            entities.ForEach(p => genericRepository.Delete(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Adds <see cref="IUserRolePoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForInset(IUserRolePoco model)
        {
            genericRepository.Insert(mapper.Map<UserRole>(model));
        }

        /// <summary>
        /// Adds <see cref="IUserRolePoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForUpdate(IUserRolePoco model)
        {
            genericRepository.Update(mapper.Map<UserRole>(model));
        }

        /// <summary>
        /// Adds <see cref="IUserRolePoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForDelete(IUserRolePoco model)
        {
            genericRepository.Delete(model);
        }

        /// <summary>
        /// Saves the context changes.
        /// </summary>
        public virtual void Save()
        {
            genericRepository.Save();
        }

        /// <summary>
        /// Saves the context changes asynchronous.
        /// </summary>
        public virtual System.Threading.Tasks.Task SaveAsync()
        {
            return genericRepository.SaveAsync();
        }

        #endregion Methods
    }
}
