using PM.DAL.Entities;
using PM.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.Repository.Common
{
    /// <summary>
    /// Role repository contract.
    /// </summary>
    /// <seealso cref="PM.Repository.Common.IRepository{PM.DAL.Entities.RoleEntity}" />
    public interface IRoleRepository : IRepository<RoleEntity>
    {
        /// <summary>
        /// Finds the by name asynchronous.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        Task<IRole> FindByNameAsync(string roleName);

        /// <summary>
        /// Finds the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<IRole> FindByIdAsync(Guid id);

        /// <summary>
        /// Adds the <see cref="IRole"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        Task AddAsync(IRole model);

        /// <summary>
        /// Asynchronously deletes <see cref="IUser"/> form the database.
        /// </summary>
        /// <param name="model">Model.</param>
        Task DeleteAsync(IRole model);

        /// <summary>
        /// Asynchronously updates entity in the database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        Task UpdateAsync(IRole model);

        /// <summary>
        /// Gets all records.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Enumerable list of records.</returns>
        IList<IRole> GetAll();
    }
}
