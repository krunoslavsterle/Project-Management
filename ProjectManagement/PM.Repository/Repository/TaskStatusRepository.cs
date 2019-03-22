using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using PagedList;
using PM.Model.Common;
using PM.Repository.Common;
using PM.Common;
using PM.DAL;

namespace PM.Repository
{
    /// <summary>
    /// TaskStatus repository.
    /// </summary>
    public class TaskStatusRepository : ITaskStatusRepository
    {
        #region Fields

        private readonly IGenericRepository<DAL.TaskStatus, ITaskStatusPoco> genericRepository;
        private readonly IMapper mapper;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskStatusRepository"/> class.
        /// </summary>
        /// <param name="genericRepository">The generic repository.</param>
        /// <param name="mapper">The mapper.</param>
        public TaskStatusRepository(IGenericRepository<DAL.TaskStatus, ITaskStatusPoco> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets a list of all <see cref="ITaskStatusPoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskStatusPoco"/> models.</returns>
        public virtual IEnumerable<ITaskStatusPoco> GetAll(ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = genericRepository.GetAll(null, orderBy, includeProperties);
            return mapper.Map<IEnumerable<ITaskStatusPoco>>(entities);
        }

        /// <summary>
        /// Gets a list of all <see cref="ITaskStatusPoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskStatusPoco"/> models asynchronously.</returns>
        public virtual async Task<IEnumerable<ITaskStatusPoco>> GetAllAsync(ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = await genericRepository.GetAllAsync(null, orderBy, includeProperties);
            return mapper.Map<IEnumerable<ITaskStatusPoco>>(entities);
        }

        /// <summary>
        /// Gets a paged list of all <see cref="ITaskStatusPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="ITaskStatusPoco"/> models.</returns>
        public virtual IPagedList<ITaskStatusPoco> GetAllPaged(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            int count = genericRepository.GetCount();
            var entities = genericRepository.GetAll(pagingParameters, orderBy, includeProperties);

            return new StaticPagedList<ITaskStatusPoco>(mapper.Map<IEnumerable<ITaskStatusPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets a paged list of all <see cref="ITaskStatusPoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="ITaskStatusPoco"/> models asynchronously.</returns>
        public virtual async Task<IPagedList<ITaskStatusPoco>> GetAllPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            int count = await genericRepository.GetCountAsync();
            var entities = await genericRepository.GetAllAsync(pagingParameters, orderBy, includeProperties);

            return new StaticPagedList<ITaskStatusPoco>(mapper.Map<IEnumerable<ITaskStatusPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the one <see cref="ITaskStatusPoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="ITaskStatusPoco"/> asynchronously.</returns>
        public virtual async Task<ITaskStatusPoco> GetOneAsync(Expression<Func<ITaskStatusPoco, bool>> filter = null, params string[] includeProperties)
        {
            var entity = await genericRepository.GetOneAsync(filter, includeProperties);
            return mapper.Map<ITaskStatusPoco>(entity);
        }

        /// <summary>
        /// Gets the one <see cref="ITaskStatusPoco"/> model.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        public virtual ITaskStatusPoco GetOne(Expression<Func<ITaskStatusPoco, bool>> filter = null, params string[] includeProperties)
        {
            var entity = genericRepository.GetOne(filter, includeProperties);
            return mapper.Map<ITaskStatusPoco>(entity);
        }

        /// <summary>
        /// Gets the list of <see cref="ITaskStatusPoco"/> models.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskStatusPoco"/> models.</returns>
        public virtual IEnumerable<ITaskStatusPoco> Get(Expression<Func<ITaskStatusPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = genericRepository.Get(null, filter, orderBy, includeProperties);
            return mapper.Map<IEnumerable<ITaskStatusPoco>>(entities);
        }

        /// <summary>
        /// Gets the list of <see cref="ITaskStatusPoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskStatusPoco"/> models asynchronous.</returns>
        public virtual async Task<IEnumerable<ITaskStatusPoco>> GetAsync(Expression<Func<ITaskStatusPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = await genericRepository.GetAsync(null, filter, orderBy, includeProperties);
            return mapper.Map<IEnumerable<ITaskStatusPoco>>(entities);
        }

        /// <summary>
        /// Gets the paged list of <see cref="ITaskStatusPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="ITaskStatusPoco"/> models.</returns>
        public virtual IPagedList<ITaskStatusPoco> GetPaged(IPagingParameters pagingParameters, Expression<Func<ITaskStatusPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var count = genericRepository.GetCount();
            var entities = genericRepository.Get(pagingParameters, filter, orderBy, includeProperties);

            return new StaticPagedList<ITaskStatusPoco>(mapper.Map<IEnumerable<ITaskStatusPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the paged list of <see cref="ITaskStatusPoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="ITaskStatusPoco"/> models asynchronous.</returns>
        public virtual async Task<IPagedList<ITaskStatusPoco>> GetPagedAsync(IPagingParameters pagingParameters, Expression<Func<ITaskStatusPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var count = await genericRepository.GetCountAsync();
            var entities = await genericRepository.GetAsync(pagingParameters, filter, orderBy, includeProperties);

            return new StaticPagedList<ITaskStatusPoco>(mapper.Map<IEnumerable<ITaskStatusPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the <see cref="ITaskStatusPoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="ITaskStatusPoco"/>.</returns>
        public virtual ITaskStatusPoco GetById(Guid id)
        {
            var entity = genericRepository.GetById(id);
            return mapper.Map<ITaskStatusPoco>(entity);
        }

        /// <summary>
        /// Gets the <see cref="ITaskStatusPoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="ITaskStatusPoco"/>.</returns>
        public virtual async Task<ITaskStatusPoco> GetByIdAsync(Guid id)
        {
            var entity = await genericRepository.GetByIdAsync(id);
            return mapper.Map<ITaskStatusPoco>(entity);
        }

        /// <summary>
        /// Gets the <see cref="ITaskStatusPoco"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="ITaskStatusPoco"/> count.</returns>
        public virtual int GetCount(Expression<Func<ITaskStatusPoco, bool>> filter = null)
        {
            return genericRepository.GetCount(filter);
        }

        /// <summary>
        /// Gets the <see cref="ITaskStatusPoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="ITaskStatusPoco"/> count asynchronous.</returns>
        public virtual Task<int> GetCountAsync(Expression<Func<ITaskStatusPoco, bool>> filter = null)
        {
            return genericRepository.GetCountAsync(filter);
        }

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual bool GetIsExists(Expression<Func<ITaskStatusPoco, bool>> filter = null)
        {
            return genericRepository.GetIsExists(filter);
        }

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual Task<bool> GetIsExistsAsync(Expression<Func<ITaskStatusPoco, bool>> filter = null)
        {
            return genericRepository.GetIsExistsAsync(filter);
        }

        /// <summary>
        /// Inserts the specified <see cref="ITaskStatusPoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Insert(ITaskStatusPoco model)
        {
            genericRepository.Insert(mapper.Map<DAL.TaskStatus>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Inserts the list of <see cref="ITaskStatusPoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual void Insert(IList<ITaskStatusPoco> models)
        {
            var entities = mapper.Map<List<DAL.TaskStatus>>(models);
            entities.ForEach(p => genericRepository.Insert(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Inserts the specified <see cref="ITaskStatusPoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task InsertAsync(ITaskStatusPoco model)
        {
            genericRepository.Insert(mapper.Map<DAL.TaskStatus>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Inserts the list of <see cref="ITaskStatusPoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual System.Threading.Tasks.Task InsertAsync(IList<ITaskStatusPoco> models)
        {
            var entities = mapper.Map<List<DAL.TaskStatus>>(models);
            entities.ForEach(p => genericRepository.Insert(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Updates the specified <see cref="ITaskStatusPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Update(ITaskStatusPoco model)
        {
            genericRepository.Update(mapper.Map<DAL.TaskStatus>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Updates the list of <see cref="ITaskStatusPoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        public virtual void Update(IList<ITaskStatusPoco> models)
        {
            var entities = mapper.Map<List<DAL.TaskStatus>>(models);
            entities.ForEach(p => genericRepository.Update(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Updates the specified <see cref="ITaskStatusPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task UpdateAsync(ITaskStatusPoco model)
        {
            genericRepository.Update(mapper.Map<DAL.TaskStatus>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Updates the list of <see cref="ITaskStatusPoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        public virtual System.Threading.Tasks.Task UpdateAsync(IList<ITaskStatusPoco> models)
        {
            var entities = mapper.Map<List<DAL.TaskStatus>>(models);
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
        /// Deletes the specified <see cref="ITaskStatusPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Delete(ITaskStatusPoco model)
        {
            genericRepository.Delete(mapper.Map<DAL.TaskStatus>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual void Delete(IList<ITaskStatusPoco> models)
        {
            var entities = mapper.Map<List<DAL.TaskStatus>>(models);
            entities.ForEach(p => genericRepository.Delete(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes the specified <see cref="ITaskStatusPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(ITaskStatusPoco model)
        {
            genericRepository.Delete(mapper.Map<DAL.TaskStatus>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(IList<ITaskStatusPoco> models)
        {
            var entities = mapper.Map<List<DAL.TaskStatus>>(models);
            entities.ForEach(p => genericRepository.Delete(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Adds <see cref="ITaskStatusPoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForInset(ITaskStatusPoco model)
        {
            genericRepository.Insert(mapper.Map<DAL.TaskStatus>(model));
        }

        /// <summary>
        /// Adds <see cref="ITaskStatusPoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForUpdate(ITaskStatusPoco model)
        {
            genericRepository.Update(mapper.Map<DAL.TaskStatus>(model));
        }

        /// <summary>
        /// Adds <see cref="ITaskStatusPoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForDelete(ITaskStatusPoco model)
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
