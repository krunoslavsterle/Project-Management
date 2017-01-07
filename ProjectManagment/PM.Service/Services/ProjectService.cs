using PM.Common.Filters;
using PM.Model.Common;
using PM.Repository.Common;
using PM.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.Service
{
    /// <summary>
    /// Project service.
    /// </summary>
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository;

        #region Constructors

        public ProjectService(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the <see cref="IProject"/> asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<IProjectPoco> GetProjectAsync(Guid id)
        {
            //return UnitOfWork.ProjectRepository.GetProjectAsync(id);
            return null;
        }

        /// <summary>
        /// Adds the project asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns><see cref="IProject"/>. </returns>
        public async Task<bool> AddAsync(IProjectPoco model)
        {
            model.Id = Guid.NewGuid();
            model.DateCreated = DateTime.UtcNow;
            model.DateUpdated = DateTime.UtcNow;

            //await UnitOfWork.ProjectRepository.AddAsync(model);
            try
            {

                //var save = await UnitOfWork.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return false;
        }

        /// <summary>
        /// Finds the list of <see cref="IProject"/>'s asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public Task<IList<IProjectPoco>> FindAsync(ProjectFilter filter)
        {
            //return UnitOfWork.ProjectRepository.FindAsync(filter);
            // return projectRepository.GetAllAsync();
            return null;
        }

        #endregion Methods
    }
}
