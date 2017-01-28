using System.Collections.Generic;
using PM.Repository.Common;
using PM.Model.Common;
using PM.Service.Common;
using PM.Common.Cache;
using System;

namespace PM.Service
{
    /// <summary>
    /// Lookup service.
    /// </summary>
    public class LookupService : ILookupService
    {
        #region Fields

        private const string TASK_PRIORITY_CACHE_KEY = "TASK_PRIORITY";

        private readonly ICacheProvider cacheProvider;
        private readonly ITaskPriorityRepository taskPriorityRepository;

        #endregion Fields

        #region Constructors

        public LookupService(ICacheProvider cacheProvider, ITaskPriorityRepository taskPriorityRepository)
        {
            this.cacheProvider = cacheProvider;
            this.taskPriorityRepository = taskPriorityRepository;
        }

        #endregion Constructors
        
        #region Methods

        /// <summary>
        /// Gets list of all <see cref="ITaskPriorityPoco"/> models.
        /// </summary>
        /// <returns>List of all <see cref="ITaskPriorityPoco"/> models.</returns>
        public IEnumerable<ITaskPriorityPoco> GetAllTaskPriority()
        {
            return this.cacheProvider.GetOrAdd<IEnumerable<ITaskPriorityPoco>>(TASK_PRIORITY_CACHE_KEY, (string key) =>
            {
                return taskPriorityRepository.GetAll();
            }, 
            DateTimeOffset.MaxValue);
            
        }
        
        #endregion Methods
    }
}
