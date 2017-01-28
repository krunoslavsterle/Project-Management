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
    }
}
