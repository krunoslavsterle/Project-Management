using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using PagedList;
using PM.Repository.Common;
using PM.DAL;
using PM.Common;
using PM.Model.Common;

namespace PM.Repository
{
    /// <summary>
    /// ProjectRole repository.
    /// </summary>
    public class ProjectRoleRepository : IProjectRoleRepository
    {
        #region Fields

        private readonly IGenericRepository<ProjectRole, IProjectRolePoco> genericRepository;
        private readonly IMapper mapper;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectRoleRepository"/> class.
        /// </summary>
        /// <param name="genericRepository">The generic repository.</param>
        /// <param name="mapper">The mapper.</param>
        public ProjectRoleRepository(IGenericRepository<ProjectRole, IProjectRolePoco> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets a list of all <see cref="IProjectRolePoco"/> models.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectRolePoco"/> models.</returns>
        public virtual IEnumerable<IProjectRolePoco> GetAll(ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = genericRepository.GetAll(null, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IProjectRolePoco>>(entities);
        }

        /// <summary>
        /// Gets a list of all <see cref="IProjectRolePoco"/> models asynchronously.
        /// </summary>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectRolePoco"/> models asynchronously.</returns>
        public virtual async Task<IEnumerable<IProjectRolePoco>> GetAllAsync(ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = await genericRepository.GetAllAsync(null, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IProjectRolePoco>>(entities);
        }

        /// <summary>
        /// Gets a paged list of all <see cref="IProjectRolePoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IProjectRolePoco"/> models.</returns>
        public virtual IPagedList<IProjectRolePoco> GetAllPaged(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            int count = genericRepository.GetCount();
            var entities = genericRepository.GetAll(pagingParameters, orderBy, includeProperties);

            return new StaticPagedList<IProjectRolePoco>(mapper.Map<IEnumerable<IProjectRolePoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets a paged list of all <see cref="IProjectRolePoco"/> models asynchronously.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of all <see cref="IProjectRolePoco"/> models asynchronously.</returns>
        public virtual async Task<IPagedList<IProjectRolePoco>> GetAllPagedAsync(IPagingParameters pagingParameters, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            int count = await genericRepository.GetCountAsync();
            var entities = await genericRepository.GetAllAsync(pagingParameters, orderBy, includeProperties);

            return new StaticPagedList<IProjectRolePoco>(mapper.Map<IEnumerable<IProjectRolePoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the one <see cref="IProjectRolePoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="IProjectRolePoco"/> asynchronously.</returns>
        public virtual async Task<IProjectRolePoco> GetOneAsync(Expression<Func<IProjectRolePoco, bool>> filter = null, params string[] includeProperties)
        {
            var entity = await genericRepository.GetOneAsync(filter, includeProperties);
            return mapper.Map<IProjectRolePoco>(entity);
        }

        /// <summary>
        /// Gets the one <see cref="IProjectRolePoco"/> model.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        public virtual IProjectRolePoco GetOne(Expression<Func<IProjectRolePoco, bool>> filter = null, params string[] includeProperties)
        {
            var entity = genericRepository.GetOne(filter, includeProperties);
            return mapper.Map<IProjectRolePoco>(entity);
        }

        /// <summary>
        /// Gets the list of <see cref="IProjectRolePoco"/> models.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectRolePoco"/> models.</returns>
        public virtual IEnumerable<IProjectRolePoco> Get(Expression<Func<IProjectRolePoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = genericRepository.Get(null, filter, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IProjectRolePoco>>(entities);
        }

        /// <summary>
        /// Gets the list of <see cref="IProjectRolePoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectRolePoco"/> models asynchronous.</returns>
        public virtual async Task<IEnumerable<IProjectRolePoco>> GetAsync(Expression<Func<IProjectRolePoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var entities = await genericRepository.GetAsync(null, filter, orderBy, includeProperties);
            return mapper.Map<IEnumerable<IProjectRolePoco>>(entities);
        }

        /// <summary>
        /// Gets the paged list of <see cref="IProjectRolePoco"/> models.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IProjectRolePoco"/> models.</returns>
        public virtual IPagedList<IProjectRolePoco> GetPaged(IPagingParameters pagingParameters, Expression<Func<IProjectRolePoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var count = genericRepository.GetCount();
            var entities = genericRepository.Get(pagingParameters, filter, orderBy, includeProperties);

            return new StaticPagedList<IProjectRolePoco>(mapper.Map<IEnumerable<IProjectRolePoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the paged list of <see cref="IProjectRolePoco"/> models asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Paged list of <see cref="IProjectRolePoco"/> models asynchronous.</returns>
        public virtual async Task<IPagedList<IProjectRolePoco>> GetPagedAsync(IPagingParameters pagingParameters, Expression<Func<IProjectRolePoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            var count = await genericRepository.GetCountAsync(filter);
            var entities = await genericRepository.GetAsync(pagingParameters, filter, orderBy, includeProperties);

            return new StaticPagedList<IProjectRolePoco>(mapper.Map<IEnumerable<IProjectRolePoco>>(entities), pagingParameters.PageNumber, pagingParameters.PageSize, count);
        }

        /// <summary>
        /// Gets the <see cref="IProjectRolePoco"/> model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IProjectRolePoco"/>.</returns>
        public virtual IProjectRolePoco GetById(Guid id)
        {
            var entity = genericRepository.GetById(id);
            return mapper.Map<IProjectRolePoco>(entity);
        }

        /// <summary>
        /// Gets the <see cref="IProjectRolePoco"/> model by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IProjectRolePoco"/>.</returns>
        public virtual async Task<IProjectRolePoco> GetByIdAsync(Guid id)
        {
            var entity = await genericRepository.GetByIdAsync(id);
            return mapper.Map<IProjectRolePoco>(entity);
        }

        /// <summary>
        /// Gets the <see cref="IProjectRolePoco"/> count.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IProjectRolePoco"/> count.</returns>
        public virtual int GetCount(Expression<Func<IProjectRolePoco, bool>> filter = null)
        {
            return genericRepository.GetCount(filter);
        }

        /// <summary>
        /// Gets the <see cref="IProjectRolePoco"/> count asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns><see cref="IProjectRolePoco"/> count asynchronous.</returns>
        public virtual Task<int> GetCountAsync(Expression<Func<IProjectRolePoco, bool>> filter = null)
        {
            return genericRepository.GetCountAsync(filter);
        }

        /// <summary>
        /// Checks if sequence in filter contains entities.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual bool GetIsExists(Expression<Func<IProjectRolePoco, bool>> filter = null)
        {
            return genericRepository.GetIsExists(filter);
        }

        /// <summary>
        /// Checks if sequence in filter contains entities asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <returns>True if sequence contains at least one entity.</returns>
        public virtual Task<bool> GetIsExistsAsync(Expression<Func<IProjectRolePoco, bool>> filter = null)
        {
            return genericRepository.GetIsExistsAsync(filter);
        }

        /// <summary>
        /// Inserts the specified <see cref="IProjectRolePoco"/> model into the database.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Insert(IProjectRolePoco model)
        {
            genericRepository.Insert(mapper.Map<ProjectRole>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Inserts the list of <see cref="IProjectRolePoco"/> models into the database.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual void Insert(IList<IProjectRolePoco> models)
        {
            var entities = mapper.Map<List<ProjectRole>>(models);
            entities.ForEach(p => genericRepository.Insert(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Inserts the specified <see cref="IProjectRolePoco"/> model into the database asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task InsertAsync(IProjectRolePoco model)
        {
            genericRepository.Insert(mapper.Map<ProjectRole>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Inserts the list of <see cref="IProjectRolePoco"/> models into the database asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual System.Threading.Tasks.Task InsertAsync(IList<IProjectRolePoco> models)
        {
            var entities = mapper.Map<List<ProjectRole>>(models);
            entities.ForEach(p => genericRepository.Insert(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Updates the specified <see cref="IProjectRolePoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Update(IProjectRolePoco model)
        {
            genericRepository.Update(mapper.Map<ProjectRole>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Updates the list of <see cref="IProjectRolePoco"/> models.
        /// </summary>
        /// <param name="model">The list of models.</param>
        public virtual void Update(IList<IProjectRolePoco> models)
        {
            var entities = mapper.Map<List<ProjectRole>>(models);
            entities.ForEach(p => genericRepository.Update(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Updates the specified <see cref="IProjectRolePoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task UpdateAsync(IProjectRolePoco model)
        {
            genericRepository.Update(mapper.Map<ProjectRole>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Updates the list of <see cref="IProjectRolePoco"/> models asynchronous.
        /// </summary>
        /// <param name="model">The list of models.</param>
        public virtual System.Threading.Tasks.Task UpdateAsync(IList<IProjectRolePoco> models)
        {
            var entities = mapper.Map<List<ProjectRole>>(models);
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
        /// Deletes the specified <see cref="IProjectRolePoco"/> model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Delete(IProjectRolePoco model)
        {
            genericRepository.Delete(mapper.Map<ProjectRole>(model));
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual void Delete(IList<IProjectRolePoco> models)
        {
            var entities = mapper.Map<List<ProjectRole>>(models);
            entities.ForEach(p => genericRepository.Delete(p));
            genericRepository.Save();
        }

        /// <summary>
        /// Deletes the specified <see cref="IProjectRolePoco"/> model asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(IProjectRolePoco model)
        {
            genericRepository.Delete(mapper.Map<ProjectRole>(model));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Deletes the list of models.
        /// </summary>
        /// <param name="models">The list of models.</param>
        public virtual System.Threading.Tasks.Task DeleteAsync(IList<IProjectRolePoco> models)
        {
            var entities = mapper.Map<List<ProjectRole>>(models);
            entities.ForEach(p => genericRepository.Delete(p));
            return genericRepository.SaveAsync();
        }

        /// <summary>
        /// Adds <see cref="IProjectRolePoco"/> model for insert. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForInset(IProjectRolePoco model)
        {
            genericRepository.Insert(mapper.Map<ProjectRole>(model));
        }

        /// <summary>
        /// Adds <see cref="IProjectRolePoco"/> model for update. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForUpdate(IProjectRolePoco model)
        {
            genericRepository.Update(mapper.Map<ProjectRole>(model));
        }

        /// <summary>
        /// Adds <see cref="IProjectRolePoco"/> model for delete. This will not call Save() method.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void AddForDelete(IProjectRolePoco model)
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
