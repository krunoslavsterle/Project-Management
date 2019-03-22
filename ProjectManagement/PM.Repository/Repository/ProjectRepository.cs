using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using PM.DAL;
using PM.Model.Common;
using PM.Common;
using PM.Repository.Common;
using PagedList;
using System.Linq.Expressions;
using PM.Model;

namespace PM.Repository
{
    /// <summary>
    /// Project repository.
    /// </summary>
    public class ProjectRepository : IProjectRepository
    {
        #region Fields

        private readonly IGenericRepository<Project, IProjectPoco> genericRepository;
        private readonly IMapper mapper;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectRepository"/> class.
        /// </summary>
        /// <param name="genericRepository">The generic repository.</param>
        /// <param name="mapper">The mapper.</param>
        public ProjectRepository(IGenericRepository<Project, IProjectPoco> genericRepository, IMapper mapper) 
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Creates the project.
        /// </summary>
        /// <returns></returns>
        public virtual IProjectPoco CreateProject()
        {
            IProjectPoco project = new ProjectPoco()
            {
                Id = Guid.NewGuid(),
                ProjectUsers = new List<IProjectUserPoco>(),
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };
            return project;
        }
        
        /// <summary>
        /// Gets a list of all <see cref="IProjectPoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectPoco"/> models.</returns>
        public virtual IEnumerable<IProjectPoco> GetAll(ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = genericRepository.GetAll(null, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IProjectPoco>>(entities);
        }

        /// <summary>
        /// Gets a list of all <see cref="IProjectPoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectPoco"/> models asynchronously.</returns>
        public virtual async Task<IEnumerable<IProjectPoco>> GetAllAsync(ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = await genericRepository.GetAllAsync(null, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IProjectPoco>>(entities);
        }

        /// <summary>
        /// Gets a paged list of all <see cref="IProjectPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IProjectPoco"/> models.</returns>
        public virtual IPagedList<IProjectPoco> GetAllPaged(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            int count = genericRepository.GetCount();
            var entities = genericRepository.GetAll(pagingParameters, orderBy, includeProperties);

            return new StaticPagedList<IProjectPoco>(mapper.Map<IEnumerable<IProjectPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets a paged list of all <see cref="IProjectPoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IProjectPoco"/> models asynchronously.</returns>
        public virtual async Task<IPagedList<IProjectPoco>> GetAllPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            int count = await genericRepository.GetCountAsync();
            var entities = await genericRepository.GetAllAsync(pagingParameters, orderBy, includeProperties);

            return new StaticPagedList<IProjectPoco>(mapper.Map<IEnumerable<IProjectPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the one <see cref="IProjectPoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="IProjectPoco"/> asynchronously.</returns>
        public virtual async Task<IProjectPoco> GetOneAsync(Expression<Func<IProjectPoco, bool>> filter = null, params string[] includeProperties)
        {
            var entity = await genericRepository.GetOneAsync(filter, includeProperties);
            return mapper.Map<IProjectPoco>(entity);
        }

        /// <summary>
        /// Gets the one <see cref="IProjectPoco"/> model.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        public virtual IProjectPoco GetOne(Expression<Func<IProjectPoco, bool>> filter = null, params string[] includeProperties)
        {
            var entity = genericRepository.GetOne(filter, includeProperties);
            return mapper.Map<IProjectPoco>(entity);
        }
        
        /// <summary>
        /// Gets the list of <see cref="IProjectPoco"/> models.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectPoco"/> models.</returns>
        public virtual IEnumerable<IProjectPoco> Get(Expression<Func<IProjectPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = genericRepository.Get(null, filter, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IProjectPoco>>(entities);
        }

        /// <summary>
        /// Gets the list of <see cref="IProjectPoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectPoco"/> models asynchronous.</returns>
        public virtual async Task<IEnumerable<IProjectPoco>> GetAsync(Expression<Func<IProjectPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = await genericRepository.GetAsync(null, filter, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IProjectPoco>>(entities);
        }
        
        /// <summary>
        /// Gets the paged list of <see cref="IProjectPoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IProjectPoco"/> models.</returns>
        public virtual IPagedList<IProjectPoco> GetPaged(IPagingParameters pagingParameters, Expression<Func<IProjectPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var count = genericRepository.GetCount();
            var entities = genericRepository.Get(pagingParameters, filter, orderBy, includeProperties);

            return new StaticPagedList<IProjectPoco>(mapper.Map<IEnumerable<IProjectPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the paged list of <see cref="IProjectPoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IProjectPoco"/> models asynchronous.</returns>
        public virtual async Task<IPagedList<IProjectPoco>> GetPagedAsync(IPagingParameters pagingParameters, Expression<Func<IProjectPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var count = await genericRepository.GetCountAsync(filter);
            var entities = await genericRepository.GetAsync(pagingParameters, filter, orderBy, includeProperties);

            return new StaticPagedList<IProjectPoco>(mapper.Map<IEnumerable<IProjectPoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the <see cref="IProjectPoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IProjectPoco"/>.</returns>
        public virtual IProjectPoco GetById(Guid id)
        {
            var entity = genericRepository.GetById(id);
            return mapper.Map<IProjectPoco>(entity);
        }

        /// <summary>
        /// Gets the <see cref="IProjectPoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IProjectPoco"/>.</returns>
        public virtual async Task<IProjectPoco> GetByIdAsync(Guid id)
        {
            var entity = await genericRepository.GetByIdAsync(id);
            return mapper.Map<IProjectPoco>(entity);
        }

        /// <summary>
        /// Gets the <see cref="IProjectPoco"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IProjectPoco"/> count.</returns>
        public virtual int GetCount(Expression<Func<IProjectPoco, bool>> filter = null)
        {
            return genericRepository.GetCount(filter);
        }

        /// <summary>
        /// Gets the <see cref="IProjectPoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IProjectPoco"/> count asynchronous.</returns>
        public virtual Task<int> GetCountAsync(Expression<Func<IProjectPoco, bool>> filter = null)
        {
            return genericRepository.GetCountAsync(filter);
        }

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual bool GetIsExists(Expression<Func<IProjectPoco, bool>> filter = null)
        {
            return genericRepository.GetIsExists(filter);
        }

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual Task<bool> GetIsExistsAsync(Expression<Func<IProjectPoco, bool>> filter = null)
        {
            return genericRepository.GetIsExistsAsync(filter);
        }

        /// <summary>
        /// Inserts the specified <see cref="IProjectPoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Insert(IProjectPoco model)
        {
            genericRepository.Insert(mapper.Map<Project>(model));
            genericRepository.Save();
        }
        
        /// <summary>
        /// Inserts the list of <see cref="IProjectPoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual void Insert(IList<IProjectPoco> models)
        {
            var entities = mapper.Map<List<Project>>(models);
            entities.ForEach(p => genericRepository.Insert(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Inserts the specified <see cref="IProjectPoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task InsertAsync(IProjectPoco model)
        {
            genericRepository.Insert(mapper.Map<Project>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Inserts the list of <see cref="IProjectPoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual System.Threading.Tasks.Task InsertAsync(IList<IProjectPoco> models)
        {
            var entities = mapper.Map<List<Project>>(models);
            entities.ForEach(p => genericRepository.Insert(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Updates the specified <see cref="IProjectPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Update(IProjectPoco model)
        {
            genericRepository.Update(mapper.Map<Project>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Updates the list of <see cref="IProjectPoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        public virtual void Update(IList<IProjectPoco> models)
        {
            var entities = mapper.Map<List<Project>>(models);
            entities.ForEach(p => genericRepository.Update(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Updates the specified <see cref="IProjectPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task UpdateAsync(IProjectPoco model)
        {
            genericRepository.Update(mapper.Map<Project>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Updates the list of <see cref="IProjectPoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        public virtual System.Threading.Tasks.Task UpdateAsync(IList<IProjectPoco> models)
        {
            var entities = mapper.Map<List<Project>>(models);
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
        /// Deletes the specified <see cref="IProjectPoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Delete(IProjectPoco model)
        {
            genericRepository.Delete(mapper.Map<Project>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual void Delete(IList<IProjectPoco> models)
        {
            var entities = mapper.Map<List<Project>>(models);
            entities.ForEach(p => genericRepository.Delete(p));
            genericRepository.Save();
        }
        
        /// <summary>
        /// Deletes the specified <see cref="IProjectPoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(IProjectPoco model)
        {
            genericRepository.Delete(mapper.Map<Project>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(IList<IProjectPoco> models)
        {
            var entities = mapper.Map<List<Project>>(models);
            entities.ForEach(p => genericRepository.Delete(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Adds <see cref="IProjectPoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForInset(IProjectPoco model)
        {
            genericRepository.Insert(mapper.Map<Project>(model));
        }

        /// <summary>
        /// Adds <see cref="IProjectPoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForUpdate(IProjectPoco model)
        {
            genericRepository.Update(mapper.Map<Project>(model));
        }

        /// <summary>
        /// Adds <see cref="IProjectPoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForDelete(IProjectPoco model)
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
