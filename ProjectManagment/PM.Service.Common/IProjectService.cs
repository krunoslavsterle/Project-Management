using PM.Common.Filters;
using PM.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.Service.Common
{
    /// <summary>
    /// Project service contract.
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// Gets the <see cref="IProject"/> asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<IProjectPoco> GetProjectAsync(Guid id);

        /// <summary>
        /// Adds the project asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns><see cref="IProject"/>. </returns>
        Task<bool> AddAsync(IProjectPoco model);

        /// <summary>
        /// Finds the list of <see cref="IProject"/>'s asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        Task<IList<IProjectPoco>> FindAsync(ProjectFilter filter);
    }
}
