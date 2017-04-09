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

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectService"/> class.
        /// </summary>
        /// <param name="projectRepository">The project repository.</param>
        public ProjectService(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
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
        /// Gets the <see cref="IProject"/> asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IProjectPoco"/> model.</returns>
        public Task<IProjectPoco> GetProjectAsync(Guid id)
        {
            return projectRepository.GetOneAsync(p => p.Id == id);
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

        #endregion Methods
    }
}
