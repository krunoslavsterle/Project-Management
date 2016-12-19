using PM.DAL;
using PM.Model.Common;
using PM.Repository.Common;
using System;
using System.Threading.Tasks;

namespace PM.Repository
{
    /// <summary>
    /// User repository contract.
    /// </summary>
    /// <seealso cref="PM.Repository.Common.IRepository{PM.DAL.Entities.User}" />
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Finds <see cref="IUser"/> the by user name asynchronous.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns><see cref="IUserPoco"/>.</returns>
        System.Threading.Tasks.Task<IUserPoco> FindByUserNameAsync(string username);

        /// <summary>
        /// Gets <see cref="IUser"/> the by user identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IUserPoco"/>.</returns>
        System.Threading.Tasks.Task<IUserPoco> GetByUserIdAsync(Guid id);

        /// <summary>
        /// Adds the <see cref="IUserPoco"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        System.Threading.Tasks.Task AddAsync(IUserPoco model);

        /// <summary>
        /// Asynchronously deletes <see cref="IUserPoco"/> form the database.
        /// </summary>
        /// <param name="model">Model.</param>
        System.Threading.Tasks.Task DeleteAsync(IUserPoco model);

        /// <summary>
        /// Asynchronously updates entity in the database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        System.Threading.Tasks.Task UpdateAsync(IUserPoco model);

        /// <summary>
        /// Creates the claim asynchronous.
        /// </summary>
        /// <returns><see cref="IClaimPoco"/>.</returns>
        System.Threading.Tasks.Task<IClaimPoco> CreateClaimAsync();


    }
}