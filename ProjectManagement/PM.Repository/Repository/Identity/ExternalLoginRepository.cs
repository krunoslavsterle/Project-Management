using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using PagedList;
using PM.Repository.Common;
using PM.DAL;
using PM.Model.Common;
using PM.Common;

namespace PM.Repository
{
    /// <summary>
    /// External login repository.
    /// </summary>
    public class ExternalLoginRepository : IExternalLoginRepository
    {
        #region Fields

        private readonly IGenericRepository<ExternalLogin, IExternalLoginPoco> genericRepository;
        private readonly IMapper mapper;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalLoginRepository"/> class.
        /// </summary>
        /// <param name="genericRepository">The generic repository.</param>
        /// <param name="mapper">The mapper.</param>
        public ExternalLoginRepository(IGenericRepository<ExternalLogin, IExternalLoginPoco> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        #endregion Constructors

        #region Methods
        
        /// <summary>
        /// Creates <see cref="IExternalLoginPoco"/> the asynchronous.
        /// </summary>
        /// <returns><see cref="IExternalLoginPoco"/>.</returns>
        public System.Threading.Tasks.Task<IExternalLoginPoco> CreateAsync()
        {
            IExternalLoginPoco model = new Model.ExternalLoginPoco();
            return System.Threading.Tasks.Task.FromResult(model);
        }

        /// <summary>
        /// Gets a list of all <see cref="IExternalLoginPoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IExternalLoginPoco"/> models.</returns>
        public virtual IEnumerable<IExternalLoginPoco> GetAll(ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = genericRepository.GetAll(null, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IExternalLoginPoco>>(entities);
        }

        /// <summary>
        /// Gets a list of all <see cref="IExternalLoginPoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IExternalLoginPoco"/> models asynchronously.</returns>
        public virtual async Task<IEnumerable<IExternalLoginPoco>> GetAllAsync(ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = await genericRepository.GetAllAsync(null, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IExternalLoginPoco>>(entities);
        }

        /// <summary>
        /// Gets a paged list of all <see cref="IExternalLoginPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IExternalLoginPoco"/> models.</returns>
        public virtual IPagedList<IExternalLoginPoco> GetAllPaged(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            int count = genericRepository.GetCount();
            var entities = genericRepository.GetAll(pagingParameters, orderBy, includeProperties);

            return new StaticPagedList<IExternalLoginPoco>(mapper.Map<IEnumerable<IExternalLoginPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets a paged list of all <see cref="IExternalLoginPoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IExternalLoginPoco"/> models asynchronously.</returns>
        public virtual async Task<IPagedList<IExternalLoginPoco>> GetAllPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            int count = await genericRepository.GetCountAsync();
            var entities = await genericRepository.GetAllAsync(pagingParameters, orderBy, includeProperties);

            return new StaticPagedList<IExternalLoginPoco>(mapper.Map<IEnumerable<IExternalLoginPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the one <see cref="IExternalLoginPoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="IExternalLoginPoco"/> asynchronously.</returns>
        public virtual async Task<IExternalLoginPoco> GetOneAsync(Expression<Func<IExternalLoginPoco, bool>> filter = null, params string[] includeProperties)
        {
            var entity = await genericRepository.GetOneAsync(filter, includeProperties);
            return mapper.Map<IExternalLoginPoco>(entity);
        }

        /// <summary>
        /// Gets the one <see cref="IExternalLoginPoco"/> model.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        public virtual IExternalLoginPoco GetOne(Expression<Func<IExternalLoginPoco, bool>> filter = null, params string[] includeProperties)
        {
            var entity = genericRepository.GetOne(filter, includeProperties);
            return mapper.Map<IExternalLoginPoco>(entity);
        }

        /// <summary>
        /// Gets the list of <see cref="IExternalLoginPoco"/> models.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IExternalLoginPoco"/> models.</returns>
        public virtual IEnumerable<IExternalLoginPoco> Get(Expression<Func<IExternalLoginPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = genericRepository.Get(null, filter, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IExternalLoginPoco>>(entities);
        }

        /// <summary>
        /// Gets the list of <see cref="IExternalLoginPoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IExternalLoginPoco"/> models asynchronous.</returns>
        public virtual async Task<IEnumerable<IExternalLoginPoco>> GetAsync(Expression<Func<IExternalLoginPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = await genericRepository.GetAsync(null, filter, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IExternalLoginPoco>>(entities);
        }

        /// <summary>
        /// Gets the paged list of <see cref="IExternalLoginPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IExternalLoginPoco"/> models.</returns>
        public virtual IPagedList<IExternalLoginPoco> GetPaged(IPagingParameters pagingParameters, Expression<Func<IExternalLoginPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var count = genericRepository.GetCount();
            var entities = genericRepository.Get(pagingParameters, filter, orderBy, includeProperties);

            return new StaticPagedList<IExternalLoginPoco>(mapper.Map<IEnumerable<IExternalLoginPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the paged list of <see cref="IExternalLoginPoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IExternalLoginPoco"/> models asynchronous.</returns>
        public virtual async Task<IPagedList<IExternalLoginPoco>> GetPagedAsync(IPagingParameters pagingParameters, Expression<Func<IExternalLoginPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var count = await genericRepository.GetCountAsync(filter);
            var entities = await genericRepository.GetAsync(pagingParameters, filter, orderBy, includeProperties);

            return new StaticPagedList<IExternalLoginPoco>(mapper.Map<IEnumerable<IExternalLoginPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the <see cref="IExternalLoginPoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IExternalLoginPoco"/>.</returns>
        public virtual IExternalLoginPoco GetById(Guid id)
        {
            var entity = genericRepository.GetById(id);
            return mapper.Map<IExternalLoginPoco>(entity);
        }

        /// <summary>
        /// Gets the <see cref="IExternalLoginPoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IExternalLoginPoco"/>.</returns>
        public virtual async Task<IExternalLoginPoco> GetByIdAsync(Guid id)
        {
            var entity = await genericRepository.GetByIdAsync(id);
            return mapper.Map<IExternalLoginPoco>(entity);
        }

        /// <summary>
        /// Gets the <see cref="IExternalLoginPoco"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IExternalLoginPoco"/> count.</returns>
        public virtual int GetCount(Expression<Func<IExternalLoginPoco, bool>> filter = null)
        {
            return genericRepository.GetCount(filter);
        }

        /// <summary>
        /// Gets the <see cref="IExternalLoginPoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IExternalLoginPoco"/> count asynchronous.</returns>
        public virtual Task<int> GetCountAsync(Expression<Func<IExternalLoginPoco, bool>> filter = null)
        {
            return genericRepository.GetCountAsync(filter);
        }

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual bool GetIsExists(Expression<Func<IExternalLoginPoco, bool>> filter = null)
        {
            return genericRepository.GetIsExists(filter);
        }

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual Task<bool> GetIsExistsAsync(Expression<Func<IExternalLoginPoco, bool>> filter = null)
        {
            return genericRepository.GetIsExistsAsync(filter);
        }

        /// <summary>
        /// Inserts the specified <see cref="IExternalLoginPoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Insert(IExternalLoginPoco model)
        {
            genericRepository.Insert(mapper.Map<ExternalLogin>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Inserts the list of <see cref="IExternalLoginPoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual void Insert(IList<IExternalLoginPoco> models)
        {
            var entities = mapper.Map<List<ExternalLogin>>(models);
            entities.ForEach(p => genericRepository.Insert(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Inserts the specified <see cref="IExternalLoginPoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task InsertAsync(IExternalLoginPoco model)
        {
            genericRepository.Insert(mapper.Map<ExternalLogin>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Inserts the list of <see cref="IExternalLoginPoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual System.Threading.Tasks.Task InsertAsync(IList<IExternalLoginPoco> models)
        {
            var entities = mapper.Map<List<ExternalLogin>>(models);
            entities.ForEach(p => genericRepository.Insert(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Updates the specified <see cref="IExternalLoginPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Update(IExternalLoginPoco model)
        {
            genericRepository.Update(mapper.Map<ExternalLogin>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Updates the list of <see cref="IExternalLoginPoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        public virtual void Update(IList<IExternalLoginPoco> models)
        {
            var entities = mapper.Map<List<ExternalLogin>>(models);
            entities.ForEach(p => genericRepository.Update(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Updates the specified <see cref="IExternalLoginPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task UpdateAsync(IExternalLoginPoco model)
        {
            genericRepository.Update(mapper.Map<ExternalLogin>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Updates the list of <see cref="IExternalLoginPoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        public virtual System.Threading.Tasks.Task UpdateAsync(IList<IExternalLoginPoco> models)
        {
            var entities = mapper.Map<List<ExternalLogin>>(models);
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
        /// Deletes the specified <see cref="IExternalLoginPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Delete(IExternalLoginPoco model)
        {
            genericRepository.Delete(mapper.Map<ExternalLogin>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual void Delete(IList<IExternalLoginPoco> models)
        {
            var entities = mapper.Map<List<ExternalLogin>>(models);
            entities.ForEach(p => genericRepository.Delete(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes the specified <see cref="IExternalLoginPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(IExternalLoginPoco model)
        {
            genericRepository.Delete(mapper.Map<ExternalLogin>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(IList<IExternalLoginPoco> models)
        {
            var entities = mapper.Map<List<ExternalLogin>>(models);
            entities.ForEach(p => genericRepository.Delete(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Adds <see cref="IExternalLoginPoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForInset(IExternalLoginPoco model)
        {
            genericRepository.Insert(mapper.Map<ExternalLogin>(model));
        }

        /// <summary>
        /// Adds <see cref="IExternalLoginPoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForUpdate(IExternalLoginPoco model)
        {
            genericRepository.Update(mapper.Map<ExternalLogin>(model));
        }

        /// <summary>
        /// Adds <see cref="IExternalLoginPoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForDelete(IExternalLoginPoco model)
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
