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
    /// Task service class.
    /// </summary>
    public class TaskService : BaseService, ITaskService
    {
        #region Constructors

        public TaskService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the task asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<ITaskPoco> GetTaskAsync(Guid id)
        {
            return UnitOfWork.TaskRepository.GetTaskAsync(id);
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        public System.Threading.Tasks.Task AddAsync(ITaskPoco model)
        {
            return UnitOfWork.TaskRepository.AddAsync(model);
        }
        
        /// <summary>
        /// Finds the list of tasks asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>List of <see cref="ITaskPoco"/>.</returns>
        public Task<IList<ITaskPoco>> FindAsync(TaskFilter filter)
        {
            return UnitOfWork.TaskRepository.FindAsync(filter);
        }

        #endregion Methods
    }
}
