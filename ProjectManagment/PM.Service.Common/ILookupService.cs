using PM.Model.Common;
using System.Collections.Generic;

namespace PM.Service.Common
{
    /// <summary>
    /// Lookup service contract.
    /// </summary>
    public interface ILookupService
    {
        /// <summary>
        /// Gets list of all <see cref="ITaskPriorityPoco"/> models.
        /// </summary>
        /// <returns>List of all <see cref="ITaskPriorityPoco"/> models.</returns>
        IEnumerable<ITaskPriorityPoco> GetAllTaskPriority();

        /// <summary>
        /// Gets a list of all <see cref="ITaskStatusPoco"/> models.
        /// </summary>
        /// <returns>List of all <see cref="ITaskStatusPoco"/> models.</returns>
        IEnumerable<ITaskStatusPoco> GetAllTaskStatus();

        /// <summary>
        /// Gets a list of all <see cref="IRolePoco"/> models.
        /// </summary>
        /// <returns>List of all <see cref="IRolePoco"/> models.</returns>
        IEnumerable<IRolePoco> GetAllRoles();

        /// <summary>
        /// Gets a list of all <see cref="IProjectRolePoco"/> models.
        /// </summary>
        /// <returns>List of all <see cref="IProjectRolePoco"/> models.</returns>
        IEnumerable<IProjectRolePoco> GetAllProjectRoles();
    }
}
