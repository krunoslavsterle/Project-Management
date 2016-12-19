using PM.Common.Filters;
using PM.DAL;
using PM.Model.Common;
using System;
using System.Collections.Generic;

namespace PM.Repository.Common
{
    /// <summary>
    /// Project repository contract.
    /// </summary>
    /// <seealso cref="PM.Repository.Common.IRepository{PM.DAL.Entities.ProjectEntity}" />
    public interface IProjectRepository : IRepository<Project>
    {
        /// <summary>
        /// Gets the <see cref="IProjectPoco"/> asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        System.Threading.Tasks.Task<IProjectPoco> GetProjectAsync(Guid id);

        /// <summary>
        /// Adds the project asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        System.Threading.Tasks.Task AddAsync(IProjectPoco model);

        /// <summary>
        /// Finds the list of <see cref="IProjectPoco"/>'s asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        System.Threading.Tasks.Task<IList<IProjectPoco>> FindAsync(ProjectFilter filter);
    }
}
