using PM.DAL.Entities;
using PM.Model.Common;
using System.Threading.Tasks;

namespace PM.Repository.Common
{
    public interface IProjectRepository : IRepository<ProjectEntity>
    {
        /// <summary>
        /// Adds the project asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task AddAsync(IProject model);
    }
}
