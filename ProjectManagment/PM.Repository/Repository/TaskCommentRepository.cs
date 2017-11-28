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
    /// TaskComment repository.
    /// </summary>
    public class TaskCommentRepository : ITaskCommentRepository
    {
        #region Fields

        private readonly IGenericRepository<TaskComment, ITaskCommentPoco> genericRepository;
        private readonly IMapper mapper;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskCommentRepository"/> class.
        /// </summary>
        /// <param name="genericRepository">The generic repository.</param>
        /// <param name="mapper">The mapper.</param>
        public TaskCommentRepository(IGenericRepository<TaskComment, ITaskCommentPoco> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Creates <see cref="ITaskCommentPoco"/> in memmory.
        /// </summary>
        /// <returns><see cref="ITaskCommentPoco"/>.</returns>
        public virtual ITaskCommentPoco Create()
        {
            var poco = new TaskCommentPoco
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };
            return poco;
        }

        /// <summary>
        /// Gets a list of all <see cref="ITaskCommentPoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskCommentPoco"/> models.</returns>
        public virtual IEnumerable<ITaskCommentPoco> GetAll(ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = genericRepository.GetAll(null, orderBy, includeProperties);
            return mapper.Map<IEnumerable<ITaskCommentPoco>>(entities);
        }

        /// <summary>
        /// Gets a list of all <see cref="ITaskCommentPoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskCommentPoco"/> models asynchronously.</returns>
        public virtual async Task<IEnumerable<ITaskCommentPoco>> GetAllAsync(ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = await genericRepository.GetAllAsync(null, orderBy, includeProperties);
            return mapper.Map<IEnumerable<ITaskCommentPoco>>(entities);
        }

        /// <summary>
        /// Gets a paged list of all <see cref="ITaskCommentPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="ITaskCommentPoco"/> models.</returns>
        public virtual IPagedList<ITaskCommentPoco> GetAllPaged(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            int count = genericRepository.GetCount();
            var entities = genericRepository.GetAll(pagingParameters, orderBy, includeProperties);

            return new StaticPagedList<ITaskCommentPoco>(mapper.Map<IEnumerable<ITaskCommentPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets a paged list of all <see cref="ITaskCommentPoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="ITaskCommentPoco"/> models asynchronously.</returns>
        public virtual async Task<IPagedList<ITaskCommentPoco>> GetAllPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            int count = await genericRepository.GetCountAsync();
            var entities = await genericRepository.GetAllAsync(pagingParameters, orderBy, includeProperties);

            return new StaticPagedList<ITaskCommentPoco>(mapper.Map<IEnumerable<ITaskCommentPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the one <see cref="ITaskCommentPoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="ITaskCommentPoco"/> asynchronously.</returns>
        public virtual async Task<ITaskCommentPoco> GetOneAsync(Expression<Func<ITaskCommentPoco, bool>> filter = null, params string[] includeProperties)
        {
            var entity = await genericRepository.GetOneAsync(filter, includeProperties);
            return mapper.Map<ITaskCommentPoco>(entity);
        }

        /// <summary>
        /// Gets the one <see cref="ITaskCommentPoco"/> model.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        public virtual ITaskCommentPoco GetOne(Expression<Func<ITaskCommentPoco, bool>> filter = null, params string[] includeProperties)
        {
            var entity = genericRepository.GetOne(filter, includeProperties);
            return mapper.Map<ITaskCommentPoco>(entity);
        }

        /// <summary>
        /// Gets the list of <see cref="ITaskCommentPoco"/> models.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskCommentPoco"/> models.</returns>
        public virtual IEnumerable<ITaskCommentPoco> Get(Expression<Func<ITaskCommentPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = genericRepository.Get(null, filter, orderBy, includeProperties);
            return mapper.Map<IEnumerable<ITaskCommentPoco>>(entities);
        }

        /// <summary>
        /// Gets the list of <see cref="ITaskCommentPoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskCommentPoco"/> models asynchronous.</returns>
        public virtual async Task<IEnumerable<ITaskCommentPoco>> GetAsync(Expression<Func<ITaskCommentPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = await genericRepository.GetAsync(null, filter, orderBy, includeProperties);
            return mapper.Map<IEnumerable<ITaskCommentPoco>>(entities);
        }

        /// <summary>
        /// Gets the paged list of <see cref="ITaskCommentPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="ITaskCommentPoco"/> models.</returns>
        public virtual IPagedList<ITaskCommentPoco> GetPaged(IPagingParameters pagingParameters, Expression<Func<ITaskCommentPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var count = genericRepository.GetCount();
            var entities = genericRepository.Get(pagingParameters, filter, orderBy, includeProperties);

            return new StaticPagedList<ITaskCommentPoco>(mapper.Map<IEnumerable<ITaskCommentPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the paged list of <see cref="ITaskCommentPoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="ITaskCommentPoco"/> models asynchronous.</returns>
        public virtual async Task<IPagedList<ITaskCommentPoco>> GetPagedAsync(IPagingParameters pagingParameters, Expression<Func<ITaskCommentPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var count = await genericRepository.GetCountAsync(filter);
            var entities = await genericRepository.GetAsync(pagingParameters, filter, orderBy, includeProperties);

            return new StaticPagedList<ITaskCommentPoco>(mapper.Map<IEnumerable<ITaskCommentPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the <see cref="ITaskCommentPoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="ITaskCommentPoco"/>.</returns>
        public virtual ITaskCommentPoco GetById(Guid id)
        {
            var entity = genericRepository.GetById(id);
            return mapper.Map<ITaskCommentPoco>(entity);
        }

        /// <summary>
        /// Gets the <see cref="ITaskCommentPoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="ITaskCommentPoco"/>.</returns>
        public virtual async Task<ITaskCommentPoco> GetByIdAsync(Guid id)
        {
            var entity = await genericRepository.GetByIdAsync(id);
            return mapper.Map<ITaskCommentPoco>(entity);
        }

        /// <summary>
        /// Gets the <see cref="ITaskCommentPoco"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="ITaskCommentPoco"/> count.</returns>
        public virtual int GetCount(Expression<Func<ITaskCommentPoco, bool>> filter = null)
        {
            return genericRepository.GetCount(filter);
        }

        /// <summary>
        /// Gets the <see cref="ITaskCommentPoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="ITaskCommentPoco"/> count asynchronous.</returns>
        public virtual Task<int> GetCountAsync(Expression<Func<ITaskCommentPoco, bool>> filter = null)
        {
            return genericRepository.GetCountAsync(filter);
        }

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual bool GetIsExists(Expression<Func<ITaskCommentPoco, bool>> filter = null)
        {
            return genericRepository.GetIsExists(filter);
        }

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual Task<bool> GetIsExistsAsync(Expression<Func<ITaskCommentPoco, bool>> filter = null)
        {
            return genericRepository.GetIsExistsAsync(filter);
        }

        /// <summary>
        /// Inserts the specified <see cref="ITaskCommentPoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Insert(ITaskCommentPoco model)
        {
            genericRepository.Insert(mapper.Map<TaskComment>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Inserts the list of <see cref="ITaskCommentPoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual void Insert(IList<ITaskCommentPoco> models)
        {
            var entities = mapper.Map<List<TaskComment>>(models);
            entities.ForEach(p => genericRepository.Insert(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Inserts the specified <see cref="ITaskCommentPoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task InsertAsync(ITaskCommentPoco model)
        {
            genericRepository.Insert(mapper.Map<TaskComment>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Inserts the list of <see cref="ITaskCommentPoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual System.Threading.Tasks.Task InsertAsync(IList<ITaskCommentPoco> models)
        {
            var entities = mapper.Map<List<TaskComment>>(models);
            entities.ForEach(p => genericRepository.Insert(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Updates the specified <see cref="ITaskCommentPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Update(ITaskCommentPoco model)
        {
            genericRepository.Update(mapper.Map<TaskComment>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Updates the list of <see cref="ITaskCommentPoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        public virtual void Update(IList<ITaskCommentPoco> models)
        {
            var entities = mapper.Map<List<TaskComment>>(models);
            entities.ForEach(p => genericRepository.Update(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Updates the specified <see cref="ITaskCommentPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task UpdateAsync(ITaskCommentPoco model)
        {
            genericRepository.Update(mapper.Map<TaskComment>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Updates the list of <see cref="ITaskCommentPoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        public virtual System.Threading.Tasks.Task UpdateAsync(IList<ITaskCommentPoco> models)
        {
            var entities = mapper.Map<List<TaskComment>>(models);
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
        /// Deletes the specified <see cref="ITaskCommentPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Delete(ITaskCommentPoco model)
        {
            genericRepository.Delete(mapper.Map<TaskComment>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual void Delete(IList<ITaskCommentPoco> models)
        {
            var entities = mapper.Map<List<TaskComment>>(models);
            entities.ForEach(p => genericRepository.Delete(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes the specified <see cref="ITaskCommentPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(ITaskCommentPoco model)
        {
            genericRepository.Delete(mapper.Map<TaskComment>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(IList<ITaskCommentPoco> models)
        {
            var entities = mapper.Map<List<TaskComment>>(models);
            entities.ForEach(p => genericRepository.Delete(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Adds <see cref="ITaskCommentPoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForInset(ITaskCommentPoco model)
        {
            genericRepository.Insert(mapper.Map<TaskComment>(model));
        }

        /// <summary>
        /// Adds <see cref="ITaskCommentPoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForUpdate(ITaskCommentPoco model)
        {
            genericRepository.Update(mapper.Map<TaskComment>(model));
        }

        /// <summary>
        /// Adds <see cref="ITaskCommentPoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForDelete(ITaskCommentPoco model)
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
