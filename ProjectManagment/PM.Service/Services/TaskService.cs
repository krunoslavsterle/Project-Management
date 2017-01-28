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
    /// Task service class.
    /// </summary>
    public class TaskService : ITaskService
    {
        #region Fields

        private readonly ITaskRepository taskRepository;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskService"/> class.
        /// </summary>
        /// <param name="taskRepository">The task repository.</param>
        public TaskService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the <see cref="ITaskPoco"/> asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="ITaskPoco"/> model.</returns>
        public Task<ITaskPoco> GetTaskAsync(Guid id)
        {
            return taskRepository.GetOneAsync(p => p.Id == id);
        }

        /// <summary>
        /// Gets the list of Tasks asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskPoco"/>.</returns>
        public Task<IEnumerable<ITaskPoco>> GetTasksAsync(Expression<Func<ITaskPoco, bool>> filter = null, ISortingParameters orderBy = null, 
            params string[] includeProperties)
        {
            return taskRepository.GetAsync(filter, orderBy, includeProperties);
        }

        /// <summary>
        /// Gets the list of <see cref="ITaskPoco"/> paged asynchronous.
        /// </summary>
        /// <param name="pagingParameters">The paging parameters.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>List of <see cref="ITaskPoco"/> paged.</returns>
        public Task<IPagedList<ITaskPoco>> GetTasksPagedAsync(IPagingParameters pagingParameters, Expression<Func<ITaskPoco, bool>> filter, 
            ISortingParameters orderBy = null, params string[] includeProperties)
        {
            return taskRepository.GetPagedAsync(pagingParameters, filter, orderBy, includeProperties);
        }

        /// <summary>
        /// Inserts the <see cref="ITaskPoco"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        public Task InsertTaskAsync(ITaskPoco model)
        {
            if (model.Id == Guid.Empty)
                model.Id = Guid.NewGuid();

            model.DateUpdated = DateTime.UtcNow;
            model.DateCreated = DateTime.UtcNow;

            return taskRepository.InsertAsync(model);
        }

        /// <summary>
        /// Inserts the list of <see cref="ITaskPoco"/> asynchronous.
        /// </summary>
        /// <param name="models">The list of Tasks.</param>
        /// <returns>Task.</returns>
        public Task InsertTasksAsync(IEnumerable<ITaskPoco> models)
        {
            foreach (var item in models)
                taskRepository.AddForInset(item);

            return taskRepository.SaveAsync();
        }

        /// <summary>
        /// Deletes the <see cref="ITaskPoco"/> asynchronous.
        /// </summary>
        /// <param name="id">The Task identifier.</param>
        /// <returns>Task.</returns>
        public Task DeleteTaskAsync(Guid id)
        {
            return taskRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Updates the <see cref="ITaskPoco"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        public Task UpdateTaskAsync(ITaskPoco model)
        {
            return taskRepository.UpdateAsync(model);
        }

        /// <summary>
        /// Updates the list of <see cref="ITaskPoco"/> asynchronous.
        /// </summary>
        /// <param name="models">The list of models.</param>
        /// <returns>Task.</returns>
        public Task UpdateTasksAsync(IEnumerable<ITaskPoco> models)
        {
            foreach (var item in models)
                taskRepository.AddForUpdate(item);

            return taskRepository.SaveAsync();
        }

        #endregion Methods
    }
}
