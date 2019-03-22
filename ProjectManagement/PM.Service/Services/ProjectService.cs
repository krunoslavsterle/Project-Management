using PagedList;
using PM.Common;
using PM.Model.Common;
using PM.Repository.Common;
using PM.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PM.Service
{
    /// <summary>
    /// Project service.
    /// </summary>
    public class ProjectService : IProjectService
    {
        #region Fields

        private readonly IProjectRepository projectRepository;
        private readonly IProjectUserRepository projectUserRepository;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectService"/> class.
        /// </summary>
        /// <param name="projectRepository">The project repository.</param>
        /// <param name="projectUserRepository">The project user repository.</param>
        public ProjectService(IProjectRepository projectRepository, IProjectUserRepository projectUserRepository)
        {
            this.projectRepository = projectRepository;
            this.projectUserRepository = projectUserRepository;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Creates the project.
        /// </summary>
        /// <returns></returns>
        public virtual IProjectPoco CreateProject()
        {
            return projectRepository.CreateProject();
        }

        /// <summary>
        /// Creates the project user in memory.
        /// </summary>
        /// <returns><see cref="IProjectUserPoco"/> model.</returns>
        public virtual IProjectUserPoco CreateProjectUser()
        {
            return projectUserRepository.Create();
        }

        /// <summary>
        /// Gets the <see cref="IProject"/> asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns><see cref="IProjectPoco"/> model.</returns>
        public Task<IProjectPoco> GetProjectAsync(Guid id, params string[] includeProperties)
        {
            return projectRepository.GetOneAsync(p => p.Id == id, includeProperties);
        }

        /// <summary>
        /// Gets the list of projects asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectPoco"/>.</returns>
        public Task<IEnumerable<IProjectPoco>> GetProjectsAsync(Expression<Func<IProjectPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            return projectRepository.GetAsync(filter, orderBy, includeProperties);
        }

        /// <summary>
        /// Gets the list of <see cref="IProjectPoco"/> paged asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectPoco"/> paged.</returns>
        public Task<IPagedList<IProjectPoco>> GetProjectsPagedAsync(IPagingParameters pagingParameters, Expression<Func<IProjectPoco, bool>> filter, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            return projectRepository.GetPagedAsync(pagingParameters, filter, orderBy, includeProperties);
        }

        /// <summary>
        /// Inserts the <see cref="IProjectPoco"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        public Task InsertProjectAsync(IProjectPoco model)
        {
            return projectRepository.InsertAsync(model);
        }

        /// <summary>
        /// Inserts the list of <see cref="IProjectPoco"/> asynchronous.
        /// </summary>
        /// <param name="models">The list of projects.</param>
        /// <returns>Task.</returns>
        public Task InsertProjectsAsync(IEnumerable<IProjectPoco> models)
        {
            foreach (var item in models)
                projectRepository.AddForInset(item);

            return projectRepository.SaveAsync();
        }

        /// <summary>
        /// Deletes the <see cref="IProjectPoco"/> asynchronous.
        /// </summary>
        /// <param name="id">The project identifier.</param>
        /// <returns>Task.</returns>
        public Task DeleteProjectAsync(Guid id)
        {
            return projectRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Updates the <see cref="IProjectPoco"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        public Task UpdateProjectAsync(IProjectPoco model)
        {
            return projectRepository.UpdateAsync(model);
        }

        /// <summary>
        /// Updates the list of <see cref="IProjectPoco"/> asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        /// <returns>Task.</returns>
        public Task UpdateProjectsAsync(IEnumerable<IProjectPoco> models)
        {
            foreach (var item in models)
                projectRepository.AddForUpdate(item);

            return projectRepository.SaveAsync();
        }

        /// <summary>
        /// Gets the one <see cref="IProjectUserPoco"/> model asynchronously.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>One <see cref="IProjectUserPoco"/> asynchronously.</returns>
        public Task<IProjectUserPoco> GetProjectUserAsync(Expression<Func<IProjectUserPoco, bool>> filter = null, params string[] includeProperties)
        {
            return projectUserRepository.GetOneAsync(filter, includeProperties);
        }

        /// <summary>
        /// Gets the list of <see cref="IProjectUserPoco"/> models asynchronous.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="IProjectUserPoco"/> models asynchronous.</returns>
        public Task<IEnumerable<IProjectUserPoco>> GetProjectUsersAsync(Expression<Func<IProjectUserPoco, bool>> filter = null, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            return projectUserRepository.GetAsync(filter, orderBy, includeProperties);
        }

        /// <summary>
        /// Gets the paged list of <see cref="IProjectUserPoco"/> asynchrously. 
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The sorting parameters.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>The paged list of <see cref="IProjectUserPoco"/> asynchrously. </returns>
        public Task<IPagedList<IProjectUserPoco>> GetProjectUsersPagedAsync(IPagingParameters pagingParameters, Expression<Func<IProjectUserPoco, bool>> filter, ISortingParameters orderBy = null, params string[] includeProperties)
        {
            return projectUserRepository.GetPagedAsync(pagingParameters, filter, orderBy, includeProperties);
        }

        /// <summary>
        /// Inserts the project user asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        public async Task InsertProjectUserAsync(IProjectUserPoco model)
        {
            var exists = await projectUserRepository.GetCountAsync(p => p.ProjectId == model.ProjectId && p.UserId == model.UserId) > 0;
            if (exists)
                throw new Exception("Selected user is allredy added to this project");

            await projectUserRepository.InsertAsync(model);
        }

        #endregion Methods
    }
}
