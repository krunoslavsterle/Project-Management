using PM.Model.Common;
using System.Threading.Tasks;

namespace PM.Service.Common
{
    /// <summary>
    /// Project service contract.
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// Adds the project asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns><see cref="IProject"/>. </returns>
        Task<bool> AddAsync(IProject model);
    }
}
