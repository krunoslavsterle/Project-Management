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
        /// <returns><see cref="IUser"/>.</returns>
        Task<IUser> FindByUserNameAsync(string username);

        /// <summary>
        /// Gets <see cref="IUser"/> the by user identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IUser"/>.</returns>
        Task<IUser> GetByUserIdAsync(Guid id);

        /// <summary>
        /// Adds the <see cref="IUser"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        Task AddAsync(IUser model);

        /// <summary>
        /// Asynchronously deletes <see cref="IUser"/> form the database.
        /// </summary>
        /// <param name="model">Model.</param>
        Task DeleteAsync(IUser model);

        /// <summary>
        /// Asynchronously updates entity in the database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        Task UpdateAsync(IUser model);

        /// <summary>
        /// Creates the claim asynchronous.
        /// </summary>
        /// <returns><see cref="IClaim"/>.</returns>
        Task<IClaim> CreateClaimAsync();


    }
}