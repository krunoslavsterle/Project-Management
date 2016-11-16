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
        Task<IExternalLogin> GetByProviderAndKeyAsync(string loginProvider, string providerKey);

        /// <summary>
        /// Adds the <see cref="IExternalLogin"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        Task AddAsync(IExternalLogin model);

        /// <summary>
        /// Asynchronously deletes <see cref="IExternalLogin"/> form the database.
        /// </summary>
        /// <param name="model">Model.</param>
        Task DeleteAsync(IExternalLogin model);

        /// <summary>
        /// Asynchronously updates entity in the database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        Task UpdateAsync(IExternalLogin model);

        /// <summary>
        /// Creates <see cref="IExternalLogin"/> the asynchronous.
        /// </summary>
        /// <returns><see cref="IExternalLogin"/>.</returns>
        Task<IExternalLogin> CreateAsync();
    }            
}
