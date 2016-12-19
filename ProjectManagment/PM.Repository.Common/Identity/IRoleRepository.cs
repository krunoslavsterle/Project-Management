using PM.DAL;
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
    public interface IRoleRepository : IRepository<Role>
    {
        /// <summary>
        /// Finds the by name asynchronous.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        System.Threading.Tasks.Task<IRolePoco> FindByNameAsync(string roleName);

        /// <summary>
        /// Finds the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        System.Threading.Tasks.Task<IRolePoco> FindByIdAsync(Guid id);

        /// <summary>
        /// Adds the <see cref="IRolePoco"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        System.Threading.Tasks.Task AddAsync(IRolePoco model);

        /// <summary>
        /// Asynchronously deletes <see cref="IUser"/> form the database.
        /// </summary>
        /// <param name="model">Model.</param>
        System.Threading.Tasks.Task DeleteAsync(IRolePoco model);

        /// <summary>
        /// Asynchronously updates entity in the database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        System.Threading.Tasks.Task UpdateAsync(IRolePoco model);

        /// <summary>
        /// Gets all records.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Enumerable list of records.</returns>
        IList<IRolePoco> GetAll();
    }
}
