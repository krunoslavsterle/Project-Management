using PM.DAL;
using PM.Model.Common;
using System.Threading.Tasks;

namespace PM.Repository.Common
{
    /// <summary>
    /// External login repository contract.
    /// </summary>
    /// <seealso cref="PM.Repository.Common.IRepository{PM.DAL.Entities.ExternalLoginEntity}" />
    public interface IExternalLoginRepository : IRepository<ExternalLogin>
    {
        /// <summary>
        /// Gets the by provider and key asynchronous.
        /// </summary>
        /// <param name="loginProvider">The login provider.</param>
        /// <param name="providerKey">The provider key.</param>
        /// <returns></returns>
        System.Threading.Tasks.Task<IExternalLoginPoco> GetByProviderAndKeyAsync(string loginProvider, string providerKey);

        /// <summary>
        /// Adds the <see cref="IExternalLoginPoco"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        System.Threading.Tasks.Task AddAsync(IExternalLoginPoco model);

        /// <summary>
        /// Asynchronously deletes <see cref="IExternalLoginPoco"/> form the database.
        /// </summary>
        /// <param name="model">Model.</param>
        System.Threading.Tasks.Task DeleteAsync(IExternalLoginPoco model);

        /// <summary>
        /// Asynchronously updates entity in the database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        System.Threading.Tasks.Task UpdateAsync(IExternalLoginPoco model);

        /// <summary>
        /// Creates <see cref="IExternalLoginPoco"/> the asynchronous.
        /// </summary>
        /// <returns><see cref="IExternalLoginPoco"/>.</returns>
        System.Threading.Tasks.Task<IExternalLoginPoco> CreateAsync();
    }            
}
