using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using PagedList;
using PM.Model.Common;
using PM.Common;
using PM.Repository.Common;
using PM.Model;

namespace PM.Repository
{
    /// <summary>
    /// Task repository.
    /// </summary>
    public class TaskRepository : ITaskRepository
    {
        #region Fields

        private readonly IGenericRepository<DAL.Task, ITaskPoco> genericRepository;
        private readonly IMapper mapper;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskRepository"/> class.
        /// </summary>
        /// <param name="genericRepository">The generic repository.</param>
        /// <param name="mapper">The mapper.</param>
        public TaskRepository(IGenericRepository<DAL.Task, ITaskPoco> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Creates new in-memory istance of <see cref="ITaskPoco"/> class.
        /// </summary>
        /// <returns>New in-memory istance of <see cref="ITaskPoco"/> class.</returns>
        public virtual ITaskPoco Create()
        {
            var model = new TaskPoco()
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            return model;
        }
        
        /// <summary>
        /// Gets a list of all <see cref="ITaskPoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskPoco"/> models.</returns>
        public virtual IEnumerable<ITaskPoco> GetAll(ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = genericRepository.GetAll(null, orderBy, includeProperties);
            return mapper.Map<IEnumerable<ITaskPoco>>(entities);
        }

        /// <summary>
        /// Gets a list of all <see cref="ITaskPoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskPoco"/> models asynchronously.</returns>
        public virtual async Task<IEnumerable<ITaskPoco>> GetAllAsync(ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = await genericRepository.GetAllAsync(null, orderBy, includeProperties);
            return mapper.Map<IEnumerable<ITaskPoco>>(entities);
        }

        /// <summary>
        /// Gets a paged list of all <see cref="ITaskPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="ITaskPoco"/> models.</returns>
        public virtual IPagedList<ITaskPoco> GetAllPaged(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            int count = genericRepository.GetCount();
            var entities = genericRepository.GetAll(pagingParameters, orderBy, includeProperties);

            return new StaticPagedList<ITaskPoco>(mapper.Map<IEnumerable<ITaskPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets a paged list of all <see cref="ITaskPoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="ITaskPoco"/> models asynchronously.</returns>
        public virtual async Task<IPagedList<ITaskPoco>> GetAllPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            int count = await genericRepository.GetCountAsync();
            var entities = await genericRepository.GetAllAsync(pagingParameters, orderBy, includeProperties);

            return new StaticPagedList<ITaskPoco>(mapper.Map<IEnumerable<ITaskPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the one <see cref="ITaskPoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="ITaskPoco"/> asynchronously.</returns>
        public virtual async Task<ITaskPoco> GetOneAsync(Expression<Func<ITaskPoco, bool>> filter = null, params string[] includeProperties)
        {
            var entity = await genericRepository.GetOneAsync(filter, includeProperties);
            return mapper.Map<ITaskPoco>(entity);
        }

        /// <summary>
        /// Gets the one <see cref="ITaskPoco"/> model.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        public virtual ITaskPoco GetOne(Expression<Func<ITaskPoco, bool>> filter = null, params string[] includeProperties)
        {
            var entity = genericRepository.GetOne(filter, includeProperties);
            return mapper.Map<ITaskPoco>(entity);
        }

        /// <summary>
        /// Gets the list of <see cref="ITaskPoco"/> models.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskPoco"/> models.</returns>
        public virtual IEnumerable<ITaskPoco> Get(Expression<Func<ITaskPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = genericRepository.Get(null, filter, orderBy, includeProperties);
            return mapper.Map<IEnumerable<ITaskPoco>>(entities);
        }

        /// <summary>
        /// Gets the list of <see cref="ITaskPoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskPoco"/> models asynchronous.</returns>
        public virtual async Task<IEnumerable<ITaskPoco>> GetAsync(Expression<Func<ITaskPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = await genericRepository.GetAsync(null, filter, orderBy, includeProperties);
            return mapper.Map<IEnumerable<ITaskPoco>>(entities);
        }

        /// <summary>
        /// Gets the paged list of <see cref="ITaskPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="ITaskPoco"/> models.</returns>
        public virtual IPagedList<ITaskPoco> GetPaged(IPagingParameters pagingParameters, Expression<Func<ITaskPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var count = genericRepository.GetCount();
            var entities = genericRepository.Get(pagingParameters, filter, orderBy, includeProperties);

            return new StaticPagedList<ITaskPoco>(mapper.Map<IEnumerable<ITaskPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the paged list of <see cref="ITaskPoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="ITaskPoco"/> models asynchronous.</returns>
        public virtual async Task<IPagedList<ITaskPoco>> GetPagedAsync(IPagingParameters pagingParameters, Expression<Func<ITaskPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var count = await genericRepository.GetCountAsync(filter);
            var entities = await genericRepository.GetAsync(pagingParameters, filter, orderBy, includeProperties);

            return new StaticPagedList<ITaskPoco>(mapper.Map<IEnumerable<ITaskPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the <see cref="ITaskPoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="ITaskPoco"/>.</returns>
        public virtual ITaskPoco GetById(Guid id)
        {
            var entity = genericRepository.GetById(id);
            return mapper.Map<ITaskPoco>(entity);
        }

        /// <summary>
        /// Gets the <see cref="ITaskPoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="ITaskPoco"/>.</returns>
        public virtual async Task<ITaskPoco> GetByIdAsync(Guid id)
        {
            var entity = await genericRepository.GetByIdAsync(id);
            return mapper.Map<ITaskPoco>(entity);
        }

        /// <summary>
        /// Gets the <see cref="ITaskPoco"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="ITaskPoco"/> count.</returns>
        public virtual int GetCount(Expression<Func<ITaskPoco, bool>> filter = null)
        {
            return genericRepository.GetCount(filter);
        }

        /// <summary>
        /// Gets the <see cref="ITaskPoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="ITaskPoco"/> count asynchronous.</returns>
        public virtual Task<int> GetCountAsync(Expression<Func<ITaskPoco, bool>> filter = null)
        {
            return genericRepository.GetCountAsync(filter);
        }

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual bool GetIsExists(Expression<Func<ITaskPoco, bool>> filter = null)
        {
            return genericRepository.GetIsExists(filter);
        }

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual Task<bool> GetIsExistsAsync(Expression<Func<ITaskPoco, bool>> filter = null)
        {
            return genericRepository.GetIsExistsAsync(filter);
        }

        /// <summary>
        /// Inserts the specified <see cref="ITaskPoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Insert(ITaskPoco model)
        {
            genericRepository.Insert(mapper.Map<DAL.Task>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Inserts the list of <see cref="ITaskPoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual void Insert(IList<ITaskPoco> models)
        {
            var entities = mapper.Map<List<DAL.Task>>(models);
            entities.ForEach(p => genericRepository.Insert(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Inserts the specified <see cref="ITaskPoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task InsertAsync(ITaskPoco model)
        {
            genericRepository.Insert(mapper.Map<DAL.Task>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Inserts the list of <see cref="ITaskPoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual System.Threading.Tasks.Task InsertAsync(IList<ITaskPoco> models)
        {
            var entities = mapper.Map<List<DAL.Task>>(models);
            entities.ForEach(p => genericRepository.Insert(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Updates the specified <see cref="ITaskPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Update(ITaskPoco model)
        {
            genericRepository.Update(mapper.Map<DAL.Task>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Updates the list of <see cref="ITaskPoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        public virtual void Update(IList<ITaskPoco> models)
        {
            var entities = mapper.Map<List<DAL.Task>>(models);
            entities.ForEach(p => genericRepository.Update(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Updates the specified <see cref="ITaskPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task UpdateAsync(ITaskPoco model)
        {
            genericRepository.Update(mapper.Map<DAL.Task>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Updates the list of <see cref="ITaskPoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        public virtual System.Threading.Tasks.Task UpdateAsync(IList<ITaskPoco> models)
        {
            var entities = mapper.Map<List<DAL.Task>>(models);
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
        /// Deletes the specified <see cref="ITaskPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Delete(ITaskPoco model)
        {
            genericRepository.Delete(mapper.Map<DAL.Task>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual void Delete(IList<ITaskPoco> models)
        {
            var entities = mapper.Map<List<DAL.Task>>(models);
            entities.ForEach(p => genericRepository.Delete(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes the specified <see cref="ITaskPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(ITaskPoco model)
        {
            genericRepository.Delete(mapper.Map<DAL.Task>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(IList<ITaskPoco> models)
        {
            var entities = mapper.Map<List<DAL.Task>>(models);
            entities.ForEach(p => genericRepository.Delete(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Adds <see cref="ITaskPoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForInset(ITaskPoco model)
        {
            genericRepository.Insert(mapper.Map<DAL.Task>(model));
        }

        /// <summary>
        /// Adds <see cref="ITaskPoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForUpdate(ITaskPoco model)
        {
            genericRepository.Update(mapper.Map<DAL.Task>(model));
        }

        /// <summary>
        /// Adds <see cref="ITaskPoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForDelete(ITaskPoco model)
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
