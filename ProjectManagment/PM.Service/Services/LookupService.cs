using System.Collections.Generic;
using PM.Repository.Common;
using PM.Model.Common;
using PM.Service.Common;
using PM.Common.Cache;
using System;
using PM.Repository;

namespace PM.Service
{
    /// <summary>
    /// Lookup service.
    /// </summary>
    public class LookupService : ILookupService
    {
        #region Fields

        private const string TASK_PRIORITY_CACHE_KEY = "TASK_PRIORITY";
        private const string TASK_STATUS_CACHE_KEY = "TASK_STATUS";
        private const string PROJECT_ROLE_CACHE_KEY = "PROJECT_ROLE";
        private const string ROLE_CACHE_KEY = "ROLES";

        private readonly ICacheProvider cacheProvider;
        private readonly ITaskPriorityRepository taskPriorityRepository;
        private readonly ITaskStatusRepository taskStatusRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IProjectRoleRepository projectRoleRepository;


        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupService"/> class.
        /// </summary>
        /// <param name="cacheProvider">The cache provider.</param>
        /// <param name="taskPriorityRepository">The task priority repository.</param>
        /// <param name="taskStatusRepository">The task status repository.</param>
        /// <param name="roleRepository">The role repository.</param>
        /// <param name="projectRoleRepository">The project role repository.</param>
        public LookupService(
            ICacheProvider cacheProvider, 
            ITaskPriorityRepository taskPriorityRepository, 
            ITaskStatusRepository taskStatusRepository,
            IRoleRepository roleRepository,
            IProjectRoleRepository projectRoleRepository)
        {
            this.cacheProvider = cacheProvider;
            this.taskPriorityRepository = taskPriorityRepository;
            this.taskStatusRepository = taskStatusRepository;
            this.roleRepository = roleRepository;
            this.projectRoleRepository = projectRoleRepository;
        }

        #endregion Constructors
        
        #region Methods

        /// <summary>
        /// Gets a list of all <see cref="ITaskPriorityPoco"/> models.
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

        /// <summary>
        /// Gets a list of all <see cref="ITaskStatusPoco"/> models.
        /// </summary>
        /// <returns>List of all <see cref="ITaskStatusPoco"/> models.</returns>
        public IEnumerable<ITaskStatusPoco> GetAllTaskStatus()
        {
            return this.cacheProvider.GetOrAdd<IEnumerable<ITaskStatusPoco>>(TASK_STATUS_CACHE_KEY, (string key) =>
            {
                return taskStatusRepository.GetAll();
            },
            DateTimeOffset.MaxValue);
        }

        /// <summary>
        /// Gets a list of all <see cref="IRolePoco"/> models.
        /// </summary>
        /// <returns>List of all <see cref="IRolePoco"/> models.</returns>
        public virtual IEnumerable<IRolePoco> GetAllRoles()
        {
            return this.cacheProvider.GetOrAdd<IEnumerable<IRolePoco>>(ROLE_CACHE_KEY, (string key) =>
            {
                return roleRepository.GetAll();
            }, 
            DateTimeOffset.MaxValue);
        }

        /// <summary>
        /// Gets a list of all <see cref="IProjectRolePoco"/> models.
        /// </summary>
        /// <returns>List of all <see cref="IProjectRolePoco"/> models.</returns>
        public virtual IEnumerable<IProjectRolePoco> GetAllProjectRoles()
        {
            return this.cacheProvider.GetOrAdd<IEnumerable<IProjectRolePoco>>(PROJECT_ROLE_CACHE_KEY, (string key) =>
            {
                return projectRoleRepository.GetAll();
            },
            DateTimeOffset.MaxValue);
        }
        
        #endregion Methods
    }
}
