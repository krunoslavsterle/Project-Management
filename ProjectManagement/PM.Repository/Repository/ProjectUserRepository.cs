using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using PagedList;
using PM.Model.Common;
using PM.DAL;
using PM.Common;
using PM.Repository.Common;
using PM.Model;

namespace PM.Repository
{
    /// <summary>
    /// ProjectUser repository.
    /// </summary>
    public class ProjectUserRepository : IProjectUserRepository
    {
        #region Fields

        private readonly IGenericRepository<ProjectUser, IProjectUserPoco> genericRepository;
        private readonly IMapper mapper;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectUserRepository"/> class.
        /// </summary>
        /// <param name="genericRepository">The generic repository.</param>
        /// <param name="mapper">The mapper.</param>
        public ProjectUserRepository(IGenericRepository<ProjectUser, IProjectUserPoco> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Creates the project user in memory.
        /// </summary>
        /// <returns><see cref="IProjectUserPoco"/> model.</returns>
        public virtual IProjectUserPoco Create()
        {
            IProjectUserPoco projectUser = new ProjectUserPoco()
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };
            return projectUser;
        }

        /// <summary>
        /// Gets a list of all <see cref="IProjectUserPoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectUserPoco"/> models.</returns>
        public virtual IEnumerable<IProjectUserPoco> GetAll(ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = genericRepository.GetAll(null, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IProjectUserPoco>>(entities);
        }

        /// <summary>
        /// Gets a list of all <see cref="IProjectUserPoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectUserPoco"/> models asynchronously.</returns>
        public virtual async Task<IEnumerable<IProjectUserPoco>> GetAllAsync(ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = await genericRepository.GetAllAsync(null, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IProjectUserPoco>>(entities);
        }

        /// <summary>
        /// Gets a paged list of all <see cref="IProjectUserPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IProjectUserPoco"/> models.</returns>
        public virtual IPagedList<IProjectUserPoco> GetAllPaged(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            int count = genericRepository.GetCount();
            var entities = genericRepository.GetAll(pagingParameters, orderBy, includeProperties);

            return new StaticPagedList<IProjectUserPoco>(mapper.Map<IEnumerable<IProjectUserPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets a paged list of all <see cref="IProjectUserPoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IProjectUserPoco"/> models asynchronously.</returns>
        public virtual async Task<IPagedList<IProjectUserPoco>> GetAllPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            int count = await genericRepository.GetCountAsync();
            var entities = await genericRepository.GetAllAsync(pagingParameters, orderBy, includeProperties);

            return new StaticPagedList<IProjectUserPoco>(mapper.Map<IEnumerable<IProjectUserPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the one <see cref="IProjectUserPoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="IProjectUserPoco"/> asynchronously.</returns>
        public virtual async Task<IProjectUserPoco> GetOneAsync(Expression<Func<IProjectUserPoco, bool>> filter = null, params string[] includeProperties)
        {
            var entity = await genericRepository.GetOneAsync(filter, includeProperties);
            return mapper.Map<IProjectUserPoco>(entity);
        }

        /// <summary>
        /// Gets the one <see cref="IProjectUserPoco"/> model.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        public virtual IProjectUserPoco GetOne(Expression<Func<IProjectUserPoco, bool>> filter = null, params string[] includeProperties)
        {
            var entity = genericRepository.GetOne(filter, includeProperties);
            return mapper.Map<IProjectUserPoco>(entity);
        }

        /// <summary>
        /// Gets the list of <see cref="IProjectUserPoco"/> models.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectUserPoco"/> models.</returns>
        public virtual IEnumerable<IProjectUserPoco> Get(Expression<Func<IProjectUserPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = genericRepository.Get(null, filter, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IProjectUserPoco>>(entities);
        }

        /// <summary>
        /// Gets the list of <see cref="IProjectUserPoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectUserPoco"/> models asynchronous.</returns>
        public virtual async Task<IEnumerable<IProjectUserPoco>> GetAsync(Expression<Func<IProjectUserPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = await genericRepository.GetAsync(null, filter, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IProjectUserPoco>>(entities);
        }

        /// <summary>
        /// Gets the paged list of <see cref="IProjectUserPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IProjectUserPoco"/> models.</returns>
        public virtual IPagedList<IProjectUserPoco> GetPaged(IPagingParameters pagingParameters, Expression<Func<IProjectUserPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var count = genericRepository.GetCount();
            var entities = genericRepository.Get(pagingParameters, filter, orderBy, includeProperties);

            return new StaticPagedList<IProjectUserPoco>(mapper.Map<IEnumerable<IProjectUserPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the paged list of <see cref="IProjectUserPoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IProjectUserPoco"/> models asynchronous.</returns>
        public virtual async Task<IPagedList<IProjectUserPoco>> GetPagedAsync(IPagingParameters pagingParameters, Expression<Func<IProjectUserPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var count = await genericRepository.GetCountAsync(filter);
            var entities = await genericRepository.GetAsync(pagingParameters, filter, orderBy, includeProperties);

            return new StaticPagedList<IProjectUserPoco>(mapper.Map<IEnumerable<IProjectUserPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the <see cref="IProjectUserPoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IProjectUserPoco"/>.</returns>
        public virtual IProjectUserPoco GetById(Guid id)
        {
            var entity = genericRepository.GetById(id);
            return mapper.Map<IProjectUserPoco>(entity);
        }

        /// <summary>
        /// Gets the <see cref="IProjectUserPoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IProjectUserPoco"/>.</returns>
        public virtual async Task<IProjectUserPoco> GetByIdAsync(Guid id)
        {
            var entity = await genericRepository.GetByIdAsync(id);
            return mapper.Map<IProjectUserPoco>(entity);
        }

        /// <summary>
        /// Gets the <see cref="IProjectUserPoco"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IProjectUserPoco"/> count.</returns>
        public virtual int GetCount(Expression<Func<IProjectUserPoco, bool>> filter = null)
        {
            return genericRepository.GetCount(filter);
        }

        /// <summary>
        /// Gets the <see cref="IProjectUserPoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IProjectUserPoco"/> count asynchronous.</returns>
        public virtual Task<int> GetCountAsync(Expression<Func<IProjectUserPoco, bool>> filter = null)
        {
            return genericRepository.GetCountAsync(filter);
        }

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual bool GetIsExists(Expression<Func<IProjectUserPoco, bool>> filter = null)
        {
            return genericRepository.GetIsExists(filter);
        }

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual Task<bool> GetIsExistsAsync(Expression<Func<IProjectUserPoco, bool>> filter = null)
        {
            return genericRepository.GetIsExistsAsync(filter);
        }

        /// <summary>
        /// Inserts the specified <see cref="IProjectUserPoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Insert(IProjectUserPoco model)
        {
            genericRepository.Insert(mapper.Map<ProjectUser>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Inserts the list of <see cref="IProjectUserPoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual void Insert(IList<IProjectUserPoco> models)
        {
            var entities = mapper.Map<List<ProjectUser>>(models);
            entities.ForEach(p => genericRepository.Insert(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Inserts the specified <see cref="IProjectUserPoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task InsertAsync(IProjectUserPoco model)
        {
            genericRepository.Insert(mapper.Map<ProjectUser>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Inserts the list of <see cref="IProjectUserPoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual System.Threading.Tasks.Task InsertAsync(IList<IProjectUserPoco> models)
        {
            var entities = mapper.Map<List<ProjectUser>>(models);
            entities.ForEach(p => genericRepository.Insert(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Updates the specified <see cref="IProjectUserPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Update(IProjectUserPoco model)
        {
            genericRepository.Update(mapper.Map<ProjectUser>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Updates the list of <see cref="IProjectUserPoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        public virtual void Update(IList<IProjectUserPoco> models)
        {
            var entities = mapper.Map<List<ProjectUser>>(models);
            entities.ForEach(p => genericRepository.Update(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Updates the specified <see cref="IProjectUserPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task UpdateAsync(IProjectUserPoco model)
        {
            genericRepository.Update(mapper.Map<ProjectUser>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Updates the list of <see cref="IProjectUserPoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        public virtual System.Threading.Tasks.Task UpdateAsync(IList<IProjectUserPoco> models)
        {
            var entities = mapper.Map<List<ProjectUser>>(models);
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
        /// Deletes the specified <see cref="IProjectUserPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Delete(IProjectUserPoco model)
        {
            genericRepository.Delete(mapper.Map<ProjectUser>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual void Delete(IList<IProjectUserPoco> models)
        {
            var entities = mapper.Map<List<ProjectUser>>(models);
            entities.ForEach(p => genericRepository.Delete(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes the specified <see cref="IProjectUserPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(IProjectUserPoco model)
        {
            genericRepository.Delete(mapper.Map<ProjectUser>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(IList<IProjectUserPoco> models)
        {
            var entities = mapper.Map<List<ProjectUser>>(models);
            entities.ForEach(p => genericRepository.Delete(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Adds <see cref="IProjectUserPoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForInset(IProjectUserPoco model)
        {
            genericRepository.Insert(mapper.Map<ProjectUser>(model));
        }

        /// <summary>
        /// Adds <see cref="IProjectUserPoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForUpdate(IProjectUserPoco model)
        {
            genericRepository.Update(mapper.Map<ProjectUser>(model));
        }

        /// <summary>
        /// Adds <see cref="IProjectUserPoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForDelete(IProjectUserPoco model)
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
