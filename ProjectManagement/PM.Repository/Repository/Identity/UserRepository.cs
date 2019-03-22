using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using PagedList;
using PM.Model.Common;
using PM.Common;
using PM.Repository.Common;
using PM.DAL;
using PM.Model;

namespace PM.Repository
{
    /// <summary>
    /// User repository.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        #region Fields

        private readonly IGenericRepository<User, IUserPoco> genericRepository;
        private readonly IMapper mapper;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="genericRepository">The generic repository.</param>
        /// <param name="mapper">The mapper.</param>
        public UserRepository(IGenericRepository<User, IUserPoco> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Creates the instance of the <see cref="IUserPoco"/> class.
        /// </summary>
        /// <returns>The instance of the <see cref="IUserPoco"/> class.</returns>
        public virtual IUserPoco CreateUser()
        {
            IUserPoco user = new UserPoco()
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };
            return user;
        }
        
        /// <summary>
        /// Creates the claim asynchronous.
        /// </summary>
        /// <returns><see cref="IClaim"/>.</returns>
        public System.Threading.Tasks.Task<IClaimPoco> CreateClaimAsync()
        {
            IClaimPoco claim = new ClaimPoco();
            return System.Threading.Tasks.Task.FromResult(claim);
        }

        /// <summary>
        /// Gets a list of all <see cref="IUserPoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IUserPoco"/> models.</returns>
        public virtual IEnumerable<IUserPoco> GetAll(ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = genericRepository.GetAll(null, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IUserPoco>>(entities);
        }

        /// <summary>
        /// Gets a list of all <see cref="IUserPoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IUserPoco"/> models asynchronously.</returns>
        public virtual async Task<IEnumerable<IUserPoco>> GetAllAsync(ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = await genericRepository.GetAllAsync(null, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IUserPoco>>(entities);
        }

        /// <summary>
        /// Gets a paged list of all <see cref="IUserPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IUserPoco"/> models.</returns>
        public virtual IPagedList<IUserPoco> GetAllPaged(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            int count = genericRepository.GetCount();
            var entities = genericRepository.GetAll(pagingParameters, orderBy, includeProperties);

            return new StaticPagedList<IUserPoco>(mapper.Map<IEnumerable<IUserPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets a paged list of all <see cref="IUserPoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IUserPoco"/> models asynchronously.</returns>
        public virtual async Task<IPagedList<IUserPoco>> GetAllPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            int count = await genericRepository.GetCountAsync();
            var entities = await genericRepository.GetAllAsync(pagingParameters, orderBy, includeProperties);

            return new StaticPagedList<IUserPoco>(mapper.Map<IEnumerable<IUserPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the one <see cref="IUserPoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="IUserPoco"/> asynchronously.</returns>
        public virtual async Task<IUserPoco> GetOneAsync(Expression<Func<IUserPoco, bool>> filter = null, params string[] includeProperties)
        {
            var entity = await genericRepository.GetOneAsync(filter, includeProperties);
            return mapper.Map<IUserPoco>(entity); 
        }

        /// <summary>
        /// Gets the one <see cref="IUserPoco"/> model.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        public virtual IUserPoco GetOne(Expression<Func<IUserPoco, bool>> filter = null, params string[] includeProperties)
        {
            var entity = genericRepository.GetOne(filter, includeProperties);
            return mapper.Map<IUserPoco>(entity);
        }

        /// <summary>
        /// Gets the list of <see cref="IUserPoco"/> models.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IUserPoco"/> models.</returns>
        public virtual IEnumerable<IUserPoco> Get(Expression<Func<IUserPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = genericRepository.Get(null, filter, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IUserPoco>>(entities);
        }

        /// <summary>
        /// Gets the list of <see cref="IUserPoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IUserPoco"/> models asynchronous.</returns>
        public virtual async Task<IEnumerable<IUserPoco>> GetAsync(Expression<Func<IUserPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = await genericRepository.GetAsync(null, filter, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IUserPoco>>(entities);
        }

        /// <summary>
        /// Gets the paged list of <see cref="IUserPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IUserPoco"/> models.</returns>
        public virtual IPagedList<IUserPoco> GetPaged(IPagingParameters pagingParameters, Expression<Func<IUserPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var count = genericRepository.GetCount();
            var entities = genericRepository.Get(pagingParameters, filter, orderBy, includeProperties);

            return new StaticPagedList<IUserPoco>(mapper.Map<IEnumerable<IUserPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the paged list of <see cref="IUserPoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IUserPoco"/> models asynchronous.</returns>
        public virtual async Task<IPagedList<IUserPoco>> GetPagedAsync(IPagingParameters pagingParameters, Expression<Func<IUserPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var count = await genericRepository.GetCountAsync(filter);
            var entities = await genericRepository.GetAsync(pagingParameters, filter, orderBy, includeProperties);

            return new StaticPagedList<IUserPoco>(mapper.Map<IEnumerable<IUserPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the <see cref="IUserPoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IUserPoco"/>.</returns>
        public virtual IUserPoco GetById(Guid id)
        {
            var entity = genericRepository.GetOne(p => p.Id == id);
            return mapper.Map<IUserPoco>(entity);
        }

        /// <summary>
        /// Gets the <see cref="IUserPoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IUserPoco"/>.</returns>
        public virtual async Task<IUserPoco> GetByIdAsync(Guid id)
        {
            var entity = await genericRepository.GetOneAsync(p => p.Id == id);
            return mapper.Map<IUserPoco>(entity);
        }

        /// <summary>
        /// Gets the <see cref="IUserPoco"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IUserPoco"/> count.</returns>
        public virtual int GetCount(Expression<Func<IUserPoco, bool>> filter = null)
        {
            return genericRepository.GetCount(filter);
        }

        /// <summary>
        /// Gets the <see cref="IUserPoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IUserPoco"/> count asynchronous.</returns>
        public virtual Task<int> GetCountAsync(Expression<Func<IUserPoco, bool>> filter = null)
        {
            return genericRepository.GetCountAsync(filter);
        }

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual bool GetIsExists(Expression<Func<IUserPoco, bool>> filter = null)
        {
            return genericRepository.GetIsExists(filter);
        }

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual Task<bool> GetIsExistsAsync(Expression<Func<IUserPoco, bool>> filter = null)
        {
            return genericRepository.GetIsExistsAsync(filter);
        }

        /// <summary>
        /// Inserts the specified <see cref="IUserPoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Insert(IUserPoco model)
        {
            genericRepository.Insert(mapper.Map<User>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Inserts the list of <see cref="IUserPoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual void Insert(IList<IUserPoco> models)
        {
            var entities = mapper.Map<List<User>>(models);
            entities.ForEach(p => genericRepository.Insert(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Inserts the specified <see cref="IUserPoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task InsertAsync(IUserPoco model)
        {
            genericRepository.Insert(mapper.Map<User>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Inserts the list of <see cref="IUserPoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual System.Threading.Tasks.Task InsertAsync(IList<IUserPoco> models)
        {
            var entities = mapper.Map<List<User>>(models);
            entities.ForEach(p => genericRepository.Insert(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Updates the specified <see cref="IUserPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Update(IUserPoco model)
        {
            genericRepository.Update(mapper.Map<User>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Updates the list of <see cref="IUserPoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        public virtual void Update(IList<IUserPoco> models)
        {
            var entities = mapper.Map<List<User>>(models);
            entities.ForEach(p => genericRepository.Update(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Updates the specified <see cref="IUserPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task UpdateAsync(IUserPoco model)
        {
            genericRepository.Update(mapper.Map<User>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Updates the list of <see cref="IUserPoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        public virtual System.Threading.Tasks.Task UpdateAsync(IList<IUserPoco> models)
        {
            var entities = mapper.Map<List<User>>(models);
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
        /// Deletes the specified <see cref="IUserPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Delete(IUserPoco model)
        {
            genericRepository.Delete(mapper.Map<User>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual void Delete(IList<IUserPoco> models)
        {
            var entities = mapper.Map<List<User>>(models);
            entities.ForEach(p => genericRepository.Delete(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes the specified <see cref="IUserPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(IUserPoco model)
        {
            genericRepository.Delete(mapper.Map<User>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(IList<IUserPoco> models)
        {
            var entities = mapper.Map<List<User>>(models);
            entities.ForEach(p => genericRepository.Delete(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Adds <see cref="IUserPoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForInset(IUserPoco model)
        {
            genericRepository.Insert(mapper.Map<User>(model));
        }

        /// <summary>
        /// Adds <see cref="IUserPoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForUpdate(IUserPoco model)
        {
            genericRepository.Update(mapper.Map<User>(model));
        }

        /// <summary>
        /// Adds <see cref="IUserPoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForDelete(IUserPoco model)
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
